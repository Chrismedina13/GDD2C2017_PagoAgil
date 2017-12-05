using PagoAgilFrba.AbmEmpresa;
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
            CargarComboEmpresas();
            dateTimePicker1.Text = f.fechaAlta.ToString() ;
            dateTimePicker2.Text = f.fechaVenc.ToString();
            textTotal.Text = f.total.ToString();
            textNroFactura.Text = f.codFactura.ToString();
            textCliente.Text = f.cli_dni.ToString();
            comboBoxEmpresa.SelectedItem = f.empresa_id.ToString();
            facturaSinModif = f;
        }
        private void CargarComboEmpresas()
        {
            //Vaciar comboBox
            comboBoxEmpresa.DataSource = null;
            try
            {
                //Indicar qué propiedad se verá en la lista
                this.comboBoxEmpresa.DisplayMember = "Nombre";
                //Indicar qué valor tendrá cada ítem
                this.comboBoxEmpresa.ValueMember = "Id";
                //Asignar la propiedad DataSource
                List<Empresa> listita = new List<Empresa>();

                listita = EmpresaDal.BuscarEmpresas();
                //this.comboBox1.Items.Insert(0, "Seleccione un rol");
                // listita.Add(new Empresa(0, "Seleccione una Empresa"));
                this.comboBoxEmpresa.DataSource = listita;
                //this.comboBox1.Items.Add(new KeyValuePair<string, string>("0", "Mujer"));
            }
            catch (Exception e)
            { MessageBox.Show("Error al intentar cargar las Empresas -" + e.Message); }
        }
        private void modificar_factura_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factura factuModif = new Factura();
           
                factuModif.fechaAlta = dateTimePicker1.Value;
                factuModif.fechaVenc = dateTimePicker2.Value;
                factuModif.total = Convert.ToDecimal(textTotal.Text);
                factuModif.codFactura=Convert.ToInt32(textNroFactura.Text);
                factuModif.cli_dni=Convert.ToDecimal(textCliente.Text);
                
                    factuModif.empresa_id = comboBoxEmpresa.SelectedIndex;
                    factuModif.facturaId = facturaSinModif.facturaId;
                    if (FacturaDal.ModificarFactura(factuModif))
                    {
                        MessageBox.Show("Se modifico correctamente la factura!");
                    }
                    else
                    {
                        MessageBox.Show("Error. No se pudo modificar la factura");
                    }
                //}
                //else
                //{
                //    MessageBox.Show("Seleccione una empresa");
                //} 
                
        }
    }
}
