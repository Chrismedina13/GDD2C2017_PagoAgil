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
    public partial class PagoConTarjetaCredito : Form
    {
        String montoTot;
        public TarjetaCredito tarjCred { get; set; }
        Decimal dniCliente;
        public PagoConTarjetaCredito(String monto,Decimal dni)
        {
            montoTot = monto;
            InitializeComponent();
            lblMonto.Text = montoTot;
            dniCliente = dni;
        }

        private void PagoConTarjetaCredito_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                this.Hide();
                tarjCred = new TarjetaCredito();
                tarjCred.codTarjeta = Convert.ToInt32(tctNroTarjeta.Text);
                tarjCred.codVerificacion = Convert.ToInt32(txtCodVerif.Text);
                tarjCred.dniTitular = Convert.ToDecimal(tctTitular.Text);
                tarjCred.monto = Convert.ToDecimal(montoTot);
                tarjCred.vtoTarj = dateTimePicker1.Value;
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
