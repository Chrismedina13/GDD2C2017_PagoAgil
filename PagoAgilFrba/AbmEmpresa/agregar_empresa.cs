using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class agregar_empresa : Form
    {

        public agregar_empresa()
        {

            InitializeComponent();

            List<String> Rubros = new List<String>();
          /* Rubros = Database.getRubrosEmpresa();
            foreach (string marca in Marcas)
            {
                cmbMarca.Items.Add(marca);
            }*/ //      PARA LLENEAR EL COMBO DE RUBROS

        }

        private void agregar_empresa_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agregarEmpresa_Click(object sender, EventArgs e)
        {
            String rubro = comboRubro.Text;
            String direccion = Direccion.Text;
            String Cuit = cuit.Text;
            String Nombre = nombre.Text;

            if (comboRubro.Text.Trim() == "" | cuit.Text.Trim() == "" | Direccion.Text.Trim() == "" | nombre.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (true) //Database.cuilExiste(cuit))
            {
                MessageBox.Show("El cuil ingresada ya esta en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                //Database.addEmpresa(Nombre,Cuit,rubro,direccion);
                this.limpiarCuadrosDeTexto();
                MessageBox.Show("Empresa ingresads correctamente", "Estado", MessageBoxButtons.OK);
            }

        }

        private void limpiarCuadrosDeTexto()
        {
            comboRubro.Text = "";
            Direccion.Text = "";
            cuit.Text = "";
            nombre.Text = "";
        }

        private void cmbRubro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
