using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnEntidad;
using NeNegocio;
using Common;
 
namespace Chilis
{
    public partial class buscarEntrevista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ////string strFlag = Request.QueryString["id"];

                ////if (strFlag == null)
                ////{
                ////    //Response.Redirect("listaCategorias.aspx");
                ////}
                //////if (strFlag == "1")
                //////{
                //////    //this.hdnFlag.Value = "1"; //Nuevo
                //////}
                ////else
                ////{
                ////    hdnCategoria.Value = strFlag;
                  
                ////    //if (strFlag == "2")
                ////    //{
                ////    //    this.hdnFlag.Value = "2"; //Modificar
                ////    //    mostrarData();
                ////    //}
                ////    //else
                ////    //{
                ////    //    Response.Redirect("listaCategorias.aspx");
                ////    //}

                ////}
            }
        }

      
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            EnSolicitud objEnSolicitud = new EnSolicitud();
            objEnSolicitud.SolCodigo = txtNroSolicitud.Text.Trim();
            objEnSolicitud.SolNombre = txtCandidato.Text.Trim();
            objEnSolicitud.SolFecha = Funciones.ObtenerDateTimeNull(txtFechaInicio.Text.Trim());
            objEnSolicitud.SolFechaEntrevista = Funciones.ObtenerDateTimeNull(txtFechaFin.Text.Trim());
            objEnSolicitud.SolEstados = "VALIDADA"; 

            NeSolicitud objNeSolicitud = new NeSolicitud();

            List<EnSolicitud> lst = objNeSolicitud.ListarSolicitudxEntrevista(validar(objEnSolicitud));
            if (lst.Count == 0)
            {
                lblMENSAJE.Text = "No existen registros ";
                gvlistado.DataSource = null;
                gvlistado.DataBind();
            }
            else
            {
                gvlistado.DataSource = lst;
                gvlistado.DataBind();
            }
        }

        protected void imgBtnVer_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;

            string strCodSolicitud = ((Label)gvlistado.Rows[row.RowIndex].FindControl("lblSolicitud")).Text.Trim();
            Response.Redirect("registrarEntrevista.aspx?idsol=" + strCodSolicitud );
        }

        public EnSolicitud validar(EnSolicitud obj1)
        {
            
            if (obj1.SolNombre.Trim() == "")
            {
                obj1.SolNombre = "0"; 
                
            }
            if (obj1.SolCodigo.Trim() == "")
            {
                obj1.SolCodigo = "0";

            }
           
            return obj1;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscarEntrevista.aspx");  
        }

     

    }
}