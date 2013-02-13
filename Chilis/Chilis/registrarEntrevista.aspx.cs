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
    public partial class registrarEntrevista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                hdnCodSol.Value = Request.QueryString["idsol"];
                mostrarBalotario();


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

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscarSolEntrevista.aspx");
        }

        private void mostrarSolicitud(Int64 intCodSolicitud)
        {
            EnSolicitud objEnSolicitud = new EnSolicitud();
            objEnSolicitud.SolCodigo = hdnCodSol.Value;
            objEnSolicitud.SolNombre = "0";
            objEnSolicitud.SolEstados = "VALIDADA"; 


            NeSolicitud objNeSolicitud = new NeSolicitud();

            List<EnSolicitud> lst = objNeSolicitud.ListarSolicitudxEntrevista(objEnSolicitud);
            if (lst.Count > 0)
            {
                LBLFECHAENTREVISTA.Text = lst[0].SolStrFechaEntrevista;
                LBLFECHASOLICITUD.Text = lst[0].SolStrFecha;
                LBLCANDIDATO.Text = lst[0].SolNombre.Trim();
                LBLNROSOLICITUD.Text = lst[0].SolCodigo.Trim();
                LBLENTREVISTADOR.Text = "Ing. Sandra Vega";
            }
           
        }


        private void mostrarBalotario()
        {
             NeBalotario objNeBalotario = new NeBalotario();
            List<EnBalotario> lst = objNeBalotario.ListarBalotario();
            
            gvlistado.DataSource = lst;
            gvlistado.DataBind(); 


        }
        

        private void setearEntrevista(Int16 intFlag)
        {
            Int16 cont=1;
            Int16 intRpta = 0;

            NeEntrevista objNeEntrevista = new NeEntrevista();
            EnEntrevista objEnEntrevista = new EnEntrevista();
            if (txtcomentario.Text.Trim()=="")
            {
                MsgBox1.ShowMessage("Ud. Debe de registrar todos los campos.");
              
            }
            else
            {
                objEnEntrevista.comentario = txtcomentario.Text.Trim();
                objEnEntrevista.nombreEntrevistador = LBLENTREVISTADOR.Text.Trim();
                objEnEntrevista.FQ_Solicitud_ID = Int32.Parse(hdnCodSol.Value);
                objEnEntrevista.fecha = DateTime.Parse(LBLFECHAENTREVISTA.Text.Trim());  

                List<EnCuestionario> lstCuestionario = new List<EnCuestionario>();
                for (int i = 0; i < gvlistado.Rows.Count; i++)
                {
                    EnCuestionario objEnCuestionario = new EnCuestionario();
                    string strvalor = ((TextBox)gvlistado.Rows[i].FindControl("txtDescripcion")).Text.Trim();
                    string strBalotario = ((Label)gvlistado.Rows[i].FindControl("lblBalotario")).Text.Trim();
                    if (strvalor == "")
                    {
                        cont = 0;
                        MsgBox1.ShowMessage("Ud. Debe de registrar todos los campos.");
                        break;
                    }
                    objEnCuestionario.valor = strvalor;
                    objEnCuestionario.FQ_Balotario_ID = Int32.Parse(strBalotario);
                    lstCuestionario.Add(objEnCuestionario);
                }
                if (cont != 0)
                {
                    if (intFlag == 1)
                    {
                        intRpta = objNeEntrevista.MantenimientoEntrevista(objEnEntrevista, lstCuestionario, "APROBADA", 1);
                        Response.Redirect("notificacion.aspx?idsol=" + hdnCodSol.Value + "&flag=" + 1);
                    }
                    if (intFlag == 2)
                    {
                        intRpta = objNeEntrevista.MantenimientoEntrevista(objEnEntrevista, lstCuestionario, "RECHAZADA", 1);
                        Response.Redirect("notificacion.aspx?idsol=" + hdnCodSol.Value + "&flag=" + 2);
                    }


                }

            }
           
           
           
        }
        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            setearEntrevista(1);
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            setearEntrevista(2);
        } 

    }
}