using Palestra.Business;
using Palestra.Model;
using System;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Web.UI;

namespace Palestra
{
    public partial class NovaInscricao : Page
    {

        #region [ Events ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                txtNome.Focus();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CamposObrigatoriosForamInformados())
                {
                    ValidarArquivos();

                    // Enviar a inscrição
                    var inscricao = new Business.Inscricao();
                    var numeroInscricao = inscricao.EnviarInscricao(PreencherModel());

                    lblNumeroInscricao.Text = $"    Nº INSCRIÇÃO: {numeroInscricao}";
                }
            }
            catch (SqlTypeException)
            {
                ClientScript.RegisterClientScriptBlock(typeof(Page), "alert", $"<script>alert('Data de Nascimento inválida!');</script>");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(typeof(Page), "alert", $"<script>alert('{ex.Message}');</script>");
            }
        }

        #endregion

        #region [ Private methods ]

        private bool CamposObrigatoriosForamInformados()
        {
            return (rfvNome.IsValid &&
                    rfvCPF.IsValid &&
                    rfvDataNascimento.IsValid);
        }

        private byte[] LerArquivoUpload(Stream input)
        {
            byte[] buffer = new byte[input.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private void ValidarArquivos()
        {
            // Verificar obrigatoriedade dos arquivos
            if (!fileUploadRG.HasFile ||
                !fileUploadCPF.HasFile ||
                !fileUploadContrato.HasFile)
            {
                throw new BusinessException("Todos os arquivos devem ser informados!");
            }

            // Verificar extensão dos arquivos
            if (!ExtensaoArquivoValida(fileUploadRG.FileName) ||
                !ExtensaoArquivoValida(fileUploadCPF.FileName) ||
                !ExtensaoArquivoValida(fileUploadContrato.FileName))
            {
                throw new BusinessException("Todos os arquivos devem estar no formato PDF!");
            }
        }

        private bool ExtensaoArquivoValida(string filename)
        {
            return Path.GetExtension(filename).ToUpper() == ".PDF";
        }

        private InscricaoModel PreencherModel()
        {
            DateTime data;
            DateTime.TryParseExact(txtDataNascimento.Text, "ddMMyyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out data);

            return new InscricaoModel
            {
                Nome = txtNome.Text,
                CPF = txtCPF.Text,
                DataNascimento = data,
                ArquivoRG = LerArquivoUpload(fileUploadRG.PostedFile.InputStream),
                ArquivoRGNome = fileUploadRG.FileName,
                ArquivoCPF = LerArquivoUpload(fileUploadCPF.PostedFile.InputStream),
                ArquivoCPFNome = fileUploadCPF.FileName,
                ArquivoContrato = LerArquivoUpload(fileUploadContrato.PostedFile.InputStream),
                ArquivoContratoNome = fileUploadContrato.FileName
            };
        }

        #endregion

    }
}