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
    public class DaReferenciaLaboral
    {
        public Int64 MantenimientoReferenciaLaboral(EnReferenciaLaboral objEnRefLaboral, Int16 intControlador)
        {
            
            Int64 intCodReferenciaLaboral;
           
                Database db = DatabaseFactory.CreateDatabase();
                SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_MantenimientoReferenciaLaboral");
                cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
                Helper.AddParam(ref cmd, "@nombreEmpresa", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefLaboral.EmpresaTi);
                Helper.AddParam(ref cmd, "@cargo", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefLaboral.CargoTi);
                Helper.AddParam(ref cmd, "@inicioTiempoServicio", SqlDbType.Date, ParameterDirection.Input, objEnRefLaboral.FechaInicio);
                Helper.AddParam(ref cmd, "@finTiempoServicio", SqlDbType.Date, ParameterDirection.Input, objEnRefLaboral.FechaFin);
                Helper.AddParam(ref cmd, "@sueldo", SqlDbType.Decimal, ParameterDirection.Input, objEnRefLaboral.SueldoTi);
                Helper.AddParam(ref cmd, "@direccion", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefLaboral.DireccionTi);
                Helper.AddParam(ref cmd, "@telefono", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefLaboral.TelefonoTi);
                Helper.AddParam(ref cmd, "@correoElectronico", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefLaboral.EmailTi);
                Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, objEnRefLaboral.SolCodSolicitud);
                Helper.AddParam(ref cmd, "@FQ_ReferenciaLaboral_ID", SqlDbType.Int, ParameterDirection.Input, objEnRefLaboral.FQ_ReferenciaLaboral_ID);
                Helper.AddParam(ref cmd, "@controlador", SqlDbType.Int, ParameterDirection.Input, intControlador);
                cmd.Parameters.Add("@num", SqlDbType.Int).Direction = ParameterDirection.Output;
                db.ExecuteNonQuery(cmd);
                //cmd.Parameters.Clear();

                intCodReferenciaLaboral = Convert.ToInt64(cmd.Parameters["@num"].Value);

           
            return intCodReferenciaLaboral;
        }


        public List<EnReferenciaLaboral> ListarReferenciaLaboral(Int64 CodSolicitud)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            Database db = DatabaseFactory.CreateDatabase();
            SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_ListarRefLaboral");
            cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
            Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, CodSolicitud);

            List<EnReferenciaLaboral> lstEnReferenciaLaboral = new List<EnReferenciaLaboral>();
            IDataReader dr = null;

            try
            {
                //cn.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                dr = db.ExecuteReader(cmd);
                while (dr.Read())
                {
                    lstEnReferenciaLaboral.Add(new EnReferenciaLaboral()
                    {
                        EmpresaTi = dr.GetString(dr.GetOrdinal("nombreEmpresa")),
                        CargoTi = dr.GetString(dr.GetOrdinal("cargo")),
                        FechaInicio = dr.GetDateTime(dr.GetOrdinal("inicioTiempoServicio")),
                        FechaFin = dr.GetDateTime(dr.GetOrdinal("finTiempoServicio")),
                        SueldoTi = dr.GetDouble(dr.GetOrdinal("sueldo")).ToString(),
                        DireccionTi = dr.GetString(dr.GetOrdinal("direccion")),
                        TelefonoTi = dr.GetString(dr.GetOrdinal("telefono")),
                        EmailTi = dr.GetString(dr.GetOrdinal("correoelectronico")),
                        FQ_ReferenciaLaboral_ID = dr.GetInt32(dr.GetOrdinal("FQ_ReferenciaLaboral_ID")),
                    });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                logger.Error("Error " + ex.Message + "Metodo :ListarReferenciaLaboral  CodSolicitud :" + CodSolicitud.ToString());
            }
            finally
            {
                if (!dr.IsClosed) dr.Close();
            }

            return lstEnReferenciaLaboral;

        }


    }
}
