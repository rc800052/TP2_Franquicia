using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnEntidad
{
    public class EnInformacionPatrimonial
    {
        public string InfPatCuenta { get; set; }
        public string InfPatAcciones { get; set; }
        public string InfPatInmuebles { get; set; }
        public string InfPatVehiculos { get; set; }
        public string InfPatOtros1 { get; set; }
        public string InfPatHipotecas { get; set; }
        public string InfPatCredito { get; set; }
        public string InfPatPrestamos { get; set; }
        public string InfPatCuentaPagar { get; set; }
        public string InfPatOtros2 { get; set; }

        public Int64 SolCodSolicitud { get; set; }
        public Int64 FQ_InformacionPatrimonialNeg_ID { get; set; }
        public Int64 FQ_InformacionPatrimonialPos_ID { get; set; }
    }
}
