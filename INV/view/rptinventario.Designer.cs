namespace INV.view
{
    partial class rptinventario
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
            this.btnimprimir = new System.Windows.Forms.Button();
            this.cbxinventario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnimprimir
            // 
            this.btnimprimir.Location = new System.Drawing.Point(108, 80);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(75, 23);
            this.btnimprimir.TabIndex = 5;
            this.btnimprimir.Text = "Imprimir";
            this.btnimprimir.UseVisualStyleBackColor = true;
            this.btnimprimir.Click += new System.EventHandler(this.btnimprimir_Click);
            // 
            // cbxinventario
            // 
            this.cbxinventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxinventario.FormattingEnabled = true;
            this.cbxinventario.Location = new System.Drawing.Point(78, 40);
            this.cbxinventario.Name = "cbxinventario";
            this.cbxinventario.Size = new System.Drawing.Size(222, 21);
            this.cbxinventario.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inventario";
            // 
            // rptinventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 143);
            this.Controls.Add(this.btnimprimir);
            this.Controls.Add(this.cbxinventario);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(335, 181);
            this.MinimumSize = new System.Drawing.Size(335, 181);
            this.Name = "rptinventario";
            this.Text = "Reporte de inventario";
            this.Load += new System.EventHandler(this.rptinventario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnimprimir;
        private System.Windows.Forms.ComboBox cbxinventario;
        private System.Windows.Forms.Label label1;
    }
}