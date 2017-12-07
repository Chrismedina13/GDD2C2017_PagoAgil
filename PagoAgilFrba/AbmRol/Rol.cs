using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmRol
{
    public class Rol
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public Funcionalidad funcionalidad { get; set; }
        public int habilitado { get; set; }
        public String RolesPorUsuario { get; set; }
        public Rol()
        {

        }
        public Rol(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
        public List<String> getAllRoles()
        {
            List<String> roles = new List<String>();

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(String.Format("SELECT DISTINCT rol_nombre from pero_compila.Rol"), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();

                while (reader.Read())
                {
                    Nombre = reader.GetString(0);

                    roles.Add(Nombre);
                }
                Conexion.Close();
            }
            return roles;
        }

        public List<Rol> getAllRol()
        {
            List<Rol> roles = new List<Rol>();
           
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(String.Format("SELECT * from pero_compila.Rol where rol_estado=1"), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();

                while (reader.Read())
                {
                    Rol r = new Rol();
                    r.Id = reader.GetInt32(0);
                    r.Nombre = reader.GetString(1);
                   
                    roles.Add(r);
                }
                Conexion.Close();
            }
            return roles;
        }

        public List<String> getRolPorUsuario(String nombreUser)
        {
            {
                List<String> roles = new List<String>();

                using (SqlConnection Conexion = BDComun.ObtenerConexion())
                {
                    SqlCommand Comando = new SqlCommand(String.Format("select distinct R.rol_nombre FROM pero_compila.Usuario u  JOIN pero_compila.rolXUsuario uxr ON (u.usuario_ID = uxr.rolXUsuario_usuario) JOIN pero_compila.Rol R ON (R.ROL_ID=uxr.rolXUsuario_rol) WHERE u.usuario_username LIKE '{0}' and R.rol_estado=1 ", nombreUser), Conexion);
                    SqlDataReader reader = Comando.ExecuteReader();

                    while (reader.Read())
                    {
                        RolesPorUsuario = reader.GetString(0);

                        roles.Add(RolesPorUsuario);
                    }
                    Conexion.Close();
                }
                return roles;
            }

        }

        public int getidRolPorNombre(string nombre)
        { 
            int id=0;
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(String.Format("SELECT rol_id from pero_compila.Rol where rol_nombre like '{0}'",nombre), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    id= reader.GetInt32(0);
                }

                Conexion.Close();
            }
            return id;
        }





        internal static int insertRolXUsuario(int id, int rol)
        {
            SqlConnection Conexion = BDComun.ObtenerConexion();
            try
            {


                SqlCommand comando = new SqlCommand("pero_compila.sp_alta_usuarioXRol", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@idUsuario", id);
                comando.Parameters.AddWithValue("@idRol", rol);
                if (comando.ExecuteNonQuery() > 0)
                {
                    Conexion.Close();
                    return 1;
                }
                else
                {
                    Conexion.Close();
                    return 0;
                }

            }
            catch (Exception ex)
            {
                Conexion.Close();
                return 0;
            }
        }

        internal bool estaHabilitado(int idRol)
        {
            try
            {

                SqlConnection Conexion = BDComun.ObtenerConexion();
                SqlCommand Comando = new SqlCommand(String.Format("SELECT rol_estado from pero_compila.Rol where rol_id='{0}'", idRol), Conexion);
                //comando.Parameters.AddWithValue("@rol_funcionalidades", Func);
                SqlDataReader reader = Comando.ExecuteReader();
                bool estado=false;
                while (reader.Read())
                {
                    estado = reader.GetBoolean(0);


                }
                Conexion.Close();
                return estado;
            }
            catch (Exception ex)
            {
                return false;
            }
                
        }
    }
}
