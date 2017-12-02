using PagoAgilFrba.TiposDePago;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.RegistroPago
{
    public partial class PagoConCheque : Form
    {
        String montoTot;
        public Cheque chkPosta { get; set; }
        public MedioDePago mp= new MedioDePago();
        Decimal dniCliente;
        public PagoConCheque(String monto,Decimal dni)
        {
            montoTot = monto;
            InitializeComponent();
            lblMonto.Text = montoTot;
            dniCliente = dni;
        }
        public PagoConCheque()
        {
          
            InitializeComponent();
    
        }

        private void PagoConCheque_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                this.Hide();
                chkPosta = new Cheque();
                chkPosta.nroCheque = Convert.ToInt32(txtNroCheque.Text);
                chkPosta.dniTitular = Convert.ToDecimal(txtTitular.Text);
                chkPosta.destino = txtEmpresa.Text;
                chkPosta.monto = Convert.ToDecimal(montoTot);
            }

          
        }
        public bool IsNumber(string numero)
        {
            return Regex.IsMatch(numero, @"^\d+$");
        } 
        private bool validarCampos()
        {
            bool retorno = false;
            if (!this.IsNumber(txtNroCheque.Text))
            {
                MessageBox.Show("Error: El nro de Cheque debe ser numérico.");
            }
            else
            {
                retorno = true;
            }
            if (dniCliente !=(Convert.ToDecimal(txtTitular.Text)))
            {
                MessageBox.Show("Error:El DNI del Titular no es válido.");
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

        public  Cheque datosCargados()
        {
            try
            {
                //Cheque chk = new Cheque();
                //chk.nroCheque = Convert.ToInt32(txtNroCheque.Text);
                //chk.dniTitular = Convert.ToDecimal(txtTitular.Text);
                //chk.destino = txtEmpresa.Text;
                //chk.monto = Convert.ToDecimal(montoTot);
               // return chk;
                return chkPosta;
            }
            catch (Exception e) { return null; }
        }

        private void txtTitular_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
