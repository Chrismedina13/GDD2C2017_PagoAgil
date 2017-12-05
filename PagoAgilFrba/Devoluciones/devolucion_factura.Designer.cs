namespace PagoAgilFrba.Devoluciones
{
    partial class devolucion_factura
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
            this.label1 = new System.Windows.Forms.Label();
            this.facturasDgv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.motivoTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.totalTb = new System.Windows.Forms.TextBox();
            this.tituloLb = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.facturasDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECCIONE FACTURAS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // facturasDgv
            // 
            this.facturasDgv.AllowUserToAddRows = false;
            this.facturasDgv.AllowUserToDeleteRows = false;
            this.facturasDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facturasDgv.Location = new System.Drawing.Point(12, 63);
            this.facturasDgv.Name = "facturasDgv";
            this.facturasDgv.Size = new System.Drawing.Size(473, 245);
            this.facturasDgv.TabIndex = 1;
            this.facturasDgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.facturasDgv_CellContentClick);
            this.facturasDgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.facturasDgv_CellValueChanged);
            this.facturasDgv.CurrentCellDirtyStateChanged += new System.EventHandler(this.facturasDgv_CurrentCellDirtyStateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MOTIVO DE DEVOLUCION:";
            // 
            // motivoTb
            // 
            this.motivoTb.Location = new System.Drawing.Point(15, 385);
            this.motivoTb.Name = "motivoTb";
            this.motivoTb.Size = new System.Drawing.Size(474, 20);
            this.motivoTb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total:";
            // 
            // totalTb
            // 
            this.totalTb.Location = new System.Drawing.Point(296, 328);
            this.totalTb.Name = "totalTb";
            this.totalTb.ReadOnly = true;
            this.totalTb.Size = new System.Drawing.Size(120, 20);
            this.totalTb.TabIndex = 5;
            this.totalTb.TextChanged += new System.EventHandler(this.totalTb_TextChanged);
            // 
            // tituloLb
            // 
            this.tituloLb.AutoSize = true;
            this.tituloLb.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloLb.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.tituloLb.Location = new System.Drawing.Point(74, 9);
            this.tituloLb.Name = "tituloLb";
            this.tituloLb.Size = new System.Drawing.Size(197, 18);
            this.tituloLb.TabIndex = 10;
            this.tituloLb.Text = "Devolución de Facturas";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 47);
            this.button1.TabIndex = 6;
            this.button1.Text = "VOLVER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(286, 427);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 47);
            this.button2.TabIndex = 7;
            this.button2.Text = "CONFIRMAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // devolucion_factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 486);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.totalTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.motivoTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.facturasDgv);
            this.Controls.Add(this.label1);
            this.Name = "devolucion_factura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolucion de Facturas2";
            this.Load += new System.EventHandler(this.devolucion_factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facturasDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView facturasDgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox motivoTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox totalTb;
        private System.Windows.Forms.Label tituloLb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}