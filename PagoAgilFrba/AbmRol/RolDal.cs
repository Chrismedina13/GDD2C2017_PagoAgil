using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmRol
{
    class RolDAL
    {

        public static bool CrearRol(String Nombre, int habilitado, String funcionalidad)
        {
            SqlConnection Conexion = BDComun.ObtenerConexion();
            try
            {

                
                SqlCommand comando = new SqlCommand("pero_compila.sp_alta_rol", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@nombre", Nombre);
                comando.Parameters.AddWithValue("@habilitado", habilitado);
                comando.Parameters.AddWithValue("@funcionalidad", funcionalidad);

                if (comando.ExecuteNonQuery() > 0)
                {
                    Conexion.Close();
                    return true;
                }
                else
                {
                    Conexion.Close();
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                Conexion.Close();
                return false;
            }
        }


        public static bool ModificarRol(int id, String nombre, int habilitado, String Func)
        {
            int Valor_Retornado = 0;
            try
            {

                SqlConnection Conexion = BDComun.ObtenerConexion();
                SqlCommand comando = new SqlCommand("pero_compila.sp_update_rol", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@rol_id", id);
                comando.Parameters.AddWithValue("@rol_nombre", nombre);
                comando.Parameters.AddWithValue("@rol_habilitado", habilitado);
                comando.Parameters.AddWithValue("@rol_funcionalidades", Func);


                if (comando.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool EliminarRol(int idRol)
        {
            try
            {
                SqlConnection Conexion = BDComun.ObtenerConexion();
                SqlCommand comando = new SqlCommand("pero_compila.sp_baja_rol", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@Id", idRol);
                if (comando.ExecuteNonQuery() > 0) { return true; }
                else { return false; }
            }
            catch (Exception ex) { return false; }
        }
        public static List<Rol> BuscarRol()
        {
            List<Rol> roles = new List<Rol>();

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {

                SqlCommand comando = new SqlCommand("pero_compila.sp_get_roles", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                //comando.Parameters.Clear();

                //executamos la consulta SqlDataReader reader = Comando.ExecuteReader();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Rol rol = new Rol();
                    rol.Id = reader.GetInt32(0);
                    rol.Nombre = reader.GetString(1);
                    rol.habilitado = reader.GetInt32(2);
                    //rol.lstFuncionalidad = reader.GetString(2);
                    roles.Add(rol);

                }
                Conexion.Close();
            }
            return roles;
        }

    }
}
