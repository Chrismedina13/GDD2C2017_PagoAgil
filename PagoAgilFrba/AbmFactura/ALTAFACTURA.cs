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
    public partial class ALTAFACTURA : Form
    {
        int totalSumaItems;
        public ALTAFACTURA()
        {
            InitializeComponent();
            CargarComboClientes();
            CargarComboEmpresas();
        }
        private void CargarComboClientes()
        {
            //Vaciar comboBox
            comboBoxCliente.DataSource = null;
            try
            {
                //Indicar qué propiedad se verá en la lista
                this.comboBoxCliente.DisplayMember = "Nombre";
                //Indicar qué valor tendrá cada ítem
                this.comboBoxCliente.ValueMember = "Id";
                //Asignar la propiedad DataSource
                List<Cliente> listita = new List<Cliente>();

                listita = ClienteDal.BuscarClientes();
                //this.comboBox1.Items.Insert(0, "Seleccione un rol");
                //listita.Add(new Cliente(0, "Seleccione un Cliente"));
                this.comboBoxCliente.DataSource = listita;
                //this.comboBox1.Items.Add(new KeyValuePair<string, string>("0", "Mujer"));
            }
            catch (Exception e)
            { MessageBox.Show("Error al intentar cargar los Clientes -" + e.Message); }
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


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ALTAFACTURA_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            //validar fecha de hoy con la de vto
            //validar que solo ingrese nros en el nro de factura
            if (textBox1.Text.Contains("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"))
            {
                MessageBox.Show("Error El nro de Factura debe ser numérico.");
            }

            // MessageBox.Show( Convert.ToString(dataGridView1[0, dataGridView1.CurrentRow.Index].Value));
            // MessageBox.Show(Convert.ToString(dataGridView1[1, dataGridView1.CurrentRow.Index].Value));
            // MessageBox.Show(Convert.ToString(dataGridView1[2, dataGridView1.CurrentRow.Index].Value));
            ////' Modify the value in the first cell of the second row.
            // dataGridView1.Rows[1].Cells[3].Value = Convert.ToInt32(dataGridView1[2, dataGridView1.CurrentRow.Index].Value) * Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);

            // MessageBox.Show(Convert.ToString(dataGridView1.Rows[1].Cells[3].Value));
            List<Item> items = new List<Item>();
            //for (int q = 0; q < dataGridView1.Rows.Count-1; q++)
            //{
            //   // DataGridViewRow row = dataGridView1.Rows();
            //    row.Cells["Total"].Value = Convert.ToInt32(row.Cells["Precio"].Value) * Convert.ToInt32(row.Cells["Cantidad"].Value);
            //    //items.Add(item);
            //    totalSumaItems += Convert.ToInt32(row.Cells["Total"].Value);
            //}

            for (int fila = 0; fila < dataGridView1.Rows.Count - 1; fila++)
            {
                for (int col = 0; col < dataGridView1.Rows[fila].Cells.Count; col++)
                {
                    string valor = dataGridView1.Rows[fila].Cells[col].Value.ToString();
                    dataGridView1.Rows[fila].Cells["Total"].Value = Convert.ToInt32(dataGridView1.Rows[fila].Cells["Precio"].Value) * Convert.ToInt32(dataGridView1.Rows[fila].Cells["Cantidad"].Value);
                    MessageBox.Show(valor);
                }
                totalSumaItems += Convert.ToInt32(dataGridView1.Rows[fila].Cells["Total"].Value);
            }
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (Convert.ToString(row.Cells["Nombre"].Value) == "")
            //   {
            //       //dataGridView1.Rows.Remove(row);
            //       //dataGridView1.Rows.RemoveAt(2);
            //   }
            //    Item item =new Item();
            //  //  item.descripcion=row.Cells["Nombre"].Value.ToString();
            //   // item.precio=Convert.ToInt32(row.Cells["Precio"].Value.ToString());
            //    MessageBox.Show(row.Cells["Nombre"].Value.ToString());
            //    MessageBox.Show(row.Cells["Precio"].Value.ToString());
            //    MessageBox.Show(row.Cells["Cantidad"].Value.ToString());
                
            //}
            totalItems.Text = totalSumaItems.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
