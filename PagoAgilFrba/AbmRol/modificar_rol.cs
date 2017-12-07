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

            dataGridView1.Columns[1].Visible = false;
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
            Rol r = new Rol();
           
            int i = 0;
            try
            {
                List<Funcionalidad> fs = new List<Funcionalidad>();
                for (i = 1; i <= dataGridView1.RowCount ; i++)
                {
                    
                    if (f.getIdFuncionalidadesPorRol(rol).Contains(i))
                    {
                        dataGridView1.Rows[i-1].Cells["idRolXFunc"].Value = f.getIdFuncionalidadXRol(rol,i);
                       int idRol= r.getidRolPorNombre(rol);
                       if (r.estaHabilitado(idRol))
                       {
                           checkBox1.Checked = true;
                       }
                       //dataGridView1.Rows[i - 1].Cells["idRolXFunc"].Value = f.getFuncionalidadesPorRol(rol).ElementAt(i).IdRolXFunc;
                       //lo voy seleccionando al q cumpla
                        dataGridView1.Rows[i-1].Cells["seleccion"].Value = true;
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
         private int agregarFuncionalidades(string rol)
         {
             int i = 0;
             List<int> ChkedRow = new List<int>();
             Funcionalidad f = new Funcionalidad();
             Rol r = new Rol();
             try
             {
                 for (i = 1; i <= dataGridView1.RowCount ; i++)
                 {     
                     //si esta sin check y esta entre los idsFunc hago un delete
                   
                     //si esta sin checj y no esta entre los idsFunc no hago nada
                     if (Convert.ToBoolean(dataGridView1.Rows[i-1].Cells["seleccion"].Value) == false)
                     {
                         //si esta sin check y esta entre los idsFunc hago un delete

                         //si esta sin checj y no esta entre los idsFunc no hago nada
                         if (f.getIdFuncionalidadXRol(rol, i) != 0)
                         {
                             Funcionalidad.delete(r.getidRolPorNombre(rol), i, f.getIdFuncionalidadXRol(rol, i));
                         }
                         MessageBox.Show("Se modificó el rol " + textBox1.Text);
                     }
                     else
                     {
                         //si esta con check y esta entre los idsFunc no hago nada
                         //si esta con check y no esta entre los idsFunc hago un insert
                         if (f.getIdFuncionalidadXRol(rol, i) == 0)
                         {
                             Funcionalidad.insert(r.getidRolPorNombre(rol), i);
                         }
                         // ChkedRow.Add(i);

                     }
           
                 }
                 if (ChkedRow.Count == 0) { return 0; }
                 //foreach (int k in ChkedRow)
                 //{
                 //    int idFunc=Int32.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString());
                 //    int idFuncXRol=Int32.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString());
                 //    Funcionalidad.update(idRol, idFunc,idFuncXRol);
                 //}
                 MessageBox.Show("Rol y funcionalidades actualizados Correctamente!");
                 modificar_rol af = new modificar_rol();
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
                     
                         int resultado = agregarFuncionalidades(textBox1.Text);
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
