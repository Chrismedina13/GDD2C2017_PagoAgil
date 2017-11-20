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
    public partial class modificarDatos : Form
    {
        public modificarDatos(string id, string idempresa, string codFactura,string total,
            string fecha_alta,string fecha_fin, string habilitado)
        {
            InitializeComponent();
            textBox1.Text = id;
            textBox2.Text = idempresa;
            textBox3.Text = codFactura;
            textBox4.Text = total;
            dateTimePicker1.Value = DateTime.Parse(fecha_inicio);
            dateTimePicker2.Value = DateTime.Parse(fecha_fin);
            if (Int16.Parse(habilitado) == 1) { radioButton1.Checked = true; } else radioButton2.Checked = true;
           

        }

        private void modificarDatos_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
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
                updateChofer(textBox1.Text,textBox3.Text, textBox4.Text, dateTimePicker1.Value, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text, radioButton1.Checked, textBox14.Text);
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

        private void updateFactura(string id, string idempresa, string codFactura, string total,
            string fecha_alta, string fecha_fin, string habilitado)
        {
            SqlCommand command = new SqlCommand("[pero_compila].sp_modificar_factura", BDCOMUN.ObtenerConexion());
            command.CommandType = CommandType.StoredProcedure;

            int hab;
            if (habilitado) { hab = 1; } else hab = 0;
            command.Parameters.AddWithValue("@clienteID", id);
            command.Parameters.AddWithValue("@empresaID", idempresa);
            command.Parameters.AddWithValue("@codFactura ", codFactura);
            command.Parameters.AddWithValue("@total ", total);
            command.Parameters.AddWithValue("@fecha_alta", fecha_alta);
            command.Parameters.AddWithValue("@fecha_vencimiento", fecha_fin);
                       command.ExecuteNonQuery();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // modificarDatos
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "modificarDatos";
            this.Load += new System.EventHandler(this.modificarDatos_Load_1);
            this.ResumeLayout(false);

        }

        private void modificarDatos_Load_1(object sender, EventArgs e)
        {

        }
    }
}
