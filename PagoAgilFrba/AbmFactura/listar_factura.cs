using PagoAgilFrba.AbmCliente;
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
    public partial class listar_factura : Form
    {
        String sucursalF;
        Decimal totalAPagar;
        Decimal dniCliente;
        public listar_factura()
        {
            InitializeComponent();
        }
        public listar_factura(List<Factura> f,String sucursal,Decimal dniCli)
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = f;
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chkbox);
            chkbox.HeaderText = "Check Data";
            chkbox.Name = "seleccion";
            //AddButtonColumn();
            sucursalF = sucursal;
            dniCliente = dniCli;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listar_factura_Load(object sender, EventArgs e)
        {

        }
        private void AddButtonColumn()
        {
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "Seleccionar";
                buttons.Text = "Seleccionar";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons.DisplayIndex = 8;
                
            }

            dataGridView1.Columns.Add(buttons);

        }
        private void ClickEnBoton(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex==7)
            {
                var row = dataGridView1.CurrentRow;
                Factura f = new Factura();
                Cliente cli = new Cliente();           
                f.codFactura = Convert.ToInt32(row.Cells[1].Value);
                f.empresa_id = Convert.ToInt32(row.Cells[3].Value);
                f.fechaAlta=Convert.ToDateTime(row.Cells[5].Value);
                f.fechaVenc=Convert.ToDateTime(row.Cells[6].Value);
                f.total = Convert.ToDecimal(row.Cells[7].Value);
                FacturaAPagar fap = new FacturaAPagar(f,sucursalF);
                fap.Show();
              
               // dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int agregarFacturas()
        {
            int i = 0;
            
            List<Factura> facturasAPagar = new List<Factura>();
            List<int> ChkedRow = new List<int>();
            try
            {
                for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["seleccion"].Value) == true)
                    {
                        ChkedRow.Add(i);
                    }
                }
                if (ChkedRow.Count == 0) { return 0; }
                totalAPagar = 0;
                foreach (int k in ChkedRow)
                {
                    Factura facturaAPagar = new Factura();
                    facturaAPagar.cli_dni = Convert.ToInt32(dataGridView1.Rows[k].Cells[1].Value.ToString());
                    facturaAPagar.cli_mail =(dataGridView1.Rows[k].Cells[2].Value.ToString());
                    facturaAPagar.codFactura=Convert.ToInt32(dataGridView1.Rows[k].Cells[4].Value.ToString());
                    facturaAPagar.empresa_id = Convert.ToInt32(dataGridView1.Rows[k].Cells[3].Value.ToString());
                    facturaAPagar.fechaAlta = Convert.ToDateTime(dataGridView1.Rows[k].Cells[5].Value);
                    facturaAPagar.fechaVenc = Convert.ToDateTime(dataGridView1.Rows[k].Cells[6].Value);
                    facturaAPagar.total = Convert.ToDecimal(dataGridView1.Rows[k].Cells[7].Value.ToString());
                    totalAPagar += Convert.ToDecimal(dataGridView1.Rows[k].Cells[7].Value.ToString());
                    facturasAPagar.Add(facturaAPagar);

                }
                MessageBox.Show("Se Seleccionaron las Facturas Correctamente!");
                lstfacturasAPagar fac = new lstfacturasAPagar(facturasAPagar, sucursalF,totalAPagar,dniCliente);
                fac.Show();
               
            }
            catch (Exception e) { return 0; }
            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                //Factura fact = new Factura();
                //int res = RolDAL.insert(rol.Nombre);
                //if (res > 0)
                //{
                //   int resultado = agregarFuncionalidades(res);

                agregarFacturas();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el alta de rol -" + ex.Message);
            }
        }

    }
}
