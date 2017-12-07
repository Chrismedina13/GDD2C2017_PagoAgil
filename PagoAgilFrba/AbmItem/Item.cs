using System;
using System.Collections.Generic;

namespace PagoAgilFrba.AbmoItem
{
    public class Item
    {
        public int item_Id { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
    }
}
