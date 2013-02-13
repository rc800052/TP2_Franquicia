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
    public class DaBalotario
    {

        public List<EnBalotario> ListarBalotario()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            Database db = DatabaseFactory.CreateDatabase();
            SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_ListarBalotario");
            cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
            List<EnBalotario> lstEnBalotario = new List<EnBalotario>();
            IDataReader dr = null;

            try
            {

                dr = db.ExecuteReader(cmd);
                while (dr.Read())
                {
                    lstEnBalotario.Add(new EnBalotario()
                    {
                        numeroOrden = dr.GetInt32(dr.GetOrdinal("numeroOrden")),
                        descripcion = dr.GetString(dr.GetOrdinal("descripcion")),
                        FQ_Balotario_ID = dr.GetInt32(dr.GetOrdinal("FQ_Balotario_ID")),
                    });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                logger.Error("Error " + ex.Message + "Metodo :ListarSolicitudxEntrevista");

            }
            finally
            {
                if (!dr.IsClosed) dr.Close();
            }

            return lstEnBalotario;

        }

        public List<EnBalotario> ListarBalotarioEntrevista(Int32 intCodSolicitud)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            Database db = DatabaseFactory.CreateDatabase();
            SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_ListarCuestionxSolicitud");
            cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
            Helper.AddParam(ref cmd, "@FQ_Solicitud_ID", SqlDbType.VarChar, ParameterDirection.Input, intCodSolicitud);
            List<EnBalotario> lstEnBalotario = new List<EnBalotario>();
            IDataReader dr = null;

            try
            {

                dr = db.ExecuteReader(cmd);
                while (dr.Read())
                {
                    lstEnBalotario.Add(new EnBalotario()
                    {
                        numeroOrden = dr.GetInt32(dr.GetOrdinal("numeroOrden")),
                        descripcion = dr.GetString(dr.GetOrdinal("descripcion")),
                        strvalor = dr.GetString(dr.GetOrdinal("valor")),
                    });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                logger.Error("Error " + ex.Message + "Metodo :ListarBalotarioEntrevista");

            }
            finally
            {
                if (!dr.IsClosed) dr.Close();
            }

            return lstEnBalotario;

        }



    }
}
