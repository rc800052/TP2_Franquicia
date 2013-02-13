using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnEntidad;
using NeNegocio;
using log4net;

namespace Chilis
{
    public partial class notificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                hdnCodSol.Value = Request.QueryString["idsol"];
                hdnFlag.Value = Request.QueryString["flag"];

               

                

                if (hdnCodSol.Value == "")
                {
                    //Response.Redirect("actualizarsol.aspx");
                }
                else
                {
                    mostrarSolicitud(Int64.Parse(hdnCodSol.Value));

                }
              
            }
     
          
        }

        private void mostrarSolicitud(Int64 intCodSolicitud)
        {
            EnSolicitud objEnSolicitud = new EnSolicitud();
            objEnSolicitud.SolCodigo = hdnCodSol.Value;
            objEnSolicitud.SolNombre = "0";
            if (hdnFlag.Value == "1")
            {
                lblTitulo.Text = "Su solicitud ha sido APROBADA";
                objEnSolicitud.SolEstados = "APROBADA"; 

            }
            if (hdnFlag.Value == "2")
            {
                lblTitulo.Text = "Su solicitud ha sido RECHAZADA";
                objEnSolicitud.SolEstados = "RECHAZADA"; 

            }
          
            NeSolicitud objNeSolicitud = new NeSolicitud();

            List<EnSolicitud> lst = objNeSolicitud.ListarSolicitudxEntrevista(objEnSolicitud);
            if (lst.Count > 0)
            {
                LBLFECHAENTREVISTA.Text = lst[0].SolStrFechaEntrevista;
                LBLFECHASOLICITUD.Text = lst[0].SolStrFecha;
                LBLCANDIDATO.Text = lst[0].SolNombre.Trim();
                LBLNROSOLICITUD.Text = lst[0].SolCodigo.Trim();
                LBLENTREVISTADOR.Text = "Ing. Sandra Vega";
                lblComentario.Text = lst[0].SolDescripcion.Trim();
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            NeEntrevista objEntrevista = new NeEntrevista();
            objEntrevista.Mensaje(hdnCodSol.Value, hdnFlag.Value);
            Response.Redirect("buscarSolEntrevista.aspx"); 
        }


    }
}