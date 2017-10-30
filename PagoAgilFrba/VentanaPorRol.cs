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
    public partial class VentanaPorRol : Form
    {
        public VentanaPorRol()
        {
            InitializeComponent();
        }
        public String nombreUser { get; set; }

        public VentanaPorRol(String idUser)
        {
            this.nombreUser = idUser;
            InitializeComponent();
            CargarComboRol();

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
            this.comboBox1.DataSource = rol.getRolPorUsuario(this.nombreUser);


        }
        private void VentanaPorRol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text.ToString() == "Administrativo")
            {
                VentanaPrincipal nuevaVentanta = new VentanaPrincipal(nombreUser);
                nuevaVentanta.ShowDialog();
                this.Hide();
            }
            else
            {
                if (this.comboBox1.Text.ToString() == "Administrativo")
                {
                    VentanaPrincipal nuevaVentanta = new VentanaPrincipal(nombreUser);
                    nuevaVentanta.ShowDialog();
                    this.Hide();
                }
                else
                {
                    VentanaCobrador nuevaVentana = new VentanaCobrador(nombreUser);
                    nuevaVentana.ShowDialog();
                    this.Hide();

                }
            }
        }
    }
}
