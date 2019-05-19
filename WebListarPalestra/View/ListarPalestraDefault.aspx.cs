using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebListarPalestra.View
{
    public partial class ListarPalestraDefault : System.Web.UI.Page
    {
        PalestraBLL pService = new PalestraBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               CarregarPalestra();
            }
        }

        //Metodo para carregar as pelestas
        public void CarregarPalestra()
        {
            List<Palestra> listaPalestra = pService.FindAllList();
            gvListaPalestra.DataSource = listaPalestra;
            gvListaPalestra.DataBind();
        }

        protected void gvListaPalestra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.RowState == DataControlRowState.Alternate)
            //    {
            //        e.Row.Style.Add("background-color", "#DDA0DD");
            //        }
            //}

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
            }
        }        
    }
}