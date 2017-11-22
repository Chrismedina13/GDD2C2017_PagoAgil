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
using PagoAgilFrba.AbmFactura;

namespace PagoAgilFrba
{
    public partial class VentanaPrincipal : Form
    {
        public String user { get; set; }
        public VentanaPrincipal(string nombre)
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
            VentanaPorRol vr = new VentanaPorRol();
            vr.Show();
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

        private void button8_Click(object sender, EventArgs e)
        {
            Registro reg = new Registro();
            reg.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ABM_Rol objRol = new ABM_Rol();
            objRol.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
             ABM_Factura abmf = new ABM_Factura();
             abmf.Show();
        }

    }
}
