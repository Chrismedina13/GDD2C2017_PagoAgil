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
    public partial class RendicionFacturas : Form
    {
        public RendicionFacturas()
        {
            InitializeComponent();
        }

        private void RendicionFacturas_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //debo buscar las facturas de la empresa seleccionada  POR MES

            //Cantidad de facturas rendidas = COUNT DE FACTURAS PAGAS DE ESA EMPRESA



            //CAMBIAR POR PERO_COMPILA.PAGO_FACTURA 

            //select * from pero_compila.Factura f join pero_compila.Empresa e 
            //on (e.empresa_Id=f.factura_empresa) where empresa_nombre= 'Empresa N°2000'
        }
    }
}
