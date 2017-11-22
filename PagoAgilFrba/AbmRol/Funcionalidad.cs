using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmRol
{
    public class Funcionalidad
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
        public List<Funcionalidad> getListFuncionalidades()
        {
            List<Funcionalidad> func = new List<Funcionalidad>();

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(String.Format("SELECT DISTINCT funcionalidad_Id,funcionalidad_descripcion from pero_compila.Funcionalidad"), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();

                while (reader.Read())
                {
                    Funcionalidad f = new Funcionalidad();
                    f.IdFuncionalidad = reader.GetInt32(0);
                    f.descripcion = reader.GetString(1);
                    func.Add(f);
                }
                Conexion.Close();
            }
            return func;
        }

        public static int insert(int idRol, int idFuncionalidad)
        {
            SqlConnection Conexion = BDComun.ObtenerConexion();
            try
            {


                SqlCommand comando = new SqlCommand("pero_compila.sp_alta_funcionalidades", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@idRol", idRol);
                comando.Parameters.AddWithValue("@idFuncionalidad", idFuncionalidad);
                if (comando.ExecuteNonQuery()>0)
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




    }
}
