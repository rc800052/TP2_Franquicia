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
   public class NeReferenciaBancaria
    {
       public List<EnReferenciaBancaria> ListarReferenciaBancaria(Int64 CodSolicitud)
       {
           DaReferenciaBancaria objReferenciaBancaria = new DaReferenciaBancaria();
           return objReferenciaBancaria.ListarReferenciaBancaria(CodSolicitud);
       }
        public Int64 MantenimientoReferenciaBancaria(EnReferenciaBancaria objEnRefBancaria, Int16 intControlador)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            Int64 intCodReferenciaBancaria;
            try
            {DaReferenciaBancaria objReferenciaBancaria = new DaReferenciaBancaria();
                intCodReferenciaBancaria=objReferenciaBancaria.MantenimientoReferenciaBancaria(objEnRefBancaria,intControlador);

                 }
            catch (Exception ex)
            {
                intCodReferenciaBancaria = 0;
                logger.Error("Error " + ex.Message + "Metodo :MantenimientoReferenciaBancaria  Flag :" + intControlador.ToString());

            }

           return intCodReferenciaBancaria;
    }
    }
}
