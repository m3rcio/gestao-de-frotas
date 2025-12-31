using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarViagem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CarregarVeiculos();
        CarregarMotoristas();

        if (!IsPostBack)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("DashboardViagens.aspx");
                return;
            }

            int id = int.Parse(Request.QueryString["id"]);
            CarregarViagem(id);
        }
    }

    private void CarregarVeiculos()
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT veiculo_id, matricula FROM veiculos WHERE estado = 'ativo'", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlVeiculo.DataSource = dt;
            ddlVeiculo.DataTextField = "matricula";
            ddlVeiculo.DataValueField = "veiculo_id";
            ddlVeiculo.DataBind();
        }
    }

    private void CarregarViagem(int id)
    {
        string cs = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"
            SELECT veiculo_id, motorista_id, data_saida, data_retorno,
                   km_saida, km_retorno
            FROM Viagens
            WHERE viagem_id = @id";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ddlVeiculo.SelectedValue = dr["veiculo_id"].ToString();
                ddlMotorista.SelectedValue = dr["motorista_id"].ToString();

                txtDataSaida.Text = Convert
                    .ToDateTime(dr["data_saida"])
                    .ToString("yyyy-MM-ddTHH:mm");

                if (dr["data_retorno"] != DBNull.Value)
                {
                    txtDataRetorno.Text = Convert
                        .ToDateTime(dr["data_retorno"])
                        .ToString("yyyy-MM-ddTHH:mm");
                }

                txtKmSaida.Text = dr["km_saida"].ToString();
                txtKmRetorno.Text = dr["km_retorno"].ToString();
            }
        }
    }

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        int id = int.Parse(Request.QueryString["id"]);

        string cs = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"
            UPDATE Viagens
            SET veiculo_id = @veiculo,
                motorista_id = @motorista,
                data_saida = @data_saida,
                data_retorno = @data_retorno,
                km_saida = @km_saida,
                km_retorno = @km_retorno
            WHERE viagem_id = @id";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@veiculo", ddlVeiculo.SelectedValue);
            cmd.Parameters.AddWithValue("@motorista", ddlMotorista.SelectedValue);
            cmd.Parameters.AddWithValue("@data_saida", DateTime.Parse(txtDataSaida.Text));
            cmd.Parameters.AddWithValue("@data_retorno",
                string.IsNullOrEmpty(txtDataRetorno.Text)
                    ? (object)DBNull.Value
                    : DateTime.Parse(txtDataRetorno.Text));
            cmd.Parameters.AddWithValue("@km_saida", int.Parse(txtKmSaida.Text));
            cmd.Parameters.AddWithValue("@km_retorno", int.Parse(txtKmRetorno.Text));
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        Response.Redirect("DashboardViagens.aspx");
    }

    protected void btnDashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("DashboardViagens.aspx");
    }

}