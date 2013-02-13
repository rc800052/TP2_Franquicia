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
   public class NeCuestionario
    {
       public Int16 MantenimientoCuestionario(EnCuestionario objEnCuestionario, Int16 intControlador)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           Int16 intCod=1;
           try
           {
               DaCuestionario objDa = new DaCuestionario();
               objDa.MantenimientoCuestionario(objEnCuestionario, intControlador);
                                
           }
           catch (Exception ex)
           {
               intCod = 0;
               logger.Error("Error " + ex.Message + "Metodo :MantenimientoCuestionario  Controlador: " + intControlador.ToString());
               
           }
           return intCod;
       }

    }
}
