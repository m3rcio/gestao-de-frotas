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

    private void CarregarVeiculos()
    {
        string cs = ConfigurationManager
                   .ConnectionStrings["DB"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"SELECT Id, Matricula, Marca, Modelo, Ano,
                              Quilometragem, Estado
                       FROM Veiculos
                       ORDER BY Id DESC";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            gvVeiculos.DataSource = dt;
            gvVeiculos.DataBind();
        }
    }
}