using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmEmpresa;
using PagoAgilFrba.AbmoItem;
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
    public partial class listar_modif_elim : Form
    {
        public listar_modif_elim()
        {
            InitializeComponent();
            DataGridViewButtonColumn btnModif = new DataGridViewButtonColumn();
            btnModif.HeaderText = "Modificar";
            btnModif.Name = "modificar";
            btnModif.Text = "Modificar";
            btnModif.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "eliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnEliminar);
            dataGridView1.Columns.Add(btnModif);
            //CargarComboClientes();
            CargarComboEmpresas();

            textTotal.AutoCompleteCustomSource = FacturaDal.LoadAutoComplete();
            textTotal.AutoCompleteMode = AutoCompleteMode.Suggest;
            textTotal.AutoCompleteSource = AutoCompleteSource.CustomSource;

            textCliente.AutoCompleteCustomSource = ClienteDal.LoadAutoComplete();
            textCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            textCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

            textNroFactura.AutoCompleteCustomSource = Factura.LoadAutoComplete();
            textNroFactura.AutoCompleteMode = AutoCompleteMode.Suggest;
            textNroFactura.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factura f = new Factura();
            f = sinNulos();
            List<Factura> facturas = f.getFacturasNoPagasYNoRendidas(f);
            // List<Factura> facturas = f.getFacturasNoPagasYNoRendidas(textNroFactura.Text,Convert.ToDecimal(textTotal.Text),textCliente.Text,comboBoxEmpresa.SelectedValue.ToString(),dateTimePicker1.Value,dateTimePicker2.Value);
            this.dataGridView1.DataSource = facturas;


        }
        private Factura sinNulos()
        {
            Factura fsn = new Factura();
            if (textNroFactura.Text!="")
            {
                fsn.codFactura = Convert.ToInt32(textNroFactura.Text);
            }
            if (textTotal.Text != "")
            {
                fsn.total = Convert.ToDecimal(textTotal.Text);
            }
            if (textCliente.Text != "")
            {
                fsn.cli_dni = Convert.ToDecimal(textCliente.Text);
            }
            if (comboBoxEmpresa.SelectedValue.ToString()  != "")
            {
                fsn.empresa_id = comboBoxEmpresa.SelectedIndex+1;
            }
            fsn.fechaAlta = dateTimePicker1.Value;
            fsn.fechaVenc = dateTimePicker2.Value;
            return fsn;
        }

        private void CargarComboEmpresas()
        {
            //Vaciar comboBox
            comboBoxEmpresa.DataSource = null;

            //Indicar qué propiedad se verá en la lista
            this.comboBoxEmpresa.DisplayMember = "nombre";
            //Indicar qué valor tendrá cada ítem
            this.comboBoxEmpresa.ValueMember = "empresaId";
            //Asignar la propiedad DataSource
            this.comboBoxEmpresa.DataSource = EmpresaDal.BuscarEmpresas();


        }
        private void listar_modif_elim_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            //if (e.RowIndex < 0 || e.ColumnIndex !=
            //    dataGridView1.Columns["Eliminar"].Index) return;
            Factura f = new Factura();
            f.facturaId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["facturaId"].Value.ToString()) ;
            f.fechaAlta =Convert.ToDateTime( dataGridView1.Rows[e.RowIndex].Cells["fechaAlta"].Value.ToString()) ;
            f.fechaVenc = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["fechaVenc"].Value.ToString());
            f.cli_dni= Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["cli_dni"].Value.ToString());
            f.cli_mail = dataGridView1.Rows[e.RowIndex].Cells["cli_mail"].Value.ToString(); ;
            f.codFactura =Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["codFactura"].Value.ToString()) ;
            f.empresa_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["empresa_id"].Value.ToString()) ;
            f.total = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["total"].Value.ToString()) ;
            if (e.RowIndex < 0 || e.ColumnIndex ==
               dataGridView1.Columns["Eliminar"].Index)
            {
              
                eliminar_factura ef = new eliminar_factura(f);
                ef.Show();
            }
            if (e.RowIndex < 0 || e.ColumnIndex ==
                 dataGridView1.Columns["Modificar"].Index)
            {
                modificar_factura mf = new modificar_factura(f);
                mf.Show();
            }
        }

        private void textNroFactura_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
