using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"SELECT usuario_id, nome_usuario
                               FROM usuarios
                               WHERE nome_usuario = @usuario
                               AND palavra_passe = @senha";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                // CRIA SESSÃO
                Session["usuario_id"] = dr["usuario_id"];
                Session["nome_usuario"] = dr["nome_usuario"];

                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblErro.Text = "Usuário ou senha inválidos.";
                lblErro.Visible = true;
            }
        }
    }
}