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
    public partial class eliminar_sucursal : Form
    {
        public eliminar_sucursal()
        {
            InitializeComponent();
            Database.cargarGriddSucursal(dataGridViewEliminarSucursal, "", "", "");
        }

        private void boton_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void eliminar_sucursal_Load(object sender, EventArgs e)
        {

        }

        private void boton_eliminar_Click(object sender, EventArgs e)
        {
             String codigoPostal = textCodigoPostal.Text;
             String nombre = textNombre.Text;
             String direccion = textDireccion.Text;

             if (!System.Text.RegularExpressions.Regex.IsMatch(textCodigoPostal.Text, @"^\d+$"))
             {
                 MessageBox.Show("Sólo se permiten numeros en el Codigo Postal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }
             if (textNombre.Text.Trim() == "" | textDireccion.Text.Trim() == "" | textCodigoPostal.Text.Trim() == "" )
            {
                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
           
          var respuesta = MessageBox.Show("¿Estas seguro?","Confirme borrado",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          if (respuesta == DialogResult.Yes)
             {
               Database.deleteSucursal(nombre,direccion, codigoPostal);
               this.limpiarCuadrosDeTexto();
               Database.cargarGriddSucursal(dataGridViewEliminarSucursal,"","","");
             }
                else return;
            }

        private void limpiarCuadrosDeTexto()
        {
            textNombre.Text = "";
            textCodigoPostal.Text = "";
            textDireccion.Text = "";
                        
        }
    }
}
