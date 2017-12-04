using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Support;

namespace PagoAgilFrba.Devoluciones
{
    public partial class devolucion_factura : Form
    {

        List<int> IdsFacturasSeleccionadas = new List<int>();

        public devolucion_factura(String nombre, String apellido, String dni,String mail)
        {
            InitializeComponent();
            Database.cargarGriddFacturasPagasCliente(facturasDgv, "", "", "","");

        }

        private void facturasDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void totalTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void devolucion_factura_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdsFacturasSeleccionadas.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar por lo menos una factura para poder realizar la devolución.", "Error en Devolución de Facturas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(motivoTb.Text))
                {
                    MessageBox.Show("Debe escribir un motivo de devolución previamente.", "Error en Devolución de Facturas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach(int factura in IdsFacturasSeleccionadas){

                    Database.updatePagoFactura(factura);
                 
                    Database.updateFacturaDevuelta(factura);
                    //falta ingresar a la tabla de devueltos
                
                
                }
                motivoTb.Text = string.Empty;
                totalTb.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en Devolución de Facturas",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void facturasDgv_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            decimal total = 0;
            IdsFacturasSeleccionadas.Clear();

            foreach (DataGridViewRow row in facturasDgv.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(true))
                {
                    row.Selected = true;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
                    total += Convert.ToDecimal(row.Cells[5].Value);
                    IdsFacturasSeleccionadas.Add(Convert.ToInt32(row.Cells[1].Value));
                }
                else
                    row.Selected = false;
            }

            totalTb.Text = total.ToString();
        }

        private void facturasDgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (facturasDgv.IsCurrentCellDirty)
            {
                facturasDgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
