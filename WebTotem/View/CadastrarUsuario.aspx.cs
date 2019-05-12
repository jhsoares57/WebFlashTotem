using Library.Business;
using Library.Model;
using Library.Model.Enuns;
using Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTotem.View
{
    public partial class CadastrarUsuario : System.Web.UI.Page
    {
        UsuarioBLL uService = new UsuarioBLL();
        Usuario u = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            if (txtConfirmarSenha.Text != txtSenha.Text)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>mensagemErro();</script>");
            }
            else
            {
                try
                {

                    u.Login = txtUser.Text;
                    u.Senha = Criptografia.GerarMD5(txtSenha.Text);
                    u.TipoUsuario = (PerfilEnum)Convert.ToInt32(ddlPerfil.SelectedValue);

                    if (uService.Insert(u))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>mensagemSucesso();</script>");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}