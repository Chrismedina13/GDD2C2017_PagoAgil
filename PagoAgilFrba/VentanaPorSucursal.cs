using PagoAgilFrba.AbmSucursal;
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
    public partial class VentanaPorSucursal : Form
    {
        public VentanaPorSucursal()
        {
            InitializeComponent();
        }
         public String nombreUser { get; set; }

        public VentanaPorSucursal(String idUser)
        {
            this.nombreUser = idUser;
            InitializeComponent();
            CargarComboSucursal();

        }
        private void CargarComboSucursal()
        {
            //Vaciar comboBox
            comboBox1.DataSource = null;
            Sucursal suc = new Sucursal();
            //Indicar qué propiedad se verá en la lista
            this.comboBox1.DisplayMember = "UsuarioPorSucursal";
            //Indicar qué valor tendrá cada ítem
            this.comboBox1.ValueMember = "UsuarioPorSucursal";
            //Asignar la propiedad DataSource
            this.comboBox1.DataSource = suc.getSucursalPorUsuario(this.nombreUser);


        }
        private void VentanaPorSucursal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
