using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmEmpresa
{
    public class EmpresaDal
    {
        public static List<Empresa> BuscarEmpresas()
        {
            List<Empresa> empresas = new List<Empresa>();

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {

                SqlCommand comando = new SqlCommand("pero_compila.sp_get_empresas", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                //comando.Parameters.Clear();

                //executamos la consulta SqlDataReader reader = Comando.ExecuteReader();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Empresa empresa = new Empresa();
                    empresa.empresaId = reader.GetInt32(0);
                    empresa.nombre = reader.GetString(1);
                    empresa.cuit = reader.GetString(2);
                    empresa.direccion = reader.GetString(3);
                    empresa.rubro = reader.GetInt32(4);
                    empresa.estado = reader.GetBoolean(5);

                    empresas.Add(empresa);

                }
                Conexion.Close();
            }
            return empresas;
        }
    }
}
