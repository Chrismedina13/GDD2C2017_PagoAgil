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

namespace PagoAgilFrba.AbmFactura
{
    public partial class Alta_Factura : Form
    {
        public Alta_Factura()
        {
            InitializeComponent();
            CargarComboClientes();
            CargarComboEmpresas();
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
                FacturaDal.registrar(
                    Int32.Parse(comboBox1.ValueMember), 
                    Int32.Parse(comboBox2.ValueMember), 
                    textBox2.Text, 
                    dateTimePicker1.Value, 
                    dateTimePicker2.Value,
                    textBox4.Text);
            }
        }
        private bool verificarCampos()
        {
            string msjFalla = "";
            if (textBox3.Text == "" || tieneLetras(textBox1.Text)) { msjFalla = msjFalla + "Ingresar ID Cliente"; }
            if (textBox3.Text == "" || tieneLetras(textBox2.Text)) { msjFalla = msjFalla + "Ingresar ID Empresa"; }
            if (textBox3.Text == "" || tieneLetras(textBox3.Text)) { msjFalla = msjFalla + "Ingresar Codigo válido"; }
            if (textBox4.Text == "" || tieneLetras(textBox7.Text)) { msjFalla = msjFalla + "Ingresar importe"; }
            if (!(DateTime.Compare(dateTimePicker1.Value, DateTime.Now) <= 0)) { msjFalla = msjFalla + "Fecha inválida"; }
            if (!(DateTime.Compare(dateTimePicker2.Value, DateTime.Now) <= 0)) { msjFalla = msjFalla + "Fecha inválida"; }
            if ((textBox5.Text == "") || tieneLetras(textBox5.Text)) { msjFalla = msjFalla + "Habilitado"; }
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
       
    }
}
