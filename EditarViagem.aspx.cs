using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarViagem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("DashboardViagens.aspx");
                return;
            }

            int id = int.Parse(Request.QueryString["id"]);
            CarregarViagem(id);
        }
    }
}