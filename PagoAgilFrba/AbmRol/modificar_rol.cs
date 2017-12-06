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
    public partial class modificar_rol : Form
    {
        public modificar_rol()
        {
            InitializeComponent();
            CargarComboRoles();
            CargarComboFuncionalidades();
        }
        private void CargarComboFuncionalidades()
        {
            //Vaciar comboBox
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            Funcionalidad f = new Funcionalidad();
            List<Funcionalidad> listFunc = f.getListFuncionalidades();
            //Asignar la propiedad DataSource
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chkbox);
            chkbox.HeaderText = "Check Data";
            chkbox.Name = "seleccion";

            this.dataGridView1.DataSource = listFunc;
            //this.dataGridView1.DataBindin();

        }
        private void BuscarFuncionalidadesPorRol(String rol)
        {
            List<int> ChkedRow = new List<int>();
            Funcionalidad f = new Funcionalidad();
           
            int i = 0;
            try
            {
                for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    if (f.getIdFuncionalidadesPorRol(rol).Contains(i))
                    {
                        //lo voy seleccionando al q cumpla
                        dataGridView1.Rows[i].Cells["seleccion"].Value = true;
                    }
                }
              
              
               
            }
            catch (Exception e) { }
   
        }
        private void CargarComboRoles()
        {
            //Vaciar comboBox
            comboBox1.DataSource = null;
            try
            {
                //Indicar qué propiedad se verá en la lista
                this.comboBox1.DisplayMember = "Nombre";
                //Indicar qué valor tendrá cada ítem
                this.comboBox1.ValueMember = "Id";
                //Asignar la propiedad DataSource
                List<Rol> listita = new List<Rol>();

                listita = RolDAL.BuscarRol();
                //this.comboBox1.Items.Insert(0, "Seleccione un rol");
                listita.Add(new Rol(0, "Seleccione un rol"));
                this.comboBox1.DataSource = listita;
                //this.comboBox1.Items.Add(new KeyValuePair<string, string>("0", "Mujer"));
            }
            catch (Exception e)
            { MessageBox.Show("Error al intentar cargar los roles -"+e.Message); }
          }

         private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                  
                    dataGridView1.Rows[i].Cells["seleccion"].Value = false;
                
            }
            int IdProducto = Convert.ToInt32(comboBox1.SelectedValue);
            string Descripcion = Convert.ToString(comboBox1.Text);
             if(IdProducto > 0){
                 textBox1.Text = Descripcion;
             }

             BuscarFuncionalidadesPorRol(textBox1.Text);
        }
         private int agregarFuncionalidades(int idRol)
         {
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
                 if (ChkedRow.Count == 0) { return 0; }
                 foreach (int k in ChkedRow)
                 {
                     Funcionalidad.update(idRol, Int32.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()));
                 }
                 MessageBox.Show("Rol y funcionalidades registrados Correctamente!");
                 Alta_Rol_Funcionalidad af = new Alta_Rol_Funcionalidad();
                 af.Close();
             }
             catch (Exception e) { return 0; }
             return 0;
         }
         
         private void btnGuardar_Click(object sender, EventArgs e)
         {

             RolDAL roldal = new RolDAL();
             Rol rol = new Rol();
             if (textBox1.Text != "")
             {
                 
                     rol.Nombre = textBox1.Text;
                     if (RolDAL.ModificarRol(roldal.RolId(textBox1.Text), rol.Nombre,Convert.ToInt32(checkBox1.Checked)))
                     {
                         int resultado = agregarFuncionalidades(roldal.RolId(textBox1.Text));
                     }
                 
             }
             else
             {
                 MessageBox.Show("Debe ingresar un nombre de ROL");
             }


             //int IdProducto = Convert.ToInt32(comboBox1.SelectedValue);
             //string Descripcion = Convert.ToString(comboBox1.Text);
             //if (RolDAL.ModificarRol(IdProducto, textBox1.Text, 1))
             //{
             //    MessageBox.Show("Se modificó el rol "+ textBox1.Text);
             //}
             //else {
             //    MessageBox.Show("Error al intentar modificar el rol seleccionado "+IdProducto);
             //}
             //CargarComboRoles();
         }

         private void btnVolver_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void modificar_rol_Load(object sender, EventArgs e)
         {

         }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

         }

         private void checkBox1_CheckedChanged(object sender, EventArgs e)
         {

         }

         private void groupBox1_Enter(object sender, EventArgs e)
         {

         }
       
    }
   
}
