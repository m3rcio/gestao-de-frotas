using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarVeiculo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario_id"] == null)
        {
            Response.Redirect("Default.aspx");
            return;
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Dashboard.aspx");
                return;
            }

            int id = int.Parse(Request.QueryString["id"]);
            CarregarVeiculo(id);
        }
    }

    protected void btnDashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }

    void CarregarVeiculo(int id)
    {
        string cs = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"SELECT Matricula, Marca, Modelo, Ano, Quilometragem, Estado
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

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        int id = int.Parse(Request.QueryString["id"]);

        string cs = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"UPDATE Veiculos
                       SET matricula = @matricula,
                           marca = @marca,
                           modelo = @modelo,
                           ano = @ano,
                           quilometragem = @km,
                           estado = @estado
                       WHERE veiculo_id = @id";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@matricula", txtMatricula.Text);
            cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
            cmd.Parameters.AddWithValue("@modelo", txtModelo.Text);
            cmd.Parameters.AddWithValue("@ano", int.Parse(txtAno.Text));
            cmd.Parameters.AddWithValue("@km", int.Parse(txtKm.Text));
            cmd.Parameters.AddWithValue("@estado", ddlEstado.SelectedValue);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        Response.Redirect("Dashboard.aspx");
    }
}