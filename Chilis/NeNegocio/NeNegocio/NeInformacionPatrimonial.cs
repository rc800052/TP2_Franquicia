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
    public class NeInformacionPatrimonial
    {
        public List<EnInformacionPatrimonial> ListarInformacionPatrimonialNeg(Int64 CodSolicitud)
        {
            DaInformacionPatrimonial objInformacionPatrimonial = new DaInformacionPatrimonial();
            return objInformacionPatrimonial.ListarInformacionPatrimonialNeg(CodSolicitud);
       }

        public List<EnInformacionPatrimonial> ListarInformacionPatrimonialPos(Int64 CodSolicitud)
        {
            DaInformacionPatrimonial objInformacionPatrimonial = new DaInformacionPatrimonial();
            return objInformacionPatrimonial.ListarInformacionPatrimonialPos(CodSolicitud);
        }
        public Int64 MantenimientoInformacionPatrimonial(EnInformacionPatrimonial objEnInfPatrimonial, Int16 intControlador)
       {  
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
           Int64 intCodInformacionPatrimonialNeg;
           try
           { DaInformacionPatrimonial objInformacionPatrimonial = new DaInformacionPatrimonial();
            intCodInformacionPatrimonialNeg = objInformacionPatrimonial.MantenimientoInformacionPatrimonial(objEnInfPatrimonial, intControlador);
           }
           catch (Exception ex)
           {
               intCodInformacionPatrimonialNeg = 0;
               logger.Error("Error " + ex.Message + "Metodo :MantenimientoInformacionPatrimonial    Flag :" + intControlador.ToString());

           }
           return intCodInformacionPatrimonialNeg;
       }
         public Int64 MantenimientoInformacionPatrimonialPos(EnInformacionPatrimonial objEnInfPatrimonial, Int16 intControlador)
       {

           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           Int64 intCodInformacionPatrimonialPos;
           try
           {
               DaInformacionPatrimonial objInformacionPatrimonial = new DaInformacionPatrimonial();
               intCodInformacionPatrimonialPos = objInformacionPatrimonial.MantenimientoInformacionPatrimonialPos(objEnInfPatrimonial, intControlador);
           }
           catch (Exception ex)
           {
               intCodInformacionPatrimonialPos = 0;
               logger.Error("Error " + ex.Message + "Metodo :MantenimientoInformacionPatrimonialPos    Flag :" + intControlador.ToString());

           }
           return intCodInformacionPatrimonialPos;
       }
    }
}
