using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.RegistroPago
{
   public class PagoFactura
    {
       public int facturaId { get; set; }
       public int sucursalId { get; set; }
       public Decimal cliente_dni { get; set; }
       public string cliente_mail { get; set; }
       public int medioPagoId { get; set; }
       public DateTime fechaCobro { get; set; }
       public Decimal importe { get; set; }
    }
   
}
