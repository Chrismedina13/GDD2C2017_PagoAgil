using PagoAgilFrba.AbmFactura;
using PagoAgilFrba.Devoluciones;
using PagoAgilFrba.ListadoEstadistico;
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
    public partial class VentanaCobrador : Form
    {
        public String user { get; set; }
        public String rolUser { get; set; }
        public VentanaCobrador()
        {
            InitializeComponent();
        }
        public VentanaCobrador(String nombre,String rol)
        {
            this.user = nombre;
            rolUser = rol;
            InitializeComponent();
           // label1.Text = label1.Text + " " + user;
            label2.Text = user;
        }
        private void VentanaCobrador_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alta_Factura af = new Alta_Factura(user,rolUser);
            af.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            estadistica est = new estadistica();
            est.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
