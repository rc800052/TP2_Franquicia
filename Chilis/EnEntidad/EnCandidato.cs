using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnEntidad
{
    public class EnCandidato
    {
    public string  codigo { get; set; }
	public string numeroDocumento { get; set; }
	public string tipoDocumento { get; set; }
	public string direccion { get; set; }
	public string telefonoFijo { get; set; }
	public string telefonoMovil { get; set; }
	public string numeroFax { get; set; }
	public string correoElectronico { get; set; }
	public string paginaWeb { get; set; }
	public Int32 FQ_Candidato_ID { get; set; }
    public Int32 FQ_Distrito_ID { get; set; }
    public string nombre { get; set; }
    }
}
