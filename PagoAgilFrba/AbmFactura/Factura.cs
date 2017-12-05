using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public class Factura
    {
        public int facturaId { get; set; }
        public Decimal cli_dni { get; set; }
        public String cli_mail { get; set; }
        public int empresa_id { get; set; }
        public int codFactura { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaVenc { get; set; }
        public Decimal total { get; set; }
        bool estado { get; set; }
        public List<Factura> getFacturasPorDatosDeFactura(Factura f)
        {
            List<Factura> facs = new List<Factura>();
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {
                //Factura factu = new Factura();
                //FALTTA IMPORTEEEE  or importe ='{2}' ,importe
                //VER PORQUE CUANDO NO PONGO IMPORTE NO ANDA
                
                    try
                    {
                        SqlCommand comando = new SqlCommand("pero_compila.filtrarFacturas", Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        //se limpian los parámetros
                        comando.Parameters.Clear();
                        //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                        //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                        comando.Parameters.AddWithValue("@fechaAlta", DateTime.Today);
                        comando.Parameters.AddWithValue("@fechaVencimiento", f.fechaVenc);
                        comando.Parameters.AddWithValue("@nroFactura", f.codFactura);
                        comando.Parameters.AddWithValue("@cliDni", f.cli_dni);
                        comando.Parameters.AddWithValue("@empresaId", f.empresa_id);
                       
                     
                        SqlDataReader reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                            Factura factu = new Factura();
                            factu.facturaId = reader.GetInt32(0);
                            factu.empresa_id = reader.GetInt32(1);
                            factu.codFactura = Convert.ToInt32(reader.GetString(2));
                            factu.cli_dni = reader.GetDecimal(3);
                            factu.cli_mail = reader.GetString(4);
                            factu.fechaAlta = reader.GetDateTime(5);
                            factu.fechaVenc = reader.GetDateTime(6);
                            factu.total = reader.GetDecimal(7);
                            facs.Add(factu);
                        }
                        Conexion.Close();
                    }
                    catch (Exception e) { }
                
            }


            return facs;
        }



        public List<Factura> getFacturasPorDatosDeEmpresa(String empresa)
        {
            List<Factura> facs = new List<Factura>();
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {

                Factura factu = new Factura();
                SqlCommand Comando = new SqlCommand(String.Format("select * from pero_compila.Factura f join pero_compila.Empresa e on(e.empresa_Id=f.factura_empresa) where  factura_enviadoAPago =0 and e.empresa_nombre '{0}'", empresa), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    factu.cli_dni = reader.GetDecimal(0);
                    factu.cli_mail = reader.GetString(1);
                    factu.empresa_id = reader.GetInt32(2);
                    factu.codFactura = reader.GetInt32(3);
                    factu.fechaAlta = reader.GetDateTime(4);
                    factu.fechaVenc = reader.GetDateTime(5);
                    factu.total = reader.GetDecimal(6);
                    facs.Add(factu);
                }
                Conexion.Close();
            }
            return facs;
        }




        public List<Factura> getFacturasPorDatosDeCliente(String nombreCli)
        {
            List<Factura> facs = new List<Factura>();
            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {

                Factura factu = new Factura();
                SqlCommand Comando = new SqlCommand(String.Format("select * from pero_compila.Factura f join pero_compila.Cliente c on(c.cliente_dni=f.factura_cliente_dni and c.cliente_email=f.factura_cliente_mail) where  factura_enviadoAPago =0 and c.cliente_nombre = '{0}' ", nombreCli), Conexion);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    factu.cli_dni = reader.GetDecimal(0);
                    factu.cli_mail = reader.GetString(1);
                    factu.empresa_id = reader.GetInt32(2);
                    factu.codFactura = reader.GetInt32(3);
                    factu.fechaAlta = reader.GetDateTime(4);
                    factu.fechaVenc = reader.GetDateTime(5);
                    factu.total = reader.GetDecimal(6);
                    facs.Add(factu);
                }

                Conexion.Close();
            }
            return facs;
        }

        public static List<Factura> BuscarFacturas()
        {
            List<Factura> facturas = new List<Factura>();

            using (SqlConnection Conexion = BDComun.ObtenerConexion())
            {

                try
                {
                    SqlCommand comando = new SqlCommand("pero_compila.sp_get_facturas", Conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //se limpian los parámetros
                    //comando.Parameters.Clear();

                    //executamos la consulta SqlDataReader reader = Comando.ExecuteReader();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Factura fact = new Factura();
                        fact.facturaId = reader.GetInt32(0);
                        fact.empresa_id = reader.GetInt32(1);
                        fact.codFactura = Convert.ToInt32(reader.GetString(2));
                        fact.cli_dni = reader.GetDecimal(3);
                        fact.cli_mail = reader.GetString(4);
                        fact.fechaAlta = reader.GetDateTime(5);
                        fact.fechaVenc = reader.GetDateTime(6);
                        fact.total = reader.GetDecimal(7);

                        facturas.Add(fact);

                    }
                    Conexion.Close();
                }
                catch (Exception e)
                {
                    
                    throw;
                } 
            }
            return facturas;
        }

        public static AutoCompleteStringCollection LoadAutoComplete()
        {
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (Factura i in Factura.BuscarFacturas())
            {
                stringCol.Add(i.codFactura.ToString());
            }
            return stringCol;
        }

        public List<Factura> getFacturasNoPagasYNoRendidas(Factura ftra)
        {
            List<Factura> facturas = new List<Factura>();

            try
            {
                using (SqlConnection Conexion = BDComun.ObtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("pero_compila.filtrarFacturas", Conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //se limpian los parámetros
                    comando.Parameters.Clear();
                    //comenzamos a mandar cada uno de los parámetros, deben de enviarse en el
                    //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                    comando.Parameters.AddWithValue("@fechaAlta", ftra.fechaAlta);
                    comando.Parameters.AddWithValue("@fechaVencimiento", ftra.fechaVenc);
                    comando.Parameters.AddWithValue("@nroFactura", ftra.codFactura);
                    comando.Parameters.AddWithValue("@cliDni", ftra.cli_dni);
                    comando.Parameters.AddWithValue("@empresaId", ftra.empresa_id);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Factura f = new Factura();
                        f.facturaId = reader.GetInt32(0);
                        f.empresa_id = reader.GetInt32(1);
                        f.codFactura = Convert.ToInt32(reader.GetString(2));
                        f.cli_dni = reader.GetDecimal(3);
                        f.cli_mail = reader.GetString(4);
                        f.fechaAlta = reader.GetDateTime(5);
                        f.fechaVenc = reader.GetDateTime(6);
                        f.total = reader.GetDecimal(7);


                        facturas.Add(f);
                    }
                }
                return facturas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
