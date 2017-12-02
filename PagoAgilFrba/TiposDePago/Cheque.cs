using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.TiposDePago
{
    public class Cheque
    {
        public  int nroCheque { get; set; }
       public  Decimal dniTitular { get; set; }
        public String destino { get; set; }
       public  Decimal monto { get; set; }


     public bool altaCheque(Cheque cheque)
       {
           SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_alta_cheque", BDComun.ObtenerConexion());
           command.CommandType = CommandType.StoredProcedure;

           command.Parameters.AddWithValue("@nroCheque", cheque.nroCheque);
           command.Parameters.AddWithValue("@dniTitular", cheque.dniTitular);
           command.Parameters.AddWithValue("@destino", cheque.destino);
           command.Parameters.AddWithValue("@monto", cheque.monto);


           return command.ExecuteNonQuery() > 0 ? true : false;
       }
    }
}
