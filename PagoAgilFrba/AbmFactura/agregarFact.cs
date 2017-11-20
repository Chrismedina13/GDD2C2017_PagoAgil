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
    public partial class agregarFact : Form
    {
        public agregarFact()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (verificarCampos())
            {
                registrarFactura(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text), Int16.Parse(textBox4.Text), dateTimePicker1.Value, dateTimePicker2.Value, Int16.Parse(textBox5.Text));
            }
        }
        private bool verificarCampos()
        {
            string msjFalla = "";
            if (textBox3.Text == "" || tieneLetras(textBox1.Text)) { msjFalla = msjFalla + "Ingresar ID Cliente"; }
            if (textBox3.Text == "" || tieneLetras(textBox2.Text)) { msjFalla = msjFalla + "Ingresar ID Empresa"; }
            if (textBox3.Text == "" || tieneLetras(textBox3.Text)) { msjFalla = msjFalla + "Ingresar Codigo válido"; }
            if (textBox4.Text == "" || tieneLetras(textBox7.Text)) { msjFalla = msjFalla + "Ingresar importe"; }
            if (!(DateTime.Compare(dateTimePicker1.Value, DateTime.Now) <= 0)) { msjFalla = msjFalla + "Fecha inválida"; }
            if (!(DateTime.Compare(dateTimePicker2.Value, DateTime.Now) <= 0)) { msjFalla = msjFalla + "Fecha inválida"; }
            if ((textBox5.Text == "") || tieneLetras(textBox5.Text)) { msjFalla = msjFalla + "Habilitado"; }
            if (msjFalla == "") { return true; }
            else { MessageBox.Show(msjFalla); return false; }
        }
        private bool tieneLetras(string texto)
        {
            string letras = "abcdefghijklmmñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            bool rta = false;
            foreach (char letra in texto)
            {
                if (letras.Contains(letra)) { rta = true; return rta; };
            }
            return rta;
        }




        private void registrarFactura(int factura_cliente, int factura_empresa,
            int factura_numero, int factura_importe, DataTime factura_fecha_inicio,
            DataTime factura_fecha_fin, long factura_habilitado)
        {
            SqlCommand command = new SqlCommand("[PERO_COMPILA].sp_alta_factura", BDCOMUN.ObtenerConexion());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@clienteID", factura_cliente);
            command.Parameters.AddWithValue("@empresaID", factura_empresa);
            command.Parameters.AddWithValue("@codFactura", factura_numero);
            command.Parameters.AddWithValue("@total", factura_total);
            command.Parameters.AddWithValue("@fecha_alta", factura_fecha_inicio);
            command.Parameters.AddWithValue("@fecha_vencimiento", factura_fecha_fin);
            command.Parameters.AddWithValue("@habilitado", factura_habilitado);

            command.ExecuteNonQuery();
        }
       
    }
}
