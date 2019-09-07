using Palestra.Model.Enum;
using System;
using System.Drawing;
using System.Web.UI;

namespace Palestra
{
    public partial class ConsultarInscricao : Page
    {

        #region [ Events ]

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                const string MENSAGEM_INSCRICAO_INEXISTENTE = "O número de inscrição não foi encontrado";
                const string MENSAGEM_INSCRICAO_PENDENTE = "Caro {0}, sua inscrição ainda está pendente de análise";
                const string MENSAGEM_INSCRICAO_ACEITA = "Caro {0}, sua inscrição foi aceita";
                const string MENSAGEM_INSCRICAO_NAOACEITA = "Caro {0}, sua inscrição não foi aceita pelo motivo: {1}";

                // Consultar a inscrição
                var inscricao = new Business.Inscricao();
                var inscricaoModel = inscricao.ConsultarInscricao(txtNumero.Text);

                if (inscricaoModel == null)
                {
                    lblSituacao.ForeColor = Color.Red;
                    lblSituacao.Text = MENSAGEM_INSCRICAO_INEXISTENTE;
                }
                else
                {
                    switch ((TipoSituacaoInscricao)inscricaoModel.SituacaoInscricao)
                    {
                        case TipoSituacaoInscricao.Pendente:
                            lblSituacao.ForeColor = Color.Blue;
                            lblSituacao.Text = string.Format(MENSAGEM_INSCRICAO_PENDENTE, inscricaoModel.Nome);
                            break;
                        case TipoSituacaoInscricao.Aceita:
                            lblSituacao.ForeColor = Color.Green;
                            lblSituacao.Text = string.Format(MENSAGEM_INSCRICAO_ACEITA, inscricaoModel.Nome);
                            break;
                        case TipoSituacaoInscricao.NaoAceita:
                            lblSituacao.ForeColor = Color.Red;
                            lblSituacao.Text = string.Format(MENSAGEM_INSCRICAO_NAOACEITA, inscricaoModel.Nome, inscricaoModel.Motivo);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(typeof(Page), "alert", $"<script>alert('{ex.Message}');</script>");
            }
        }

        #endregion

    }
}