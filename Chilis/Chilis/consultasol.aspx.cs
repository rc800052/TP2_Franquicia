using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnEntidad;
using NeNegocio;
 

namespace Chilis
{
    public partial class consultasol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strFlag = Request.QueryString["id"];
               
                if (strFlag == null)
                {
                    //Response.Redirect("listaCategorias.aspx");
                }
                else
                {
                    hdnCategoria.Value = strFlag;
                    mostrarContacto("0",Int64.Parse(strFlag));
                   
                }
            }
        }

        protected void imgBtnEditar_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;
            string strCodSolicitud = ((Label)gvlistado.Rows[row.RowIndex].FindControl("lblSolicitud")).Text.Trim();
            string strCodCandidato = ((Label)gvlistado.Rows[row.RowIndex].FindControl("lblCandidato")).Text.Trim();

            Response.Redirect("detallesol.aspx?fl=M&idsol=" + strCodSolicitud + "&id=" + strCodCandidato);
           
        }
        protected void imgBtnVer_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;

            string strCodSolicitud = ((Label)gvlistado.Rows[row.RowIndex].FindControl("lblSolicitud")).Text.Trim();
           string strCodCandidato = ((Label)gvlistado.Rows[row.RowIndex].FindControl("lblCandidato")).Text.Trim();
            Response.Redirect("detallesol.aspx?fl=V&idsol=" + strCodSolicitud + "&id=" + strCodCandidato);
      
        }

        

        protected void imgBtnEliminar_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;

            string strCodSolicitud = ((Label)gvlistado.Rows[row.RowIndex].FindControl("lblSolicitud")).Text.Trim();
            string strCodCandidato = ((Label)gvlistado.Rows[row.RowIndex].FindControl("lblCandidato")).Text.Trim();

            NeSolicitud objSolicitud = new NeSolicitud();
            List<EnSolicitud> lst= objSolicitud.ListarSolicitud(Int32.Parse(strCodSolicitud));
            if (lst.Count>0 )
            {
                if (lst[0].SolEstados.Trim()=="ELIMINADO")
                {
                   MsgBox1.ShowMessage("La Solicitud ya se encuentra ELIMINADA"); 
                }
                else
                {
                    string confirmValue = Request.Form["confirm_value"];
                    if (confirmValue == "Yes")
                    {
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                        NeSolicitud objNeSolicitud = new NeSolicitud();
                        objNeSolicitud.MantenimientoSolicitudEstado(Int64.Parse(strCodSolicitud), "ELIMINADO");
                        
                        btnBuscar_Click(sender, e);
                        MsgBox1.ShowMessage("Solicitud eliminada");  
                    }
                    else
                    {
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
                    }
                 
                }
            }
         
            
        }
      

        private void mostrarContacto(string strNumero,Int64 intCodContacto)
        {
            NeCandidato objCandidato=new NeCandidato();

           List<EnCandidato> lstCandidato=objCandidato.ListarBusquedaxCandidato("0", "0", intCodContacto, 4);
           lblCandidato.Text = lstCandidato[0].nombre;

            NeSolicitud objNeSolicitud = new NeSolicitud();
            List<EnSolicitud> lst = objNeSolicitud.ListarBusquedaxCandidatoxSolicitud(strNumero, intCodContacto);
            if (lst.Count==0 )
            {
                MsgBox1.ShowMessage("El contacto no tiene ninguna solicitud"); 
                gvlistado.DataSource = null;
                gvlistado.DataBind();
            }
            else{
                gvlistado.DataSource = lst;
                gvlistado.DataBind();
            }
           

        }
      
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedValue=="TODOS")
	        {

                mostrarContacto("0", Int64.Parse(hdnCategoria.Value));
	        }
            else 
            {
                if (txtBuscar.Text.Trim()=="")
                {
                    MsgBox1.ShowMessage("Ud. Debe ingresar un Nº de Solicitud");  
                }
                {
                    mostrarContacto(txtBuscar.Text.Trim(), Int64.Parse(hdnCategoria.Value));
                }
                
            }

        }
    }
}