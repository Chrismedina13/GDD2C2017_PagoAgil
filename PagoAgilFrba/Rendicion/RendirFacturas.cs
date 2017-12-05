using PagoAgilFrba.AbmUsuario;
using PagoAgilFrba.RegistroPago;
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
    public partial class cantArendir : Form
    {
         List<PagoFacturaReporte> rendiciones { get; set; }
         int mes;
         int año;
         public String usuario { get; set; }
        public cantArendir()
        {
            InitializeComponent();
        }
        public cantArendir(int empresaId,int _mes,int _año,String user)
        {
            Usuario u = new Usuario();
            usuario = user;
            InitializeComponent();
            mes = _mes;
            año = _año;
            RendicionDal rdal = new RendicionDal();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            rendiciones=rdal.buscarRendicionPorEmpresaMesAño(empresaId,mes,año,u.getSucursal(usuario));
            if (rendiciones.Count > 0)
            {
                dataGridView1.DataSource = rendiciones;
                totalARendir.Text = rendiciones.Sum(x=>x.importe).ToString();
                label8.Text = rendiciones.Count.ToString();
                lblEmpresa.Text=rendiciones[0].empresa;
                lblMes.Text=mes.ToString();
            }
            button1.Visible = false;
        }

        private void cantArendir_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPorcentaje.Text != "" && Convert.ToDecimal(txtPorcentaje.Text) > 0 && Convert.ToDecimal(txtPorcentaje.Text) <100)
            {
                comision.Text = ((Convert.ToDecimal(totalARendir.Text) * Convert.ToDecimal(txtPorcentaje.Text)) / 100).ToString();
                totalconDTO.Text = (Convert.ToDecimal(totalARendir.Text) - Convert.ToDecimal(comision.Text)).ToString();
                button1.Visible = true;
            }
            else
            {
                MessageBox.Show("Error. Valor de porcentaje inválido");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (RendicionDal.registrarRendicion(DateTime.Now,
                       Convert.ToInt32(label8.Text),
                       Convert.ToDecimal(comision.Text),
                       lblEmpresa.Text,
                       Convert.ToDecimal(txtPorcentaje.Text),
                       Convert.ToDecimal(totalconDTO.Text)))
                 {
                     if (actualizarFacturasPagasARendidas()) {
                         
                         MessageBox.Show("Salio todo bien");
                         this.Hide();
                     } else { MessageBox.Show("Error. "); };    
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Error. ");
            }
        }
        private bool actualizarFacturasPagasARendidas()
        {
            List<int> ChkedRow = new List<int>();
            
            try
            {
                int i;
                  for (i = 0; i <= dataGridView1.RowCount - 1; i++) 
                {
                    
                        ChkedRow.Add(i);
                   
                }
                  if (ChkedRow.Count == 0) { return false; }
                foreach (int k in ChkedRow)
                {
                    int id = Int32.Parse(dataGridView1.Rows[k].Cells[0].Value.ToString());
                    RendicionDal.updateARendidos(id);
                }
                return true;
                
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
