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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void IniciarSesion_Click(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == txtContrasenia.Text)
            {
                if (UsuarioDAL.Autenticacion(txtUsuario.Text, txtContrasenia.Text))
                {
                    VentanaPorRol vpr = new VentanaPorRol(txtUsuario.Text);
                    this.Hide();
                    vpr.ShowDialog();
                }
                else
                {

                    MessageBox.Show("Error al iniciar sesion");
                }
            }
        }
    }
}
