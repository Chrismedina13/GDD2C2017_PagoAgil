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
    public partial class agregar_sucursal : Form
    {
        public agregar_sucursal()
        {
            InitializeComponent();
        }
        private void agregar_sucursal_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agregarEmpresa_Click(object sender, EventArgs e)
        {
            String Nombre = nombre.Text;
            String direccion = Direccion.Text;
            String CodigoPostal = codigoPostal.Text;

            if (nombre.Text.Trim() == "" | codigoPostal.Text.Trim() == "" | Direccion.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (true) //Database.coExiste(cuit))
            {
                MessageBox.Show("El cuil ingresada ya esta en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                //Database.addSucursal(Nombre,Direccion,CodigoPostal);
                this.limpiarCuadrosDeTexto();
                MessageBox.Show("Empresa ingresads correctamente", "Estado", MessageBoxButtons.OK);
            }

        }

        private void limpiarCuadrosDeTexto()
        {
            codigoPostal.Text = "";
            Direccion.Text = "";
            nombre.Text = "";
        }

    
    }
}
