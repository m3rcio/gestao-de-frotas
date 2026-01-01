using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManutencaoForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarVeiculos();
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

        ddlVeiculo.Items.Insert(0, new ListItem("-- selecione --", ""));
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"
            INSERT INTO manutencoes
            (veiculo_id, tipo, custo, data, descricao)
            VALUES
            (@veiculo, @tipo, @custo, @data, @descricao)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@veiculo", ddlVeiculo.SelectedValue);
            cmd.Parameters.AddWithValue("@tipo", txtTipo.Text);
            cmd.Parameters.AddWithValue("@custo", decimal.Parse(txtCusto.Text));
            cmd.Parameters.AddWithValue("@data", DateTime.Parse(txtData.Text));
            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        Response.Redirect("DashboardManutencoes.aspx");
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("DashboardManutencoes.aspx");
    }


}