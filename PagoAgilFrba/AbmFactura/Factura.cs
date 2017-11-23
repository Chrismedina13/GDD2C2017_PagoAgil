using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmFactura
{
    class Factura
    {
        public Decimal cli_dni { get; set; }
        public String cli_mail { get; set; }
        public int empresa_id { get; set; }
        public int codFactura { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaVenc { get; set; }
        public Decimal total { get; set; }

        //public List<String> getFacturas()
        //{
        //    using (SqlConnection Conexion = BDComun.ObtenerConexion())
        //    {
        //        SqlCommand Comando = new SqlCommand(String.Format("SELECT DISTINCT id_factura from pero_compila.Factura"), Conexion);
        //        SqlDataReader reader = Comando.ExecuteReader();

             
        //        Conexion.Close();
        //    }
        //    return ;
        //}
    }
}
