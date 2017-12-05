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
    public partial class modificar_cliente : Form
    {
        public modificar_cliente()
        {
            InitializeComponent();
            Database.cargarGriddCliente(dataGridViewModificarC, "", "", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            String nombre = textNombre.Text;
            String apellido = textApellido.Text;
            String dni = textDni.Text;
            if (textNombre.Text.Trim() == "" | textApellido.Text.Trim() == "" | textDni.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var respuesta = MessageBox.Show("¿Estas seguro?", "Confirme borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    modificar_clienteElegido form = new modificar_clienteElegido(nombre, apellido, dni);
                    this.limpiarCuadrosDeTexto();
                    form.Show();
                }
            }
        }

        private void modificar_cliente_Load(object sender, EventArgs e)
        {

        }



        private void limpiarCuadrosDeTexto()
        {

            textNombre.Text = "";
            textApellido.Text = "";
            textDni.Text = "";


        }

    }
}
