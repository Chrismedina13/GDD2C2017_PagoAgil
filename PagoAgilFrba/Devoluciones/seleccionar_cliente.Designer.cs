﻿namespace PagoAgilFrba.Devoluciones
{
    partial class seleccionar_cliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnSeleccionarCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.textDni = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.dataGridViewSeleccionarCliente = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeleccionarCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "VOLVER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSeleccionarCliente
            // 
            this.btnSeleccionarCliente.Location = new System.Drawing.Point(377, 26);
            this.btnSeleccionarCliente.Name = "btnSeleccionarCliente";
            this.btnSeleccionarCliente.Size = new System.Drawing.Size(108, 49);
            this.btnSeleccionarCliente.TabIndex = 1;
            this.btnSeleccionarCliente.Text = "SELECCIONAR";
            this.btnSeleccionarCliente.UseVisualStyleBackColor = true;
            this.btnSeleccionarCliente.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Apellido : ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "DNI :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(167, 67);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(147, 20);
            this.textApellido.TabIndex = 11;
            // 
            // textDni
            // 
            this.textDni.Location = new System.Drawing.Point(167, 108);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(147, 20);
            this.textDni.TabIndex = 12;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(167, 26);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(147, 20);
            this.textNombre.TabIndex = 10;
            this.textNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridViewSeleccionarCliente
            // 
            this.dataGridViewSeleccionarCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeleccionarCliente.Location = new System.Drawing.Point(58, 182);
            this.dataGridViewSeleccionarCliente.Name = "dataGridViewSeleccionarCliente";
            this.dataGridViewSeleccionarCliente.Size = new System.Drawing.Size(439, 125);
            this.dataGridViewSeleccionarCliente.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ingrese datos para filtrar la tabla";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "EMAIL :";
            // 
            // seleccionar_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 319);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridViewSeleccionarCliente);
            this.Controls.Add(this.textDni);
            this.Controls.Add(this.textApellido);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSeleccionarCliente);
            this.Controls.Add(this.button1);
            this.Name = "seleccionar_cliente";
            this.Text = "Devoluciones";
            this.Load += new System.EventHandler(this.seleccionar_cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeleccionarCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSeleccionarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.TextBox textDni;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.DataGridView dataGridViewSeleccionarCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;


    }
}