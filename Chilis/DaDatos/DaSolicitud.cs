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
   public class DaSolicitud
    {
       public Int64 MantenimientoSolicitud(EnSolicitud objEnSolicitud,Int16 intControlador )
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           Int64 intCodSolicitud;
           try
           {
               Database db = DatabaseFactory.CreateDatabase();
               SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_MantenimientoSolicitud");
               cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
               Helper.AddParam(ref cmd, "@CODIGO", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnSolicitud.SolCodigo);
               Helper.AddParam(ref cmd, "@RESUMEN", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnSolicitud.Solresumen);
               Helper.AddParam(ref cmd, "@DESCRIPCION", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnSolicitud.SolDescripcion);
               Helper.AddParam(ref cmd, "@ESTADO", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnSolicitud.SolEstados);
               Helper.AddParam(ref cmd, "@FQ_SOLICITUD_ID", SqlDbType.Int, ParameterDirection.Input, objEnSolicitud.SolCodSolicitud);
               Helper.AddParam(ref cmd, "@FQ_CANDIDATO_ID", SqlDbType.Int, ParameterDirection.Input, objEnSolicitud.SolCodCandidato);
               Helper.AddParam(ref cmd, "@controlador", SqlDbType.Int, ParameterDirection.Input, intControlador);
             
               cmd.Parameters.Add("@num", SqlDbType.Int).Direction = ParameterDirection.Output;
               db.ExecuteNonQuery(cmd);
               
               intCodSolicitud = Convert.ToInt64(cmd.Parameters["@num"].Value);

           }
           catch (Exception ex)
           {
               intCodSolicitud = 0;
               logger.Error("Error " + ex.Message + "Metodo :MantenimientoSolicitud Controlador: " + intControlador.ToString());
           }
           return intCodSolicitud;
       }


       public List<EnSolicitud> ListarBusquedaxCandidatoxSolicitud(string strNumSolicitud, Int64 CodCandidato)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           Database db = DatabaseFactory.CreateDatabase();
           SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_ListarBusquedaxCandidatoxSolicitud");
            cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
            Helper.AddParam(ref cmd, "@CODIGO", SqlDbType.VarChar, 255, ParameterDirection.Input, strNumSolicitud);
           Helper.AddParam(ref cmd, "@FQ_Candidato_ID", SqlDbType.Int, ParameterDirection.Input, CodCandidato);

           List<EnSolicitud> lstEnSolicitud = new List<EnSolicitud>();
           IDataReader dr = null;
           
           try
           {
               dr = db.ExecuteReader(cmd);
               while (dr.Read())
               {
                   lstEnSolicitud.Add(new EnSolicitud()
                   {
                       SolCodigo  = dr.GetString(dr.GetOrdinal("CODIGO")),
                       SolEstados  = dr.GetString(dr.GetOrdinal("estado")),
                       SolCodSolicitud = dr.GetInt32(dr.GetOrdinal("FQ_Solicitud_ID")),
                       SolFecha = dr.GetDateTime(dr.GetOrdinal("fecha")),
                       SolCodCandidato = CodCandidato,
                       Solresumen = dr.GetString(dr.GetOrdinal("resu")),
                   });
               }
               dr.Close();
           }
           catch (Exception ex)
           {
               logger.Error("Error " + ex.Message + "Metodo :ListarBusquedaxCandidatoxSolicitud  Nro de Solicitud: " + strNumSolicitud + "Cod Candidato :" + CodCandidato.ToString());
           }
           finally
           {
               if (!dr.IsClosed) dr.Close();
           }

           return lstEnSolicitud;

       }


       public List<EnSolicitud> ListarSolicitud(Int64 CodSolicitud)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           Database db = DatabaseFactory.CreateDatabase();
           SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_ListarSolicitud");
           cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
           Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, CodSolicitud);

           List<EnSolicitud> lstEnSolicitud = new List<EnSolicitud>();
           IDataReader dr = null;

           try
           {
             
               dr = db.ExecuteReader(cmd);
               while (dr.Read())
               {
                   lstEnSolicitud.Add(new EnSolicitud()
                   {
                       SolCodigo = dr.GetString(dr.GetOrdinal("codigo")),
                       SolEstados = dr.GetString(dr.GetOrdinal("estado")),
                       Solresumen = dr.GetString(dr.GetOrdinal("resumen")),
                       SolDescripcion = dr.GetString(dr.GetOrdinal("descripcion")),
                       SolFecha = dr.GetDateTime(dr.GetOrdinal("fecha")),
                   });
               }
               dr.Close();
           }
           catch (Exception ex)
           {
               logger.Error("Error " + ex.Message + "Metodo :ListarSolicitud  Nro de Solicitud: " + CodSolicitud.ToString() );
 
           }
           finally
           {
               if (!dr.IsClosed) dr.Close();
           }

           return lstEnSolicitud;

       }


       public Int64 MantenimientoSolicitudEstado(Int64 intCodSolicitud,string strEstado)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           
           try
           {
               Database db = DatabaseFactory.CreateDatabase();
               SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_MantenimientoSolicitudEstado");
               cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
               Helper.AddParam(ref cmd, "@ESTADO", SqlDbType.VarChar, 255, ParameterDirection.Input, strEstado);
               Helper.AddParam(ref cmd, "@FQ_SOLICITUD_ID", SqlDbType.Int, ParameterDirection.Input, intCodSolicitud);
              
               db.ExecuteNonQuery(cmd);
           }
           catch (Exception ex)
           {
               
               logger.Error("Error " + ex.Message + "Metodo :MantenimientoSolicitudEstado Cod. Solicitud : " + intCodSolicitud.ToString() + "Estado:" + strEstado);
           }
           return intCodSolicitud;
       }


       public List<EnSolicitud> ListarSolicitudxEntrevista(EnSolicitud objEnSolicitud)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           Database db = DatabaseFactory.CreateDatabase();
           SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_ListarSolicitudxEntrevista");
           cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
           Helper.AddParam(ref cmd, "@nroSolicitud", SqlDbType.VarChar, ParameterDirection.Input, objEnSolicitud.SolCodigo);
           Helper.AddParam(ref cmd, "@candidato", SqlDbType.VarChar, ParameterDirection.Input, objEnSolicitud.SolNombre);
           Helper.AddParam(ref cmd, "@fechaInicio", SqlDbType.DateTime, ParameterDirection.Input, objEnSolicitud.SolFecha);
           Helper.AddParam(ref cmd, "@fechaFin", SqlDbType.DateTime, ParameterDirection.Input, objEnSolicitud.SolFechaEntrevista);
           Helper.AddParam(ref cmd, "@estado", SqlDbType.VarChar, ParameterDirection.Input, objEnSolicitud.SolEstados);
           List<EnSolicitud> lstEnSolicitud = new List<EnSolicitud>();
           IDataReader dr = null;

           try
           {

               dr = db.ExecuteReader(cmd);
               while (dr.Read())
               {
                   lstEnSolicitud.Add(new EnSolicitud()
                   {
                       SolCodigo = dr.GetString(dr.GetOrdinal("codigo")),
                       SolNombre = dr.GetString(dr.GetOrdinal("NOMBRE")),
                       SolStrFechaEntrevista = dr.GetDateTime(dr.GetOrdinal("FechEntrevista")).ToShortDateString(),
                       SolStrFecha = dr.GetDateTime(dr.GetOrdinal("FECH")).ToShortDateString(),
                       SolCodSolicitud = dr.GetInt32(dr.GetOrdinal("FQ_Solicitud_Id")),
                       SolDescripcion = dr.GetString(dr.GetOrdinal("Descrip")),
                       SolEmail = dr.GetString(dr.GetOrdinal("correoElectronico")),
                       SolEstados = dr.GetString(dr.GetOrdinal("estado")),
                   });
               }
               dr.Close();
           }
           catch (Exception ex)
           {
               logger.Error("Error " + ex.Message + "Metodo :ListarSolicitudxEntrevista  Nro de Solicitud: " + objEnSolicitud.SolCodigo + "Candidato :" + objEnSolicitud.SolNombre + "sFechaInicio:" + objEnSolicitud.SolFecha + "FechaFin:" + objEnSolicitud.SolFechaEntrevista);

           }
           finally
           {
               if (!dr.IsClosed) dr.Close();
           }

           return lstEnSolicitud;

       }
    }
}
