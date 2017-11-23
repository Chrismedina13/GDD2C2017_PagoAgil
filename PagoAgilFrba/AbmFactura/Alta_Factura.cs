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

namespace PagoAgilFrba.AbmFactura
{
    public partial class Alta_Factura : Form
    {
        public Alta_Factura()
        {
            InitializeComponent();
            //CargarComboClientes();
            //CargarComboEmpresas();
            CargarComboItems();
            //
            // cargo la lista de items para el autocomplete
            //

            comboBox4.AutoCompleteCustomSource = ItemDal.LoadAutoComplete();
            comboBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void CargarComboClientes()
        {
            //Vaciar comboBox
            comboBox1.DataSource = null;

            //Indicar qué propiedad se verá en la lista
            this.comboBox1.DisplayMember = "nombre";
            //Indicar qué valor tendrá cada ítem
            this.comboBox1.ValueMember = "dni";
            //Asignar la propiedad DataSource
            this.comboBox1.DataSource = ClienteDal.BuscarClientes();


        }
        private void CargarComboItems()
        {
            //Vaciar comboBox
            comboBox4.DataSource = null;

            //Indicar qué propiedad se verá en la lista
            this.comboBox4.DisplayMember = "descripcion";
            //Indicar qué valor tendrá cada ítem
            this.comboBox4.ValueMember = "item_Id";
            //Asignar la propiedad DataSource
            this.comboBox4.DataSource = ItemDal.BuscarItems();


        }
        private void CargarComboEmpresas()
        {
            //Vaciar comboBox
            comboBox1.DataSource = null;
           
            //Indicar qué propiedad se verá en la lista
            this.comboBox2.DisplayMember = "nombre";
            //Indicar qué valor tendrá cada ítem
            this.comboBox2.ValueMember = "empresaId";
            //Asignar la propiedad DataSource
            this.comboBox2.DataSource = EmpresaDal.BuscarEmpresas();


        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificarCampos())
            {
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
        private bool verificarCampos()
        {
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

       
       
    }
}
