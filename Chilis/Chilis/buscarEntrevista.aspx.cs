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
    public partial class buscarEntrevista1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscarSolEntrevista.aspx");  
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            EnSolicitud objEnSolicitud = new EnSolicitud();
            objEnSolicitud.SolCodigo = txtNroSolicitud.Text.Trim();
            objEnSolicitud.SolNombre = txtCandidato.Text.Trim();
            objEnSolicitud.SolFecha = Funciones.ObtenerDateTimeNull(txtFechaInicio.Text.Trim());
            objEnSolicitud.SolFechaEntrevista = Funciones.ObtenerDateTimeNull(txtFechaFin.Text.Trim());
            objEnSolicitud.SolEstados = ddlEstado.SelectedValue;

            NeSolicitud objNeSolicitud = new NeSolicitud();

            List<EnSolicitud> lst = objNeSolicitud.ListarSolicitudxEntrevista(validar(objEnSolicitud));
            if (lst.Count == 0)
            {
                MsgBox1.ShowMessage("No existen registros ");
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
            string strTipo = ddlEstado.SelectedValue;
            string strFlag = "";
            if (strTipo=="APROBADA")
            {
                strFlag = "1";
            }
            else
            {
                strFlag = "2";
            }
            string strCodSolicitud = ((Label)gvlistado.Rows[row.RowIndex].FindControl("lblSolicitud")).Text.Trim();
            Response.Redirect("detalleEntrevista.aspx?idsol=" + strCodSolicitud + "&flag="+strFlag);
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


    }
}