namespace PagoAgilFrba.AbmFactura
{
    partial class Alta_Factura
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
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxNroFact = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.labelSucursal = new System.Windows.Forms.Label();
            this.labelFechaAct = new System.Windows.Forms.Label();
            this.Guardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textCliente = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textImporte = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número de factura";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Fecha de cobro";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Empresa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Cliente *";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Fecha de vencimiento de la factura";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Sucursal";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // textBoxNroFact
            // 
            this.textBoxNroFact.Location = new System.Drawing.Point(332, 42);
            this.textBoxNroFact.Name = "textBoxNroFact";
            this.textBoxNroFact.Size = new System.Drawing.Size(107, 20);
            this.textBoxNroFact.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(190, 88);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(178, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(66, 137);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(125, 21);
            this.comboBoxEmpresa.TabIndex = 10;
            this.comboBoxEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmpresa_SelectedIndexChanged);
            // 
            // labelSucursal
            // 
            this.labelSucursal.AutoSize = true;
            this.labelSucursal.Location = new System.Drawing.Point(118, 18);
            this.labelSucursal.Name = "labelSucursal";
            this.labelSucursal.Size = new System.Drawing.Size(10, 13);
            this.labelSucursal.TabIndex = 12;
            this.labelSucursal.Text = " ";
            // 
            // labelFechaAct
            // 
            this.labelFechaAct.AutoSize = true;
            this.labelFechaAct.Location = new System.Drawing.Point(310, 18);
            this.labelFechaAct.Name = "labelFechaAct";
            this.labelFechaAct.Size = new System.Drawing.Size(10, 13);
            this.labelFechaAct.TabIndex = 13;
            this.labelFechaAct.Text = " ";
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(194, 304);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(108, 28);
            this.Guardar.TabIndex = 14;
            this.Guardar.Text = "Volver";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textImporte);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textCliente);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.textBoxNroFact);
            this.groupBox2.Controls.Add(this.comboBoxEmpresa);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(23, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(463, 215);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda por Factura";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textCliente
            // 
            this.textCliente.Location = new System.Drawing.Point(66, 40);
            this.textCliente.Name = "textCliente";
            this.textCliente.Size = new System.Drawing.Size(105, 20);
            this.textCliente.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(237, 196);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "* Campos oligatorios";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Importe";
            // 
            // textImporte
            // 
            this.textImporte.Location = new System.Drawing.Point(58, 186);
            this.textImporte.Name = "textImporte";
            this.textImporte.Size = new System.Drawing.Size(100, 20);
            this.textImporte.TabIndex = 21;
            // 
            // Alta_Factura
            // 
            this.ClientSize = new System.Drawing.Size(498, 344);
            this.Controls.Add(this.labelFechaAct);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.labelSucursal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Name = "Alta_Factura";
            this.Load += new System.EventHandler(this.Alta_Factura_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblLstFunc;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxNroFact;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.Label labelSucursal;
        private System.Windows.Forms.Label labelFechaAct;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textCliente;
        private System.Windows.Forms.TextBox textImporte;
        private System.Windows.Forms.Label label10;
    }
}