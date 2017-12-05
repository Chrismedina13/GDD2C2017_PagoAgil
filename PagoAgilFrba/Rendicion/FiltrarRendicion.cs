using PagoAgilFrba.AbmEmpresa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Rendicion
{
    public partial class RendirFactura : Form
    {
        public String usuario { get; set; }
        public RendirFactura(String user)
        {
            usuario = user;
            InitializeComponent();
            CargarComboEmpresas();
        }
        private void CargarComboEmpresas()
        {
            //Vaciar comboBox
            comboBoxEmpresa.DataSource = null;
            try
            {
                //Indicar qué propiedad se verá en la lista
                this.comboBoxEmpresa.DisplayMember = "nombre";
                //Indicar qué valor tendrá cada ítem
                this.comboBoxEmpresa.ValueMember = "empresaId";
                //Asignar la propiedad DataSource
                List<Empresa> listita = new List<Empresa>();

                listita = EmpresaDal.BuscarEmpresas();
                //this.comboBox1.Items.Insert(0, "Seleccione un rol");
                //listita.Add(new Empresa(0, "Seleccione una empresa"));
                this.comboBoxEmpresa.DataSource = listita;
                //this.comboBox1.Items.Add(new KeyValuePair<string, string>("0", "Mujer"));
            }
            catch (Exception e)
            { MessageBox.Show("Error al intentar cargar las Empresas -" + e.Message); }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBoxEmpresa.SelectedValue);
            cantArendir rfacts = new cantArendir(id, dateTimePicker1.Value.Month, dateTimePicker1.Value.Year,usuario);
            rfacts.Show();
        }

        private void RendirFactura_Load(object sender, EventArgs e)
        {

        }
    }
}
