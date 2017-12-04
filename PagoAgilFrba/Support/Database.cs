using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data;

namespace PagoAgilFrba.Support
{
    class Database
    {

        /*   ABM CLIENTE */


        internal static string[] getDatosCliente(string nombreViejo, string apellidoViejo, string dniViejo)
        {
            String[] datos = new string[8];
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand getDatosClienteCommand = new SqlCommand("SELECT [cliente_nombre],[cliente_apellido],[cliente_dni],[cliente_email],[cliente_direccion],[cliente_telefono],[cliente_fecha_nacimiento],[cliente_habilitado] FROM [GD1C2017].[pero_compila].[Cliente] WHERE cliente_nombre = @nombreViejo AND cliente_apellido = @apellidoViejo AND cliente_dni = @dniViejo");
            getDatosClienteCommand.Parameters.AddWithValue("nombreViejo", nombreViejo);
            getDatosClienteCommand.Parameters.AddWithValue("apellidoViejo", apellidoViejo);
            getDatosClienteCommand.Parameters.AddWithValue("dniViejo", dniViejo);
            getDatosClienteCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = getDatosClienteCommand.ExecuteReader();
            while (reader.Read())
            {
                datos[0] = reader["cliente_nombre"].ToString();
                datos[1] = reader["cliente_apellido"].ToString();
                datos[2] = reader["cliente_dni"].ToString();
                datos[3] = reader["cliente_email"].ToString();
                datos[4] = reader["cliente_direccion"].ToString();
                datos[5] = reader["cliente_telefono"].ToString();
                datos[6] = reader["cliente_fecha_nacimiento"].ToString();
                datos[7] = reader["cliente_habilitado"].ToString();
            }
            connection.Close();
            return datos;
        }


