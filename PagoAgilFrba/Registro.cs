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
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (UsuarioDAL.CrearCuenta(txtUsuario.Text, txtContrasenia.Text) > 0)
            {
                MessageBox.Show("Cuenta Creada Correctamente!");
            }
            else
            {
                MessageBox.Show("No se pudo crear la cuenta :(");
            }
        }
    }
}
