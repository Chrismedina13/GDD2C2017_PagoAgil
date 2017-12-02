using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.TiposDePago
{
   public class TarjetaCredito
    {
       public Decimal dniTitular { get; set; }
       public int codTarjeta { get; set; }
       public int codVerificacion { get; set; }
       public Decimal monto { get; set; }
       public DateTime vtoTarj { get; set; }

        public bool altaTarjCredito(TarjetaCredito cred)
        {
            SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_alta_tarjCredito", BDComun.ObtenerConexion());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@nroTarjCredit", cred.codTarjeta);
            command.Parameters.AddWithValue("@fechaVtoTarjeta", cred.vtoTarj);
            command.Parameters.AddWithValue("@codVerificacionTarjeta", cred.codVerificacion);
            command.Parameters.AddWithValue("@dniTitular", cred.dniTitular);
            command.Parameters.AddWithValue("@monto", cred.monto);
             


            return command.ExecuteNonQuery() > 0 ? true : false;
        }





    }
}
