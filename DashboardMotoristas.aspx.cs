using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DashboardMotoristas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logado"] == null)
            Response.Redirect("Default.aspx");

        if (!IsPostBack)
            CarregarMotoristas();
    }

    private void CarregarMotoristas()
    {
        string cs = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"SELECT 
                           motorista_id,
                           Nome, Contacto, Carta, Morada
                       FROM Motoristas
                       ORDER BY motorista_id DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvMotoristas.DataSource = dt;
            gvMotoristas.DataBind();
        }
    }
}