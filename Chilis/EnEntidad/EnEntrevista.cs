using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnEntidad
{
   public  class EnEntrevista
    {
         public DateTime fecha  { get; set; }
         public string nombreEntrevistador { get; set; }
         public string comentario { get; set; }
         public Int32 FQ_Entrevista_ID { get; set; }
         public Int32 FQ_Solicitud_ID { get; set; }
    }
}
