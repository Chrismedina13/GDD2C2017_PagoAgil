using PagoAgilFrba.AbmEmpresa;
using PagoAgilFrba.AbmoItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
           
            textNroFactura.Text = f.codFactura.ToString();
            textCliente.Text = f.cli_dni.ToString();
            comboBoxEmpresa.SelectedItem = f.empresa_id.ToString();
            facturaSinModif = f;
            dataGridView1.DataSource = ItemDal.BuscarItemsDeFactura(f);
            dataGridView1.Columns[0].Visible = false;
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
        public bool IsNumber(string numero)
        {
            return Regex.IsMatch(numero, @"^\d+$");
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            Factura factuModif = new Factura();
            decimal totalPorItem;
            decimal total1=0;
            if (!IsNumber(textCliente.Text) || !IsNumber(textNroFactura.Text) )
            {
                MessageBox.Show("Error. Verifique que los campos coincidan con lo pedido");
            }
            else{

                factuModif.fechaAlta = dateTimePicker1.Value;
                factuModif.fechaVenc = dateTimePicker2.Value;
               // factuModif.total = Convert.ToDecimal(textTotal.Text);
                factuModif.codFactura=Convert.ToInt32(textNroFactura.Text);
                factuModif.cli_dni=Convert.ToDecimal(textCliente.Text);
                
                    factuModif.empresa_id = comboBoxEmpresa.SelectedIndex;
                    factuModif.facturaId = facturaSinModif.facturaId;

                    for (int fila = 0; fila < dataGridView1.Rows.Count; fila++)
                    {
                      
                            Item i = new Item();
                            //string valor = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                            totalPorItem = Convert.ToInt32(dataGridView1.Rows[fila].Cells["precio"].Value) * Convert.ToInt32(dataGridView1.Rows[fila].Cells["cantidad"].Value);
                            i.item_Id=Convert.ToInt32(dataGridView1.Rows[fila].Cells["item_id"].Value);
                            i.cantidad=Convert.ToInt32(dataGridView1.Rows[fila].Cells["cantidad"].Value);
                            i.descripcion=Convert.ToString(dataGridView1.Rows[fila].Cells["descripcion"].Value);
                            i.precio=Convert.ToDecimal(dataGridView1.Rows[fila].Cells["precio"].Value);
                            ItemDal.update(factuModif.facturaId,i);
                            total1+= totalPorItem;
                        
                        total.Text=total1.ToString();
                    }
                    if (Convert.ToDecimal(total.Text) < 0)
                    {
                        MessageBox.Show("No se puede Modificar, el importe da negativo.");
                    }
                    else
                    {
                        factuModif.total = Convert.ToDecimal(total.Text);
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
                //}
                //else
                //{
                //    MessageBox.Show("Seleccione una empresa");
                //} 
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
