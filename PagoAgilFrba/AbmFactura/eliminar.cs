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
    public partial class eliminar : Form
    {

        SqlDataAdapter dataAdapter;
        DataTable tablaDatos;

        public eliminar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataAdapter = new SqlDataAdapter();
            tablaDatos = new DataTable();

            dataAdapter.SelectCommand = consultaFactura(textBox1.Text, textBox2.Text);
            dataAdapter.Fill(tablaDatos);
            dataGridView1.DataSource = tablaDatos;
            dataGridView1.CellClick += dataGridView1_CellClick;
            DataGridViewButtonColumn eliminar = new DataGridViewButtonColumn();
            eliminar.Name = "Eliminar";
            eliminar.Text = "Eliminar";
            eliminar.Name = "Eliminar";
            eliminar.UseColumnTextForButtonValue = true;
            int columnIndex = dataGridView1.ColumnCount;
            if (dataGridView1.Columns["Eliminar"] == null) { dataGridView1.Columns.Insert(columnIndex, eliminar); }
            else { dataGridView1.Columns["Eliminar"].DisplayIndex = dataGridView1.ColumnCount - 1; };
            dataGridView1.Columns["Eliminar"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns["Modificar"].Index) && (e.RowIndex >= 0))
            {
                eliminarFactura(e.RowIndex);
            }
        }

        private SqlCommand consultaChoferes(int clienteID, int empresaID)
        {
            SqlCommand comand = new SqlCommand(
                @"select factura_id,"
                + "factura_cliente,"
                + "factura_empresa,"
                + "factura_numero,"
                + "factura_importe,"
                + "factura_fecha_inicio,"
                + "factura_fecha_fin,"
                + "factura_habilitado,"
                + " from pero_compila.Factura"
                + " where factura_habilitado = 1", BDCOMUN.ObtenerConexion());
            return comand;
        }

       
        private void eliminarFactura(int row) {
            int id = Int32.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
            SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_eliminar_factura", BDCOMUN.ObtenerConexion());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@idfactura", id);

            command.ExecuteNonQuery();
        }

    }
}
