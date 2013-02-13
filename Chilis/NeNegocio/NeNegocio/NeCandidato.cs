using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnEntidad;
using DaDatos;
using Common;
using log4net;

namespace NeNegocio
{
   public  class NeCandidato
    {
       DaCandidato objNeCandidato;

       public List<EnCandidato> ListarBusqueda(string strNumDocumento, string strnombre, Int16 intFlag)
       {
           objNeCandidato = new DaCandidato();
           return objNeCandidato.ListarBusqueda(strNumDocumento, strnombre, intFlag);
   
        }
       public List<EnCandidato> ListarBusquedaxCandidato(string strNumDocumento, string strnombre, Int64 intCodCandidato, Int16 intFlag)
       {
           objNeCandidato = new DaCandidato();
           return objNeCandidato.ListarBusquedaxCandidato(strNumDocumento,strnombre,intCodCandidato,intFlag);

       }

    }
}
