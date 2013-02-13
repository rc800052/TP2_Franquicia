using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnEntidad
{
    public class EnReferenciaComercial
    {
        public string RefEmpresa1 { get; set; }
        public string RefDireccion1 { get; set; }
        public string RefContacto { get; set; }
        public Int64 FQ_SOLICITUD_ID { get; set; }
        public Int64 FQ_ReferenciaComercial_ID { get; set; }
    }
}
