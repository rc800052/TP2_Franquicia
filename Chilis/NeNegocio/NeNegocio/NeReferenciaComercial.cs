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
    public class NeReferenciaComercial
    {
        public List<EnReferenciaComercial> ListarReferenciaComercial(Int64 CodSolicitud)
        {
            DaReferenciaComercial objReferenciaComercial = new DaReferenciaComercial();
            return objReferenciaComercial.ListarReferenciaComercial(CodSolicitud);
        }
         public Int64 MantenimientoReferenciaComercial(EnReferenciaComercial objEnRefComercial, Int16 intControlador)
        {
            Int64 intCodReferenciaComercial;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            
            try
            {
                DaReferenciaComercial objReferenciaComercial = new DaReferenciaComercial();
                intCodReferenciaComercial=objReferenciaComercial.MantenimientoReferenciaComercial(objEnRefComercial,intControlador);
            }
           catch (Exception ex)
           {
               intCodReferenciaComercial = 0;
               logger.Error("Error " + ex.Message + "Metodo :MantenimientoReferenciaComercial Controlador: " + intControlador.ToString());
           }
            return intCodReferenciaComercial;
       
         }
    }
}
