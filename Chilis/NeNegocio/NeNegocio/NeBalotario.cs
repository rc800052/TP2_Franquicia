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
    public class NeBalotario
    {
        public List<EnBalotario> ListarBalotario()
        {
            DaBalotario objdaBalotario = new DaBalotario();
            return objdaBalotario.ListarBalotario();
        }
        public List<EnBalotario> ListarBalotarioEntrevista(Int32 intCodSolicitud)
        {
            DaBalotario objdaBalotario = new DaBalotario();
            return objdaBalotario.ListarBalotarioEntrevista(intCodSolicitud);
        }

    }
}
