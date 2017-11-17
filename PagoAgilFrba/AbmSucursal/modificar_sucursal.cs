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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class modificar_sucursal : Form
    {
       public modificar_sucursal()
        {
            InitializeComponent();
            Database.cargarGriddSucursal(dataGridViewModificarSucursal,"", "", "");
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
            String codigoPostal = textCodigoPostal.Text;
            String direccion = textDireccion.Text;
            if (!System.Text.RegularExpressions.Regex.IsMatch(textCodigoPostal.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el Codigo Postal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textNombre.Text.Trim() == "" | textCodigoPostal.Text.Trim() == "" | textDireccion.Text.Trim() == "" )
            {
                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             var respuesta = MessageBox.Show("¿Estas seguro?", "Confirme modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                {
                    modificar_sucursalElegida form = new modificar_sucursalElegida(nombre, codigoPostal, direccion);                  
                    form.Show();
                }
            
        }

        private void modificar_sucursal_Load(object sender, EventArgs e)
        {
        
        }
            
    }
}
