using PagoAgilFrba.RegistroPago;
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
    public partial class FacturaAPagar : Form
    {
        String sucursalF;
        Factura factura;
        public FacturaAPagar()
        {
            InitializeComponent();
        }
        public FacturaAPagar(Factura f,String sucu)
        {
            InitializeComponent();
            nroFactura.Text = Convert.ToString(f.codFactura);
            fechaSistema.Text = Convert.ToString(f.fechaAlta);
            fechaVto.Text = Convert.ToString(f.fechaVenc);
            empresa.Text = Convert.ToString(f.empresa_id);
            importe.Text= Convert.ToString(f.total);
            sucursalF = sucu;
            sucursal.Text = sucursalF;
            //cargarComboMedioDePago();
            factura = f;

        }

     
        private void Cliente_Click(object sender, EventArgs e)
        {

        }

        private void importe_Click(object sender, EventArgs e)
        {

        }

        private void FacturaAPagar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Factura f,String sucu
            this.Hide();
        }

        private void datosPorMedioDePago(object sender, EventArgs e)
        {
            ////Como ahcer que elija el seleccionado , me elige el anterior...
            //if (comboBox1.Text == "Cheque")
            //{
            //    PagoConCheque pcheq = new PagoConCheque(importe.Text);
            //    pcheq.Show();
            //}
            //else
            //{
            //    if (comboBox1.Text == "Tarjeta de Crédito")
            //    {
            //        PagoConTarjetaCredito pcred = new PagoConTarjetaCredito(importe.Text);
            //        pcred.Show();
            //    }
            //    else
            //    {
            //        PagoConDebito pdeb = new PagoConDebito(importe.Text);
            //        pdeb.Show();
            //    }
            //    lblMedioPago.Text = comboBox1.Text;
            //}
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //tengo que ver como elimino del datagridview la sleccionada
            //y la agrego en otra lista (la de facturaSSSaPagar)
            this.Hide();
            //lstfacturasAPagar fapList = new lstfacturasAPagar();
            //fapList.agregarAldgv(factura,sucursalF);
           // fapList.Show();
        }
    }
}
