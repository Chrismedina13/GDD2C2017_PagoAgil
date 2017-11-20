using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmCliente
{
    public class ClienteDal
    {
        public static List<Cliente> BuscarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {

                SqlCommand comando = new SqlCommand("pero_compila.sp_get_clientes", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                //comando.Parameters.Clear();

                //executamos la consulta SqlDataReader reader = Comando.ExecuteReader();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    
                    cliente.nombre = reader.GetString(1);
                    cliente.apellido = reader.GetString(2);
                    cliente.dni = reader.GetInt32(3);
                    cliente.mail = reader.GetString(4);
                    cliente.telefono = reader.GetString(5);
                    cliente.direccion = reader.GetString(6);
                    cliente.CP = reader.GetString(7);
                    cliente.estado = reader.GetBoolean(8);

                    clientes.Add(cliente);

                }
                Conexion.Close();
            }
            return clientes;
        }
    }
}
