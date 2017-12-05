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

namespace PagoAgilFrba.ListadoEstadistico
{

    public partial class estadistica : Form
    {
       
        List<Trimestre> trimestres;

        public estadistica()
        {
            InitializeComponent();
            trimestres = new List<Trimestre>();
            trimestres.Add(new Trimestre(1, 1, 31, 3, "1° Trimestre (Enero - Marzo)"));
            trimestres.Add(new Trimestre(1, 4, 30, 6, "2° Trimestre (Abril - Junio)"));
            trimestres.Add(new Trimestre(1, 7, 30, 9, "3° Trimestre (Julio - Septiembre)"));
            trimestres.Add(new Trimestre(1, 10, 31, 12, "4° Trimestre (Octubre - Diciembre)"));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex <= -1 | cmbTrimestre.SelectedIndex <= -1) MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                switch (cmbTipo.Text)
                {
                    case "Porcentaje de facturas cobradas por empresa":
                       Database.cargarGriddPorcentajeFacturasCobradasPorEmpresa(dataGridView1, cmbTrimestre.SelectedItem as Trimestre, añoNUD.Value);
                        break;
                    case "Empresas con mayor monto rendido":
                        Database.cargarGriddEmpresasConMayorMontoRendido(dataGridView1, cmbTrimestre.SelectedItem as Trimestre, añoNUD.Value);
                        break;
                    case "Clientes con mas pagos":
                        Database.cargarGriddClienteConMasPagos(dataGridView1, cmbTrimestre.SelectedItem as Trimestre, añoNUD.Value);
                        break;
                    case "Clientes con mayor porcentaje de facturas pagadas":
                        Database.cargarGriddClienteConMayorPorcentajeFacturasPagas(dataGridView1, cmbTrimestre.SelectedItem as Trimestre, añoNUD.Value);
                        break;

                    default:
                        MessageBox.Show("Problemas al cargar la grilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }

            }
        }

        private void estadistica_Load(object sender, EventArgs e)
        {
            cmbTrimestre.DataSource = trimestres;
            cmbTrimestre.DisplayMember = "nombre";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
