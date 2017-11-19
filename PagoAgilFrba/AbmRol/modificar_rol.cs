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
            int IdProducto = Convert.ToInt32(comboBox1.SelectedValue);
            string Descripcion = Convert.ToString(comboBox1.Text);
             if(IdProducto > 0){
                 textBox1.Text = Descripcion;
             }
        }

         private void btnGuardar_Click(object sender, EventArgs e)
         {
             int IdProducto = Convert.ToInt32(comboBox1.SelectedValue);
             string Descripcion = Convert.ToString(comboBox1.Text);
             if (RolDAL.ModificarRol(IdProducto, textBox1.Text, 1))
             {
                 MessageBox.Show("Se modificó el rol "+ textBox1.Text);
             }
             else {
                 MessageBox.Show("Error al intentar modificar el rol seleccionado "+IdProducto);
             }
             CargarComboRoles();
         }

         private void btnVolver_Click(object sender, EventArgs e)
         {
             this.Close();
         }
       
    }
   
}
