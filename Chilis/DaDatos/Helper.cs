using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DaDatos
{
    public static class Helper
    {
        public static void AddParam(ref SqlCommand cmd, string nombreParametro, SqlDbType tipoDato, ParameterDirection direccionParametro, object datoParametro)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = nombreParametro;
            param.SqlDbType = tipoDato;
            param.Direction = direccionParametro;
            param.Value = datoParametro;

            cmd.Parameters.Add(param);
        }

        public static void AddParam(ref SqlCommand cmd, string nombreParametro, SqlDbType tipoDato, int nroCaracteres, ParameterDirection direccionParametro, object datoParametro)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = nombreParametro;
            param.SqlDbType = tipoDato;
            param.Size = nroCaracteres;
            param.Direction = direccionParametro;
            param.Value = datoParametro;

            cmd.Parameters.Add(param);
        }

        public static void AddParam(ref SqlCommand cmd, string nombreParametro, SqlDbType tipoDato, byte escala, byte precision, ParameterDirection direccionParametro, object datoParametro)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = nombreParametro;
            param.SqlDbType = tipoDato;
            param.Scale = escala;
            param.Precision = precision;
            param.Direction = direccionParametro;
            param.Value = datoParametro;

            cmd.Parameters.Add(param);
        }
    }
}
