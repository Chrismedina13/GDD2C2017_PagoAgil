namespace PagoAgilFrba.AbmSucursal
{
    partial class agregar_sucursal
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Direccion = new System.Windows.Forms.TextBox();
            this.codigoPostal = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.agregarEmpresa = new System.Windows.Forms.Button();
            this.SuspendLayout();
     
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
            this.label4.Text = "codigo postal:";
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
            this.codigoPostal.Location = new System.Drawing.Point(97, 129);
            this.codigoPostal.Name = "codigo postal";
            this.codigoPostal.Size = new System.Drawing.Size(159, 20);
            this.codigoPostal.TabIndex = 5;
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
            // bton_agregarSucursal            // 
            this.agregarEmpresa.Location = new System.Drawing.Point(206, 265);
            this.agregarEmpresa.Name = "agregarSucursal";
            this.agregarEmpresa.Size = new System.Drawing.Size(100, 49);
            this.agregarEmpresa.TabIndex = 11;
            this.agregarEmpresa.Text = "AGREGAR SUCURSAL";
            this.agregarEmpresa.UseVisualStyleBackColor = true;
            this.agregarEmpresa.Click += new System.EventHandler(this.agregarEmpresa_Click);
 
            // 
            // agregar_sucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 349);
            this.Controls.Add(this.agregarEmpresa);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.codigoPostal);
            this.Controls.Add(this.Direccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "agregar_sucursal";
            this.Text = "AGREGAR SUCURSAL ";
            this.Load += new System.EventHandler(this.agregar_sucursal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Direccion;
        private System.Windows.Forms.TextBox codigoPostal;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button agregarEmpresa;
    }

}