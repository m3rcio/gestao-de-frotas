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

    protected void gvVeiculos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int veiculoId = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            Response.Redirect("VeiculoForm.aspx?id=" + veiculoId);
        }

        if (e.CommandName == "Apagar")
        {
            ApagarVeiculo(veiculoId);
            CarregarVeiculos(); 
        }
    }

    private void ApagarVeiculo(int id)
    {
        string cs = ConfigurationManager
                        .ConnectionStrings["DB"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = "DELETE FROM Veiculos WHERE veiculo_id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    protected void btnVeiculoForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("VeiculoForm.aspx");
    }

    protected void Editar_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("EditarVeiculo.aspx?id=" + e.CommandArgument);
    }

   
}