using PagoAgilFrba.AbmRol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmEmpresa;
using PagoAgilFrba.AbmSucursal;
using PagoAgilFrba.ListadoEstadistico;
using PagoAgilFrba.AbmFactura;
using PagoAgilFrba.Rendicion;
using PagoAgilFrba.Devoluciones;
using PagoAgilFrba.Support;

namespace PagoAgilFrba
{
    public partial class VentanaPrincipal : Form
    {
        public String user { get; set; }
        public String rol { get; set; }
        public String fechaSistema { get; set; }
        public VentanaPrincipal(string nombre,String rolUser)
        {
            user = nombre;
            rol = rolUser;
           // label2.Text = nombre;

            this.user = nombre;
            InitializeComponent();
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaPorRol vr = new VentanaPorRol();
            vr.Show();
        }

        private void VentanaPrincipal_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fechaSistema == null)
            {
                MessageBox.Show("Error. Debe elegir una fecha para que inicie el sistema.");
            }
            int idRol = Database.IdDelRol(rol);
            if (Database.TieneAsignadaFuncionalidad(idRol, 3))
            {

                MessageBox.Show("EL ROL QUE USTED TIENE NO PERMITE ESTA FUNCIONALIDAD");
                return;
            }
            else
            {
                abm_cliente form3 = new abm_cliente();
                form3.Show();
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (fechaSistema == null)
            {
                MessageBox.Show("Error. Debe elegir una fecha para que inicie el sistema.");
            }
            int idRol = Database.IdDelRol(rol);
            if (Database.TieneAsignadaFuncionalidad(idRol,4))
            {

                MessageBox.Show("EL ROL QUE USTED TIENE NO PERMITE ESTA FUNCIONALIDAD");
                return;
            }
            else
            {
                abm_empresa form11 = new abm_empresa();
                form11.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (fechaSistema == null)
            {
                MessageBox.Show("Error. Debe elegir una fecha para que inicie el sistema.");
            }
            int idRol = Database.IdDelRol(rol);
            if (Database.TieneAsignadaFuncionalidad(idRol, 5))
            {

                MessageBox.Show("EL ROL QUE USTED TIENE NO PERMITE ESTA FUNCIONALIDAD");
                return;
            }
            else
            {
                Abm_sucursal form4 = new Abm_sucursal();
                form4.Show();
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            if (fechaSistema == null)
            {
                MessageBox.Show("Error. Debe elegir una fecha para que inicie el sistema.");
            }
            int idRol = Database.IdDelRol(rol);
            if (Database.TieneAsignadaFuncionalidad(idRol, 10))
            {

                MessageBox.Show("EL ROL QUE USTED TIENE NO PERMITE ESTA FUNCIONALIDAD");
                return;
            }
            else
            {
                estadistica form10 = new estadistica();
                form10.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (fechaSistema == null)
            {
                MessageBox.Show("Error. Debe elegir una fecha para que inicie el sistema.");
            }
            int idRol = Database.IdDelRol(rol);
            if (Database.TieneAsignadaFuncionalidad(idRol, 7))
            {

                MessageBox.Show("EL ROL QUE USTED TIENE NO PERMITE ESTA FUNCIONALIDAD");
                return;
            }
            else
            {
                Registro reg = new Registro();
                reg.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (fechaSistema == null)
            {
                MessageBox.Show("Error. Debe elegir una fecha para que inicie el sistema.");
            }
            int idRol = Database.IdDelRol(rol);
            if (Database.TieneAsignadaFuncionalidad(idRol, 1))
            {

                MessageBox.Show("EL ROL QUE USTED TIENE NO PERMITE ESTA FUNCIONALIDAD");
                return;
            }
            else
            {
                ABM_Rol objRol = new ABM_Rol();
                objRol.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (fechaSistema == null)
            {
                MessageBox.Show("Error. Debe elegir una fecha para que inicie el sistema.");
            }
            int idRol = Database.IdDelRol(rol);
            if (Database.TieneAsignadaFuncionalidad(idRol, 6))
            {

                MessageBox.Show("EL ROL QUE USTED TIENE NO PERMITE ESTA FUNCIONALIDAD");
                return;
            }
            else
            {
                ABM_Factura abmf = new ABM_Factura();
                abmf.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (fechaSistema == null)
            {
                MessageBox.Show("Error. Debe elegir una fecha para que inicie el sistema.");
            }

            int idRol = Database.IdDelRol(rol);
            if (Database.TieneAsignadaFuncionalidad(idRol, 8))
             {

                    MessageBox.Show("EL ROL QUE USTED TIENE NO PERMITE ESTA FUNCIONALIDAD");
                    return;
            }
            else
            {
                RendirFactura frend = new RendirFactura(user);
                frend.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (fechaSistema == null)
            {
                MessageBox.Show("Error. Debe elegir una fecha para que inicie el sistema.");
            }
            int idRol = Database.IdDelRol(rol);

            if(Database.TieneAsignadaFuncionalidad(idRol,9)){

                MessageBox.Show("EL ROL QUE USTED TIENE NO PERMITE ESTA FUNCIONALIDAD");
                return;
            }
            else
            {
                seleccionar_cliente frend = new seleccionar_cliente(user);
                frend.Show();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechaSistema = dateTimePicker1.Value.ToString("dd/MM/yyyy");
        }


    

    }
}
