using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.RegistroPago
{
    public class PagoFacturaReporte
    {
        public int facturaId { get; set; }
        public decimal importe { get; set; }
        public string factura { get; set; }
        public string empresa { get; set; }
    }
}
