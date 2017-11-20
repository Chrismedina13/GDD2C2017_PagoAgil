using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmFactura
{
    public partial class modificar : Form
    {
        SqlDataAdapter dataAdapter;
        DataTable tablaDatos;
        
        public modificar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataAdapter = new SqlDataAdapter();
            tablaDatos = new DataTable();

           dataAdapter.SelectCommand = consultaChoferes(textBox1.Text, textBox2.Text);
           dataAdapter.Fill(tablaDatos);
            dataGridView1.DataSource = tablaDatos;
            dataGridView1.CellClick += dataGridView1_CellClick;
            DataGridViewButtonColumn mod = new DataGridViewButtonColumn();
            mod.Name = "Modificar";
            mod.Text = "Modificar";
            mod.Name = "Modificar";
            mod.UseColumnTextForButtonValue = true;
            int columnIndex = dataGridView1.ColumnCount;
            if (dataGridView1.Columns["Modificar"] == null) { dataGridView1.Columns.Insert(columnIndex, mod); }
            else { dataGridView1.Columns["Modificar"].DisplayIndex = dataGridView1.ColumnCount - 1; };
            dataGridView1.Columns["Modificar"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns["Modificar"].Index) && (e.RowIndex >= 0))
            {
                modificarFactura(e.RowIndex);
            }
        }

        private void modificarFactura(int row)
        {
            string idcliente = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string idempresa = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string codFactura = dataGridView1.Rows[row].Cells[3].Value.ToString();
            string total = dataGridView1.Rows[row].Cells[4].Value.ToString();
            string fecha_alta = dataGridView1.Rows[row].Cells[5].Value.ToString();
            string fecha_fin = dataGridView1.Rows[row].Cells[6].Value.ToString();
            string habilitado = dataGridView1.Rows[row].Cells[7].Value.ToString();

          
            modificarDatos pantallamodtur = new modificarDatos(idcliente,idempresa,codFactura,total,fecha_alta,fecha_fin,habilitado);
            pantallamodtur.Show();
        }

        private SqlCommand consultaChoferes(String nomb, String ap)
        {
            SqlCommand comand = new SqlCommand(
                @"select factura_cliente,"
                + "factura_empresa,"
                + "factura_cod,"
                + "factura_total,"
                + "factura_fecha_inicio,"
                + "factura_fecha_vencimiento,"
                + "factura_habilitado,"
                + " from pero_compila.Factura"
                + " where factura_habilitado=1", BDCOMUN.ObtenerConexion());
            return comand;
        }

        
    }
}
