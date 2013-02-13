using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnEntidad;
using NeNegocio;
using log4net;
using Common;

namespace Chilis
{
    public partial class detallesol : System.Web.UI.Page
    {
        log4net.ILog logger = log4net.LogManager.GetLogger("File");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnCodContac.Value = Request.QueryString["id"];
                hdnCodSol.Value = Request.QueryString["idsol"];
                hdnAccion.Value = Request.QueryString["fl"];
                mostrarTipoAnexo();
                if (hdnAccion.Value == "")
                {
                    //Response.Redirect("actualizarsol.aspx");
                }
                else
                {
                    if (hdnAccion.Value == "V")
                    {
                        lbltitulo.Text = "SOLICITUD"; 
                        estadoControl(true);
                        btnGrabar.Visible = false; 
                    }
                    else
                    {
                        if (hdnAccion.Value == "N")
                        { lbltitulo.Text = "REGISTRAR SOLICITUD"; }
                        if (hdnAccion.Value == "M")
                        { lbltitulo.Text = "MODIFICAR SOLICITUD"; }
                        
                      estadoControl(false);
                      btnGrabar.Visible = true; 
                    }

                    if (hdnAccion.Value == "E")
                    {
                        lbltitulo.Text = "SOLICITUD A ELIMINAR"; 
                        estadoControl(true);
                        btnGrabar.Visible = true;
                    }
                }

                if (hdnCodSol.Value == "")
                {
                    //Response.Redirect("actualizarsol.aspx");
                }
                else
                {
                    mostrarSolicitud(Int64.Parse(hdnCodSol.Value));
                   
                }

                if (hdnCodContac.Value == "")
                {
                    //Response.Redirect("actualizarsol.aspx");
                }
             
                else
                {
                    mostrarContacto(Int64.Parse(hdnCodContac.Value));
                    //if (strFlag == "2")
                    //{
                    //    this.hdnFlag.Value = "2"; //Modificar
                    //    mostrarData();
                    //}
                    //else
                    //{
                    //    Response.Redirect("listaCategorias.aspx");
                    //}
                   
                }
            }
            txtTelefono.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtCelular.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            //txtEdadN.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            //txtEdadDatos.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtTelefonoTi.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            //txtTelefonoCony.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");


