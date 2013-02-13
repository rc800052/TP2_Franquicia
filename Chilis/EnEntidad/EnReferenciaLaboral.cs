using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnEntidad
{
    public class EnReferenciaLaboral
    {
        public string EmpresaTi { get; set; }
        public string EmpresaCony { get; set; }
        public string CargoTi { get; set; }
        public string CargoCony { get; set; }
        public string TiempoTi { get; set; }
        public string TiempoCony { get; set; }
        public string SueldoTi { get; set; }
        public string SueldoCony { get; set; }
        public string DireccionTi { get; set; }
        public string DireccionCony { get; set; }
        public string TelefonoTi { get; set; }
        public string TelefonoCony { get; set; }
        public string EmailTi { get; set; }
        public string EmailCony { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Int64 SolCodSolicitud { get; set; }
        public Int64 FQ_ReferenciaLaboral_ID { get; set; }

    }
}
