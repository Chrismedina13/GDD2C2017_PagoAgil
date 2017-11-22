using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmSucursal
{
    class Sucursal
    {

        public int Id { get; set; }
        public String Nombre { get; set; }
        public int habilitado { get; set; }
        public String UsuarioPorSucursal { get; set; }

        public List<String> getSucursalPorUsuario(String nombreUser)
        {
            {
                List<String> sucursales = new List<String>();

                using (SqlConnection Conexion = BDComun.ObtenerConexion())
                {
                    SqlCommand Comando = new SqlCommand(String.Format("select distinct S.sucursal_nombre FROM pero_compila.Usuario u JOIN pero_compila.UsuarioXSucursal uxs ON (u.usuario_ID = uxs.usuarioXSucursal_usuario) JOIN pero_compila.Sucursal S ON (S.sucursal_Id=uxs.usuarioXSucursal_sucursal) WHERE u.usuario_username LIKE '{0}' and S.sucursal_estado=1", nombreUser), Conexion);
                    SqlDataReader reader = Comando.ExecuteReader();

                    while (reader.Read())
                    {
                        UsuarioPorSucursal = reader.GetString(0);

                        sucursales.Add(UsuarioPorSucursal);
                    }
                    Conexion.Close();
                }
                return sucursales;
            }
        }
    }
}
