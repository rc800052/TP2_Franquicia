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
   public  class NeTipoAnexo
    {
       public List<EnTipoAnexo> ListarTipoAnexo()
       {
           DaTipoAnexo objTipoAnexo = new DaTipoAnexo();
           return objTipoAnexo.ListarTipoAnexo();
       }
    }
}
