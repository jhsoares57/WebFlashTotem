﻿using Library.Business;
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
                    txtData.Text = p.Data.ToString("dd/MM/yyyy");
                    txtHora.Text = p.Hora.ToString();

                }
            }
        }

        

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string erros = string.Empty;
            try
            {
               
                if (string.IsNullOrEmpty(txtCodigo.Text))
                {

                    if (string.IsNullOrEmpty(txtTitulo.Text))
                        erros += "* Digite um titulo <br/><br/>";

                    if (string.IsNullOrEmpty(txtDescricao.Text))
                        erros += "* Digite uma descrição<br/><br/>";

                    if (string.IsNullOrEmpty(txtPalestrante.Text))
                        erros += "* Digite um palestrante<br/><br/>";

                    if (string.IsNullOrEmpty(txtData.Text))
                        erros += "* Digite uma data válída<br/><br/>";

                    if (string.IsNullOrEmpty(txtHora.Text))
                        erros += "* Digite uma hora válída<br/><br/>";

                    if (!string.IsNullOrEmpty(erros))
                    {
                        throw new Exception(erros);
                    }


                    Palestra p = new Palestra();
                    p.Titulo = txtTitulo.Text;
                    p.Descricao = txtDescricao.Text;
                    p.Palestrante = txtPalestrante.Text;
                    p.Data = Convert.ToDateTime(txtData.Text);
                    p.Hora = txtHora.Text;
                    p.TipoPalestra = Convert.ToInt32(ddlTipoPalestra.SelectedIndex);

                    pService.Insert(p);
                    
                        ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>mensagem();</script>");
                        //ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>ExibirMensagemSucesso();</script>");
                    
                }
                else
                {


                    if (string.IsNullOrEmpty(txtTitulo.Text))
                        erros += "* Digite um titulo <br/><br/>";

                    if (string.IsNullOrEmpty(txtDescricao.Text))
                        erros += "* Digite uma descrição<br/><br/>";

                    if (string.IsNullOrEmpty(txtPalestrante.Text))
                        erros += "* Digite um palestrante<br/><br/>";

                    if (string.IsNullOrEmpty(txtData.Text))
                        erros += "* Digite uma data válída<br/><br/>";

                    if (string.IsNullOrEmpty(txtHora.Text))
                        erros += "* Digite uma hora válída<br/><br/>";


                    if ((ddlTipoPalestra.Text == "Selecione"))
                        erros += "* Selecione um tipo de palestra<br/><br/>";

                    if (!string.IsNullOrEmpty(erros))
                    {
                        throw new Exception(erros);
                    }

                    Palestra p = new Palestra();
                    p.Titulo = txtTitulo.Text;
                    p.Descricao = txtDescricao.Text;
                    p.Palestrante = txtPalestrante.Text;
                    p.Data = Convert.ToDateTime(txtData.Text);
                    p.Hora = txtHora.Text;
                    p.Id = Convert.ToInt32(txtCodigo.Text);

                    pService.Update(p); 
                    
                        ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>mensagemUPDT();</script>");
                        //ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>ExibirMensagemSucesso();</script>");
                    
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>mensagemErro();</script>");
                //string scriptMensagem = string.Format("<script>ChamarExibirMensagemErro('{0}');</script>", ex.Message);
                //ClientScript.RegisterStartupScript(this.GetType(), "ChaveMensagem", scriptMensagem);
               // throw;
            }
        }
    }
}