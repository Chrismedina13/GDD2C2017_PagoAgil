using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmoItem
{
    public class ItemDal
    {
        public static List<Item> BuscarEmpresas()
        {
            List<Item> items = new List<Item>();

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {

                SqlCommand comando = new SqlCommand("pero_compila.sp_get_items", Conexion);
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

                    items.Add(empresa);

                }
                Conexion.Close();
            }
            return items;
        }
    }
}
