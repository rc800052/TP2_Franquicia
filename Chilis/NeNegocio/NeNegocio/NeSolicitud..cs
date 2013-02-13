using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnEntidad;
using DaDatos;
using Common;
using System.Transactions;
using log4net;
  
namespace NeNegocio
{
    public class NeSolicitud
    {
        public void MantenimientoSolicitud(EnSolicitud objEnSolicitud, EnReferenciaLaboral objEnReferenciaLaboral, List<EnReferenciaBancaria> lstReferenciaBancaria, EnInformacionPatrimonial objInformacionPatrimonial, List<EnReferenciaComercial> lstReferenciComercial, Int16 intControlador)
        {
            log4net.ILog logger=log4net.LogManager.GetLogger("File");
            
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    Int64 intCodSolicitud;
                   
                    intCodSolicitud=(new DaSolicitud()).MantenimientoSolicitud(objEnSolicitud, intControlador);
                    if (intControlador==2)
                    {
                        intCodSolicitud = objEnSolicitud.SolCodSolicitud;
                    }
                    objEnReferenciaLaboral.SolCodSolicitud = intCodSolicitud;
                    
                     Int64 intLaboral;
                     intLaboral = (new NeReferenciaLaboral()).MantenimientoReferenciaLaboral(objEnReferenciaLaboral, intControlador);
                    
                    for (int i = 0; i < lstReferenciaBancaria.Count; i++)
                    {
                        EnReferenciaBancaria objEnReferenciaBancaria = new EnReferenciaBancaria();
                        objEnReferenciaBancaria.SolCodSolicitud = intCodSolicitud;
                        if (lstReferenciaBancaria[i].Banco1 == null)
                        {
                            break;
                        }
                        if (lstReferenciaBancaria[i].Banco1.Trim() == "")
                        {
                            break;
                        }
                        Int64 intBanco;
                        objEnReferenciaBancaria.Banco1 = lstReferenciaBancaria[i].Banco1;
                        objEnReferenciaBancaria.Sucursal1 = lstReferenciaBancaria[i].Sucursal1;
                        objEnReferenciaBancaria.Sectorista1 = lstReferenciaBancaria[i].Sectorista1;
                        objEnReferenciaBancaria.Cuenta1 = lstReferenciaBancaria[i].Cuenta1;
                        intBanco = (new NeReferenciaBancaria()).MantenimientoReferenciaBancaria(objEnReferenciaBancaria, intControlador);
                        objEnReferenciaBancaria = null;
                    }

                    Int64 intCodIng;
                    Int64 intCodPos;
                    
                    objInformacionPatrimonial.SolCodSolicitud = intCodSolicitud;
                    intCodIng = (new NeInformacionPatrimonial()).MantenimientoInformacionPatrimonial(objInformacionPatrimonial, intControlador);
                   
                    intCodPos = (new NeInformacionPatrimonial()).MantenimientoInformacionPatrimonialPos(objInformacionPatrimonial, intControlador);

                   
                    for (int i = 0; i < lstReferenciComercial.Count; i++)
                    {
                        EnReferenciaComercial objEnReferenciaComercial = new EnReferenciaComercial();
                        objEnReferenciaComercial.FQ_SOLICITUD_ID = intCodSolicitud;
                        if (lstReferenciComercial[i].RefEmpresa1==null)
                        {
                            break; 
                        }
                        if (lstReferenciComercial[i].RefEmpresa1.Trim()== "")
                        {
                            break;
                        }
                        objEnReferenciaComercial.RefDireccion1 = lstReferenciComercial[i].RefDireccion1.Trim();
                        objEnReferenciaComercial.RefEmpresa1 = lstReferenciComercial[i].RefEmpresa1.Trim();
                        intCodPos = (new NeReferenciaComercial()).MantenimientoReferenciaComercial(objEnReferenciaComercial, intControlador);

                    }

                    tx.Complete();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error " + ex.Message + "Metodo :MantenimientoSolicitud  " );
                //throw ex;
            }
        }

        public List<EnSolicitud> ListarBusquedaxCandidatoxSolicitud(string strNumSolicitud, Int64 CodCandidato)
       {
           DaSolicitud objdaSolicitud = new DaSolicitud();
           return objdaSolicitud.ListarBusquedaxCandidatoxSolicitud(strNumSolicitud,CodCandidato);

       }
         public List<EnSolicitud> ListarSolicitud(Int64 CodSolicitud)
        {
            DaSolicitud objdaSolicitud = new DaSolicitud();
            return objdaSolicitud.ListarSolicitud(CodSolicitud);
        }

         public void MantenimientoSolicitudEstado(Int64 intCodSolicitud, string strEstado)
         {
             log4net.ILog logger = log4net.LogManager.GetLogger("File");

             try
             {
                 using (TransactionScope tx = new TransactionScope())
                 {

                     intCodSolicitud = (new DaSolicitud()).MantenimientoSolicitudEstado(intCodSolicitud, strEstado);

                     tx.Complete();
                 }
             }
             catch (Exception ex)
             {
                 logger.Error("Error " + ex.Message + "Metodo :MantenimientoSolicitudEstado  CodSolicitud: " + intCodSolicitud.ToString() + "  Estado: " + strEstado);
                
             }
         }


         public Int16 ActualizarSolicitudEstado(Int64 intCodSolicitud, string strEstado)
         {
             log4net.ILog logger = log4net.LogManager.GetLogger("File");
             Int16 intRpta=1;
             try
             {
                 intCodSolicitud = (new DaSolicitud()).MantenimientoSolicitudEstado(intCodSolicitud, strEstado);
             }
             catch (Exception ex)
             {
                 intRpta = 0;
                 logger.Error("Error " + ex.Message + "Metodo :MantenimientoSolicitudEstado  CodSolicitud: " + intCodSolicitud.ToString() + "  Estado: " + strEstado);

             }
             return intRpta;
         }

         public List<EnSolicitud> ListarSolicitudxEntrevista(EnSolicitud obj1)
         {
             DaSolicitud objdaSolicitud = new DaSolicitud();
             return objdaSolicitud.ListarSolicitudxEntrevista(obj1);
         }

    }
}
