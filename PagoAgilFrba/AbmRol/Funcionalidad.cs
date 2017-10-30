using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmRol
{
    class Funcionalidad
    {

        public int IdFuncionalidad { get; set; }
        public String descripcion { get; set; }



        public List<String> getAllFuncionalidades()
        {
            List<String> func = new List<String>();

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(String.Format("SELECT DISTINCT funcionalidad_descripcion from pero_compila.Funcionalidad"), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();

                while (reader.Read())
                {
                    Funcionalidad f = new Funcionalidad();
                    //f.IdFuncionalidad = reader.GetInt32(0);
                    descripcion = reader.GetString(0);
                    func.Add(descripcion);
                }
                Conexion.Close();
            }
            return func;
        }
    }
}
