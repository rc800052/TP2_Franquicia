using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnEntidad
{
    public class EnAnexo
    {
        public string nombreDescriptivo { get; set; }
	    public string nombreArchivo { get; set; }
	    public string archivoFisico { get; set; }
        public Int32 FQ_Solicitud_ID { get; set; }
        public Int32 FQ_TipoAnexo_ID { get; set; }
    }
}
