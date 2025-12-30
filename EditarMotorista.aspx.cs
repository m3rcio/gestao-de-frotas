using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarMotorista : System.Web.UI.Page
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
            CarregarMotorista(id);
        }
    }

    protected void btnDashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }

    private void CarregarMotorista(int id)
    {
        string cs = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"SELECT Nome, Contacto, Carta,Morada
                       FROM Motoristas
                       WHERE motorista_id = @id";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtNome.Text = dr["Nome"].ToString();
                txtContacto.Text = dr["Contacto"].ToString();
                txtCarta.Text = dr["Carta"].ToString();
                txtMorada.Text = dr["Morada"].ToString();
      
            }
        }
    }
}