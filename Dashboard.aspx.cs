using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Logado"] == null)
            Response.Redirect("Default.aspx");

        if (!IsPostBack)
            CarregarVeiculos();
    }

    protected void gvVeiculos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int veiculoId = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            Response.Redirect("VeiculoForm.aspx?id=" + veiculoId);
        }

        if (e.CommandName == "Apagar")
        {
            ApagarVeiculo(veiculoId);
            CarregarVeiculos(); 
        }
    }

    private void ApagarVeiculo(int id)
    {
        string cs = ConfigurationManager
                        .ConnectionStrings["DB"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = "DELETE FROM Veiculos WHERE veiculo_id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    protected void btnVeiculoForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("VeiculoForm.aspx");
    }

    protected void Editar_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("EditarVeiculo.aspx?id=" + e.CommandArgument);
    }

    private void CarregarVeiculos(int id)
    {
        string cs = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"SELECT matricula, marca, modelo, ano, quilometragem, estado
                       FROM Veiculos
                       WHERE veiculo_id = @id";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtMatricula.Text = dr["matricula"].ToString();
                txtMarca.Text = dr["marca"].ToString();
                txtModelo.Text = dr["modelo"].ToString();
                txtAno.Text = dr["ano"].ToString();
                txtKm.Text = dr["quilometragem"].ToString();
                ddlEstado.SelectedValue = dr["estado"].ToString();
            }
        }
    }
}