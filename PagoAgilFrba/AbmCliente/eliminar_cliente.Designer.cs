namespace PagoAgilFrba.AbmCliente
{
    partial class eliminar_cliente
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
            this.boton_cancelar = new System.Windows.Forms.Button();
            this.boton_eliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.textDni = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewEliminarC = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEliminarC)).BeginInit();
            this.SuspendLayout();
            // 
            // boton_cancelar
            // 
            this.boton_cancelar.Location = new System.Drawing.Point(358, 80);
            this.boton_cancelar.Name = "boton_cancelar";
            this.boton_cancelar.Size = new System.Drawing.Size(98, 49);
            this.boton_cancelar.TabIndex = 1;
            this.boton_cancelar.Text = "CANCELAR";
            this.boton_cancelar.UseVisualStyleBackColor = true;
            this.boton_cancelar.Click += new System.EventHandler(this.boton_cancelar_Click);
            // 
            // boton_eliminar
            // 
            this.boton_eliminar.Location = new System.Drawing.Point(358, 23);
            this.boton_eliminar.Name = "boton_eliminar";
            this.boton_eliminar.Size = new System.Drawing.Size(98, 51);
            this.boton_eliminar.TabIndex = 2;
            this.boton_eliminar.Text = "ELIMINAR";
            this.boton_eliminar.UseVisualStyleBackColor = true;
            this.boton_eliminar.Click += new System.EventHandler(this.boton_eliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(99, 34);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(182, 20);
            this.textNombre.TabIndex = 4;
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(99, 64);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(182, 20);
            this.textApellido.TabIndex = 5;
            // 
            // textDni
            // 
            this.textDni.Location = new System.Drawing.Point(99, 95);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(182, 20);
            this.textDni.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "DNI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Apellido";
            // 
            // dataGridViewEliminarC
            // 
            this.dataGridViewEliminarC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEliminarC.Location = new System.Drawing.Point(32, 180);
            this.dataGridViewEliminarC.Name = "dataGridViewEliminarC";
            this.dataGridViewEliminarC.Size = new System.Drawing.Size(477, 184);
            this.dataGridViewEliminarC.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ingrese datos para filtrar la tabla";
            // 
            // eliminar_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 425);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridViewEliminarC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDni);
            this.Controls.Add(this.textApellido);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boton_eliminar);
            this.Controls.Add(this.boton_cancelar);
            this.Name = "eliminar_cliente";
            this.Text = "ELIMINAR CLIENTE";
            this.Load += new System.EventHandler(this.eliminar_cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEliminarC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button boton_cancelar;
        private System.Windows.Forms.Button boton_eliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.TextBox textDni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewEliminarC;
        private System.Windows.Forms.Label label6;
    }


}