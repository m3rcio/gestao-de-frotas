using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarVeiculo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

    void CarregarVeiculo(int id)
    {
        string cs = @"SUA_CONNECTION_STRING";

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"SELECT matricula, marca, modelo, ano, quilometragem, estado
                           FROM Veiculos
                           WHERE id = @id";

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