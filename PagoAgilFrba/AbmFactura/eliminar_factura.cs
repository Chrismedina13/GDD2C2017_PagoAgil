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
    public partial class eliminar_factura : Form
    {
        public eliminar_factura()
        {
            InitializeComponent();
        }
        Factura factAEliminar;
        public eliminar_factura(Factura f)
        {
            InitializeComponent();
            Cliente.Text = f.cli_dni.ToString();
            fechaSistema.Text=DateTime.Today.ToString("dd/MM/yyyy");
            fechaVto.Text = f.fechaVenc.ToString();
            empresa.Text = f.empresa_id.ToString();
            importe.Text = f.total.ToString();
            nroFactura.Text = f.codFactura.ToString();
            factAEliminar = f;
        }


        private void eliminar_factura_Load(object sender, EventArgs e)
        {

        }

        private void fechaVto_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FacturaDal.EliminarFactura(factAEliminar))
            {
                MessageBox.Show("Se eliminó correctamente.");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error. No se pudo eliminar la factura");
            }
        }
    }
}
