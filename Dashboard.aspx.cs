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

    protected void btnVeiculoForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("VeiculoForm.aspx");
    }

    private void CarregarVeiculos()
    {
        string cs = ConfigurationManager
                   .ConnectionStrings["DB"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"SELECT veiculo_id, Matricula, Marca, Modelo, Ano,
                              Quilometragem, Estado
                       FROM Veiculos
                       ORDER BY veiculo_id DESC";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            gvVeiculos.DataSource = dt;
            gvVeiculos.DataBind();
        }
    }
}