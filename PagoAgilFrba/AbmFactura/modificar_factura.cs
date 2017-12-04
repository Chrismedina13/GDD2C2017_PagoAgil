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
    public partial class modificar_factura : Form
    {
        public modificar_factura()
        {
            InitializeComponent();
        }
        Factura facturaSinModif;
        public modificar_factura(Factura f)
        {
            InitializeComponent();
            dateTimePicker1.Text = f.fechaAlta.ToString() ;
            dateTimePicker2.Text = f.fechaVenc.ToString();
            textTotal.Text = f.total.ToString();
            textNroFactura.Text = f.codFactura.ToString();
            textCliente.Text = f.cli_dni.ToString();
            comboBoxEmpresa.Text = f.empresa_id.ToString();
            facturaSinModif = f;
        }

        private void modificar_factura_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factura factuModif = new Factura();
            if (dateTimePicker1.Text != facturaSinModif.fechaAlta.ToString())
            {
                factuModif.fechaAlta = dateTimePicker1.Value;
            }
            if (dateTimePicker2.Text !=facturaSinModif.fechaVenc.ToString())
            {
                factuModif.fechaVenc = dateTimePicker2.Value;
            }
            if (textTotal.Text != facturaSinModif.total.ToString())
            {
                factuModif.total = Convert.ToDecimal(textTotal.Text);
            }
            if (textNroFactura.Text != facturaSinModif.codFactura.ToString())
            {
                 factuModif.codFactura=Convert.ToInt32(textNroFactura.Text);
            }
            if (textCliente.Text != facturaSinModif.cli_dni.ToString())
            {
                 factuModif.cli_dni=Convert.ToDecimal(textCliente.Text);
            }
            if (comboBoxEmpresa.Text != facturaSinModif.empresa_id.ToString())
            {
                factuModif.empresa_id = Convert.ToInt32(comboBoxEmpresa.SelectedIndex.ToString());
            }
            factuModif.facturaId = facturaSinModif.facturaId;
            if (FacturaDal.ModificarFactura(factuModif))
            {
                MessageBox.Show("Se modifico correctamente la factura!");
            }
            else
            {
                MessageBox.Show("Error. No se pudo modificar la factura");
            }
        }
    }
}
