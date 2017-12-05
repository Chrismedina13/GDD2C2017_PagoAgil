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
            CargarListadoSucursales();
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


        private void CargarListadoSucursales()
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
            if (comboBox1.SelectedItem.ToString() == "Cobrador")
            {
                if (verificarCantCheck())
                {
                    int res = UsuarioDAL.CrearCuenta(txtUsuario.Text, txtContrasenia.Text, comboBox1.SelectedItem.ToString());
                    if (res > 0)
                    {
                        verificarSucursalCobrador(res);
                        MessageBox.Show("Cuenta del Cobrador Creada Correctamente !");
                    }
                    else
                    {
                        MessageBox.Show("Error. No se pudo registrar el usuario");
                    }
 
                }
            }
            else
            {
                int res = UsuarioDAL.CrearCuenta(txtUsuario.Text, txtContrasenia.Text, comboBox1.SelectedItem.ToString());
                if (res > 0)
                {
                   altaAdmin(res);
                   MessageBox.Show("Cuenta Creada Correctamente !");
                }
                else
                {
                    MessageBox.Show("Error. No se pudo registrar el usuario");
                }
            }
        }
        private bool verificarCantCheck()
        {
            int i = 0;
            List<int> ChkedRow = new List<int>();
            try
            {
                for (i = 0; i <= dataGridView2.RowCount - 1; i++)
                {
                    if (Convert.ToBoolean(dataGridView2.Rows[i].Cells["seleccion"].Value) == true)
                    {
                        ChkedRow.Add(i);
                    }
                }
                if (ChkedRow.Count == 0 && ChkedRow.Count > 1) { return false; }
                 return true;
            }
            catch (Exception e) { return false; }
        }
        private bool verificarSucursalCobrador(int id)
        { int i = 0;
            List<int> ChkedRow = new List<int>();
            try
            {
                for (i = 0; i <= dataGridView2.RowCount - 1; i++)
                {
                    if (Convert.ToBoolean(dataGridView2.Rows[i].Cells["seleccion"].Value) == true)
                    {
                        ChkedRow.Add(i);
                    }
                }
                if (ChkedRow.Count == 0 && ChkedRow.Count > 1) { return false; }
                foreach (int k in ChkedRow)
                {
                    int sucursal= Int32.Parse(dataGridView2.Rows[k].Cells[1].Value.ToString());
                    Sucursal.insert(id,sucursal);
                    
                }return true;
            }
            catch (Exception e) { return false; }
 
        }


        private bool altaAdmin(int id)
        {
            int i = 0;
            List<int> ChkedRow = new List<int>();
            try
            {
                for (i = 0; i <= dataGridView2.RowCount - 1; i++)
                {
                    if (Convert.ToBoolean(dataGridView2.Rows[i].Cells["seleccion"].Value) == true)
                    {
                        ChkedRow.Add(i);
                    }
                }
                if (ChkedRow.Count == 0) { return false; }
                foreach (int k in ChkedRow)
                {
                    Sucursal.insert(id, Int32.Parse(dataGridView2.Rows[k].Cells[1].Value.ToString()));

                } return true;
            }
            catch (Exception e) { return false; }

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
