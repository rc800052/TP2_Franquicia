using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnEntidad
{
    public class EnReferenciaBancaria
    {
         public string Banco1 { get; set; }
         public string Sucursal1 { get; set; }
         public string Cuenta1 { get; set; }
         public string Sectorista1 { get; set; }

         public string Banco2 { get; set; }
         public string Sucursal2 { get; set; }
         public string Cuenta2 { get; set; }
         public string Sectorista2 { get; set; }
         public Int64 SolCodSolicitud { get; set; }
         public Int64 FQ_ReferenciaBancaria_ID { get; set; }
    }
}
