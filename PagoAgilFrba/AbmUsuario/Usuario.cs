using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmUsuario
{
    class Usuario
    {

        public string getSucursal(string user)
        {
            string sucu="";
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(String.Format("select sucursal_nombre from pero_compila.Usuario u join pero_compila.UsuarioXSucursal uxs on(u.usuario_Id=uxs.usuarioXSucursal_usuario) join pero_compila.Sucursal s on(s.sucursal_Id=uxs.usuarioXSucursal_sucursal) where  sucursal_nombre not like 'null' and  u.usuario_username like'{0}'", user), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    sucu = reader.GetString(0);
                }

                Conexion.Close();
            }
            return sucu;
        }
    }
}
