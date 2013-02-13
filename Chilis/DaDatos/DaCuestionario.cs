using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EnEntidad;
using System.Data;
using log4net;


namespace DaDatos
{
   public  class DaCuestionario
   {
       public void MantenimientoCuestionario(EnCuestionario objEnCuestionario, Int16 intControlador)
       {
          
           
               Database db = DatabaseFactory.CreateDatabase();
               SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_MantenimientoCuestionario");
               cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
               Helper.AddParam(ref cmd, "@valor", SqlDbType.VarChar, ParameterDirection.Input, objEnCuestionario.valor);
               Helper.AddParam(ref cmd, "@FQ_Balotario_ID", SqlDbType.Int, ParameterDirection.Input, objEnCuestionario.FQ_Balotario_ID);
               Helper.AddParam(ref cmd, "@FQ_Entrevista_ID", SqlDbType.Int, ParameterDirection.Input, objEnCuestionario.FQ_Entrevista_ID);
               Helper.AddParam(ref cmd, "@controlador", SqlDbType.Int, ParameterDirection.Input, intControlador);

               db.ExecuteNonQuery(cmd);

         

       }

     
    }
}
