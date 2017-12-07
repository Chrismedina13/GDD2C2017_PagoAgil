using PagoAgilFrba.AbmFactura;
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

        public static List<Item> BuscarItemsDeFactura(Factura f)
        {
            List<Item> items = new List<Item>();

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
               try 
	            {

                    SqlCommand Comando = new SqlCommand(String.Format("select item_Id,item_descripcion,item_precio,itemXFactura_cantidad from pero_compila.Item i join pero_compila.ItemXFactura ixf on(i.item_Id=ixf.itemXFactura_item) join pero_compila.Factura f on(f.factura_Id=ixf.itemXFactura_factura) where f.factura_cod_factura='{0}'", f.codFactura), Conexion);
                    SqlDataReader reader = Comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Item i = new Item();
                        i.item_Id=reader.GetInt32(0);
                        i.descripcion=reader.GetString(1);
                        i.precio=reader.GetDecimal(2);
                        i.cantidad=reader.GetInt32(3);
                        items.Add(i);
                    }
                    Conexion.Close();
	            }
	            catch (Exception){
	            
		
		            throw;
	            }
                   
                   
                
            }
            return items;
        }


        public static bool update(int idFactura, Item i)
        {
            try
            {
                SqlConnection Conexion = BDComun.ObtenerConexion();
                SqlCommand comando = new SqlCommand("pero_compila.sp_update_item", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@facturaId", idFactura);
                comando.Parameters.AddWithValue("@itemId",i.item_Id );
                comando.Parameters.AddWithValue("@descripcion", i.descripcion);
                comando.Parameters.AddWithValue("@precio", i.precio);
                comando.Parameters.AddWithValue("@cantidad",i.cantidad);
                return comando.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex) { return false; }
        }

    }

    
}
