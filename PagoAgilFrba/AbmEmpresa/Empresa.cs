using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmEmpresa
{
    public class Empresa
    {
        public int empresaId { get; set; }
        public string nombre { get; set; }
        public string cuit { get; set; }
        public string direccion { get; set; }
        public int rubro { get; set; }
        public bool estado { get; set; }

    }
}
