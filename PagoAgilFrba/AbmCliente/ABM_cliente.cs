using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class abm_cliente : Form

          
    {
        public abm_cliente()
        {
            InitializeComponent();
        } 


        private void button1_Click(object sender, EventArgs e)
        {
            agregar_cliente form1 = new agregar_cliente();
            form1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            modificar_cliente form2 = new modificar_cliente();
            form2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            eliminar_cliente form3 = new eliminar_cliente();
            form3.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //seleccion_de_ABMs.Show();
            this.Close();
        }   //Esto lo hace a tocar el boton volver todavia no hace nada 
    }
}
