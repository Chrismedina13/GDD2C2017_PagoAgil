﻿using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmEmpresa;
using PagoAgilFrba.AbmoItem;
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

namespace PagoAgilFrba.AbmFactura
{
    public partial class ALTAFACTURA : Form
    {
        int totalSumaItems;
        List<Decimal> totalASumar = new List<decimal>();
        public ALTAFACTURA()
        {
            InitializeComponent();
           // CargarComboClientes();
            CargarComboEmpresas();
            textCliente.AutoCompleteCustomSource = ClienteDal.LoadAutoComplete();
            textCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            textCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        //private void CargarComboClientes()
        //{
        //    //Vaciar comboBox
        //    comboBoxCliente.DataSource = null;
        //    try
        //    {
        //        //Indicar qué propiedad se verá en la lista
        //        this.comboBoxCliente.DisplayMember = "Nombre";
        //        //Indicar qué valor tendrá cada ítem
        //        this.comboBoxCliente.ValueMember = "Id";
        //        //Asignar la propiedad DataSource
        //        List<Cliente> listita = new List<Cliente>();

        //        listita = ClienteDal.BuscarClientes();
        //        //this.comboBox1.Items.Insert(0, "Seleccione un rol");
        //        //listita.Add(new Cliente(0, "Seleccione un Cliente"));
        //        this.comboBoxCliente.DataSource = listita;
        //        //this.comboBox1.Items.Add(new KeyValuePair<string, string>("0", "Mujer"));
        //    }
        //    catch (Exception e)
        //    { MessageBox.Show("Error al intentar cargar los Clientes -" + e.Message); }
        //}


        private void CargarComboEmpresas()
        {
            //Vaciar comboBox
            comboBoxEmpresa.DataSource = null;
            try
            {
                //Indicar qué propiedad se verá en la lista
                this.comboBoxEmpresa.DisplayMember = "Nombre";
                //Indicar qué valor tendrá cada ítem
                this.comboBoxEmpresa.ValueMember = "Id";
                //Asignar la propiedad DataSource
                List<Empresa> listita = new List<Empresa>();

                listita = EmpresaDal.BuscarEmpresas();
                //this.comboBox1.Items.Insert(0, "Seleccione un rol");
               // listita.Add(new Empresa(0, "Seleccione una Empresa"));
                this.comboBoxEmpresa.DataSource = listita;
                //this.comboBox1.Items.Add(new KeyValuePair<string, string>("0", "Mujer"));
            }
            catch (Exception e)
            { MessageBox.Show("Error al intentar cargar las Empresas -" + e.Message); }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ALTAFACTURA_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public bool IsNumber(string numero)
        {
            return Regex.IsMatch(numero, @"^\d+$");
        } 
        private void guardar_Click(object sender, EventArgs e)
        {

            DateTime Hoy = DateTime.Today;
            List<Item> items = new List<Item>();
            Factura factura = new Factura();
            ClienteDal clientedal = new ClienteDal();
          //  Cliente cliente = new Cliente();
            EmpresaDal empresadal = new EmpresaDal();
           //funcion para buscar el id dni-mail del cliente dado el nombre
            //validar que solo ingrese nros en el nro de factura

            try
            {
                if (!this.IsNumber(textBox1.Text))
                {
                    MessageBox.Show("Error: El nro de Factura debe ser numérico.");
                }
                else
                {
                   // cliente = clientedal.BuscarClientePorNombreYApellido(comboBoxCliente.Text);
                    if (textCliente.Text == "")
                    {
                        MessageBox.Show("Error. Debe ingresar un DNI");
                    }
                    else
                    {
                        factura.cli_dni = Convert.ToDecimal(textCliente.Text);
                        factura.cli_mail = Cliente.obtenerMailPorDNI(textCliente.Text);
                    }
                    
                    
                    factura.codFactura = Convert.ToInt32(textBox1.Text);
                    factura.empresa_id = empresadal.buscarIdPorNombre(comboBoxEmpresa.Text);
                }
                if (dateTimePicker1.Value.ToString("dd/MM/yyyy") != Hoy.ToString("dd/MM/yyyy"))
                {
                    MessageBox.Show("Error: la fecha de alta debe coincidir con la actual.");
                }
                else
                {
                    factura.fechaAlta = dateTimePicker1.Value;
                }
                //validar fecha de hoy con la de vto
                if (DateTime.Compare(dateTimePicker2.Value, DateTime.Today) < 0)
                {
                    MessageBox.Show("Error: la fecha de vencimiento debe ser posterior a la actual.");
                }
                else
                {
                    factura.fechaVenc = dateTimePicker2.Value;
                }
                

              
               
                FacturaDal fdal = new FacturaDal();
                if (textCliente.Text == "" || textBox1.Text == "" || comboBoxEmpresa.SelectedValue == "")
                {
                    MessageBox.Show("Error. Todos los campos deben estar completos");
                }
                else
                {
                    if ((fdal.buscarIdFactura(Convert.ToInt32(textBox1.Text)) > 0))
                    {
                        MessageBox.Show("Error. Ya existe ese código de Factura");
                    }
                    else
                    {
                        if ((totalSumaItems < 0))
                        {
                            MessageBox.Show("Error. Factura con importe negativo.");
                        }
                        else
                        {
                            if (textCliente.Text== "" || textBox1.Text == "" || comboBoxEmpresa.SelectedValue == "")
                            {
                                MessageBox.Show("Error. Todos los campos deben estar completos");
                            }
                            else
                            {
                                int idFactura=FacturaDal.registrar(factura.cli_dni, factura.cli_mail, factura.empresa_id, factura.codFactura, factura.fechaAlta, factura.fechaVenc, factura.total);
                                if (idFactura>0)
                                {   
                                    factura.total = 0;
                                    totalItems.Text = "";
                                    for (int fila = 0; fila < dataGridView1.Rows.Count - 1; fila++)
                                    {
                                        //for (int col = 0; col < dataGridView1.Rows[fila].Cells.Count; col++)
                                        //{
                                            string valor = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                                            dataGridView1.Rows[fila].Cells["Total"].Value = Convert.ToInt32(dataGridView1.Rows[fila].Cells["Precio"].Value) * Convert.ToInt32(dataGridView1.Rows[fila].Cells["Cantidad"].Value);
                                            //falta ver como obtener el id de la factura porque todavia esa fact no se creo..
                                            ItemDal.registrar(dataGridView1.Rows[fila].Cells["Nombre"].Value.ToString(), Convert.ToDecimal(dataGridView1.Rows[fila].Cells["Precio"].Value), Convert.ToInt32(dataGridView1.Rows[fila].Cells["Cantidad"].Value),idFactura );                  
                                            //MessageBox.Show(valor);
                                        //}
                                       totalASumar.Add( Convert.ToInt32(dataGridView1.Rows[fila].Cells["Total"].Value));
                                    }
                                    
                                    totalItems.Text = totalASumar.Sum().ToString() ;
                                    if (Convert.ToDecimal(totalItems.Text) < 0)
                                    {
                                        //Delete de factura
                                        FacturaDal.delete(idFactura);
                                        MessageBox.Show("Error. No se puede dar de alta a una factura con importe negativo");
                                    }
                                    else
                                    {
                                        //update de factura
                                        FacturaDal.update(idFactura, Convert.ToDecimal(totalItems.Text));
                                        factura.total = Convert.ToDecimal(totalASumar.Sum().ToString());
                                        MessageBox.Show("Factura registrada Correctamente!");
                                    }

                                    
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo registrar la factura :(");
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
