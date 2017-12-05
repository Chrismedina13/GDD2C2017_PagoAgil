using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.TiposDePago
{
    class Efectivo
    {
        Decimal monto;

        public bool altaEfectivo(Decimal total, Decimal dni)
        {
            SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_alta_efectivo", BDComun.ObtenerConexion());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@dniTitular", dni);
            command.Parameters.AddWithValue("@monto", total);



            return command.ExecuteNonQuery() > 0 ? true : false;
        }
    }
}
