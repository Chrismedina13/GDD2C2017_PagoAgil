using PagoAgilFrba.AbmRol;
using PagoAgilFrba.AbmSucursal;
using PagoAgilFrba.AbmUsuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            CargarComboRol();
            CargarComboSucursales();
        }
        private void CargarComboRol()
        {
            //Vaciar comboBox
            comboBox1.DataSource = null;
            Rol rol = new Rol();
            //Indicar qué propiedad se verá en la lista
            this.comboBox1.DisplayMember = "RolesPorUsuario";
            //Indicar qué valor tendrá cada ítem
            this.comboBox1.ValueMember = "RolesPorUsuario";
            //Asignar la propiedad DataSource
            this.comboBox1.DataSource = rol.getAllRoles();


        }


        private void CargarComboSucursales()
        {
            //Vaciar comboBox
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = null;
            Sucursal s = new Sucursal();
            List<Sucursal> listFunc = s.getListSucursales();
            //Asignar la propiedad DataSource
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            dataGridView2.Columns.Add(chkbox);
            chkbox.HeaderText = "Check Data";
            chkbox.Name = "seleccion";

            this.dataGridView2.DataSource = listFunc;
            //this.dataGridView1.DataBindin();

        }






        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (UsuarioDAL.CrearCuenta(txtUsuario.Text, txtContrasenia.Text,comboBox1.SelectedItem.ToString()) > 0)
            {
                MessageBox.Show("Cuenta Creada Correctamente!");
            }
            else
            {
                MessageBox.Show("No se pudo crear la cuenta :(");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
