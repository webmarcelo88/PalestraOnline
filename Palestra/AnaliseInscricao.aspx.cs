using Palestra.Business;
using Palestra.Model;
using Palestra.Model.Enum;
using System;
using System.Globalization;
using System.Web.UI;

namespace Palestra
{
    public partial class AnaliseInscricao : Page
    {

        #region [ Properties ]

        private long Id
        {
            get
            {
                if (Request.QueryString["ID"] == null)
                {
                    Response.Redirect("ListaInscricao.aspx");
                    return 0;
                }

                return Convert.ToInt64(Request.QueryString["ID"]);
            }
        }

        #endregion

        #region [ Events ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregarInscricao();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            var modelInscricao = BuscarInscricao();

            PreencherModel(modelInscricao);

            var inscricao = new Inscricao();
            inscricao.AtualizarInscricao(Id, modelInscricao);

            Response.Redirect("ListaInscricao.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaInscricao.aspx");
        }

        protected void lnkCopiaRG_Click(object sender, EventArgs e)
        {
            var modelInscricao = BuscarInscricao();

            FazerDownload(modelInscricao.ArquivoRGNome, modelInscricao.ArquivoRG);
        }

        protected void lnkCopiaCPF_Click(object sender, EventArgs e)
        {
            var modelInscricao = BuscarInscricao();

            FazerDownload(modelInscricao.ArquivoCPFNome, modelInscricao.ArquivoCPF);
        }

        protected void lnkCopiaContrato_Click(object sender, EventArgs e)
        {
            var modelInscricao = BuscarInscricao();

            FazerDownload(modelInscricao.ArquivoContratoNome, modelInscricao.ArquivoContrato);
        }

        #endregion

        #region [ Private methods ]

        private void CarregarInscricao()
        {
            var modelInscricao = BuscarInscricao();

            lblInscricao.Text = "Inscrição nº " + modelInscricao.NumeroInscricao;
            txtNome.Text = modelInscricao.Nome;
            txtCPF.Text = modelInscricao.CPF;
            txtDataNascimento.Text = modelInscricao.DataNascimento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            lnkCopiaRG.Text = modelInscricao.ArquivoRGNome;
            lnkCopiaCPF.Text = modelInscricao.ArquivoCPFNome;
            lnkCopiaContrato.Text = modelInscricao.ArquivoContratoNome;
            drpSituacao.SelectedValue = modelInscricao.SituacaoInscricao.ToString();

            if (modelInscricao.SituacaoInscricao != (int)TipoSituacaoInscricao.NaoAceita)
            {
                txtMotivo.Enabled = false;
            }
        }

        private InscricaoModel BuscarInscricao()
        {
            return new Inscricao().BuscarInscricaoPeloID(Id);
        }

        private void PreencherModel(InscricaoModel model)
        {
            if (!string.IsNullOrEmpty(drpSituacao.SelectedValue))
                model.SituacaoInscricao = Convert.ToInt32(drpSituacao.SelectedValue);

            model.Motivo = txtMotivo.Text;
        }

        private void FazerDownload(string nomeArquivo, byte[] arquivo)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", $"attachment;filename={nomeArquivo}");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(arquivo, 0, arquivo.Length);
            Response.OutputStream.Flush();
            Response.End();
        }

        #endregion

    }
}