            txtCtasBancarias.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtAcciones.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtInmuebles.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtVehiculos.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtHipotecas.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtCreditos.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtPrestamos.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtCtasPorPagar.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtOtros1.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtOtros2.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
            txtSueldoTi.Attributes.Add("onKeypress", "if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;");
        }

        private void mostrarSolicitud(Int64 intCodSolicitud)
        {
            //'List<EnSolicitud> ListarBusquedaxCandidatoxSolicitud(string strNumSolicitud, Int64 CodCandidato)
            NeSolicitud objNeSolicitud = new NeSolicitud();
            List<EnSolicitud> lst = objNeSolicitud.ListarSolicitud(intCodSolicitud);
            txtcodigosol.Text = lst[0].SolCodigo.Trim();
            txtfechasol.Text = lst[0].SolFecha.ToString().Trim();
            txtresumen.Text = lst[0].Solresumen.Trim();
            txtDescripcionSol.Text = lst[0].SolDescripcion.Trim();
            NeReferenciaLaboral objNeReferenciaLaboral = new NeReferenciaLaboral();

            List<EnReferenciaLaboral> lstB = objNeReferenciaLaboral.ListarReferenciaLaboral(intCodSolicitud);
            if (lstB.Count>0 )
            {
                txtEmpresaTi.Text = lstB[0].EmpresaTi.Trim();
                txtCargoTi.Text = lstB[0].CargoTi.Trim();
                txtTiempoServTi.Text = lstB[0].FechaInicio.ToShortDateString();
                txtFechaFin.Text = lstB[0].FechaFin.ToShortDateString();
                txtSueldoTi.Text = lstB[0].SueldoTi.Trim();
                txtDireccionTi.Text = lstB[0].DireccionTi.Trim();
                txtTelefonoTi.Text = lstB[0].TelefonoTi.Trim();
                txtEmailTi.Text = lstB[0].EmailTi.Trim();
                hdnRefLaboral.Value = lstB[0].FQ_ReferenciaLaboral_ID.ToString().Trim();
            }
           

            NeReferenciaBancaria objReferenciaBancaria = new NeReferenciaBancaria();
            List<EnReferenciaBancaria> lstC = objReferenciaBancaria.ListarReferenciaBancaria(intCodSolicitud);
           
                if (lstC.Count==1)
                {
                    txtBanco1.Text = lstC[0].Banco1.Trim();
                    txtSucursal1.Text = lstC[0].Sucursal1.Trim();
                    txtSectorista1.Text = lstC[0].Sectorista1.Trim();
                    txtCuenta1.Text = lstC[0].Cuenta1.Trim();
                    hdnRefBancaria1.Value = lstC[0].FQ_ReferenciaBancaria_ID.ToString().Trim();
                }
                if (lstC.Count == 2)
                {
                    txtBanco1.Text = lstC[0].Banco1.Trim();
                    txtSucursal1.Text = lstC[0].Sucursal1.Trim();
                    txtSectorista1.Text = lstC[0].Sectorista1.Trim();
                    txtCuenta1.Text = lstC[0].Cuenta1.Trim();
                    hdnRefBancaria1.Value = lstC[0].FQ_ReferenciaBancaria_ID.ToString().Trim();

                    if (lstC[1].Banco1.Trim()=="")
                    {
                        txtBanco2.ReadOnly=true;
                        txtSucursal2.ReadOnly = true;
                        txtSectorista2.ReadOnly = true;
                        txtCuenta2.ReadOnly = true;
                        hdnRefBancaria2.Value = "0";
                    }
                    else
                    {
                        txtBanco2.Text = lstC[1].Banco1.Trim();
                        txtSucursal2.Text = lstC[1].Sucursal1.Trim();
                        txtSectorista2.Text = lstC[1].Sectorista1.Trim();
                        txtCuenta2.Text = lstC[1].Cuenta1.Trim();
                        hdnRefBancaria2.Value = lstC[1].FQ_ReferenciaBancaria_ID.ToString().Trim();
                    }
                    
                }
                NeInformacionPatrimonial objInformacionPatrimonial = new NeInformacionPatrimonial();
                List<EnInformacionPatrimonial> lstD = objInformacionPatrimonial.ListarInformacionPatrimonialPos(intCodSolicitud);
              
            
                 if (lstD.Count>0 )
                {
                    txtCtasBancarias.Text = lstD[0].InfPatCuenta.Trim();
                    txtAcciones.Text = lstD[0].InfPatAcciones.Trim();
                    txtInmuebles.Text = lstD[0].InfPatInmuebles.Trim();
                    txtVehiculos.Text = lstD[0].InfPatVehiculos.Trim();
                    txtOtros1.Text = lstD[0].InfPatOtros1.Trim();
                    hdnInfPatPos.Value = lstD[0].FQ_InformacionPatrimonialPos_ID.ToString().Trim();
                }
                 List<EnInformacionPatrimonial> lstE = objInformacionPatrimonial.ListarInformacionPatrimonialNeg(intCodSolicitud);

                 if (lstE.Count > 0)
                 {
                     txtHipotecas.Text = lstE[0].InfPatHipotecas.Trim();
                     txtCreditos.Text = lstE[0].InfPatCredito.Trim();
                     txtPrestamos.Text = lstE[0].InfPatPrestamos.Trim();
                     txtCtasPorPagar.Text = lstE[0].InfPatCuentaPagar.Trim();
                     txtOtros2.Text = lstE[0].InfPatOtros2.Trim();
                     hdnInfPatNeg.Value = lstE[0].FQ_InformacionPatrimonialNeg_ID.ToString().Trim();
                 }
                 NeReferenciaComercial objReferenciaComercial = new NeReferenciaComercial();
                 List<EnReferenciaComercial> lstCom = objReferenciaComercial.ListarReferenciaComercial(intCodSolicitud);
                 if (lstCom.Count==1)
                 {
                     if (lstCom[0].RefEmpresa1.Trim()=="")
                     {
                         txtEmpresa1.ReadOnly = true;
                         txtDireccion1.ReadOnly = true;
                         hdnRefCom1.Value = "0";
                     }
                     else
                     {
                         txtEmpresa1.Text = lstCom[0].RefEmpresa1.Trim();
                         txtDireccion1.Text = lstCom[0].RefDireccion1.Trim();
                         hdnRefCom1.Value = lstCom[0].FQ_ReferenciaComercial_ID.ToString().Trim(); 
                     }
                     
                 }
                 if (lstCom.Count == 2)
                 {
                     //if (lstCom[0].RefEmpresa1.Trim() == "")
                     //{

                     //}
                     //else
                     //{

                     //}
                     txtEmpresa1.Text = lstCom[0].RefEmpresa1.Trim();
                     txtDireccion1.Text = lstCom[0].RefDireccion1.Trim();
                     hdnRefCom1.Value = lstCom[0].FQ_ReferenciaComercial_ID.ToString().Trim(); 

                     txtEmpresa2.Text = lstCom[1].RefEmpresa1.Trim();
                     txtDireccion2.Text = lstCom[1].RefDireccion1.Trim();
                     hdnRefCom2.Value = lstCom[1].FQ_ReferenciaComercial_ID.ToString().Trim(); 
                 }
                 if (lstCom.Count == 3)
                 {
                     if (lstCom[0].RefEmpresa1.Trim() == "")
                     {

                     }
                     else
                     {

                     }

                     txtEmpresa1.Text = lstCom[0].RefEmpresa1.Trim();
                     txtDireccion1.Text = lstCom[0].RefDireccion1.Trim();
                     hdnRefCom1.Value = lstCom[0].FQ_ReferenciaComercial_ID.ToString().Trim(); 

                     txtEmpresa2.Text = lstCom[1].RefEmpresa1.Trim();
                     txtDireccion2.Text = lstCom[1].RefDireccion1.Trim();
                     hdnRefCom2.Value = lstCom[1].FQ_ReferenciaComercial_ID.ToString().Trim(); 

                     txtEmpresa3.Text = lstCom[2].RefEmpresa1.Trim();
                     txtDireccion3.Text = lstCom[2].RefDireccion1.Trim();
                     hdnRefCom3.Value = lstCom[2].FQ_ReferenciaComercial_ID.ToString().Trim(); 
                 }
        } 

        private void mostrarContacto(Int64 intCodContacto)
        {
            NeCandidato objNeCandidato = new NeCandidato();
           List<EnCandidato>lst = objNeCandidato.ListarBusquedaxCandidato("0","0",intCodContacto,4);
           txtNombre.Text = lst[0].nombre.Trim();
          // txtEdadN.Text = lst[0].nombre.Trim();
           txtDomicilio.Text = lst[0].direccion.Trim();
           //txtNacionalidad.Text = lst[0].nombre.Trim();
           txtPasaporte.Text = lst[0].numeroDocumento;
           ddlTipo.SelectedValue = lst[0].tipoDocumento;
           txtTelefono.Text = lst[0].telefonoFijo.Trim();
           txtEmail.Text = lst[0].correoElectronico.Trim();
          

        }
        private void mostrarTipoAnexo()
        {
            NeTipoAnexo objTipoAnexo = new NeTipoAnexo();
            List<EnTipoAnexo> lst = objTipoAnexo.ListarTipoAnexo();
            ddltipo1.DataValueField = "FQ_TipoAnexo_ID";
            ddltipo1.DataTextField = "Nombre";
            ddltipo1.DataSource = lst;
            ddltipo1.DataBind();

            ddltipo2.DataValueField = "FQ_TipoAnexo_ID";
            ddltipo2.DataTextField = "Nombre";
            ddltipo2.DataSource = lst;
            ddltipo2.DataBind();

            ddltipo3.DataValueField = "FQ_TipoAnexo_ID";
            ddltipo3.DataTextField = "Nombre";
            ddltipo3.DataSource = lst;
            ddltipo3.DataBind();


        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                EnSolicitud objSolicitud = new EnSolicitud();
                objSolicitud.SolNombre = txtNombre.Text.Trim();
                //objSolicitud.SolEdad = txtEdadN.Text.Trim();
                objSolicitud.SolDomicilio = txtDomicilio.Text.Trim();
                objSolicitud.SolNacionalidad = txtNacionalidad.Text.Trim();
                objSolicitud.SolPasaporte = txtPasaporte.Text.Trim();
                objSolicitud.SolTelefono = txtTelefono.Text.Trim();
                objSolicitud.SolEmail = txtEmail.Text.Trim();

                objSolicitud.SolCodCandidato = Int64.Parse(Request.QueryString["id"]);

                if (hdnAccion.Value == "N")
                {
                    objSolicitud.SolCodSolicitud = 0;
                }
                if (hdnAccion.Value == "M")
                {
                    objSolicitud.SolCodSolicitud = Int64.Parse(hdnCodSol.Value);
                }

                objSolicitud.SolCodigo = txtcodigosol.Text.Trim();
                objSolicitud.Solresumen = txtresumen.Text.Trim();
                objSolicitud.SolDescripcion = txtDescripcionSol.Text.Trim();
                objSolicitud.SolEstados = "PENDIENTE";

                List<EnReferenciaLaboral> lstReferenciaLaboral = new List<EnReferenciaLaboral>();
                EnReferenciaLaboral objEnReferenciaLaboral = new EnReferenciaLaboral();

                if (hdnAccion.Value == "N")
                {
                    objEnReferenciaLaboral.FQ_ReferenciaLaboral_ID = 0;
                }
                if (hdnAccion.Value == "M")
                {
                    objEnReferenciaLaboral.FQ_ReferenciaLaboral_ID = Int64.Parse(hdnRefLaboral.Value);
                }
                objEnReferenciaLaboral.EmpresaTi = txtEmpresaTi.Text.Trim();
                objEnReferenciaLaboral.CargoTi = txtCargoTi.Text.Trim();
                objEnReferenciaLaboral.FechaInicio = DateTime.Parse(txtTiempoServTi.Text.Trim());
                objEnReferenciaLaboral.FechaFin = DateTime.Parse(txtFechaFin.Text.Trim());

                objEnReferenciaLaboral.SueldoTi = txtSueldoTi.Text.Trim();
                objEnReferenciaLaboral.DireccionTi = txtDireccionTi.Text.Trim();
                objEnReferenciaLaboral.TelefonoTi = txtTelefonoTi.Text.Trim();
                objEnReferenciaLaboral.EmailTi = txtEmailTi.Text.Trim();
                //lstReferenciaLaboral.Add(objEnReferenciaLaboral);
                //EnReferenciaLaboral objEnReferenciaLaboralB = new EnReferenciaLaboral();
                //objEnReferenciaLaboralB.EmpresaCony = txtEmpresaCony.Text.Trim();
                //objEnReferenciaLaboralB.CargoCony = txtCargoCony.Text.Trim();
                //objEnReferenciaLaboralB.TiempoCony = txtTiempoServCony.Text.Trim();
                //objEnReferenciaLaboralB.SueldoCony = txtSueldoCony.Text.Trim();
                //objEnReferenciaLaboralB.DireccionCony = txtDireccionCony.Text.Trim();
                //objEnReferenciaLaboralB.TelefonoCony = txtTelefonoCony.Text.Trim();
                //objEnReferenciaLaboralB.EmailCony = txtEmailCony.Text.Trim();
                //lstReferenciaLaboral.Add(objEnReferenciaLaboralB);

                List<EnReferenciaBancaria> lstReferenciaBancaria = new List<EnReferenciaBancaria>();

                EnReferenciaBancaria objEnReferenciaBancaria = new EnReferenciaBancaria();

                if (hdnAccion.Value == "N")
                {
                    objEnReferenciaBancaria.FQ_ReferenciaBancaria_ID = 0;
                }
                if (hdnAccion.Value == "M")
                {
                    objEnReferenciaBancaria.FQ_ReferenciaBancaria_ID = Int64.Parse(hdnRefBancaria1.Value);
                }
                objEnReferenciaBancaria.Banco1 = txtBanco1.Text.Trim();
                objEnReferenciaBancaria.Sucursal1 = txtSucursal1.Text.Trim();
                objEnReferenciaBancaria.Sectorista1 = txtSectorista1.Text.Trim();
                objEnReferenciaBancaria.Cuenta1 = txtCuenta1.Text.Trim();
                lstReferenciaBancaria.Add(objEnReferenciaBancaria);

                EnReferenciaBancaria objEnReferenciaBancariaB = new EnReferenciaBancaria();
                objEnReferenciaBancariaB.Banco1 = txtBanco2.Text.Trim();
                objEnReferenciaBancariaB.Sucursal1 = txtSucursal2.Text.Trim();
                objEnReferenciaBancariaB.Sectorista1 = txtSectorista2.Text.Trim();
                objEnReferenciaBancariaB.Cuenta1 = txtCuenta2.Text.Trim();

                if (hdnAccion.Value == "N")
                {
                    objEnReferenciaBancariaB.FQ_ReferenciaBancaria_ID = 0;
                }
                if (hdnAccion.Value == "M")
                {
                    if (txtBanco2.Text != "")
                    {
                        objEnReferenciaBancariaB.FQ_ReferenciaBancaria_ID = Int64.Parse(hdnRefBancaria2.Value);
                    }
                    else
                    {
                        objEnReferenciaBancariaB.FQ_ReferenciaBancaria_ID = 0;
                    }
                }
                lstReferenciaBancaria.Add(objEnReferenciaBancariaB);

                EnInformacionPatrimonial objInformacionPatrimonial = new EnInformacionPatrimonial();
                objInformacionPatrimonial.InfPatCuenta = Funciones.ObtenerCero(txtCtasBancarias.Text.Trim());
                objInformacionPatrimonial.InfPatAcciones = Funciones.ObtenerCero(txtAcciones.Text.Trim());
                objInformacionPatrimonial.InfPatInmuebles = Funciones.ObtenerCero(txtInmuebles.Text.Trim());
                objInformacionPatrimonial.InfPatVehiculos = Funciones.ObtenerCero(txtVehiculos.Text.Trim());
                objInformacionPatrimonial.InfPatHipotecas = Funciones.ObtenerCero(txtHipotecas.Text.Trim());
                objInformacionPatrimonial.InfPatCredito = Funciones.ObtenerCero(txtCreditos.Text.Trim());
                objInformacionPatrimonial.InfPatPrestamos = Funciones.ObtenerCero(txtPrestamos.Text.Trim());
                objInformacionPatrimonial.InfPatCuentaPagar = Funciones.ObtenerCero(txtCtasPorPagar.Text.Trim());
                objInformacionPatrimonial.InfPatOtros1 = Funciones.ObtenerCero(txtOtros1.Text.Trim());
                objInformacionPatrimonial.InfPatOtros2 = Funciones.ObtenerCero(txtOtros2.Text.Trim());

                if (hdnAccion.Value == "N")
                {
                    objInformacionPatrimonial.FQ_InformacionPatrimonialNeg_ID = 0;
                    objInformacionPatrimonial.FQ_InformacionPatrimonialPos_ID = 0;
                }
                if (hdnAccion.Value == "M")
                {
                    objInformacionPatrimonial.FQ_InformacionPatrimonialNeg_ID = Int64.Parse(hdnInfPatNeg.Value);
                    objInformacionPatrimonial.FQ_InformacionPatrimonialPos_ID = Int64.Parse(hdnInfPatPos.Value);
                }



                List<EnReferenciaComercial> lstReferenciaComercial = new List<EnReferenciaComercial>();
                EnReferenciaComercial objReferenciaComercialA = new EnReferenciaComercial();
                objReferenciaComercialA.RefEmpresa1 = txtEmpresa1.Text.Trim();
                objReferenciaComercialA.RefDireccion1 = txtDireccion1.Text.Trim();
                if (hdnAccion.Value == "N")
                {
                    objReferenciaComercialA.FQ_ReferenciaComercial_ID = 0;
                }
                if (hdnAccion.Value == "M")
                {
                   
                    if (txtEmpresa1.Text != "")
                    {
                        objReferenciaComercialA.FQ_ReferenciaComercial_ID = Int64.Parse(hdnRefCom1.Value);
                    }
                    else
                    {
                        objReferenciaComercialA.FQ_ReferenciaComercial_ID = 0;
                    }
                }
                lstReferenciaComercial.Add(objReferenciaComercialA);

                EnReferenciaComercial objReferenciaComercialB = new EnReferenciaComercial();
                objReferenciaComercialB.RefEmpresa1 = txtEmpresa2.Text.Trim();
                objReferenciaComercialB.RefDireccion1 = txtDireccion2.Text.Trim();
                if (hdnAccion.Value == "N")
                {
                    objReferenciaComercialB.FQ_ReferenciaComercial_ID = 0;
                }
                if (hdnAccion.Value == "M")
                {
                    if (txtEmpresa2.Text != "")
                    {
                        objReferenciaComercialB.FQ_ReferenciaComercial_ID = Int64.Parse(hdnRefCom2.Value);
                    }
                    else
                    {
                        objReferenciaComercialB.FQ_ReferenciaComercial_ID = 0;
                    }

                }
                lstReferenciaComercial.Add(objReferenciaComercialB);

                EnReferenciaComercial objReferenciaComercialC = new EnReferenciaComercial();
                objReferenciaComercialC.RefEmpresa1 = txtEmpresa3.Text.Trim();
                objReferenciaComercialC.RefDireccion1 = txtDireccion3.Text.Trim();
                if (hdnAccion.Value == "N")
                {
                    objReferenciaComercialC.FQ_ReferenciaComercial_ID = 0;
                }
                if (hdnAccion.Value == "M")
                {
                    if (txtEmpresa3.Text != "")
                    {
                        objReferenciaComercialC.FQ_ReferenciaComercial_ID = Int64.Parse(hdnRefCom3.Value);
                    }
                    else
                    {
                        objReferenciaComercialC.FQ_ReferenciaComercial_ID = 0;
                    }
                }
                lstReferenciaComercial.Add(objReferenciaComercialC);




                if (validar(objSolicitud, objEnReferenciaLaboral, lstReferenciaBancaria, objInformacionPatrimonial, objReferenciaComercialA) == true)
                {
                    NeSolicitud objNeSolicitud = new NeSolicitud();

                    if (hdnAccion.Value == "N")
                    {
                        objNeSolicitud.MantenimientoSolicitud(objSolicitud, objEnReferenciaLaboral, lstReferenciaBancaria, objInformacionPatrimonial, lstReferenciaComercial, 1);
                        MsgBox1.ShowMessage("Registro realizado"); 
                    }
                    if (hdnAccion.Value == "M")
                    {
                        objNeSolicitud.MantenimientoSolicitud(objSolicitud, objEnReferenciaLaboral, lstReferenciaBancaria, objInformacionPatrimonial, lstReferenciaComercial, 2);
                        MsgBox1.ShowMessage("Modificacion realizada."); 
                    }

                   
                    limpiar();
                   
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error " + ex.Message + "Metodo :Grabar");
 
            }
       
        }


        private void limpiar()
        {
           
            txtNombre.Text="";
            txtDomicilio.Text = "";
            txtNacionalidad.Text = "";
            txtPasaporte.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtEmpresaTi.Text = "";
            txtCargoTi.Text = "";
            txtTiempoServTi.Text = "";
            txtFechaFin.Text = "";

            txtSueldoTi.Text = "";
            txtDireccionTi.Text = "";
            txtTelefonoTi.Text = "";
            txtEmailTi.Text = "";
            txtBanco1.Text = "";
            txtSucursal1.Text = "";
            txtSectorista1.Text = "";
            txtCuenta1.Text = "";

            txtBanco2.Text = "";
            txtSucursal2.Text = "";
            txtSectorista2.Text = "";
            txtCuenta2.Text = "";

            txtCtasBancarias.Text = "";
            txtAcciones.Text = "";
            txtInmuebles.Text = "";
            txtVehiculos.Text = "";
            txtHipotecas.Text= "";
            txtCreditos.Text = "";
            txtPrestamos.Text = "";
            txtCtasPorPagar.Text = "";
            txtOtros1.Text = "";
            txtOtros2.Text = "";

            txtEmpresa1.Text = "";
            txtDireccion1.Text= "";
            txtEmpresa2.Text = "";
            txtDireccion2.Text = "";
            txtEmpresa3.Text = "";
            txtDireccion3.Text = "";

        }


        private void estadoControl(bool valor)
        {

            txtNombre.ReadOnly = valor;
            txtDomicilio.ReadOnly = valor;
            txtNacionalidad.ReadOnly = valor;
            txtPasaporte.ReadOnly = valor;
            txtTelefono.ReadOnly = valor;
            txtEmail.ReadOnly = valor;
            txtEmpresaTi.ReadOnly = valor;
            txtCargoTi.ReadOnly = valor;
            txtTiempoServTi.ReadOnly = valor;
            txtFechaFin.ReadOnly = valor;

            txtSueldoTi.ReadOnly = valor;
            txtDireccionTi.ReadOnly = valor;
            txtTelefonoTi.ReadOnly = valor;
            txtEmailTi.ReadOnly = valor;
            txtBanco1.ReadOnly = valor;
            txtSucursal1.ReadOnly = valor;
            txtSectorista1.ReadOnly = valor;
            txtCuenta1.ReadOnly = valor;

            txtBanco2.ReadOnly = valor;
            txtSucursal2.ReadOnly = valor;
            txtSectorista2.ReadOnly = valor;
            txtCuenta2.ReadOnly = valor;

            txtCtasBancarias.ReadOnly = valor;
            txtAcciones.ReadOnly = valor;
            txtInmuebles.ReadOnly = valor;
            txtVehiculos.ReadOnly = valor;
            txtHipotecas.ReadOnly = valor;
            txtCreditos.ReadOnly = valor;
            txtPrestamos.ReadOnly = valor;
            txtCtasPorPagar.ReadOnly = valor;
            txtOtros1.ReadOnly = valor;
            txtOtros2.ReadOnly = valor;

            txtEmpresa1.ReadOnly = valor;
            txtDireccion1.ReadOnly = valor;
            txtEmpresa2.ReadOnly = valor;
            txtDireccion2.ReadOnly = valor;
            txtEmpresa3.ReadOnly = valor;
            txtDireccion3.ReadOnly = valor;
            txtresumen.ReadOnly = valor;
            txtDescripcionSol.ReadOnly = valor;
        }


        public bool validar(EnSolicitud obj1, EnReferenciaLaboral lstEnReferenciaLaboral, List<EnReferenciaBancaria> lstReferenciaBancaria, EnInformacionPatrimonial obj4, EnReferenciaComercial obj5)
        {
            bool blnRpta = true;
            if (obj4.InfPatCuenta == "0" && obj4.InfPatAcciones == "0" && obj4.InfPatInmuebles == "0" && obj4.InfPatVehiculos == "0" && obj4.InfPatHipotecas == "0" && obj4.InfPatCredito == "0" && obj4.InfPatPrestamos == "0" && obj4.InfPatCuentaPagar == "0" && obj4.InfPatOtros1 == "0" && obj4.InfPatOtros2 == "0")
	        {
                this.MsgBox1.ShowMessage("Ud. Debe ingresar por lo menos una Informacion Patrimonial.");
                blnRpta = false;
            }
            
            
            return blnRpta;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            if (hdnAccion.Value == "N")
            { Response.Redirect("consultasol.aspx?id=" + hdnCodContac.Value); }
            if (hdnAccion.Value == "M")
            { Response.Redirect("consultasol.aspx?id=" + hdnCodContac.Value); }
            if (hdnAccion.Value == "V")
            { Response.Redirect("actualizarsol.aspx"); }
             
        }
    }
}