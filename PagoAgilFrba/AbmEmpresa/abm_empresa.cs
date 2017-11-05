using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class abm_empresa : Form
    {
        

        public abm_empresa()
        {
            InitializeComponent();
        
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarEmpresa_Click(object sender, EventArgs e)
        {
            agregar_empresa frm = new agregar_empresa();
            frm.Show();
        }

        private void btnModificarEmpresa_Click(object sender, EventArgs e)
        {
            modificar_empresa form2 = new modificar_empresa();
            form2.Show();
        }

        private void btnEliminarEmpresa_Click(object sender, EventArgs e)
        {
             eliminar_empresa form3 = new eliminar_empresa();
            form3.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            //seleccion_de_ABMs.Show();
        }
    }
}
