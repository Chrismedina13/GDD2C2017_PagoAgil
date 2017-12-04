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
    public partial class eliminar_empresa : Form
    {
        public eliminar_empresa()
        {
            InitializeComponent();

            List<String> rubros = new List<String>();
            rubros = Database.getRubros();
            foreach (string rubro in rubros)
            {
                cmbRubro.Items.Add(rubro);
            }
        }

        private void eliminar_empresa_Load(object sender, EventArgs e)
        {
            Database.cargarGriddEmpresa(dataGridView1,"","","");
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                txtNombre.Text = row.Cells["empresa_nombre"].Value.ToString();
                txtCuit.Text = row.Cells["empresa_cuit"].Value.ToString();
               // cmbRubro.SelectedIndex = cmbRubro.FindString(row.Cells["comboRubro"].Value.ToString());
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String rubro = cmbRubro.Text;
            String nombre = txtNombre.Text;
            String cuit = txtCuit.Text;

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCuit.Text, @"^\d+$"))
            {
                MessageBox.Show("Debe ingresar el cuit numérico de la empresa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCuit.Text.Trim() == "" | cmbRubro.Text.Trim() == "" | txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Database.cuitHabilitado(cuit))
            {
                MessageBox.Show("La empresa ingresada ya esta dado de baja. Para darlo de alta ingrese en Modificar automivil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var respuesta = MessageBox.Show("¿Estas seguro?","Confirme borrado",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {

                    int idRubro = Database.idDelRubro(rubro);
                    Database.deleteEmpresa(idRubro, nombre, cuit);
                    this.limpiarCuadrosDeTexto();
                    Database.cargarGriddEmpresa(dataGridView1,"","","");
                }
                else return;
            }
        }

        private void limpiarCuadrosDeTexto()
        {
            cmbRubro.Text = "";
            txtNombre.Text = "";
            txtCuit.Text = "";

        }

        private void txtCuit_KeyUp(object sender, KeyEventArgs e)
        {

            Database.cargarGriddEmpresa(dataGridView1, cmbRubro.Text, txtNombre.Text, txtCuit.Text);
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            Database.cargarGriddEmpresa(dataGridView1, cmbRubro.Text, txtNombre.Text, txtCuit.Text);
        }

        private void cmbRubro_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void cmbRubro_MouseClick(object sender, MouseEventArgs e)
        {
            Database.cargarGriddEmpresa(dataGridView1, cmbRubro.Text, txtNombre.Text, txtCuit.Text);

        }

        private void cmbRubro_DropDownClosed(object sender, EventArgs e)
        {
            Database.cargarGriddEmpresa(dataGridView1, cmbRubro.Text, txtNombre.Text, txtCuit.Text);
        }
    }
}
