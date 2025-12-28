using System;
using System.Collections.Generic;
using System.Data;
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
            CarregarTabela();
    }

    private void CarregarTabela()
    {
        string sql = @"SELECT Id, Matricula, Marca, Modelo, Ano,
                                  Quilometragem, Estado
                           FROM Veiculos
                           ORDER BY Id DESC";

        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        gvVeiculos.DataSource = dt;
        gvVeiculos.DataBind();
    }
}