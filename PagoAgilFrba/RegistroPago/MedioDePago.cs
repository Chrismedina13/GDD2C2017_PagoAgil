using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.RegistroPago
{
    public class MedioDePago
    {
        string descripcion;

        public List<String> getAllMediosDePago()
        {
            List<String> func = new List<String>();

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(String.Format("SELECT DISTINCT medioPago_descripcion from pero_compila.MedioPago"), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();

                while (reader.Read())
                {
                    MedioDePago mp = new MedioDePago();
                    //f.IdFuncionalidad = reader.GetInt32(0);
                    descripcion = reader.GetString(0);
                    func.Add(descripcion);
                }
                Conexion.Close();
            }
            return func;
        }


    public int buscarIdPorMedioDePago(string mpDesc)
        {
            int id = 0;
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {


                SqlCommand Comando = new SqlCommand(String.Format("select medioPago_id from pero_compila.MedioPago where  medioPago_descripcion = '{0}'", mpDesc), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                   id = reader.GetInt32(0);
                   
                }

                Conexion.Close();
            }
            return id ;
        
        
        
        }

    public bool corroborarDNIexistente(Decimal dni)
    {
        decimal id = 0;
        using (SqlConnection Conexion = BDComun.ObtenerConexion())
        {


            SqlCommand Comando = new SqlCommand(String.Format("select cliente_dni from pero_compila.Cliente where  cliente_dni = '{0}'", dni), Conexion);
            SqlDataReader reader = Comando.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetDecimal(0);

            }

            Conexion.Close();
        }
        return id!=null;
    }


       
    
    }
}
