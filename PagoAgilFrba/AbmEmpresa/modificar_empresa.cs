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
    public partial class modificar_empresa : Form
    {
        public modificar_empresa()
        {
            InitializeComponent();

            List<String> rubros = new List<String>();
            //rubros = Database.getRubros();
            foreach (string rubro in rubros)
            {
                cmbRubro.Items.Add(rubro);
            }
        }

        private void modificar_empresa_Load(object sender, EventArgs e)
        {
            //Database.cargarGriddEmpresa(dataGridView1,"","","","");
            //dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                txtNombre.Text = row.Cells["empresa_nombre"].Value.ToString();
                txtCuit.Text = row.Cells["empresa_cuit"].Value.ToString();
                cmbRubro.SelectedIndex = cmbRubro.FindString(row.Cells["comboRubro"].Value.ToString());
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
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
            else{
                var respuesta = MessageBox.Show("¿Estas seguro?","Confirme modificado",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    String Rubro = cmbRubro.Text;
                    String Nombre = txtNombre.Text;
                    String Cuit = txtCuit.Text;
                    
                    String Direccio;
                    Direccio = "hola";

                    //Direccio = Database.getDireccionEmpresa(Rubro,Nombre,Cuit);
                    if (Direccio != null)
                    {
                      //  modificarElegido form = new modificarElegido(Rubro,Nombre,Cuit,Direccio);
                        //form.Show();
                        limpiarCuadrosDeTexto();
                        //Database.cargarGriddAutomovil(dataGridView1, "", "", "");
               
                    }
                    else MessageBox.Show("Los datos ingresados no corresponden a ningun registro","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

            //Database.cargarGriddEmpresa(dataGridView1, cmbRubro.Text, txtNombre.Text, txtCuit.Text);
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            //Database.cargarGriddEmpresa(dataGridView1, cmbRubro.Text, txtNombre.Text, txtCuit.Text);
        }

        private void cmbRubro_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void cmbRubro_MouseClick(object sender, MouseEventArgs e)
        {
            //Database.cargarGriddEmpresa(dataGridView1, cmbRubro.Text, txtNombre.Text, txtCuit.Text);

        }

        private void cmbRubro_DropDownClosed(object sender, EventArgs e)
        {
            //Database.cargarGriddEmpresa(dataGridView1, cmbRubro.Text, txtNombre.Text, txtCuit.Text);
        }
    }
}
