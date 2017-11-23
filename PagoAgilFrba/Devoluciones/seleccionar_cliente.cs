﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Support;

namespace PagoAgilFrba.Devoluciones
{
    public partial class seleccionar_cliente : Form
    {
        public seleccionar_cliente()
        {
            InitializeComponent();
            Database.cargarGriddCliente(dataGridViewSeleccionarCliente, "", "", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            String nombre = textNombre.Text;
            String apellido = textApellido.Text;
            String dni = textDni.Text;
            if (!System.Text.RegularExpressions.Regex.IsMatch(textDni.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textNombre.Text.Trim() == "" | textApellido.Text.Trim() == "" | textDni.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (dni.Length != 8)
            {
                MessageBox.Show("Verificar que el DNI haya sido ingresado de forma correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var respuesta = MessageBox.Show("¿Estas seguro?", "Confirme borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    devolucion_factura form ; //= new devolucion_factura(nombre, apellido, dni);
                    form.Show();
                }
            }
        }

        private void seleccionar_cliente_Load(object sender, EventArgs e)
        {

        }

    }
}
