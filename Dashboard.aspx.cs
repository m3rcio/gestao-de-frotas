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
            Response.Redirect("Login.aspx");

        if (!IsPostBack)
            CarregarTabela();
    }

    private void CarregarTabela()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Nome");
        dt.Columns.Add("Cargo");
        dt.Columns.Add("Prioridade");
        dt.Columns.Add("Budget");

        dt.Rows.Add("Sunil Joshi", "Web Designer", "Low", "$3.9K");

        gvPerformance.DataSource = dt;
        gvPerformance.DataBind();
    }
}