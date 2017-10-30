using PagoAgilFrba.AbmRol;
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
    public partial class VentanaPrincipal : Form
    {
        public String user { get; set; }
        public VentanaPrincipal()
        {
            InitializeComponent();
        }
        public VentanaPrincipal(String nombre)
        {
            this.user = nombre;
            InitializeComponent();
            this.CargarComboFuncionalidades();
        }

        private void CargarComboFuncionalidades()
        {

            label1.Text = label1.Text + user;
            //Vaciar comboBox
            comboBox1.DataSource = null;
            Funcionalidad f = new Funcionalidad();
            //Indicar qué propiedad se verá en la lista
            this.comboBox1.DisplayMember = "funcionalidad_descripcion";
            //Indicar qué valor tendrá cada ítem
            this.comboBox1.ValueMember = "ID";
            //Asignar la propiedad DataSource
            this.comboBox1.DataSource = f.getAllFuncionalidades();


        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
