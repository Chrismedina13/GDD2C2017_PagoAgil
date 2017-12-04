using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.AbmEmpresa;
using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmoItem;
using PagoAgilFrba.AbmUsuario;
using System.Text.RegularExpressions;

namespace PagoAgilFrba.AbmFactura
{
    public partial class Alta_Factura : Form
    {
        
        public Alta_Factura()
        {
            InitializeComponent();
          //  CargarComboClientes();
            CargarComboEmpresas();
            //CargarComboItems();
            //
            // cargo la lista de items para el autocomplete
            //
            Usuario u = new Usuario();
            //textImporte.AutoCompleteCustomSource = ItemDal.LoadAutoComplete();
            //textImporte.AutoCompleteMode = AutoCompleteMode.Suggest;
            //textImporte.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MessageBox.Show("Falta buscar el usuario actual!!!!");
            labelSucursal.Text = u.getSucursal("admin");
            labelFechaAct.Text = DateTime.Today.ToString("dd/MM/yyyy");
            //CargarComboClientes();
            textCliente.AutoCompleteCustomSource = ClienteDal.LoadAutoComplete();
            textCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            textCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void CargarComboEmpresas()
        {
            //Vaciar comboBox
            comboBoxEmpresa.DataSource = null;
           
            //Indicar qué propiedad se verá en la lista
            this.comboBoxEmpresa.DisplayMember = "nombre";
            //Indicar qué valor tendrá cada ítem
            this.comboBoxEmpresa.ValueMember = "empresaId";
            //Asignar la propiedad DataSource
            this.comboBoxEmpresa.DataSource = EmpresaDal.BuscarEmpresas();


        }

        private bool verificarCampos()
        {
            //if ((Convert.ToInt32(textImporte.SelectedText)) < 0)
            //{
            //    MessageBox.Show("Error: El nro de Factura debe ser numérico o mayor a CERO.");
            //}
            if (DateTime.Compare(dateTimePicker1.Value, DateTime.Today) < 0)
            {
                MessageBox.Show("Error: la fecha de vencimiento debe ser posterior a la actual.");
            }
            string msjFalla = "";
            //if (textBox3.Text == "" || tieneLetras(textBox1.Text)) { msjFalla = msjFalla + "Ingresar ID Cliente"; }
            //if (textBox3.Text == "" || tieneLetras(textBox2.Text)) { msjFalla = msjFalla + "Ingresar ID Empresa"; }
            //if (textBox3.Text == "" || tieneLetras(textBox3.Text)) { msjFalla = msjFalla + "Ingresar Codigo válido"; }
            //if (textBox4.Text == "" || tieneLetras(textBox7.Text)) { msjFalla = msjFalla + "Ingresar importe"; }
            //if (!(DateTime.Compare(dateTimePicker1.Value, DateTime.Now) <= 0)) { msjFalla = msjFalla + "Fecha inválida"; }
            //if (!(DateTime.Compare(dateTimePicker2.Value, DateTime.Now) <= 0)) { msjFalla = msjFalla + "Fecha inválida"; }
            //if ((textBox5.Text == "") || tieneLetras(textBox5.Text)) { msjFalla = msjFalla + "Habilitado"; }
            if (msjFalla == "") { return true; }
            else { MessageBox.Show(msjFalla); return false; }
        }
        private bool tieneLetras(string texto)
        {
            string letras = "abcdefghijklmmñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            bool rta = false;
            foreach (char letra in texto)
            {
                if (letras.Contains(letra)) { rta = true; return rta; };
            }
            return rta;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Alta_Factura_Load(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idImporte = Convert.ToInt32(textCliente.AutoCompleteSource.ToString());
           
            //if (idImporte > 0)
            //{
            //    textBox1.Text = Descripcion;
            //}

        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (verificarCampos())
            {
                //DAR DE ALTA EN LA ENTIDAD FACTURAPAGO Y FACTURAXPAGO
                //FacturaDal.registrar(
                //    Int32.Parse(comboBox1.ValueMember), 
                //    Int32.Parse(comboBox2.ValueMember), 
                //    textBox2.Text, 
                //    //dateTimePicker1.Value, 
                //    DateTime.Now,
                //    dateTimePicker2.Value
                //    );
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factura f = new Factura();
            List<Factura> facturasElegidas = new List<Factura>();

            facturasElegidas = f.getFacturasPorDatosDeFactura(textBoxNroFact.Text, dateTimePicker1.Value,Convert.ToDecimal(textCliente.Text.ToString()));
            if (facturasElegidas.Count() > 0)
            {
                listar_factura lstFact = new listar_factura(facturasElegidas, labelSucursal.Text, Convert.ToDecimal(textCliente.Text.ToString()));
                lstFact.ShowDialog();
               
            }
           }

        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdProducto = Convert.ToInt32(textCliente.SelectedText);
            string Descripcion = Convert.ToString(textCliente.Text);
            //if (IdProducto > 0)
            //{
            //    textBox1.Text = Descripcion;
            //}
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
         
    }
}
