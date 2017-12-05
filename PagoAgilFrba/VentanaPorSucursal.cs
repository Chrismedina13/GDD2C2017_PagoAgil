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
         public String nombreUser { get; set; }
         public String rolUser { get; set; }
        public VentanaPorSucursal()
        {
            InitializeComponent();
        }
          public VentanaPorSucursal(String idUser,String rolUsuario)
        {
            this.nombreUser = idUser;
            rolUser = rolUsuario;
            InitializeComponent();
            CargarComboSucursal(idUser,rolUsuario);

        }
          private void CargarComboSucursal(String idUser, String rolUsuario)
          {
              //Vaciar comboBox
              comboBox1.DataSource = null;
              Sucursal suc = new Sucursal();
              //Indicar qué propiedad se verá en la lista
              this.comboBox1.DisplayMember = "UsuarioPorSucursal";
              //Indicar qué valor tendrá cada ítem
              this.comboBox1.ValueMember = "UsuarioPorSucursal";
              //Asignar la propiedad DataSource
              this.comboBox1.DataSource = suc.getSucursalPorUsuario(this.nombreUser,rolUsuario);
          }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                    if (rolUser == "Administrativo")
            {
                VentanaPrincipal nuevaVentanta = new VentanaPrincipal(nombreUser,rolUser);
                nuevaVentanta.ShowDialog();
                this.Hide();
            }
            else
            {
                VentanaCobrador vcob = new VentanaCobrador(nombreUser,rolUser);
                vcob.Show();
                this.Hide();
            }
        }

        private void VentanaPorSucursal_Load(object sender, EventArgs e)
        {

        }
    }
}
