using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Support;

namespace PagoAgilFrba.AbmCliente
{

    public partial class agregar_cliente : Form
    {
        public agregar_cliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void bnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textDni.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textTelefono.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el Teléfono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textNombre.Text.Trim() == "" | textApellido.Text.Trim() == "" | textDni.Text.Trim() == "" | textTelefono.Text.Trim() == "" | textDireccion.Text.Trim() == "" | dateTimePickerFechaNac.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                String nombre = textNombre.Text;
                String apellido = textApellido.Text;
                String dni = textDni.Text;
                String mail = textMail.Text;
                String telefono = textTelefono.Text;
                String direccion = textDireccion.Text;
                String codigoPostal = textCodigoPostal.Text;
                int localidad = 3;
                String fechanacimiento = dateTimePickerFechaNac.Text;
                DateTime fecha = Convert.ToDateTime(fechanacimiento);
                Database.AddCliente(nombre, apellido, dni, mail, telefono, direccion,codigoPostal,localidad,fechanacimiento);
                this.limpiarCuadrosDeTexto();
            }

        }

        private void limpiarCuadrosDeTexto()
        {
            textNombre.Text = "";
            textApellido.Text = "";
            textDni.Text = "";
            textMail.Text = "";
            textTelefono.Text = "";
            textDireccion.Text = "";
            dateTimePickerFechaNac.Text = "";

        }

        private void dateTimePickerFechaNac_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
