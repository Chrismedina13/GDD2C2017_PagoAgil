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
    public partial class agregar_empresa : Form
    {

        public agregar_empresa()
        {

            InitializeComponent();

            List<String> Rubros = new List<String>();
            Rubros = Database.getRubros();
            foreach (string rubro in Rubros)
            {
                comboRubro.Items.Add(rubro);
            }

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
            else if (Database.cuitExistente(Cuit))
            {
                MessageBox.Show("El cuil ingresada ya esta en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int idRubro = Database.idDelRubro(rubro);
   
                Database.AddEmpresa(Nombre,Cuit,idRubro,direccion);
                this.limpiarCuadrosDeTexto();
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
