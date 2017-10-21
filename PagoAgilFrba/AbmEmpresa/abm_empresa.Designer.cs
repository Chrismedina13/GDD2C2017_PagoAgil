namespace PagoAgilFrba.AbmEmpresa
{
    partial class abm_empresa
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
            this.btnAgregarEmpresa = new System.Windows.Forms.Button();
            this.btnModificarEmpresa = new System.Windows.Forms.Button();
            this.btnEliminarEmpresa = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarEmpresa
            // 
            this.btnAgregarEmpresa.Location = new System.Drawing.Point(104, 46);
            this.btnAgregarEmpresa.Name = "btnAgregarEmpresa";
            this.btnAgregarEmpresa.Size = new System.Drawing.Size(131, 48);
            this.btnAgregarEmpresa.TabIndex = 0;
            this.btnAgregarEmpresa.Text = "AGREGAR EMPRESA";
            this.btnAgregarEmpresa.UseVisualStyleBackColor = true;
            this.btnAgregarEmpresa.Click += new System.EventHandler(this.btnAgregarEmpresa_Click);
            // 
            // btnModificarEmpresa
            // 
            this.btnModificarEmpresa.Location = new System.Drawing.Point(104, 116);
            this.btnModificarEmpresa.Name = "btnModificarEmpresa";
            this.btnModificarEmpresa.Size = new System.Drawing.Size(131, 53);
            this.btnModificarEmpresa.TabIndex = 1;
            this.btnModificarEmpresa.Text = "MODIFICAR EMPRESA";
            this.btnModificarEmpresa.UseVisualStyleBackColor = true;
            this.btnModificarEmpresa.Click += new System.EventHandler(this.btnModificarEmpresa_Click);
            // 
            // btnEliminarEmpresa
            // 
            this.btnEliminarEmpresa.Location = new System.Drawing.Point(104, 187);
            this.btnEliminarEmpresa.Name = "btnEliminarEmpresa";
            this.btnEliminarEmpresa.Size = new System.Drawing.Size(131, 55);
            this.btnEliminarEmpresa.TabIndex = 2;
            this.btnEliminarEmpresa.Text = "ELIMINAR EMPRESA";
            this.btnEliminarEmpresa.UseVisualStyleBackColor = true;
            this.btnEliminarEmpresa.Click += new System.EventHandler(this.btnEliminarEmpresa_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(104, 270);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(131, 23);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // abm_Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 318);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnEliminarEmpresa);
            this.Controls.Add(this.btnModificarEmpresa);
            this.Controls.Add(this.btnAgregarEmpresa);
            this.Name = "abm_empresa";
            this.Text = "ABM EMPRESA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnAgregarEmpresa;
        private System.Windows.Forms.Button btnModificarEmpresa;
        private System.Windows.Forms.Button btnEliminarEmpresa;
        private System.Windows.Forms.Button btnVolver;


    }
}