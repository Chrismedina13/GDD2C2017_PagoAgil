using PagoAgilFrba.RegistroPago;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Rendicion
{
    class RendicionDal
    {

        public List<Rendicion> buscarRendicionPorEmpresa(string empresa)
        {
            int id = 0;
            List<Rendicion> rendiciones = new List<Rendicion>();
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {

                
                int idEmpresa = buscarIdEmpresaPorNombre(empresa);
                SqlCommand Comando = new SqlCommand(String.Format("select * from pero_compila.Rendicion_Facturas where rendicion_facturas_empresa= '{0}'", idEmpresa), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    Rendicion rendi = new Rendicion();
                    rendi.facturas_fecha=reader.GetDateTime(1);
                    //rendi.facturas_cantidad = reader.GetInt32(2);
                   // rendi.facturas_facturas = reader.GetInt32(3);
                    rendi.facturas_empresa = reader.GetInt32(4);
                    rendi.facturas_porcentaje = reader.GetDecimal(5);
                    rendi.facturas_total = reader.GetDecimal(6);
                    rendi.facturas_nro = reader.GetInt32(7);

                    rendiciones.Add(rendi);

                }

                Conexion.Close();
            }
            return rendiciones;

        }
        public List<PagoFacturaReporte> buscarRendicionPorEmpresaMesAño(int empresaId, int mes, int año,String sucu)
        {
            int id = 0;
            List<PagoFacturaReporte> facturasARendir = new List<PagoFacturaReporte>();
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {


                //int idEmpresa = buscarIdEmpresaPorNombre(empresaId);
                SqlCommand Comando = new SqlCommand(String.Format("select distinct pf.pagoFactura_id,pagoFactura_importe,f.factura_cod_factura,e.empresa_nombre from pero_compila.Empresa e join pero_compila.Factura f on f.factura_empresa=e.empresa_Id join pero_compila.PagoFactura pf on pf.pagoFactura_factura=f.factura_Id join pero_compila.Sucursal s on(s.sucursal_Id=pf.pagoFactura_sucursal) where pagoFactura_estado=1 and e.empresa_Id = '{0}' and month(pagoFactura_fecha_cobro)='{1}' and year(pagoFactura_fecha_cobro)='{2}' and sucursal_nombre= '{3}'", empresaId, mes, año, sucu), Conexion);
                SqlDataReader reader = Comando.ExecuteReader(); 
                while (reader.Read())
                {
                    PagoFacturaReporte f = new PagoFacturaReporte();
                    f.facturaId = reader.GetInt32(0);
                    f.importe = reader.GetDecimal(1);
                    f.factura = reader.GetString(2);
                    f.empresa = reader.GetString(3);
                    
                    facturasARendir.Add(f);

                }

                Conexion.Close();
            }
            return facturasARendir;

        }
        public int buscarIdEmpresaPorNombre(String nombre)
        {
            int id = 0;
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {

               
                SqlCommand Comando = new SqlCommand(String.Format("select empresa_id from pero_compila.Empresa where empresa_nombre = '{0}'", nombre), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);

                }

                Conexion.Close();
            }
            return id;

        }

        public static bool registrarRendicion(
             DateTime rendicion_fecha,
             int cantidad,
             Decimal importeRecaudado,
             string empresa,
             Decimal porcentaje,
             decimal total)
        {
            try
            {
                SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_alta_rendicion", BDComun.ObtenerConexion());
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@rendicion_fecha", rendicion_fecha);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                command.Parameters.AddWithValue("@importeRecaudado", importeRecaudado);
                command.Parameters.AddWithValue("@empresa", empresa);
                command.Parameters.AddWithValue("@porcentaje", porcentaje);
                command.Parameters.AddWithValue("@total", total);

                return command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception e) { return false; }
        }
        public static bool updateARendidos(int idPagoFactura)
        {
            try
            {
                using (SqlConnection Conexion = BDComun.ObtenerConexion())
                {

                    int resultado;
                    string query = "";
                    query=String.Format("update pero_compila.PagoFactura set pagoFactura_estado =  0 where pagoFactura_id='{0}'", idPagoFactura);
                    SqlCommand Comando = new SqlCommand(query, Conexion);
                    resultado = Comando.ExecuteNonQuery();
                    Conexion.Close();
                    //return resultado > 0 ? true : false;
                    if (resultado > 0) { return true; }
                    else { return false; }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
