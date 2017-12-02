using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    
                    cliente.nombre = reader.GetString(0);
                    cliente.apellido = reader.GetString(1);
                    cliente.dni = reader.GetDecimal(2);
                    cliente.mail = reader.GetString(3);
                    //cliente.telefono = reader.GetString(4);
                    cliente.direccion = reader.GetString(5);
                    cliente.CP = reader.GetString(6);
                    cliente.estado = reader.GetBoolean(9);

                    clientes.Add(cliente);

                }
                Conexion.Close();
            }
            return clientes;
        }
        public static AutoCompleteStringCollection LoadAutoComplete()
        {
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (Cliente i in ClienteDal.BuscarClientes())
            {
                stringCol.Add(i.dni.ToString());
            }
            return stringCol;
        }


        public Cliente BuscarClientePorNombreYApellido(string nombre)
        {
            Cliente cliente = new Cliente();
           
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(String.Format("select cliente_dni,cliente_email from pero_compila.Cliente where cliente_nombre like '{0}' " , nombre), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();

                while (reader.Read())
                {
                    cliente.dni = reader.GetDecimal(0);
                    cliente.mail= reader.GetString(1);
                }
                Conexion.Close();
            }
            return cliente;
        }
    }
}
