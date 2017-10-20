namespace PagoAgilFrba.AbmCliente
{
    partial class abm_cliente
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
            this.components = new System.ComponentModel.Container();
            this.btn_acliente = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();


            this.btn_acliente.Location = new System.Drawing.Point(86, 25);
            this.btn_acliente.Name = "btn_acliente";
            this.btn_acliente.Size = new System.Drawing.Size(146, 57);
            this.btn_acliente.TabIndex = 0;
            this.btn_acliente.Text = "AGREGAR CLIENTE";
            this.btn_acliente.UseVisualStyleBackColor = true;
            this.btn_acliente.Click += new System.EventHandler(this.button1_Click);

            this.button2.Location = new System.Drawing.Point(86, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 66);
            this.button2.TabIndex = 2;
            this.button2.Text = "MODIFICAR CLIENTE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);

            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);

            this.button3.Location = new System.Drawing.Point(86, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 58);
            this.button3.TabIndex = 3;
            this.button3.Text = "ELIMINAR CLIENTE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);

            this.button1.Location = new System.Drawing.Point(114, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_acliente);
            this.Name = "abm_cliente";
            this.Text = "ABM CLIENTE";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btn_acliente;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;



        #endregion
    }
}