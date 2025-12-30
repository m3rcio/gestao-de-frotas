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
            string sql = @"INSERT INTO Veiculos
                          (Matricula, Marca, Modelo, Ano, Quilometragem, Estado)
                           VALUES
                          (@Matricula, @Marca, @Modelo, @Ano, @Km, @Estado)";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Matricula", txtNome.Text);
            cmd.Parameters.AddWithValue("@Marca", txtContacto.Text);
            cmd.Parameters.AddWithValue("@Modelo", txtCarta.Text);
            cmd.Parameters.AddWithValue("@Ano", int.Parse(txtMorada.Text));
            cmd.Parameters.AddWithValue("@Km", int.Parse(txtKm.Text));
            cmd.Parameters.AddWithValue("@Estado", ddlEstado.SelectedValue);


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