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
        public static int CrearCuenta(String nomUsuario, String contrasenia,String rol)
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
                comando.Parameters.AddWithValue("@rol", r.getidRolPorNombre(rol));
                   //declaramos el parámetro de retorno
                //executamos la consulta
                resultado = comando.ExecuteNonQuery();
                // traemos el valor de retorno

                //dependiendo del valor de retorno se asigna la variable success
                //si el procedimiento retorna un 2 en este caso afecta dos filas
                //la operación se realizó con éxito
                //de no ser así se mantiene en false y pr lo tanto falló la operación
                Conexion.Close();
                if (resultado == 2)
                    return 1;
                else
                    return 0;

            }
            catch (Exception ex)
            {
                return -1;
                //al ocurrir un error mostramos un mensaje
                //MessageBox.Show(“Error en la operación”, “Error”, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static bool Autenticacion(String user, String pass)
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
                if (Valor_Retornado == 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
                //al ocurrir un error mostramos un mensaje
                //MessageBox.Show(“Error en la operación”, “Error”, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

}
