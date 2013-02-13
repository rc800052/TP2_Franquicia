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
   public class DaReferenciaComercial
    {
       public Int64 MantenimientoReferenciaComercial(EnReferenciaComercial objEnRefComercial, Int16 intControlador)
       {
          
           Int64 intCodReferenciaComercial;
          
               Database db = DatabaseFactory.CreateDatabase();
               SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_MantenimientoReferenciaComercial");
               cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
               Helper.AddParam(ref cmd, "@nombreEmpresa", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefComercial.RefEmpresa1);
               Helper.AddParam(ref cmd, "@direccion", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefComercial.RefDireccion1);
               Helper.AddParam(ref cmd, "@contacto", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefComercial.RefContacto);
               Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, objEnRefComercial.FQ_SOLICITUD_ID);
               Helper.AddParam(ref cmd, "@FQ_ReferenciaComercial_ID", SqlDbType.Int, ParameterDirection.Input, objEnRefComercial.FQ_ReferenciaComercial_ID);
               Helper.AddParam(ref cmd, "@controlador", SqlDbType.Int, ParameterDirection.Input, intControlador);
               cmd.Parameters.Add("@num", SqlDbType.Int).Direction = ParameterDirection.Output;
               db.ExecuteNonQuery(cmd);
               //cmd.Parameters.Clear();

               intCodReferenciaComercial = Convert.ToInt64(cmd.Parameters["@num"].Value);

          
           return intCodReferenciaComercial;
       }

       public List<EnReferenciaComercial> ListarReferenciaComercial(Int64 CodSolicitud)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           Database db = DatabaseFactory.CreateDatabase();
           SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_ListarRefComercial");
           cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
           Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, CodSolicitud);

           List<EnReferenciaComercial> lstEnReferenciaComercial = new List<EnReferenciaComercial>();
           IDataReader dr = null;

           try
           {

               dr = db.ExecuteReader(cmd);
               while (dr.Read())
               {
                   lstEnReferenciaComercial.Add(new EnReferenciaComercial()
                   {
                       RefEmpresa1 = dr.GetString(dr.GetOrdinal("nombreEmpresa")),
                       RefDireccion1 = dr.GetString(dr.GetOrdinal("direccion")),
                       RefContacto = dr.GetString(dr.GetOrdinal("contacto")),
                       FQ_ReferenciaComercial_ID = dr.GetInt64(dr.GetOrdinal("FQ_ReferenciaComercial_ID"))
                   });
               }
               dr.Close();
           }
           catch (Exception ex)
           {
               logger.Error("Error " + ex.Message + "Metodo :ListarReferenciaComercial  CodigoSolicitud: " + CodSolicitud.ToString());

           }
           finally
           {
               if (!dr.IsClosed) dr.Close();
           }

           return lstEnReferenciaComercial;

       }

    }
}