        internal static void AddCliente(string nombre, string apellido, string dni, string mail, string telefono, string direccion, string codigoPostal, int localidad, string fechanacimiento)
        {

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand addClienteCommand = new SqlCommand("insert into [GD2C2017].[pero_compila].[Cliente] (cliente_nombre, cliente_apellido, cliente_dni , cliente_email, cliente_telefono ,cliente_direccion,cliente_cp,cliente_localidad,cliente_fecha_nacimiento) values (@nombre,@apellido,@dni,@mail,@telefono,@direccion,@codigoPostal,@localidad,@fechadenacimiento)");
            // SqlCommand addClienteCommand = new SqlCommand("insert into [GD2C2017].[pero_compila].[Cliente] (cliente_nombre, cliente_apellido) values (@nombre,@apellido)");
            addClienteCommand.Parameters.AddWithValue("nombre", nombre);
            addClienteCommand.Parameters.AddWithValue("apellido", apellido);
            addClienteCommand.Parameters.AddWithValue("dni", dni);
            addClienteCommand.Parameters.AddWithValue("mail", mail);
            addClienteCommand.Parameters.AddWithValue("telefono", telefono);
            addClienteCommand.Parameters.AddWithValue("direccion", direccion);
            addClienteCommand.Parameters.AddWithValue("codigoPostal", codigoPostal);
            addClienteCommand.Parameters.AddWithValue("localidad", localidad);
            addClienteCommand.Parameters.AddWithValue("fechadenacimiento", fechanacimiento);
            addClienteCommand.Connection = connection;
            connection.Open();
            int registrosModificados = addClienteCommand.ExecuteNonQuery();
            connection.Close();
            if (registrosModificados > 0) MessageBox.Show("Cliente ingresado correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error al cargar registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        internal static void deleteCliente(String nombre, String apellido, String dni)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand deleteClienteCommand = new SqlCommand("update [GD2C2017].[pero_compila].[Cliente] set [cliente_habilitado] = 0 where cliente_nombre = @nombre and cliente_apellido = @apellido and cliente_dni = @dni ");
            deleteClienteCommand.Parameters.AddWithValue("nombre", nombre);
            deleteClienteCommand.Parameters.AddWithValue("apellido", apellido);
            deleteClienteCommand.Parameters.AddWithValue("dni", dni);

            deleteClienteCommand.Connection = connection;
            int FilasAfectadasAutos = deleteClienteCommand.ExecuteNonQuery();

            if (FilasAfectadasAutos > 0) MessageBox.Show("El cliente ha sido dado de baja exitosamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("El registro que quiso eliminar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        internal static void cargarGriddCliente(DataGridView dgv, String nombre, String apellido, String dni)
        {

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017"); ;
            connection.Open();
            try
            {
                String query = "SELECT [cliente_nombre],[cliente_apellido],[cliente_dni] FROM [GD2C2017].[pero_compila].[Cliente] where [cliente_nombre] like '" + nombre + "%' and [cliente_apellido] like '" + apellido + "%' and [cliente_dni] like '" + dni + "%'";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el DataGridView: " + ex.ToString());
            }
            connection.Close();
        }

        internal static void modificarCliente(String nombre, String apellido, String dni, String nombreNuevo, String apellidoNuevo, String dniNuevo, String telefonoNuevo, String direccionNueva, String mailNuevo, String FechaNacimientoNueva, String habilitadoNuevo)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand updateClienteCommand = new SqlCommand("UPDATE [GD1C2017].[pero_compila].[Cliente] set cliente_nombre = @nombreNuevo, cliente_apellido = @apellidoNuevo, cliente_dni = @dniNuevo, cliente_telefono = @telefonoNuevo, cliente_direccion = @direccionNueva , cliente_email = @mailNuevo, cliente_fecha_nacimiento = @fechaNacimientoNueva, cliente_habilitado = @habilitadoNuevo  WHERE cliente_nombre = @nombre and cliente_apellido = @apellido and cliente_dni = @dni ");

            updateClienteCommand.Parameters.AddWithValue("nombre", nombre);
            updateClienteCommand.Parameters.AddWithValue("apellido", apellido);
            updateClienteCommand.Parameters.AddWithValue("dni", dni);
            updateClienteCommand.Parameters.AddWithValue("nombreNuevo", nombreNuevo);
            updateClienteCommand.Parameters.AddWithValue("apellidoNuevo", apellidoNuevo);
            updateClienteCommand.Parameters.AddWithValue("dniNuevo", dniNuevo);
            updateClienteCommand.Parameters.AddWithValue("mailNuevo", mailNuevo);
            updateClienteCommand.Parameters.AddWithValue("telefonoNuevo", telefonoNuevo);
            updateClienteCommand.Parameters.AddWithValue("direccionNueva", direccionNueva);
            updateClienteCommand.Parameters.AddWithValue("fechaNacimientoNueva", FechaNacimientoNueva);
            updateClienteCommand.Parameters.AddWithValue("habilitadoNuevo", habilitadoNuevo);

            updateClienteCommand.Connection = connection;
            connection.Open();
            int FilasAfectadasClientes = updateClienteCommand.ExecuteNonQuery();

            if (FilasAfectadasClientes > 0)
            {
                MessageBox.Show("El cliente se ha modificado exitosamente.", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("El registro que quiso modificar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /*   ABM EMPRESA */

        internal static void AddEmpresa(string nombre, string cuit, int rubro, string direccion)
        {

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand addEmpresaCommand = new SqlCommand("insert into [GD2C2017].[pero_compila].[Empresa] (empresa_nombre,empresa_cuit,empresa_rubro,empresa_direccion) values (@nombre,@cuit,@rubro,@direccion)");
            addEmpresaCommand.Parameters.AddWithValue("nombre", nombre);
            addEmpresaCommand.Parameters.AddWithValue("cuit", cuit);
            addEmpresaCommand.Parameters.AddWithValue("rubro", rubro);
            addEmpresaCommand.Parameters.AddWithValue("direccion", direccion);
            addEmpresaCommand.Connection = connection;
            connection.Open();
            int registrosModificados = addEmpresaCommand.ExecuteNonQuery();
            connection.Close();
            if (registrosModificados > 0) MessageBox.Show("Empresa ingresada correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error al cargar registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        internal static Int32 idDelRubro(string rubro)
        {
            
            Int32 Id;

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand getIDRUBRO = new SqlCommand("Select rubro_Id  From [GD2C2017].[pero_compila].[Rubro] Where rubro_descripcion = @rubro");
            getIDRUBRO.Parameters.AddWithValue("rubro", rubro);

            getIDRUBRO.Connection = connection;
            connection.Open();
            SqlDataReader reader = getIDRUBRO.ExecuteReader();

            reader.Read();
           
                Id = reader.GetInt32(0);


            reader.Close();
            connection.Close();


            return Id;
        }




        internal static string getDireccionEmpresa(string rubro, string nombre, string cuit)
        {
            String direccion = null;

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand getEmpresaDireccionCommand = new SqlCommand("Select empresa_direccion From [GD2C2017].[pero_compila].[Empresa] Where empresa_nombre =@nombre and empresa_cuit = @cuit ");
            getEmpresaDireccionCommand.Parameters.AddWithValue("rubro", rubro);
            getEmpresaDireccionCommand.Parameters.AddWithValue("nombre", nombre);
            getEmpresaDireccionCommand.Parameters.AddWithValue("cuit", cuit);

            getEmpresaDireccionCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = getEmpresaDireccionCommand.ExecuteReader();

            reader.Read();
            
                direccion = reader["empresa_direccion"].ToString();
            

            reader.Close();
            connection.Close();


            return direccion;
        }


        internal static List<string> getRubros()
        {
            List<string> Rubros = new List<string>();
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");

            SqlCommand getRubros = new SqlCommand(" SELECT rubro_descripcion FROM [GD2C2017].[pero_compila].[Rubro] ");
            getRubros.Connection = connection;
            connection.Open();
            SqlDataReader reader = getRubros.ExecuteReader();

            while (reader.Read())
            {
                Rubros.Add(reader["rubro_descripcion"].ToString());
            }
            connection.Close();

            return Rubros;

        }

        internal static void cargarGriddEmpresa(DataGridView dgv, String nombre, String cuit, String rubro)
        {

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017"); ;
            connection.Open();
            try
            {
                String query = "SELECT [empresa_nombre],[empresa_cuit],[empresa_rubro] FROM [GD2C2017].[pero_compila].[Empresa] where [empresa_estado] = 1 and[empresa_nombre] like '" + nombre + "%' and [empresa_cuit] like '" + cuit + "%' and [empresa_rubro] like '" + rubro + "%'";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el DataGridView: " + ex.ToString());
            }
            connection.Close();
        }

        internal static bool cuitHabilitado(string cuit)
        {
            String empresaID = null;
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand empresaHabilitada = new SqlCommand("SELECT empresa_Id FROM [GD2C2017].[pero_compila].[Empresa] WHERE empresa_cuit = @cuit and empresa_estado = 1");
            empresaHabilitada.Parameters.AddWithValue("cuit", cuit);
            empresaHabilitada.Connection = connection;
            connection.Open();
            SqlDataReader reader = empresaHabilitada.ExecuteReader();
            while (reader.Read())
            {
                empresaID = reader["empresa_Id"].ToString();
            }
            connection.Close();
            return empresaID != null;
        }


        internal static bool cuitExistente(string cuit)
        {
            String empresaID = null;
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand cuitExistente = new SqlCommand("SELECT empresa_Id FROM [GD2C2017].[pero_compila].[Empresa] WHERE empresa_cuit = @cuit");
            cuitExistente.Parameters.AddWithValue("cuit", cuit);
            cuitExistente.Connection = connection;
            connection.Open();
            SqlDataReader reader = cuitExistente.ExecuteReader();
            while (reader.Read())
            {
                empresaID = reader["empresa_Id"].ToString();
            }
            connection.Close();
            return empresaID != null;
        }

        internal static void deleteEmpresa(int rubro, String nombre, String cuit)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand deleteEmpresaCommand = new SqlCommand("DELETE [GD2C2017].[pero_compila].[Empresa] SET empresa_estado = 0 where empresa_nombre = @nombre and empresa_cuit = @cuit and empresa_rubro = @rubro ");
            deleteEmpresaCommand.Parameters.AddWithValue("rubro", rubro);
            deleteEmpresaCommand.Parameters.AddWithValue("nombre", nombre);
            deleteEmpresaCommand.Parameters.AddWithValue("cuit", cuit);
            deleteEmpresaCommand.Connection = connection;
            connection.Open();
            int FilasAfectadasAutos = deleteEmpresaCommand.ExecuteNonQuery();

            if (FilasAfectadasAutos > 0)
            {
                MessageBox.Show("La empresa ha sido dado de baja exitosamente", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("El registro que quiso dar de baja no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        internal static void modificarEmpresa(String rubro, String nombre, String direccion, String cuit, String RubroNuevo, String nombreNuevo, String DireccionNuevo, String cuitNuevo, String habilitadoNuevo)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand updateEmpresaCommand = new SqlCommand("UPDATE [GD2C2017].[pero_compila].[Empresa] set empresa_nombre = @nombreNuevo, empresa_rubro = @RubroNuevo, empresa_direccion = @DireccionNuevo, empresa_cuit = @cuitNuevo, empresa_estado = @habilitadoNuevo WHERE empresa_nombre = @nombre and empresa_cuit = @cuit");

            updateEmpresaCommand.Parameters.AddWithValue("rubro", rubro);
            updateEmpresaCommand.Parameters.AddWithValue("nombre", nombre);
            updateEmpresaCommand.Parameters.AddWithValue("direccion", direccion);
            updateEmpresaCommand.Parameters.AddWithValue("cuit", cuit);
            updateEmpresaCommand.Parameters.AddWithValue("RubroNuevo", RubroNuevo);
            updateEmpresaCommand.Parameters.AddWithValue("nombreNuevo", nombreNuevo);
            updateEmpresaCommand.Parameters.AddWithValue("DireccionNuevo", DireccionNuevo);
            updateEmpresaCommand.Parameters.AddWithValue("cuitNuevo", cuitNuevo);
            updateEmpresaCommand.Parameters.AddWithValue("habilitadoNuevo", habilitadoNuevo);

            updateEmpresaCommand.Connection = connection;
            connection.Open();
            int FilasAfectadasClientes = updateEmpresaCommand.ExecuteNonQuery();

            if (FilasAfectadasClientes > 0)
            {
                MessageBox.Show("La empresa se ha modificado exitosamente.", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("El registro que quiso modificar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }




        /*   ABM Sucursal */

        internal static void cargarGriddSucursal(DataGridView dgv, String nombre, String direccion, String codigoPostal)
        {

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017"); ;
            connection.Open();
            try
            {
                String query = "SELECT [sucursal_nombre],[sucursal_direccion],[sucursal_CP] FROM [GD2C2017].[pero_compila].[Sucursal] where sucursal_estado = 1 and[sucursal_nombre] like '" + nombre + "%' and [sucursal_direccion] like '" + direccion + "%' and [sucursal_CP] like '" + codigoPostal + "%'";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el DataGridView: " + ex.ToString());
            }
            connection.Close();
        }

        internal static void deleteSucursal(String nombre, String direccion, String codigoPostal)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand deleteSucursalCommand = new SqlCommand("Delete [GD2C2017].[pero_compila].[Sucursal] where sucursal_estado = 1 and sucursal_nombre = @nombre and sucursal_CP = @codigoPostal and sucursal_direccion = @direccion ");
            deleteSucursalCommand.Parameters.AddWithValue("direccion", direccion);
            deleteSucursalCommand.Parameters.AddWithValue("nombre", nombre);
            deleteSucursalCommand.Parameters.AddWithValue("codigoPostal", codigoPostal);
            deleteSucursalCommand.Connection = connection;
            connection.Open();
            int FilasAfectadasAutos = deleteSucursalCommand.ExecuteNonQuery();

            if (FilasAfectadasAutos > 0)
            {
                MessageBox.Show("La sucursal ha sido dado de baja exitosamente", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("El registro que quiso dar de baja no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        internal static string[] getDatosSucursal(string nombreViejo, string codigoPostalViejo, string direccionVieja)
        {
            String[] datos = new string[4];
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand getDatosSucursal = new SqlCommand("SELECT [sucursal_nombre],[sucursal_CP],[sucursal_direccion],[sucursal_estado] FROM [GD1C2017].[pero_compila].[Sucursal] WHERE sucursal_nombre = @nombreViejo AND sucursal_direccion = @direccionVieja AND sucursal_CP = @codigoPostalViejo");
            getDatosSucursal.Parameters.AddWithValue("nombreViejo", nombreViejo);
            getDatosSucursal.Parameters.AddWithValue("codigoPostalViejo", codigoPostalViejo);
            getDatosSucursal.Parameters.AddWithValue("direccionVieja", direccionVieja);
            getDatosSucursal.Connection = connection;
            connection.Open();
            SqlDataReader reader = getDatosSucursal.ExecuteReader();
            while (reader.Read())
            {
                datos[0] = reader["sucursal_nombre"].ToString();
                datos[2] = reader["sucursal_direccion"].ToString();
                datos[1] = reader["sucursal_CP"].ToString();
                datos[3] = reader["Sucursal_estado"].ToString();

                connection.Close();
            }
            return datos;

        }

        internal static void AddSucursal(string nombre, string direccion, string cp)
        {

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand addsucursal = new SqlCommand("insert into [GD2C2017].[pero_compila].[Sucursal] (sucursal_direccion,sucursal_nombre,sucursal_CP,sucursal_localidad) values (@nombre,@direccion,@cp,1)");
            addsucursal.Parameters.AddWithValue("nombre", nombre);
            addsucursal.Parameters.AddWithValue("direccion", direccion);
            addsucursal.Parameters.AddWithValue("cp", cp);

            addsucursal.Connection = connection;
            connection.Open();
            int registrosModificados = addsucursal.ExecuteNonQuery();
            connection.Close();
            if (registrosModificados > 0) MessageBox.Show("Sucursal ingresada correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error al cargar registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }



        internal static void modificarSucursal(String nombre, String direccion, String cp, String nombreNuevo, string cpNuevo, String DireccionNuevo, String habilitadoNuevo)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand updateSucursalCommand = new SqlCommand("UPDATE [GD2C2017].[pero_compila].[Sucursal] set sucursal_nombre = @nombreNuevo, sucursal_CP = @cpNuevo, sucursal_direccion = @DireccionNuevo,sucursal_estado = @habilitadoNuevo WHERE sucursal_nombre = @nombre and sucursal_direccion = @direccion and sucursal_CP = @cp ");

            updateSucursalCommand.Parameters.AddWithValue("nombre", nombre);
            updateSucursalCommand.Parameters.AddWithValue("direccion", direccion);
            updateSucursalCommand.Parameters.AddWithValue("cp", cp);
            updateSucursalCommand.Parameters.AddWithValue("nombreNuevo", nombreNuevo);
            updateSucursalCommand.Parameters.AddWithValue("cpNuevo", cpNuevo);
            updateSucursalCommand.Parameters.AddWithValue("DireccionNuevo", DireccionNuevo);
            updateSucursalCommand.Parameters.AddWithValue("habilitadoNuevo", habilitadoNuevo);

            updateSucursalCommand.Connection = connection;
            connection.Open();
            int FilasAfectadasClientes = updateSucursalCommand.ExecuteNonQuery();

            if (FilasAfectadasClientes > 0)
            {
                MessageBox.Show("La sucursal se ha modificado exitosamente.", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("El registro que quiso modificar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        internal static bool CPExistente(string codigoPostal)
        {
            String sucursalId = null;
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand CPexistente = new SqlCommand("SELECT sucursal_Id FROM [GD2C2017].[pero_compila].[Sucursal] WHERE sucursal_CP = @codigoPostal");
            CPexistente.Parameters.AddWithValue("codigoPostal", codigoPostal);
            CPexistente.Connection = connection;
            connection.Open();
            SqlDataReader reader = CPexistente.ExecuteReader();
            reader.Read();

            while (reader.Read())
            {
                sucursalId = reader["empresa_Id"].ToString();
            }
            
            connection.Close();
            return sucursalId != null;
        }

        /*ESTADISTICAS */

        internal static void cargarGriddClienteConMayorPorcentajeFacturasPagas(DataGridView dataGridView1, Trimestre trimestre, decimal año)
        {
            SqlCommand command = new SqlCommand("SELECT TOP 5 cliente_nombre as 'nombre', ((count(pagoFactura_Id)*100)/count(cliente_Id)) as 'Porcentaje' FROM pero_compila.Cliente JOIN pero_compila.PagoFactura ON (pagoFactura_cliente = cliente_Id) WHERE pagoFactura_fecha_cobro > @inicioFecha AND pagoFactura_fecha_cobro < @finFecha GROUP cliente_nombre ORDER BY ((count(pagoFactura_Id)*100)/count(cliente_Id)) DESC");
            obtenerEstadistica(dataGridView1, trimestre, año, command);
        }


        internal static void cargarGriddClienteConMasPagos(DataGridView dataGridView1, Trimestre trimestre, decimal año)
        {
            SqlCommand command = new SqlCommand("SELECT TOP 5 cliente_nombre as 'CLIENTE', count(pagoFActura_Id) as 'PAGOS' FROM pero_compila.Cliente JOIN pero_compila.PagoFactura ON (pagoFactura_cliente = cliente_Id) WHERE pagoFactura_fecha_cobro > @inicioFecha AND pagoFactura_fecha_cobro < @finFecha GROUP BY cliente_nombre ORDER BY count(pagoFactura_Id) DESC");
            obtenerEstadistica(dataGridView1, trimestre, año, command);
        }

        private static void obtenerEstadistica(DataGridView dataGridView1, Trimestre trimestre, decimal año, SqlCommand command)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            connection.Open();
            DateTime fechaIni = new DateTime(Convert.ToInt32(año), trimestre.mesInicio, trimestre.diaInicio);
            DateTime fechaFin = new DateTime(Convert.ToInt32(año), trimestre.mesFin, trimestre.diaFin);
            command.Parameters.AddWithValue("inicioFecha", fechaIni);
            command.Parameters.AddWithValue("finFecha", fechaFin);
            command.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = command;
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }


        internal static void cargarGriddFacturasPagasCliente(DataGridView dgv, String nombre, String apellido, String dni, String mail)
        {

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017"); ;
            connection.Open();
            try
            {
                String query = "SELECT [pagoFactura_Id],[pagoFactura_sucursal],[pagoFactura_medioPago],[pagoFactura_fecha_cobro],[pagoFactura_importe],[pagoFactura_nro] FROM [GD2C2017].[pero_compila].[PagoFactura] where [pagoFactura_cliente_dni] like '" + dni + "%' and [pagoFactura_cliente_mail] like '" + mail + "%' and [pagoFactura_estado] like '" + 1 + "%'";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el DataGridView: " + ex.ToString());
            }
            connection.Close();
        }

        internal static void updatePagoFactura(int nroPagoFactura)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand updatePagoFactura = new SqlCommand("UPDATE [GD1C2017].[pero_compila].[PagoFactura] set pagoFactura_estado = 0 WHERE pagoFactura_Id = @nroPagoFactura ");

            updatePagoFactura.Parameters.AddWithValue("nroPagoFactura", nroPagoFactura);

            updatePagoFactura.Connection = connection;
            connection.Open();
            int FilasAfectadasClientes = updatePagoFactura.ExecuteNonQuery();

            if (FilasAfectadasClientes > 0)
            {
                MessageBox.Show("Pago Factura se ha modificado exitosamente.", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("El registro que quiso modificar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        internal static void updateFacturaDevuelta(int nroPagoFactura)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2017; User id=gd; Password= gd2017");
            SqlCommand updateFacturaDevuelta = new SqlCommand("UPDATE [GD1C2017].[pero_compila].[Factura] set factura_enviadoAPago = 1 WHERE factura_Id = (select pagoFactura_factura from [pero_compila].[PagoFactura] where pagoFactura_Id = @nroPagoFactura)");

            updateFacturaDevuelta.Parameters.AddWithValue("nroPagoFactura", nroPagoFactura);

            updateFacturaDevuelta.Connection = connection;
            connection.Open();
            int FilasAfectadasClientes = updateFacturaDevuelta.ExecuteNonQuery();

            if (FilasAfectadasClientes > 0)
            {
                MessageBox.Show("Pago Factura se ha modificado exitosamente.", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("El registro que quiso modificar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
    }




