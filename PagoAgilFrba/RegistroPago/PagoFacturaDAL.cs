using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.RegistroPago
{
    public class PagoFacturaDAL
    {
        
     public bool altaEnPagados(
        int facturaId,
        int sucursalId,
        decimal cliente_dni,
        string cliente_mail,
        int medioPagoId,
        DateTime fechaCobro,
        decimal importe)
        {
            try
            {
                SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_alta_Pago_Factura", BDComun.ObtenerConexion());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@facturaId", facturaId);
                command.Parameters.AddWithValue("@sucursalId", sucursalId);
                command.Parameters.AddWithValue("@cliente_dni", cliente_dni);
                command.Parameters.AddWithValue("@cliente_mail", cliente_mail);
                command.Parameters.AddWithValue("@medioPagoId", medioPagoId);
                command.Parameters.AddWithValue("@fechaCobro", fechaCobro);
                command.Parameters.AddWithValue("@importe", importe);

                return command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception e) { return false; }
        }

        
    }
}
