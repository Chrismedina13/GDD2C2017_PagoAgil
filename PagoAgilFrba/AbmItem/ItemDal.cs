using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmoItem
{
    public class ItemDal
    {
        public static List<Item> BuscarItems()
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
                    Item item = new Item();
                    item.item_Id = reader.GetInt32(0);
                    item.descripcion = reader.GetString(1);
                    item.precio = reader.GetDecimal(2);
                    items.Add(item);

                }
                Conexion.Close();
            }
            return items;
        }
        public static AutoCompleteStringCollection LoadAutoComplete()
        {
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (Item i in ItemDal.BuscarItems())
            {
                stringCol.Add(i.descripcion);
            }
            return stringCol;
        }

        public static bool registrar(
         String descripcion,
         decimal precio,
         int cantidad,
         int idFactura)
        {
            try
            {
                SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_alta_item", BDComun.ObtenerConexion());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@descripcion",descripcion);
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                command.Parameters.AddWithValue("@idFactura", idFactura);


                return command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception e) { return false; }
        }



    }
}
