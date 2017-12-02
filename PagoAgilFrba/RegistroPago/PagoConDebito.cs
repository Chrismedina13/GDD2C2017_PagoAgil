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
    public partial class PagoConDebito : Form
    {
        String montoTot;
        public TarjetaDebito tarjDeb { get; set; }
        Decimal dniCliente;
        public PagoConDebito(String monto,Decimal dni)
        {
            montoTot = monto;
            InitializeComponent();
            lblMonto.Text = montoTot;
            dniCliente = dni;
        }
        public PagoConDebito()
        {
          
            InitializeComponent();
            
        }
        //public TarjetaDebito datosCargados()
        //{
        //    TarjetaDebito tdeb = new TarjetaDebito();

        //}
        private void PagoConDebito_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                this.Hide();
                tarjDeb = new TarjetaDebito();
                tarjDeb.nroTarjeta = Convert.ToInt32(tctNroTarjeta.Text);
                tarjDeb.codVerificacion = Convert.ToInt32(txtCodVerif.Text);
                tarjDeb.dniTitular = Convert.ToDecimal(tctTitular.Text);
                tarjDeb.monto = Convert.ToDecimal(montoTot);
                tarjDeb.vtoTarj = dateTimePicker1.Value;
            }
        }
        public bool IsNumber(string numero)
        {
            return Regex.IsMatch(numero, @"^\d+$");
        }
        private bool validarCampos()
        {
            bool retorno = false;
            if (!this.IsNumber(tctNroTarjeta.Text))
            {
                MessageBox.Show("Error: El nro de Tarjeta debe ser numérico.");
            }
            else
            {
                retorno = true;
            }
            if (dniCliente != (Convert.ToDecimal(tctTitular.Text)))
            {
                MessageBox.Show("Error:El DNI del Titular no es válido.");
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }
    }
}
