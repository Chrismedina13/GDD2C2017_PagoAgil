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
            this.volver = new System.Windows.Forms.Button();
            this.confirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.facturasDgv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.motivoTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.totalTb = new System.Windows.Forms.TextBox();
            this.tituloLb = new System.Windows.Forms.Label();
            this.cerrarSesionHl = new System.Windows.Forms.LinkLabel();
            this.exitBtn = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.facturasDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // volver
            // 
            this.volver.BackColor = System.Drawing.SystemColors.Control;
            this.volver.Location = new System.Drawing.Point(377, 81);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(86, 47);
            this.volver.TabIndex = 1;
            this.volver.Text = "VOLVER";
            this.volver.UseVisualStyleBackColor = false;
            // 
            // confirmar
            // 
            this.confirmar.Location = new System.Drawing.Point(0, 0);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(75, 23);
            this.confirmar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione las facturas a devolver";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // facturasDgv
            // 
            this.facturasDgv.AllowUserToAddRows = false;
            this.facturasDgv.AllowUserToDeleteRows = false;
            this.facturasDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facturasDgv.Location = new System.Drawing.Point(16, 75);
            this.facturasDgv.Name = "facturasDgv";
            this.facturasDgv.Size = new System.Drawing.Size(473, 245);
            this.facturasDgv.TabIndex = 1;
            this.facturasDgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.facturasDgv_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Motivo:";
            // 
            // motivoTb
            // 
            this.motivoTb.Location = new System.Drawing.Point(12, 393);
            this.motivoTb.Name = "motivoTb";
            this.motivoTb.Size = new System.Drawing.Size(477, 20);
            this.motivoTb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total:";
            // 
            // totalTb
            // 
            this.totalTb.Location = new System.Drawing.Point(352, 343);
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
            // cerrarSesionHl
            // 
            this.cerrarSesionHl.AutoSize = true;
            this.cerrarSesionHl.Location = new System.Drawing.Point(426, 41);
            this.cerrarSesionHl.Name = "cerrarSesionHl";
            this.cerrarSesionHl.Size = new System.Drawing.Size(67, 13);
            this.cerrarSesionHl.TabIndex = 8;
            this.cerrarSesionHl.TabStop = true;
            this.cerrarSesionHl.Text = "cerrar sesión";
            // 
            // exitBtn
            // 
            this.exitBtn.AutoSize = true;
            this.exitBtn.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.exitBtn.LinkColor = System.Drawing.Color.LightGray;
            this.exitBtn.Location = new System.Drawing.Point(467, 9);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(16, 13);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.TabStop = true;
            this.exitBtn.Text = "X";
            // 
            // devolucion_factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 486);
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
        private System.Windows.Forms.LinkLabel cerrarSesionHl;
        private System.Windows.Forms.LinkLabel exitBtn;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button confirmar;
    }
}