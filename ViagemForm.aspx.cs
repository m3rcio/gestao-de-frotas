using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViagemForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Logado"] == null)
            Response.Redirect("Default.aspx");

        if (!IsPostBack)
        {
            CarregarVeiculos();
            CarregarMotoristas();
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


    void CarregarMotoristas()
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT motorista_id, nome FROM motoristas", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlMotorista.DataSource = dt;
            ddlMotorista.DataTextField = "nome";
            ddlMotorista.DataValueField = "motorista_id";
            ddlMotorista.DataBind();
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"INSERT INTO viagens
                           (veiculo_id, motorista_id, data_saida, km_saida)
                           VALUES (@veiculo, @motorista, @data_saida, @km_saida)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@veiculo", ddlVeiculo.SelectedValue);
            cmd.Parameters.AddWithValue("@motorista", ddlMotorista.SelectedValue);
            cmd.Parameters.AddWithValue("@data_saida", DateTime.Parse(txtDataSaida.Text));
            cmd.Parameters.AddWithValue("@km_saida", int.Parse(txtKmSaida.Text));

            con.Open();
            cmd.ExecuteNonQuery();
        }

        Response.Redirect("DashboardViagem.aspx");
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("DashboardViagem.aspx");
    }

}