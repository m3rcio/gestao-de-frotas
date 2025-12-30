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

    protected void gvMotoristas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int motoristaId = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            Response.Redirect("MotoristaForm.aspx?id=" + motoristaId);
        }

        if (e.CommandName == "Apagar")
        {
            ApagarMotorista(motoristaId);
            CarregarMotoristas();
        }
    }

    private void ApagarMotorista(int id)
    {
        string cs = ConfigurationManager
                        .ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = "DELETE FROM Motoristas WHERE motorista_id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    protected void btnMotoristaForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("MotoristaForm.aspx");
    }

    protected void Editar_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("EditarMotorista.aspx?id=" + e.CommandArgument);
    }
}