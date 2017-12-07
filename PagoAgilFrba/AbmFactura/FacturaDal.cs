using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public class FacturaDal
    {
        public static int registrar(
            Decimal factura_cliente_dni,
            string factura_cliente_mail,
            int factura_empresa,
            int factura_numero,  
            DateTime factura_fecha_inicio,
            DateTime factura_fecha_fin,
            decimal factura_total)
        {
            try
            {
                SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_alta_factura", BDComun.ObtenerConexion());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@cliente_dni", factura_cliente_dni);
            command.Parameters.AddWithValue("@cliente_mail", factura_cliente_mail);
            command.Parameters.AddWithValue("@empresaID", factura_empresa);
            command.Parameters.AddWithValue("@cod_factura", factura_numero);
            command.Parameters.AddWithValue("@total", factura_total);
            command.Parameters.AddWithValue("@fecha_alta", factura_fecha_inicio);
            command.Parameters.AddWithValue("@fecha_vencimiento", factura_fecha_fin);

            int id = Convert.ToInt32(command.ExecuteScalar());
            if (id > 0)
            {
                //comando.CommandText = "Select Max(rol_Id) from [pero_compila].[Rol]";
                //id= Convert.ToInt32(comando.ExecuteScalar());
                //Conexion.Close();
                return id;
            }
            else
            {
                
                return id;
            }
            }            catch (Exception e){return 0;} 
        }

        public static bool registrarPago(
            Decimal factura_cliente_dni,
            string factura_cliente_mail,
            int factura_empresa,
            int factura_numero,
            DateTime factura_fecha_inicio,
            DateTime factura_fecha_fin,
            decimal factura_total)
        {
            try
            {
                SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_alta_factura", BDComun.ObtenerConexion());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@cliente_dni", factura_cliente_dni);
                command.Parameters.AddWithValue("@cliente_mail", factura_cliente_mail);
                command.Parameters.AddWithValue("@empresaID", factura_empresa);
                command.Parameters.AddWithValue("@cod_factura", factura_numero);
                command.Parameters.AddWithValue("@total", factura_total);
                command.Parameters.AddWithValue("@fecha_alta", factura_fecha_inicio);
                command.Parameters.AddWithValue("@fecha_vencimiento", factura_fecha_fin);

                return command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception e) { return false; }
        }



        public  bool pasarAPagada(
            Decimal factura_cliente_dni,
            string factura_cliente_mail,
            int factura_numero
           )
        {
            try
            {
                SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_pasar_a_pagada", BDComun.ObtenerConexion());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@cliente_dni", factura_cliente_dni);
                command.Parameters.AddWithValue("@cliente_mail", factura_cliente_mail);
                command.Parameters.AddWithValue("@cod_factura", factura_numero);
                return command.ExecuteNonQuery() > 0 ? true : false;
               
            }
            catch (Exception e) { return false; }
        }
        public static bool Modificar(int id, String nombre, int habilitado)
        {
            try
            {

                SqlConnection Conexion = BDComun.ObtenerConexion();
                SqlCommand comando = new SqlCommand("pero_compila.sp_update_rol", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@habilitado", habilitado);
                //comando.Parameters.AddWithValue("@rol_funcionalidades", Func);
                return comando.ExecuteNonQuery() > 0?true:false;
            }
            catch (Exception ex){return false;}
        }
        public static bool Eliminar(int idRol)
        {
            try
            {
                SqlConnection Conexion = BDComun.ObtenerConexion();
                SqlCommand comando = new SqlCommand("pero_compila.sp_baja_rol", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@Id", idRol);
                return comando.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex) { return false; }
        }







        public int buscarIdFactura(int codFact)
        {
            int id = 0;
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
          
                Factura factu = new Factura();
                SqlCommand Comando = new SqlCommand(String.Format("select factura_id from pero_compila.Factura where  factura_cod_factura = '{0}'", codFact), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                   id = reader.GetInt32(0);
                   
                }

                Conexion.Close();
            }
            return id ;
        
        }





        public static bool EliminarFactura(Factura f)
        {
            try
            {
                SqlConnection Conexion = BDComun.ObtenerConexion();
                SqlCommand comando = new SqlCommand("pero_compila.sp_eliminar_factura", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@codFactura", f.codFactura);
                comando.Parameters.AddWithValue("@cli_dni", f.cli_dni);
                comando.Parameters.AddWithValue("@facturaID", f.facturaId);
                return comando.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex) { return false; }
        }


        public static bool ModificarFactura(Factura f)
        {
            try
            {
                SqlConnection Conexion = BDComun.ObtenerConexion();
                SqlCommand comando = new SqlCommand("pero_compila.sp_update_factura", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                comando.Parameters.AddWithValue("@facturaId", f.facturaId);
                comando.Parameters.AddWithValue("@total", f.total);
                comando.Parameters.AddWithValue("@codFactura", f.codFactura);
                comando.Parameters.AddWithValue("@cli_dni", f.cli_dni);
                comando.Parameters.AddWithValue("@empresaId", f.empresa_id+1);
                comando.Parameters.AddWithValue("@fechaAlta", f.fechaAlta);
                comando.Parameters.AddWithValue("@fechaVto", f.fechaVenc);
                return comando.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex) { return false; }
        }

        public static List<Factura> BuscarTotales()
        {
            List<Factura> fs = new List<Factura>();

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {

                SqlCommand comando = new SqlCommand("pero_compila.sp_get_facturas", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                //comando.Parameters.Clear();

                //executamos la consulta SqlDataReader reader = Comando.ExecuteReader();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Factura f = new Factura();
                    f.facturaId= reader.GetInt32(0);
                    f.total =reader.GetDecimal(7);
                    fs.Add(f);

                }
                Conexion.Close();
            }
            return fs;
        }
        public static AutoCompleteStringCollection LoadAutoComplete()
        {
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (Factura f in FacturaDal.BuscarTotales())
            {
                stringCol.Add(Convert.ToString(f.total));
            }
            return stringCol;
        }


    }
}
