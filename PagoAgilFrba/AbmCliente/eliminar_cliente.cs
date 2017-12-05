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
    public partial class eliminar_cliente : Form
    {
        public eliminar_cliente()
        {
            InitializeComponent();
            Database.cargarGriddCliente(dataGridViewEliminarC, "", "", "");
        }

        private void boton_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void eliminar_cliente_Load(object sender, EventArgs e)
        {

        }

        private void boton_eliminar_Click(object sender, EventArgs e)
        {
            String dni = textDni.Text;
            String nombre = textNombre.Text;
            String apellido = textApellido.Text;

            if (!System.Text.RegularExpressions.Regex.IsMatch(textDni.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textNombre.Text.Trim() == "" | textApellido.Text.Trim() == "" | textDni.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (false)
            {
                MessageBox.Show("Verificar que el DNI haya sido ingresado de forma correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var respuesta = MessageBox.Show("¿Estas seguro?", "Confirme borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    Database.deleteCliente(nombre, apellido, dni);
                    this.limpiarCuadrosDeTexto();
                    Database.cargarGriddCliente(dataGridViewEliminarC, "", "", "");
                }
                else return;
            }
        }

        private void limpiarCuadrosDeTexto()
        {
            textNombre.Text = "";
            textApellido.Text = "";
            textDni.Text = "";

        }

        
    }
  
}
