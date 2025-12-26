using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        
        const string USER = "admin";
        const string PASS = "1234";

        if (username == USER && password == PASS)
        {
            
            Session["Logado"] = true;
            Session["Usuario"] = username;

            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            lblErro.Text = "Usuário ou palavra-passe inválidos";
            lblErro.Visible = true;
        }

    }
}