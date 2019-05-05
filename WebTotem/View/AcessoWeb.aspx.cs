using Library.Business;
using Library.Model;
using Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTotem.View
{
    public partial class AcessoWeb : System.Web.UI.Page
    {
        UsuarioBLL uService = new UsuarioBLL();
        Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAcessar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBLL uService = new UsuarioBLL();
               // Usuario usuario = new Usuario();

                usuario = uService.FindByLogin(txtUsuario.Text, Criptografia.GerarMD5(txtSenha.Text));

                if (usuario != null)
                {
                    Session["Usuario"] = usuario;
                    Response.Redirect("ListarPalestra.aspx");
                }
                else
                {
                    throw new Exception("Usuario e senha incorretos.");
                }
            }
            catch (Exception ex)
            {

                string scriptMensagem = string.Format("<script>alert('{0}');</script>", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "ChaveMensagem", scriptMensagem);
            }
        }
    }
}