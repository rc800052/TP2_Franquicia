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
    public class NeReferenciaLaboral
    {
        public List<EnReferenciaLaboral> ListarReferenciaLaboral(Int64 CodSolicitud)
        {
            DaReferenciaLaboral objReferenciaLaboral = new DaReferenciaLaboral();
            return objReferenciaLaboral.ListarReferenciaLaboral(CodSolicitud);
        }
         public Int64 MantenimientoReferenciaLaboral(EnReferenciaLaboral objEnRefLaboral, Int16 intControlador)
        {
            Int64 intCodReferenciaLaboral;
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                DaReferenciaLaboral objReferenciaLaboral = new DaReferenciaLaboral();
                intCodReferenciaLaboral=objReferenciaLaboral.MantenimientoReferenciaLaboral(objEnRefLaboral,intControlador);
              }
            catch (Exception ex)
            {
                intCodReferenciaLaboral = 0;
                logger.Error("Error " + ex.Message + "Metodo :MantenimientoReferenciaLaboral  Flag :" + intControlador.ToString());

            }
            return intCodReferenciaLaboral;
        }

    }
}
