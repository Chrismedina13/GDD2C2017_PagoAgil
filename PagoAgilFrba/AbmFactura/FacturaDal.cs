﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmFactura
{
    public class FacturaDal
    {
        public static bool registrar(
            int factura_cliente, 
            int factura_empresa,
            string factura_numero,  
            DateTime factura_fecha_inicio,
            DateTime factura_fecha_fin,
            decimal factura_total)
        {
            try
            {
                SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_alta_factura", BDComun.ObtenerConexion());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@clienteID", factura_cliente);
            command.Parameters.AddWithValue("@empresaID", factura_empresa);
            command.Parameters.AddWithValue("@codFactura", factura_numero);
            command.Parameters.AddWithValue("@total", factura_total);
            command.Parameters.AddWithValue("@fecha_alta", factura_fecha_inicio);
            command.Parameters.AddWithValue("@fecha_vencimiento", factura_fecha_fin);

            return command.ExecuteNonQuery()> 0 ? true : false;
            }
            catch (Exception e){return false;} 
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
        
    }
}