using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VeiculoForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario_id"] == null)
        {
            Response.Redirect("Default.aspx");
            return;
        }
    }

    protected void btnDashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }

    private void verificarMtricula()
    {
        string sqlCheck = "SELECT COUNT(*) FROM veiculos WHERE matricula = @matricula";

        SqlCommand cmdCheck = new SqlCommand(sqlCheck, con);
        cmdCheck.Parameters.AddWithValue("@matricula", txtMatricula.Text.Trim());

        int existe = (int)cmdCheck.ExecuteScalar();

        if (existe > 0)
        {
            lblMensagem.Text = "Esta matrícula já está registada.";
            lblMensagem.ForeColor = System.Drawing.Color.Red;
            return;
        }
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

            cmd.Parameters.AddWithValue("@Matricula", txtMatricula.Text);
            cmd.Parameters.AddWithValue("@Marca", txtMarca.Text);
            cmd.Parameters.AddWithValue("@Modelo", txtModelo.Text);
            cmd.Parameters.AddWithValue("@Ano", int.Parse(txtAno.Text));
            cmd.Parameters.AddWithValue("@Km", int.Parse(txtKm.Text));
            cmd.Parameters.AddWithValue("@Estado", ddlEstado.SelectedValue);


            con.Open();
            cmd.ExecuteNonQuery();
        }

        txtMatricula.Text = "";
        txtMarca.Text = "";
        txtModelo.Text = "";
        txtAno.Text = "";
        txtKm.Text = "";

        lblMsg.Text = "Veículo inserido com sucesso";
        lblMsg.Visible = true;
    }
}
