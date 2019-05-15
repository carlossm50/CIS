namespace INV
{
    partial class frminvHistorial
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtentidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btngenerar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtfecha);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtentidad);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(16, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 77);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            // 
            // txtfecha
            // 
            this.txtfecha.Enabled = false;
            this.txtfecha.Location = new System.Drawing.Point(81, 39);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(133, 20);
            this.txtfecha.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Fecha";
            // 
            // txtentidad
            // 
            this.txtentidad.Enabled = false;
            this.txtentidad.Location = new System.Drawing.Point(81, 13);
            this.txtentidad.Name = "txtentidad";
            this.txtentidad.Size = new System.Drawing.Size(318, 20);
            this.txtentidad.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Entidad";
            // 
            // btngenerar
            // 
            this.btngenerar.Location = new System.Drawing.Point(279, 88);
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(75, 23);
            this.btngenerar.TabIndex = 77;
            this.btngenerar.Text = "Generar";
            this.btngenerar.UseVisualStyleBackColor = true;
            this.btngenerar.Click += new System.EventHandler(this.button1_Click);
            // 
            // frminvHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 125);
            this.Controls.Add(this.btngenerar);
            this.Controls.Add(this.groupBox2);
            this.Name = "frminvHistorial";
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.frminvHistorial_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtentidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btngenerar;

    }
}