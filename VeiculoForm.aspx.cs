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
        if (Session["Logado"] == null)
            Response.Redirect("Default.aspx");
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager
                        .ConnectionStrings["DB"].ConnectionString;

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
            cmd.Parameters.AddWithValue("@Estado", txtEstado.Text);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        lblMsg.Text = "Veículo inserido com sucesso";
        lblMsg.Visible = true;
    }
}
}