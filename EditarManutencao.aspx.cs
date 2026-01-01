using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarManutencao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("DashboardManutencoes.aspx");
                return;
            }

            CarregarVeiculos();

            int id = int.Parse(Request.QueryString["id"]);
            CarregarManutencao(id);
        }
    }

    private void CarregarVeiculos()
    {
        string cs = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = "SELECT veiculo_id, matricula FROM veiculos";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            ddlVeiculo.DataSource = dr;
            ddlVeiculo.DataTextField = "matricula";
            ddlVeiculo.DataValueField = "veiculo_id";
            ddlVeiculo.DataBind();
        }
    }

    private void CarregarManutencao(int id)
    {
        string cs = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"
            SELECT veiculo_id, tipo, custo, data, descricao
            FROM manutencoes
            WHERE manutencao_id = @id";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ddlVeiculo.SelectedValue = dr["veiculo_id"].ToString();
                txtTipo.Text = dr["tipo"].ToString();
                txtCusto.Text = dr["custo"].ToString();

                DateTime dt = Convert.ToDateTime(dr["data"]);
                txtData.Text = dt.ToString("yyyy-MM-ddTHH:mm");

                txtDescricao.Text = dr["descricao"].ToString();
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
            UPDATE manutencoes
            SET veiculo_id = @veiculo,
                tipo = @tipo,
                custo = @custo,
                data = @data,
                descricao = @descricao
            WHERE manutencao_id = @id";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@veiculo", ddlVeiculo.SelectedValue);
            cmd.Parameters.AddWithValue("@tipo", txtTipo.Text);
            cmd.Parameters.AddWithValue("@custo", decimal.Parse(txtCusto.Text));
            cmd.Parameters.AddWithValue("@data", DateTime.Parse(txtData.Text));
            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        Response.Redirect("DashboardManutencoes.aspx");
    }
}