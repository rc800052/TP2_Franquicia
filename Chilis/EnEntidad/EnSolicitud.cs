using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnEntidad
{
    public class EnSolicitud
    {
         public string SolNombre { get; set; }
         public string SolEdad { get; set; }
         public string SolDomicilio { get; set; }
         public string SolNacionalidad { get; set; }
         public string SolPasaporte { get; set; }
         public string SolTelefono { get; set; }
         public string SolCelular { get; set; }
         public string SolEmail { get; set; }
         public string SolWeb { get; set; }
         public string SolCivil { get; set; }
         public string SolHijos { get; set; }
         public string SolConyuge { get; set; }
         public string SolConyugeEdad { get; set; }
         public string SolEducacionHijos { get; set; }
         public string SolEstudiosRealizados { get; set; }

         public string SolCodigo { get; set; }
         public string Solresumen { get; set; }
         public string SolDescripcion { get; set; }
         public string SolEstados { get; set; }
         public Int64 SolCodSolicitud { get; set; }
         public Int64 SolCodCandidato { get; set; }
         public DateTime? SolFecha { get; set; }
         public DateTime? SolFechaEntrevista { get; set; }
         public string SolStrFecha { get; set; }
         public string SolStrFechaEntrevista { get; set; }

    }
}
