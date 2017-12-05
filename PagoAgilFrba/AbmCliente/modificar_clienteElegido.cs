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
    public partial class modificar_clienteElegido : Form
    {
        String nombre;
        String apellido;
        String dni;

        public modificar_clienteElegido(String nombreViejo, String apellidoViejo, String dniViejo)
        {
            InitializeComponent();

            nombre = nombreViejo;
            apellido = apellidoViejo;
            dni = dniViejo;

            if (!System.Text.RegularExpressions.Regex.IsMatch(textDniN.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textTelefonoN.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el Teléfono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(textHabilitado.Text == "0" || textHabilitado.Text == "1"))
            {
                MessageBox.Show("Ingrese 1 o 0 para la habilitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String[] datosClienteElegido = new String[8];
            datosClienteElegido = Database.getDatosCliente(nombreViejo, apellidoViejo, dniViejo);
            textNombreN.Text = datosClienteElegido[0];
            textApellidoN.Text = datosClienteElegido[1];
            textDniN.Text = datosClienteElegido[2];
            textMailN.Text = datosClienteElegido[3];
            textDireccionN.Text = datosClienteElegido[4];
            textTelefonoN.Text = datosClienteElegido[5];
            dateTimePickerFechaNacN.Text = datosClienteElegido[6];
            textHabilitado.Text = datosClienteElegido[7];


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {

            String nombreNuevo = textNombreN.Text;
            String apellidoNuevo = textApellidoN.Text;
            String dniNuevo = textDniN.Text;
            String mailNuevo = textMailN.Text;
            String telefonoNuevo = textTelefonoN.Text;
            String direccionNueva = textDireccionN.Text;
            String fechaNacimientoNueva = dateTimePickerFechaNacN.Text;
            DateTime fechaAPoner = Convert.ToDateTime(fechaNacimientoNueva);
            String habilitadoNuevo = textHabilitado.Text;
            if (nombreNuevo == "" | apellidoNuevo == "" | dniNuevo == "" | telefonoNuevo == "" | direccionNueva == "" | fechaNacimientoNueva == "" | habilitadoNuevo == "")
            {
                MessageBox.Show("Verifique que los campos obligatorios hayan sido completados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (false)
            {
                MessageBox.Show("Verifique que el dni sea valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Database.modificarCliente(nombre, apellido, dni, nombreNuevo, apellidoNuevo, dniNuevo, telefonoNuevo, direccionNueva, mailNuevo, fechaAPoner, habilitadoNuevo);
                this.limpiarCuadrosDeTexto();
                this.Close();
            }


        }

        private void limpiarCuadrosDeTexto()
        {

            textNombreN.Text = "";
            textApellidoN.Text = "";
            textDniN.Text = "";
            textMailN.Text = "";
            textTelefonoN.Text = "";
            textDireccionN.Text = "";
            dateTimePickerFechaNacN.Text = "";
            textHabilitado.Text = "";
           

        }


    }
}
