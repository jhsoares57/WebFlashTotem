﻿using Library.DAL;
using Library.Model;
using Library.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library.Model.Enuns;

namespace WebTotem.View
{
    public partial class ListarPalestra : System.Web.UI.Page
    {
        PalestraDAL pService = new PalestraDAL();
        Usuario usuarioLogado = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioLogado = (Usuario)Session["Usuario"];

            Button btnUser = (Button)FindControl("btnUser");
            if (!Page.IsPostBack)
            {
                CarregarPalestra();

                if (usuarioLogado.TipoUsuario == PerfilEnum.Gestor)
                {
                    btnUser.Visible = false;
                }
            }
        }
        public void CarregarPalestra()
        {
            List<Palestra> listaPalestra = pService.FindAll();
            gvPalestra.DataSource = listaPalestra;
            gvPalestra.DataBind();
        }
        protected void btnCarregarPessoas_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarPalestra();
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    int Id = Convert.ToInt32(hdnId.Value);

            //    if (pService.Delete(Id))
            //    {
            //        CarregarPalestra();
            //        string scriptMensagem = "<script>ExibirMensagemSucesso('Exclusão realizada com sucesso.');<script>";
            //        ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", scriptMensagem);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    string scriptMensagem = string.Format("<script>ExibirMensagemErro('{0}');<script>", ex.Message);
            //    ClientScript.RegisterStartupScript(this.GetType(), "ChaveMensagem", scriptMensagem);
            //}
        }

        protected void gvCadastroPessoa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              
                Panel pnlLinhaEditar = (Panel)e.Row.FindControl("pnlEditar");

               
                if (usuarioLogado.TipoUsuario == PerfilEnum.Gestor)
                {
                    pnlLinhaEditar.Visible = false;
                }

                if (usuarioLogado.TipoUsuario == PerfilEnum.UsuarioComum)
                {
                    pnlLinhaEditar.Visible = false;
                }


            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((e.Row.RowIndex + 1) % 2) == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.LightSalmon;
                }
            }
            //if (e.Row.RowType == DataControlRowType.DataRow)            
            //{
            //    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            //    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            //}
        }

    }
}