using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                    v.viagem_id,
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

    protected void gvViagens_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "Editar")
            Response.Redirect("EditarViagem.aspx?id=" + id);

        if (e.CommandName == "Apagar")
        {
            ApagarViagem(id);
            CarregarViagens();
        }
    }

    void ApagarViagem(int id)
    {
        string cs = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            string sql = "DELETE FROM viagens WHERE viagem_id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    protected void btnNovaViagem_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViagemForm.aspx");
    }

    protected void Editar_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("EditarViagem.aspx?id=" + e.CommandArgument);
    }
}