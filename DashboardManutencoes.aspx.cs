using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DashboardManutencoes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarManutencoes();
        }
        if (Session["Logado"] == null)
            Response.Redirect("Default.aspx");
    }

    private void CarregarManutencoes()
    {
        string cs = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"
            SELECT
                m.manutencao_id,
                v.matricula AS veiculo,
                m.tipo,
                m.custo,
                m.data,
                m.descricao
            FROM manutencoes m
            JOIN veiculos v ON v.veiculo_id = m.veiculo_id
            ORDER BY m.data DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvManutencoes.DataSource = dt;
            gvManutencoes.DataBind();
        }
    }

    protected void btnNovaManutencao_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManutencaoForm.aspx");
    }

    protected void gvManutencoes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            Response.Redirect("EditarManutencao.aspx?id=" + id);
        }

        if (e.CommandName == "Apagar")
        {
            ApagarManutencao(id);
            CarregarManutencoes();
        }
    }
}