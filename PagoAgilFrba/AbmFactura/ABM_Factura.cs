using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public partial class ABM_Factura : Form
    {
        public ABM_Factura()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Alta_Factura af = new Alta_Factura();
            //af.Show();
            ALTAFACTURA afposta = new ALTAFACTURA();
            afposta.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listar_modif_elim modelim = new listar_modif_elim();
            modelim.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            eliminar_factura ef = new eliminar_factura();
            ef.Show();

        }
    }
}
