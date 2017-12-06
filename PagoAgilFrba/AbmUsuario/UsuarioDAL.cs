using PagoAgilFrba.AbmRol;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmUsuario
{
    class UsuarioDAL
    {
        public static int CrearCuenta(String nomUsuario, String contrasenia)
        {
            int resultado = 0;
            try
            {
                Rol r = new Rol();
                SqlConnection Conexion = BDComun.ObtenerConexion();
                SqlCommand comando = new SqlCommand("pero_compila.registrarUsuario", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@user", nomUsuario);
                comando.Parameters.AddWithValue("@pass", contrasenia);
                   //declaramos el parámetro de retorno
                //executamos la consulta
                int id = Convert.ToInt32(comando.ExecuteScalar());
                if (id > 0)
                {
                    //comando.CommandText = "Select Max(rol_Id) from [pero_compila].[Rol]";
                    //id= Convert.ToInt32(comando.ExecuteScalar());
                    //Conexion.Close();
                    return id;
                }
                else
                {
                    Conexion.Close();
                    return id;
                }

            }
            catch (Exception ex)
            {
                return -1;
                //al ocurrir un error mostramos un mensaje
                //MessageBox.Show(“Error en la operación”, “Error”, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static int Autenticacion(String user, String pass)
        {
            try
            {
                int Valor_Retornado = 0;
                SqlConnection Conexion = BDComun.ObtenerConexion();
                SqlCommand comando = new SqlCommand("pero_compila.login", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@user", user);
                comando.Parameters.AddWithValue("@pass", pass);              //declaramos el parámetro de retorno

               SqlParameter ValorRetorno = new SqlParameter("@ret", SqlDbType.Int);

                //asignamos el valor de retorno
                ValorRetorno.Direction = ParameterDirection.Output;
                comando.Parameters.Add(ValorRetorno);
                //executamos la consulta
                comando.ExecuteNonQuery();
                // traemos el valor de retorno
                Valor_Retornado = Convert.ToInt32(ValorRetorno.Value);
                //dependiendo del valor de retorno se asigna la variable success
                //si el procedimiento retorna un 1 la operación se realizó con éxito
                //de no ser así se mantiene en false y pr lo tanto falló la operación
                Conexion.Close();
                return Valor_Retornado;

            }
            catch (Exception ex)
            {
                return 0;
                //al ocurrir un error mostramos un mensaje
                //MessageBox.Show(“Error en la operación”, “Error”, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        internal static void PasarAInhabilitado(string p)
        {
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(String.Format("update pero_compila.Usuario set usuario_estado=0 where usuario_username='{0}'", p), Conexion);
                Comando.ExecuteNonQuery();
              

                Conexion.Close();
            }
            
        }
    }

}
