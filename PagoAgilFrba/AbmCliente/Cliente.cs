using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmCliente
{
    public class Cliente
    {
        public decimal dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string CP { get; set; }
        public bool estado { get; set; }


     

        public static string obtenerMailPorDNI(string dni)
        {

            string mail = "";

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(String.Format("select cliente_email from pero_compila.Cliente where cliente_dni like '{0}' ", Convert.ToDecimal(dni)), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();

                while (reader.Read())
                {
                    mail = reader.GetString(0);

                }
                Conexion.Close();
            }
            return mail;
        }
    }
}
