using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.TiposDePago
{
    public class TarjetaDebito
    {
        public Decimal dniTitular;
        public int nroTarjeta;
        public int codVerificacion;
        public Decimal monto;
        public DateTime vtoTarj;

        public bool altaTarjDebito(TarjetaDebito cred)
        {
            SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_alta_tarjDebito", BDComun.ObtenerConexion());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@nroTarjDebito", cred.nroTarjeta);
            command.Parameters.AddWithValue("@fechaVtoTarjeta", cred.vtoTarj);
            command.Parameters.AddWithValue("@codVerificacionTarjeta", cred.codVerificacion);
            command.Parameters.AddWithValue("@dniTitular", cred.dniTitular);
            command.Parameters.AddWithValue("@monto", cred.monto);



            return command.ExecuteNonQuery() > 0 ? true : false;
        }
    }
}
