using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class Abm_sucursal : Form
    {

          public Abm_sucursal()
          {
              InitializeComponent();
              
          } 


        private void button1_Click(object sender, EventArgs e)
        {
            agregar_sucursal form1 = new agregar_sucursal();
            form1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            modificar_sucursal form2 = new modificar_sucursal();
            form2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            eliminar_sucursal form3 = new eliminar_sucursal();
            form3.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //seleccion_de_ABMs.Show();
            this.Close();
        }   //Esto lo hace a tocar el boton volver todavia no hace nada 
    }
}
