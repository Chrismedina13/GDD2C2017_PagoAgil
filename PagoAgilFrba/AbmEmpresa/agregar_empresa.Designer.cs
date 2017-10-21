namespace PagoAgilFrba.AbmEmpresa
{
    partial class agregar_empresa
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Direccion = new System.Windows.Forms.TextBox();
            this.cuit = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.agregarEmpresa = new System.Windows.Forms.Button();
            this.comboRubro = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rubro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Direccion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cuit:";
            // 
            // Direccion
            // 
            this.Direccion.Location = new System.Drawing.Point(97, 103);
            this.Direccion.Name = "Direccion";
            this.Direccion.Size = new System.Drawing.Size(159, 20);
            this.Direccion.TabIndex = 4;
            // 
            // cuit
            // 
            this.cuit.Location = new System.Drawing.Point(97, 129);
            this.cuit.Name = "cuit";
            this.cuit.Size = new System.Drawing.Size(159, 20);
            this.cuit.TabIndex = 5;
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(97, 77);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(159, 20);
            this.nombre.TabIndex = 6;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 265);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(101, 49);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // bton_agregarEmpresa
            // 
            this.agregarEmpresa.Location = new System.Drawing.Point(206, 265);
            this.agregarEmpresa.Name = "agregarEmpresa";
            this.agregarEmpresa.Size = new System.Drawing.Size(100, 49);
            this.agregarEmpresa.TabIndex = 11;
            this.agregarEmpresa.Text = "AGREGAR EMPRESA";
            this.agregarEmpresa.UseVisualStyleBackColor = true;
            this.agregarEmpresa.Click += new System.EventHandler(this.agregarEmpresa_Click);
            // 
            // comboRubro
            // 
            this.comboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRubro.FormattingEnabled = true;
            this.comboRubro.Location = new System.Drawing.Point(97, 51);
            this.comboRubro.Name = "comboRubro";
            this.comboRubro.Size = new System.Drawing.Size(159, 21);
            this.comboRubro.TabIndex = 17;
            // 
            // agregar_empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 349);
            this.Controls.Add(this.comboRubro);
            this.Controls.Add(this.agregarEmpresa);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.cuit);
            this.Controls.Add(this.Direccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "agregar_empresa";
            this.Text = "AGREGAR EMPRESA ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Direccion;
        private System.Windows.Forms.TextBox cuit;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button agregarEmpresa;
        private System.Windows.Forms.ComboBox comboRubro;
    }


}