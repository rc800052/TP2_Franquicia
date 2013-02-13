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
    public class DaTipoAnexo
    {
        public List<EnTipoAnexo> ListarTipoAnexo()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            Database db = DatabaseFactory.CreateDatabase();
            SqlCommand cmd = (SqlCommand)db.GetStoredProcCommand("sp_ListarTipoAnexo");
            cmd.CommandTimeout = Convert.ToInt32(DuracionConexion.corta);
            List<EnTipoAnexo> lstTipoAnexo = new List<EnTipoAnexo>();
            IDataReader dr = null;

            try
            {

                dr = db.ExecuteReader(cmd);
                while (dr.Read())
                {
                    lstTipoAnexo.Add(new EnTipoAnexo()
                    {
                        Nombre = dr.GetString(dr.GetOrdinal("nombre")),
                        FQ_TipoAnexo_ID = dr.GetInt32(dr.GetOrdinal("FQ_TipoAnexo_ID")),
                    });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                logger.Error("Error " + ex.Message + "Metodo :ListarTipoAnexo");

            }
            finally
            {
                if (!dr.IsClosed) dr.Close();
            }

            return lstTipoAnexo;

        }

    }
}
