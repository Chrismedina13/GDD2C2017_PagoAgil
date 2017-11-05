using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class ABM_Rol : Form
    {
        public ABM_Rol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alta_Rol alta = new Alta_Rol();
        }
    }
}
