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
    public class NeEntrevista
    {
        public Int16 MantenimientoEntrevista(EnEntrevista objEntrevista, List<EnCuestionario> lstCuestionario, string strEstado,Int16 intControlador)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            Int16 intRpta = 0;
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    Int64 intCodEntrevista;
                    
                    intCodEntrevista = (new DaEntrevista()).MantenimientoEntrevista(objEntrevista, intControlador);
                   

                    for (int i = 0; i < lstCuestionario.Count; i++)
                    {
                        EnCuestionario objEnCuestionario = new EnCuestionario();
                        objEnCuestionario.FQ_Balotario_ID = lstCuestionario[i].FQ_Balotario_ID;
                        objEnCuestionario.valor = lstCuestionario[i].valor;
                        objEnCuestionario.FQ_Entrevista_ID = intCodEntrevista;
                        NeCuestionario objNe = new NeCuestionario();
                        objNe.MantenimientoCuestionario(objEnCuestionario,intControlador);
                        objEnCuestionario = null;
                    }

                    NeSolicitud objNesolicitud = new NeSolicitud();
                    intRpta = objNesolicitud.ActualizarSolicitudEstado(objEntrevista.FQ_Solicitud_ID, strEstado); 
                    tx.Complete();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error " + ex.Message + "Metodo :MantenimientoEntrevista    Controlador :" + intControlador.ToString() );
               
            }
            return intRpta;
        }

        public void Mensaje(string strCodSolicitud, string strFlag)
        {
            string strEstado="";
             string strCorreo;
            EnSolicitud objEnSolicitud = new EnSolicitud();
            objEnSolicitud.SolCodigo = strCodSolicitud;
            objEnSolicitud.SolNombre = "0";
            if (strFlag == "1")
            {
                strEstado = "APROBADA";
                objEnSolicitud.SolEstados = "APROBADA";

            }
            if (strFlag == "2")
            {
                strEstado = "RECHAZADA";
                objEnSolicitud.SolEstados = "RECHAZADA";

            }

            NeSolicitud objNeSolicitud = new NeSolicitud();

            List<EnSolicitud> lst = objNeSolicitud.ListarSolicitudxEntrevista(objEnSolicitud);
            strCorreo = lst[0].SolEmail.Trim();
            
            StringBuilder p_email = new StringBuilder();
            p_email.Append("<Font face='arial' size='2'><strong>Su solicitud ha sido " + strEstado + " </strong><blockquote>");
            p_email.Append("<LI style='margin-left:15px;' type=square>" + String.Format("Fecha de Solicitud :{0}", lst[0].SolStrFecha));
            p_email.Append("<LI style='margin-left:15px;' type=square>" + String.Format("Nro Solicitud :{0}", lst[0].SolCodigo.Trim()));
            p_email.Append("<LI style='margin-left:15px;' type=square>" + String.Format("Candidato :{0}", lst[0].SolNombre.Trim()));
            p_email.Append("<LI style='margin-left:15px;' type=square>" + String.Format("Entrevistador :{0}", "Ing. Sandra Vega"));
            p_email.Append("<LI style='margin-left:15px;' type=square>" + String.Format("Fecha de Entrevista :{0}", lst[0].SolStrFechaEntrevista)+"</LI>");

            p_email.Append("<p align='justify'>" + lst[0].SolDescripcion.Trim() + "</p></blockquote><br></Font>");
                      
            Email objEmail = new Email();
            objEmail.EnviarEmail("Notificacion", p_email.ToString(), strCorreo);
            
        }

    }
}
