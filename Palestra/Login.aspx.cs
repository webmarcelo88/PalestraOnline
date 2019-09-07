using Palestra.Business;
using System;
using System.Web.UI;

namespace Palestra
{
    public partial class Login : Page
    {

        #region [ Events ]

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = new Usuario();
                var idUsuario = usuario.BuscarUsuario(txtUsuario.Text, txtSenha.Text);

                // verificar login
                if (idUsuario == 0)
                    throw new BusinessException("Login inválido.");

                Session["Login"] = idUsuario;
                Response.Redirect("ListaInscricao.aspx");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(typeof(Page), "alert", $"<script>alert('{ex.Message}');</script>");
            }
        }

        #endregion

    }
}