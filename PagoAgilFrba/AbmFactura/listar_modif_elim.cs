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
            //CargarComboClientes();
            CargarComboEmpresas();

            //textTotal.AutoCompleteCustomSource = ItemDal.LoadAutoComplete();
            //textTotal.AutoCompleteMode = AutoCompleteMode.Suggest;
            //textTotal.AutoCompleteSource = AutoCompleteSource.CustomSource;

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
            DataGridViewButtonColumn btnModif = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btnModif);
            btnModif.HeaderText = "Modificar";
            btnModif.Name = "modificar";
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btnEliminar);
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "eliminar";
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
            //if ( textTotal.Text != "")
            //{
            //    fsn.total = Convert.ToDecimal(textTotal.Text);
            //}
            if (textCliente.Text != "")
            {
                fsn.cli_dni = Convert.ToDecimal(textCliente.Text);
            }
            if (comboBoxEmpresa.SelectedValue.ToString()  != "")
            {
                fsn.empresa_id = comboBoxEmpresa.SelectedIndex;
            }
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
    }
}
