using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmRol
{
    class Rol
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public Funcionalidad funcionalidad { get; set; }
        public int habilitado { get; set; }
        public String RolesPorUsuario { get; set; }

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

        public List<String> getRolPorUsuario(String nombreUser)
        {
            {
                List<String> roles = new List<String>();

                using (SqlConnection Conexion = BDComun.ObtenerConexion())
                {
                    SqlCommand Comando = new SqlCommand(String.Format("select distinct R.rol_nombre FROM pero_compila.Usuario u  JOIN pero_compila.rolXUsuario uxr ON (u.usuario_ID = uxr.rolXUsuario_usuario) JOIN pero_compila.Rol R ON (R.ROL_ID=uxr.rolXUsuario_rol) WHERE u.usuario_username LIKE '{0}' ", nombreUser), Conexion);
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

    }
}
