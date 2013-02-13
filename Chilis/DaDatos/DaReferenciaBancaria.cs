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
    public class DaReferenciaBancaria
    {
        public Int64 MantenimientoReferenciaBancaria(EnReferenciaBancaria objEnRefBancaria, Int16 intControlador)
        {
            
            Int64 intCodReferenciaBancaria;
            
                Database db = DatabaseFactory.CreateDatabase();
                SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_MantenimientoReferenciaBancaria");
                cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
                Helper.AddParam(ref cmd, "@nombre", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefBancaria.Banco1);
                Helper.AddParam(ref cmd, "@tipoCuenta", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefBancaria.Cuenta1);
                Helper.AddParam(ref cmd, "@sucursal", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefBancaria.Sucursal1);
                Helper.AddParam(ref cmd, "@sectorista", SqlDbType.VarChar, 255, ParameterDirection.Input, objEnRefBancaria.Sectorista1);
                Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, objEnRefBancaria.SolCodSolicitud);
                Helper.AddParam(ref cmd, "@FQ_ReferenciaBancaria_ID", SqlDbType.Int, ParameterDirection.Input, objEnRefBancaria.FQ_ReferenciaBancaria_ID);
                Helper.AddParam(ref cmd, "@controlador", SqlDbType.Int, ParameterDirection.Input, intControlador);
                cmd.Parameters.Add("@num", SqlDbType.Int).Direction = ParameterDirection.Output;
                db.ExecuteNonQuery(cmd);
                //cmd.Parameters.Clear();

                intCodReferenciaBancaria = Convert.ToInt64(cmd.Parameters["@num"].Value);

           
            return intCodReferenciaBancaria;
        }


        public List<EnReferenciaBancaria> ListarReferenciaBancaria(Int64 CodSolicitud)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            Database db = DatabaseFactory.CreateDatabase();
            SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_ListarRefBancaria");
            cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
            Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.Int, ParameterDirection.Input, CodSolicitud);

            List<EnReferenciaBancaria> lstEnReferenciaBancaria = new List<EnReferenciaBancaria>();
            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(cmd);
                while (dr.Read())
                {
                    lstEnReferenciaBancaria.Add(new EnReferenciaBancaria()
                    {
                        Banco1 = dr.GetString(dr.GetOrdinal("nombre")),
                        Sucursal1 = dr.GetString(dr.GetOrdinal("sucursal")),
                        Cuenta1 = dr.GetString(dr.GetOrdinal("tipocuenta")),
                        Sectorista1 = dr.GetString(dr.GetOrdinal("sectorista")),
                        FQ_ReferenciaBancaria_ID = dr.GetInt32(dr.GetOrdinal("FQ_ReferenciaBancaria_ID")),
                    });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                logger.Error("Error " + ex.Message + "Metodo :ListarReferenciaBancaria  Solicitud: " + CodSolicitud.ToString());

            }
            finally
            {
                if (!dr.IsClosed) dr.Close();
            }

            return lstEnReferenciaBancaria;

        }


    }
}
