using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnEntidad
{
    public class EnUsuario
    {
       
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string DNI { get; set; }
        public string CorreoPrincipal { get; set; }
        public string CorreoSecundario { get; set; }
        public Int64 intCodUsuario { get; set; }
         public string Estado { get; set; }
         public Int64 UsuRegistro { get; set; }
    }
}
