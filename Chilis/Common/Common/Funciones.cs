using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnEntidad;

namespace Common
{
    public class Funciones
    {
       
      
      
        //  ***********************************************************************************************/
        /// <summary>
        /// Validar Numero, Letras o Alfanumericos
        /// </summary>Autor:Erika Endara
        /// <param name="cadena">Campo a validar</param>
        /// <param name="longitud">Tamaño del campo a validar</param>
        
        /// <returns>True si es valido, False si es invalido</returns>
        public static bool ValidarNumero(String cadena, int longitud, int accion)
        {

            char[] CaracteresValidos = "1234567890".ToCharArray();


            bool valor = true;
            char[] cCadena = cadena.ToCharArray();

            //-------------------------------Números------------------------------------------
            if (accion == 2)
            {
                for (int i = 0; i < longitud; i++)
                {
                    bool va = false;
                    for (int k = 0; k < CaracteresValidos.Length; k++)
                    {
                        if (cCadena[i].ToString() == CaracteresValidos[k].ToString())
                            va = true;
                    }
                    if (!va) return false;
                }
            }

            return valor;
        }

        public static bool Validar(String cadena, int longitud, int accion)
        {//  char[] CaracteresNoValidos = "|,;();[]{}¿?¡!/\':&*$#%=.-+@'Ç<>_´¨^`ªº".ToCharArray();
            char[] CaracteresNoValidos = "|[]{}¡!\'&*$#=-+@'Ç<>_^ªº".ToCharArray();
         
            bool valor = true;
            char[] cCadena = cadena.ToCharArray();

            //-------------------------Números y letras------------------------------------------------
            if (accion == 1)
            {
                for (int i = 0; i < longitud; i++)
                {
                    for (int k = 0; k < CaracteresNoValidos.Length; k++)
                    {
                        if (cCadena[i].ToString() == CaracteresNoValidos[k].ToString())
                            return false;
                    }
                }
            }

           
            return valor;
        }


        public static DateTime? ObtenerDateTimeNull(string strValor)
        {
            if (strValor == string.Empty)
            {
                return null;
            }
            else
            {
                return DateTime.Parse(strValor);
               
            }
        }
        public static string ObtenerCero(string strValor)
        {
            if (strValor == string.Empty)
            {
                return "0";
            }
            else
            {
                return strValor;

            }
        }
    }
}
