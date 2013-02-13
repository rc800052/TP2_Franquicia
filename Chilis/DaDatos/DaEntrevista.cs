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
    public class DaEntrevista
    {
        public Int64 MantenimientoEntrevista(EnEntrevista objEnEntrevista, Int16 intControlador)
        {
            //log4net.ILog logger = log4net.LogManager.GetLogger("File");
            Int64 intCodEntrevista;
           
                Database db = DatabaseFactory.CreateDatabase();
                SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_MantenimientoEntrevista");
                cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
                Helper.AddParam(ref cmd, "@fecha", SqlDbType.Date, ParameterDirection.Input, objEnEntrevista.fecha);
                Helper.AddParam(ref cmd, "@nombreEntrevistador", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnEntrevista.nombreEntrevistador);
                Helper.AddParam(ref cmd, "@comentario", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnEntrevista.comentario);
                Helper.AddParam(ref cmd, "@FQ_Entrevista_ID", SqlDbType.Int, ParameterDirection.Input, objEnEntrevista.FQ_Entrevista_ID);
                Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, objEnEntrevista.FQ_Solicitud_ID);
                Helper.AddParam(ref cmd, "@controlador", SqlDbType.Int, ParameterDirection.Input, intControlador);

                cmd.Parameters.Add("@num", SqlDbType.Int).Direction = ParameterDirection.Output;
                db.ExecuteNonQuery(cmd);

                intCodEntrevista = Convert.ToInt64(cmd.Parameters["@num"].Value);

           
            return intCodEntrevista;
        }

    }
}
