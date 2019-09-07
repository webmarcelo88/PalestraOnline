using Palestra.Business;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Palestra
{
    public partial class ListaInscricao : Page
    {

        #region [ Events ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("Login");
                return;
            }

            if (!IsPostBack)
            {
                CarregarInscricoes();
            }
        }

        protected void gridInscricao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Selecionar")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                long id = Convert.ToInt64(gridInscricao.DataKeys[rowIndex].Values[0]);

                Response.Redirect("AnaliseInscricao.aspx?ID=" + id);
            }
        }

        #endregion

        #region [ Private methods ]

        private void CarregarInscricoes()
        {
            var inscricao = new Inscricao();
            var lista = inscricao.BuscarInscricoes();

            gridInscricao.Columns[0].Visible = false;

            gridInscricao.DataSource = lista;
            gridInscricao.DataBind();
        }

        #endregion

    }
}