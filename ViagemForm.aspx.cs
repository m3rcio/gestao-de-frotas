using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViagemForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Logado"] == null)
            Response.Redirect("Default.aspx");

        if (!IsPostBack)
        {
            CarregarVeiculos();
            CarregarMotoristas();
        }
    }

    private void CarregarVeiculos()
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT veiculo_id, matricula FROM veiculos WHERE estado = 'ativo'", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlVeiculo.DataSource = dt;
            ddlVeiculo.DataTextField = "matricula";
            ddlVeiculo.DataValueField = "veiculo_id";
            ddlVeiculo.DataBind();
        }
    }

}