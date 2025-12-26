using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VeiculoForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logado"] == null)
            Response.Redirect("Default.aspx");
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string marca = txtMarca.Text.Trim();
        string modelo = txtModelo.Text.Trim();
        string matricula = txtMatricula.Text.Trim();
        string localizacao = txtLocalizacao.Text.Trim();

        lblMsg.Text = "Veículo registrado com sucesso!";
        lblMsg.Visible = true;

        txtMarca.Text = "";
        txtModelo.Text = "";
        txtMatricula.Text = "";
        txtLocalizacao.Text = "";
    }
}