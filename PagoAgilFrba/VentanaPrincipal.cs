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
using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmEmpresa;
using PagoAgilFrba.AbmSucursal;
using PagoAgilFrba.ListadoEstadistico;


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
            InitializeComponent();
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VentanaPrincipal_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            abm_cliente form3 = new abm_cliente();
            form3.Show();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            abm_empresa form11 = new abm_empresa();
            form11.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Abm_sucursal form4 = new Abm_sucursal();
            form4.Show();
        }


        private void button10_Click(object sender, EventArgs e)
        {
            estadistica form10 = new estadistica();
            form10.Show();
        }

    }
}
