using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DashboardViagens : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logado"] == null)
            Response.Redirect("Default.aspx");

        if (!IsPostBack)
            CarregarViagens();

    }

    private void CarregarViagens()
    {
        string cs = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = @"
                SELECT 
                    v.id,
                    ve.matricula AS veiculo,
                    m.nome AS motorista,
                    v.data_saida,
                    v.data_retorno,
                    v.km_saida,
                    v.km_retorno
                FROM viagens v
                INNER JOIN veiculos ve ON ve.veiculo_id = v.veiculo_id
                INNER JOIN motoristas m ON m.motorista_id = v.motorista_id
                ORDER BY v.data_saida DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvViagens.DataSource = dt;
            gvViagens.DataBind();
        }
    }
}