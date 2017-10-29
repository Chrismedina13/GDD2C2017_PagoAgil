namespace PagoAgilFrba.AbmSucursal
{
    partial class modificar_sucursal
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
            this.btnModificarSucursal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textCodigoPostal = new System.Windows.Forms.TextBox();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.dataGridViewModificarSucursal = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificarSucursal)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "VOLVER";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnModificarSucursal
            // 
            this.btnModificarSucursal.Location = new System.Drawing.Point(377, 26);
            this.btnModificarSucursal.Name = "btnModificarSucursal";
            this.btnModificarSucursal.Size = new System.Drawing.Size(86, 47);
            this.btnModificarSucursal.TabIndex = 1;
            this.btnModificarSucursal.Text = "MODIFICAR";
            this.btnModificarSucursal.UseVisualStyleBackColor = true;
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
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cod. Postal : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Direccion :";
            // 
            // textCodigoPostal
            // 
            this.textCodigoPostal.Location = new System.Drawing.Point(167, 67);
            this.textCodigoPostal.Name = "textCodigoPostal";
            this.textCodigoPostal.Size = new System.Drawing.Size(147, 20);
            this.textCodigoPostal.TabIndex = 11;
            // 
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(167, 108);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(147, 20);
            this.textDireccion.TabIndex = 12;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(167, 26);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(147, 20);
            this.textNombre.TabIndex = 10;
            // 
            // dataGridViewModificarSucursal
            // 
            this.dataGridViewModificarSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewModificarSucursal.Location = new System.Drawing.Point(58, 157);
            this.dataGridViewModificarSucursal.Name = "dataGridViewModificarSucursal";
            this.dataGridViewModificarSucursal.Size = new System.Drawing.Size(439, 150);
            this.dataGridViewModificarSucursal.TabIndex = 14;
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
            // modificar_sucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 319);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridViewModificarSucursal);
            this.Controls.Add(this.textDireccion);
            this.Controls.Add(this.textCodigoPostal);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModificarSucursal);
            this.Controls.Add(this.button1);
            this.Name = "modificar_sucursal";
            this.Text = "MODIFICAR SUCURSAL";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificarSucursal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnModificarSucursal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCodigoPostal;
        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.DataGridView dataGridViewModificarSucursal;
        private System.Windows.Forms.Label label6;
    }
}