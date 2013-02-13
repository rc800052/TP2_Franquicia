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
   public class DaInformacionPatrimonial
    {
       public Int64 MantenimientoInformacionPatrimonial(EnInformacionPatrimonial objEnInfPatrimonial, Int16 intControlador)
       {
        
           Int64 intCodInformacionPatrimonialNeg;
            Database db = DatabaseFactory.CreateDatabase();
               SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_MantenimientoInformacionPatrimonialNeg");
               cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
               Helper.AddParam(ref cmd, "@hipotecas", SqlDbType.Decimal, ParameterDirection.Input, objEnInfPatrimonial.InfPatHipotecas);
               Helper.AddParam(ref cmd, "@creditos", SqlDbType.Decimal, ParameterDirection.Input, objEnInfPatrimonial.InfPatCredito);
               Helper.AddParam(ref cmd, "@prestamos", SqlDbType.Decimal, ParameterDirection.Input, objEnInfPatrimonial.InfPatPrestamos);
               Helper.AddParam(ref cmd, "@ctsxpagar", SqlDbType.Decimal, ParameterDirection.Input, objEnInfPatrimonial.InfPatCuentaPagar);
               Helper.AddParam(ref cmd, "@otros", SqlDbType.Decimal, ParameterDirection.Input, objEnInfPatrimonial.InfPatOtros1);
               Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, objEnInfPatrimonial.SolCodSolicitud);
               Helper.AddParam(ref cmd, "@FQ_InformacionPatrimonialNeg_ID", SqlDbType.Int, ParameterDirection.Input, objEnInfPatrimonial.FQ_InformacionPatrimonialNeg_ID);
               Helper.AddParam(ref cmd, "@controlador", SqlDbType.Int, ParameterDirection.Input, intControlador);
               cmd.Parameters.Add("@num", SqlDbType.Int).Direction = ParameterDirection.Output;
               db.ExecuteNonQuery(cmd);
               //cmd.Parameters.Clear();

               intCodInformacionPatrimonialNeg = Convert.ToInt64(cmd.Parameters["@num"].Value);

           
           return intCodInformacionPatrimonialNeg;
       }


       public Int64 MantenimientoInformacionPatrimonialPos(EnInformacionPatrimonial objEnInfPatrimonial, Int16 intControlador)
       {
          
           Int64 intCodInformacionPatrimonialPos;
           
               Database db = DatabaseFactory.CreateDatabase();
               SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_MantenimientoInformacionPatrimonialPos");
               cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
               Helper.AddParam(ref cmd, "@ctsBancarias", SqlDbType.Decimal, ParameterDirection.Input, objEnInfPatrimonial.InfPatCuenta);
               Helper.AddParam(ref cmd, "@acciones", SqlDbType.Decimal, ParameterDirection.Input, objEnInfPatrimonial.InfPatAcciones);
               Helper.AddParam(ref cmd, "@inmuebles", SqlDbType.Decimal, ParameterDirection.Input, objEnInfPatrimonial.InfPatInmuebles);
               Helper.AddParam(ref cmd, "@vehiculos", SqlDbType.Decimal, ParameterDirection.Input, objEnInfPatrimonial.InfPatVehiculos);
               Helper.AddParam(ref cmd, "@otros", SqlDbType.Decimal, ParameterDirection.Input, objEnInfPatrimonial.InfPatOtros2);
               Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, objEnInfPatrimonial.SolCodSolicitud);
               Helper.AddParam(ref cmd, "@FQ_InformacionPatrimonialPos_ID", SqlDbType.Int, ParameterDirection.Input, objEnInfPatrimonial.FQ_InformacionPatrimonialPos_ID);
               Helper.AddParam(ref cmd, "@controlador", SqlDbType.Int, ParameterDirection.Input, intControlador);
               cmd.Parameters.Add("@num", SqlDbType.Int).Direction = ParameterDirection.Output;
               db.ExecuteNonQuery(cmd);
               //cmd.Parameters.Clear();

               intCodInformacionPatrimonialPos = Convert.ToInt64(cmd.Parameters["@num"].Value);

           return intCodInformacionPatrimonialPos;
       }


       public List<EnInformacionPatrimonial> ListarInformacionPatrimonialPos(Int64 CodSolicitud)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           Database db = DatabaseFactory.CreateDatabase();
           SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_ListarInfPatPos");
           cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
           Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, CodSolicitud);

           List<EnInformacionPatrimonial> lstEnInformacionPatrimonial = new List<EnInformacionPatrimonial>();
           IDataReader dr = null;

           try
           {
               dr = db.ExecuteReader(cmd);
               while (dr.Read())
               {
                   lstEnInformacionPatrimonial.Add(new EnInformacionPatrimonial()
                   {
                       InfPatCuenta = dr.GetDouble(dr.GetOrdinal("ctsBancarias")).ToString(),
                       InfPatAcciones = dr.GetDouble(dr.GetOrdinal("acciones")).ToString(),
                       InfPatInmuebles = dr.GetDouble(dr.GetOrdinal("inmuebles")).ToString(),
                       InfPatVehiculos = dr.GetDouble(dr.GetOrdinal("vehiculos")).ToString(),
                       InfPatOtros1 = dr.GetDouble(dr.GetOrdinal("otros")).ToString(),
                       FQ_InformacionPatrimonialPos_ID = dr.GetInt32(dr.GetOrdinal("FQ_InformacionPatrimonialPos_ID")),
                   });
               }
               dr.Close();
           }
           catch (Exception ex)
           {
               logger.Error("Error " + ex.Message + "Metodo :ListarInformacionPatrimonialPos  Solicitud :" + CodSolicitud.ToString());

           }
           finally
           {
               if (!dr.IsClosed) dr.Close();
           }

           return lstEnInformacionPatrimonial;

       }

       public List<EnInformacionPatrimonial> ListarInformacionPatrimonialNeg(Int64 CodSolicitud)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           Database db = DatabaseFactory.CreateDatabase();
           SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_ListarInfPatNeg");
           cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
           Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, CodSolicitud);

           List<EnInformacionPatrimonial> lstEnInformacionPatrimonial = new List<EnInformacionPatrimonial>();
           IDataReader dr = null;

           try
           {
               dr = db.ExecuteReader(cmd);
               while (dr.Read())
               {
                   lstEnInformacionPatrimonial.Add(new EnInformacionPatrimonial()
                   {
                       InfPatHipotecas = dr.GetDouble(dr.GetOrdinal("hipotecas")).ToString(),
                       InfPatCredito = dr.GetDouble(dr.GetOrdinal("creditos")).ToString(),
                       InfPatPrestamos = dr.GetDouble(dr.GetOrdinal("prestamos")).ToString(),
                       InfPatCuentaPagar = dr.GetDouble(dr.GetOrdinal("ctsxpagar")).ToString(),
                       InfPatOtros2 = dr.GetDouble(dr.GetOrdinal("otros")).ToString(),
                       FQ_InformacionPatrimonialNeg_ID = dr.GetInt32(dr.GetOrdinal("FQ_InformacionPatrimonialNeg_ID")),
                   });
               }
               dr.Close();
           }
           catch (Exception ex)
           {
               logger.Error("Error " + ex.Message + "Metodo :ListarInformacionPatrimonialNeg  Solicitud :" + CodSolicitud.ToString());
           }
           finally
           {
               if (!dr.IsClosed) dr.Close();
           }

           return lstEnInformacionPatrimonial;

       }


    }
}
