using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTotem.View
{
    public partial class CadastrarPalestra : System.Web.UI.Page
    {
        PalestraBLL pService = new PalestraBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                if (!string.IsNullOrEmpty(Request.QueryString["PalestraId"]))
                {
                    int ID = Convert.ToInt32(Request.QueryString["PalestraId"].ToString());
                    Palestra p = pService.FindById(ID);
                    txtCodigo.Text = p.Id.ToString();
                    txtTitulo.Text = p.Titulo.ToString();
                    txtDescricao.Text = p.Descricao.ToString();
                    txtPalestrante.Text = p.Palestrante.ToString();
                    txtData.Text = p.Data.ToString();
                    txtHora.Text = p.Hora.ToString();
                    txtEndereco.Text = p.LocalPalestra.ToString();
                }
            }
            if (Session["Usuario"] == null)
            {
                Response.Redirect("AcessoWeb.aspx");
            }
        }

        

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
           
            try
            {
               
                if (string.IsNullOrEmpty(txtCodigo.Text))
                {

                    

                    Palestra p = new Palestra();
                    p.Titulo = txtTitulo.Text;
                    p.Descricao = txtDescricao.Text;
                    p.Palestrante = txtPalestrante.Text;
                    p.Data = Convert.ToDateTime(txtData.Text);
                    p.Hora = txtHora.Text;
                    p.LocalPalestra = txtEndereco.Text;

                    pService.Insert(p);
                    
                        ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>mensagem();</script>");
                       
                    
                }
                else
                {
                   

                    Palestra p = new Palestra();
                    p.Titulo = txtTitulo.Text;
                    p.Descricao = txtDescricao.Text;
                    p.Palestrante = txtPalestrante.Text;
                    p.Data = Convert.ToDateTime(txtData.Text);
                    p.Hora = txtHora.Text;
                    p.LocalPalestra = txtEndereco.Text;
                    p.Id = Convert.ToInt32(txtCodigo.Text);

                    pService.Update(p); 
                    
                        ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>mensagemUPDT();</script>");
                       
                    
                }
            }
            catch (Exception )
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>mensagemErro();</script>");
                //throw;
            }
        }
    }
}