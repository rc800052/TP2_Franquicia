using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnEntidad;
using NeNegocio;
using Common;
using log4net;
namespace Chilis
{
    public partial class actualizarsol : System.Web.UI.Page
    {
        log4net.ILog logger = log4net.LogManager.GetLogger("File");

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnNuevoCandidato_Click(object sender, EventArgs e)
        {
            Response.Redirect("detallesol.aspx");  
        }

        //protected void NuevaSolicitud_Click(object sender, ImageClickEventArgs e)
        //{
        //    string strDocumento = ((ImageButton)sender).DescriptionUrl;
        //    Response.Redirect("detallesol.aspx");  
           
        //}

        //protected void VerSolicitudes_Click(object sender, ImageClickEventArgs e)
        //{
        //    string strDocumento = ((ImageButton)sender).DescriptionUrl;
        //    Response.Redirect("consultasol.aspx");  
           
        //}

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<EnCandidato> lst=new  List<EnCandidato>();
            NeCandidato objCandidato=new NeCandidato();
            bool blnRpta=false;
            string strBuscar="0";
            if (ddlTipo.SelectedValue.Trim() == "DNI" || ddlTipo.SelectedValue == "RUC")
            {
                if (txtBuscar.Text.Trim() == "")
                {
                    strBuscar = "0";
                    blnRpta = Funciones.ValidarNumero(strBuscar, txtBuscar.Text.Trim().Length, 2);
                }
                else
                {
                    strBuscar = txtBuscar.Text.Trim();
                    blnRpta = Funciones.ValidarNumero(strBuscar, txtBuscar.Text.Trim().Length, 2);
                }
            }
            if (ddlTipo.SelectedValue=="DNI")
            {
               
                if (blnRpta==true)
                {
                   lst = objCandidato.ListarBusqueda(strBuscar,"0", 1);
                }
                
            }
            if (ddlTipo.SelectedValue == "RUC")
            {
                if (blnRpta == true)
                {
                    lst = objCandidato.ListarBusqueda(strBuscar, "0", 2);
                }

            }
            if (ddlTipo.SelectedValue == "NOMBRES")
            {
                if (txtBuscar.Text.Trim() == "")
                {
                    strBuscar = "0";
                }
                else
                {
                    strBuscar = txtBuscar.Text.Trim();
                }

                lst = objCandidato.ListarBusqueda("0", strBuscar, 3);
                
            }
            if (lst.Count>0 )
            {
                gvlistado.DataSource = lst;
                gvlistado.DataBind();
            }
            else
            {
                gvlistado.DataSource =null;
                gvlistado.DataBind();
            }
           
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            if (gvlistado.Rows.Count >0 )
            {

                Response.Clear();


                Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");


                Response.Charset = "";


                // If you want the option to open the Excel file without saving than


                // comment out the line below


                // Response.Cache.SetCacheability(HttpCacheability.NoCache);


                Response.ContentType = "application/vnd.xls";


                System.IO.StringWriter stringWrite = new System.IO.StringWriter();


                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);


                gvlistado.RenderControl(htmlWrite);


                Response.Write(stringWrite.ToString());


                Response.End();
            }

        }

        public override void VerifyRenderingInServerForm(Control control)
        {


            // Confirms that an HtmlForm control is rendered for the
            //specified ASP.NET server control at run time.


        }
    }
}