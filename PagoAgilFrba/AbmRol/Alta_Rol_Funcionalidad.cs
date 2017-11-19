using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class Alta_Rol_Funcionalidad : Form
    {
        public Alta_Rol_Funcionalidad()
        {
            InitializeComponent();
            CargarComboFuncionalidades();
        }
        private void CargarComboFuncionalidades()
        {
            //Vaciar comboBox
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            Funcionalidad f = new Funcionalidad();
            List<Funcionalidad>listFunc= f.getListFuncionalidades();
            //Asignar la propiedad DataSource
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chkbox);
            chkbox.HeaderText = "Check Data";
            chkbox.Name = "seleccion";
            
            this.dataGridView1.DataSource = listFunc;
            //this.dataGridView1.DataBindin();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Rol rol = new Rol();
                if(textBox1.Text!="")
                {
                    rol.Nombre = textBox1.Text;
                    int res =RolDAL.insert(rol.Nombre);
                    if (res>0)
                    {
                        int resultado = agregarFuncionalidades(res);
                    }
                }
                else{
                    MessageBox.Show("Debe ingresar un nombre de ROL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el alta de rol -"+ ex.Message);
            }
        }
        private int agregarFuncionalidades(int idRol) {
            int i = 0;
            List<int> ChkedRow = new List<int>();
            try
           {
                for (i = 0; i <= dataGridView1.RowCount - 1; i++) 
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["seleccion"].Value) == true) 
                    {
                        ChkedRow.Add(i);
                    }
                }
                if (ChkedRow.Count == 0){return 0;}
                foreach (int k in ChkedRow)
                {
                   Funcionalidad.insert(idRol, Int32.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()));
                }
                MessageBox.Show("Rol y funcionalidades registrados Correctamente!");
                Alta_Rol_Funcionalidad af = new Alta_Rol_Funcionalidad();
                af.Close();
            }
            catch (Exception e){return 0;}
            return 0;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
