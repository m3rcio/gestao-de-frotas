using System;
using System.Collections.Generic;
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


}