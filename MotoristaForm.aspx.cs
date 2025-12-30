using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MotoristaForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logado"] == null)
            Response.Redirect("Default.aspx");
    }

    protected void btnDashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager
                        .ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"INSERT INTO Motoristas
                          (Nome, Contacto, Carta, Morada)
                           VALUES
                          (@Nome, @Contacto, @Carta, @Morada)";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@Contacto", txtContacto.Text);
            cmd.Parameters.AddWithValue("@Carta", txtCarta.Text);
            cmd.Parameters.AddWithValue("@Morada", txtMorada.Text);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        txtNome.Text = "";
        txtContacto.Text = "";
        txtCarta.Text = "";
        txtMorada.Text = "";

        lblMsg.Text = "Motorista inserido com sucesso!";
        lblMsg.Visible = true;
    }
}