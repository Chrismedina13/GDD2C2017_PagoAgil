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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class modificarElegido : Form
    {
        public modificarElegido(String rubro, String nombre, String direccion, String cuit)
        {
            InitializeComponent();

            lblRubro.Text = rubro;
            lblNombre.Text = nombre;
            lblDireccion.Text = direccion;
            lblCuit.Text = cuit;
            //lblHabilitado.Text = Database.habilitadaEmpresa();


            List<String> Rubros = new List<String>();
            Rubros = Database.getRubros();
            foreach (string elem in Rubros)
            {
                cmbRubro.Items.Add(elem);
            }
        }
        private void modificarElegido_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!(txtHabilitado.Text == "0" || txtHabilitado.Text == "1"))
            {
                MessageBox.Show("Debe ingresar 0 o 1 para habilitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        /*    if (!System.Text.RegularExpressions.Regex.IsMatch(txtCuit.Text, @"^\d+$"))
            {
                MessageBox.Show("Debe ingresar el CUIL numérico de la empresa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } */

            String Rubro = lblRubro.Text;
            String nombre = lblNombre.Text;
            String direccion = lblDireccion.Text;
            String Cuit = lblCuit.Text;
            String RubroNuevo = cmbRubro.Text;
            String nombreNuevo = txtNombre.Text;
            String direccionNueva = txtDireccion.Text;
            String cuitNuevo = txtCuit.Text;
            String habilitadoNuevo = txtHabilitado.Text;

            int idRubro = Database.idDelRubro(RubroNuevo);



            Database.modificarEmpresa(Rubro, nombre, direccion, Cuit, idRubro, nombreNuevo, direccionNueva, cuitNuevo, habilitadoNuevo);


            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
