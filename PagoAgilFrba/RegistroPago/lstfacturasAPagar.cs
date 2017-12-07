using PagoAgilFrba.AbmFactura;
using PagoAgilFrba.AbmSucursal;
using PagoAgilFrba.TiposDePago;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.RegistroPago
{
    public partial class lstfacturasAPagar : Form
    {
        Decimal totalAP;
        List<Factura> facturas;
        String sucursalObt;
        Decimal dniCliente;
        public PagoConCheque pcheq;
        public PagoConTarjetaCredito pcred;
        public PagoConDebito pdeb;
        public lstfacturasAPagar(List<Factura> f, String sucu, Decimal totalap,Decimal dniCli)
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            facturas = f;
            //aca voy a agregar todas las facturas q selecciona y el monto total
            cargarComboMedioDePago();
            agregarAldgv(f, sucu);
            totalAP = totalap;
            total.Text = totalAP.ToString();
            sucursalObt = sucu;
            dniCliente = dniCli;
        }


        private void cargarComboMedioDePago()
        {
            //Vaciar comboBox
            comboBox1.DataSource = null;
            MedioDePago mp = new MedioDePago();
            //Indicar qué propiedad se verá en la lista
            this.comboBox1.DisplayMember = "funcionalidad_descripcion";
            //Indicar qué valor tendrá cada ítem
            this.comboBox1.ValueMember = "ID";
            //Asignar la propiedad DataSource
            this.comboBox1.DataSource = mp.getAllMediosDePago();
        }
        private void facturasAPagar_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        internal void agregarAldgv(List<Factura> factura, string sucursalF)
        {
            dataGridView1.DataSource = factura;
        }

        private void medioDePagoElegido(object sender, EventArgs e)
        {
            //Como ahcer que elija el seleccionado , me elige el anterior...
            label10.Text = total.Text;
           
            if (comboBox1.SelectedValue.ToString() == "Cheque")
            {
                pcheq = new PagoConCheque(total.Text,dniCliente);
                lblMedioPago.Text = "Cheque";        
                pcheq.Show();
           
            }
            else
            {
                if (comboBox1.SelectedValue.ToString() == "Tarjeta de Crédito")
                {
                     pcred = new PagoConTarjetaCredito(total.Text,dniCliente);
                     lblMedioPago.Text = "Tarjeta de Crédito";
                    pcred.Show();
                }
                else
                {
                    if (comboBox1.SelectedValue.ToString() == "Tarjeta de Débito")
                    {
                        pdeb = new PagoConDebito(total.Text, dniCliente);
                        lblMedioPago.Text = "Tarjeta de Débito";
                        pdeb.Show();
                    }
                    else
                    {
                        lblMedioPago.Text = "Efectivo";
                        label10.Text = total.Text;
                        Efectivo ef = new Efectivo();
                        if (ef.altaEfectivo(Convert.ToDecimal(total.Text),dniCliente))
                        {
                            MessageBox.Show("Se aceptó el pago con efectivo Correctamente!");
                        }
                        else
                        {
                            MessageBox.Show("Error. no se pudo realizar el pago");
                        }
                    }
                }
               // lblMedioPago.Text = comboBox1.SelectedValue.ToString();
            }
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valor = false;
            FacturaDal factu = new FacturaDal();
          
            foreach (Factura unaFactura in facturas)
            {   valor=factu.pasarAPagada(unaFactura.cli_dni, unaFactura.cli_mail, unaFactura.codFactura);
                if (valor)
                {
                    MedioDePagoDAL mp = new MedioDePagoDAL();
                    MedioDePago mp2 = new MedioDePago();
                    Sucursal sucu = new Sucursal();
                    //Cargar datos del medio de pago
                    PagoFacturaDAL pagoFact = new PagoFacturaDAL();
                    int idFact = factu.buscarIdFactura(unaFactura.codFactura);
                    int idSucu = sucu.buscarIdSucu(sucursalObt);
                    int idMp = mp2.buscarIdPorMedioDePago(comboBox1.SelectedItem.ToString());
                    valor = pagoFact.altaEnPagados(idFact, idSucu, Convert.ToDecimal(unaFactura.cli_dni), unaFactura.cli_mail, idMp, Convert.ToDateTime(unaFactura.fechaAlta), Convert.ToDecimal(unaFactura.total));
                    //mp.cargarDatosSegunMP(idMp, comboBox1.SelectedItem.ToString());
                   
                    
                    
                }

            }
            if(valor)
            {
                cargarSPSegunMedioDePago(comboBox1.SelectedItem.ToString());
                MessageBox.Show("Se ha efectuado el Pago Correctamente!!");
                this.Hide();
            }

        }


        public void cargarSPSegunMedioDePago(String medioDePago)
        {
            if (medioDePago == "Cheque")
            {
                //PagoConCheque pgchk ;
                Cheque chk = new Cheque();
                //cheque = pcheq.datosCargados();
                chk.nroCheque=Convert.ToInt32(pcheq.chkPosta.nroCheque.ToString());
                chk.dniTitular = Convert.ToDecimal(pcheq.chkPosta.dniTitular.ToString());
               
                chk.monto=Convert.ToDecimal(pcheq.chkPosta.monto.ToString());
                chk.altaCheque(chk);
            }
            else
            {
                if (medioDePago == "Tarjeta de Crédito")
                {
                    TarjetaCredito tcred = new TarjetaCredito();
                    tcred.codTarjeta = Convert.ToInt32(pcred.tarjCred.codTarjeta.ToString());
                    tcred.codVerificacion = Convert.ToInt32(pcred.tarjCred.codVerificacion.ToString());
                    tcred.dniTitular = Convert.ToDecimal(pcred.tarjCred.dniTitular);
                    tcred.monto = Convert.ToDecimal(pcred.tarjCred.monto);
                    tcred.vtoTarj = Convert.ToDateTime(pcred.tarjCred.vtoTarj);
                    tcred.altaTarjCredito(tcred);
                }
                else
                {
                    if (medioDePago == "Tarjeta de Débito")
                    {
                        TarjetaDebito tdeb = new TarjetaDebito();
                        tdeb.nroTarjeta = Convert.ToInt32(pdeb.tarjDeb.nroTarjeta.ToString());
                        tdeb.codVerificacion = Convert.ToInt32(pdeb.tarjDeb.codVerificacion.ToString());
                        tdeb.dniTitular = Convert.ToDecimal(pdeb.tarjDeb.dniTitular);
                        tdeb.monto = Convert.ToDecimal(pdeb.tarjDeb.monto);
                        tdeb.vtoTarj = Convert.ToDateTime(pdeb.tarjDeb.vtoTarj);
                        tdeb.altaTarjDebito(tdeb);

                    }
                    else
                    {

                    }
                }
            }




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
