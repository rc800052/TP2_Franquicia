using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnEntidad;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//using Common;
using log4net;

namespace DaDatos
{
   public class DaCandidato
    {
       string cadenaconexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

       public List<EnCandidato> ListarBusqueda(string strNumDocumento, string strnombre, Int16 intFlag)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           SqlConnection cn = new SqlConnection(this.cadenaconexion);
           SqlCommand cmd = new SqlCommand("sp_ListarBusqueda", cn);
           List<EnCandidato> lstEnCandidato = new List<EnCandidato>();
           cmd.Parameters.Add(new SqlParameter("@numeroDocumento", SqlDbType.VarChar)).Value = strNumDocumento;
           cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar)).Value = strnombre;
           cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Int)).Value = intFlag;
           cmd.CommandType = CommandType.StoredProcedure;

           try
           {
               cn.Open();
               SqlDataReader dr = cmd.ExecuteReader();

               while (dr.Read())
               {
                   lstEnCandidato.Add(new EnCandidato()
                   {
                       FQ_Candidato_ID = dr.GetInt32(dr.GetOrdinal("FQ_Candidato_ID")),
                       nombre = dr.GetString(dr.GetOrdinal("NOMBRE")),
                       numeroDocumento = dr.GetString(dr.GetOrdinal("numeroDocumento")),
                       tipoDocumento = dr.GetString(dr.GetOrdinal("tipoDocumento")),
                   });
               }
               dr.Close();
           }
           catch (Exception ex)
           {
               logger.Error("Error " + ex.Message + "Metodo :ListarBusqueda  NumeroDocumento: " + strNumDocumento + " Nombre :" + strnombre + " Flag :" + intFlag.ToString());
           }
           finally
           {
               if (cn.State == ConnectionState.Open)
               {
                   cn.Close();
               }

               cn.Dispose();
           }

           return lstEnCandidato;

       }


       public List<EnCandidato> ListarBusquedaxCandidato(string strNumDocumento, string strnombre, Int64 intCodCandidato, Int16 intFlag)
       {
           log4net.ILog logger = log4net.LogManager.GetLogger("File");
           SqlConnection cn = new SqlConnection(this.cadenaconexion);
           SqlCommand cmd = new SqlCommand("sp_ListarBusquedaxCandidato", cn);
           List<EnCandidato> lstEnCandidato = new List<EnCandidato>();
           cmd.Parameters.Add(new SqlParameter("@numeroDocumento", SqlDbType.VarChar)).Value = strNumDocumento;
           cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar)).Value = strnombre;
           cmd.Parameters.Add(new SqlParameter("@FQ_Candidato_ID", SqlDbType.Int)).Value = intCodCandidato;
           cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Int)).Value = intFlag;
           cmd.CommandType = CommandType.StoredProcedure;

           try
           {
               cn.Open();
               SqlDataReader dr = cmd.ExecuteReader();

               while (dr.Read())
               {
                   lstEnCandidato.Add(new EnCandidato()
                   {
                       FQ_Candidato_ID = dr.GetInt32(dr.GetOrdinal("FQ_Candidato_ID")),
                       nombre = dr.GetString(dr.GetOrdinal("NOMBRE")),
                       numeroDocumento = dr.GetString(dr.GetOrdinal("numeroDocumento")),
                       tipoDocumento = dr.GetString(dr.GetOrdinal("tipoDocumento")),

                       direccion = dr.GetString(dr.GetOrdinal("direccion")),
                       telefonoFijo = dr.GetString(dr.GetOrdinal("telefonofijo")),
                       telefonoMovil = dr.GetString(dr.GetOrdinal("telefonomovil")),
                       numeroFax = dr.GetString(dr.GetOrdinal("numerofax")),
                       correoElectronico = dr.GetString(dr.GetOrdinal("correoElectronico")),
                       paginaWeb = dr.GetString(dr.GetOrdinal("paginaweb")),
                   });
               }
               dr.Close();
           }
           catch (Exception ex)
           {
               logger.Error("Error " + ex.Message + "Metodo :ListarBusquedaxCandidato  NumeroDocumento: " + strNumDocumento + " Nombre :" + strnombre + "Candidato :" + intCodCandidato.ToString() + " Flag :" + intFlag.ToString());

           }
           finally
           {
               if (cn.State == ConnectionState.Open)
               {
                   cn.Close();
               }

               cn.Dispose();
           }

           return lstEnCandidato;

       }


    }
}
