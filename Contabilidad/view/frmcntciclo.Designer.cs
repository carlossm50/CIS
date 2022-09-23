namespace Contabilidad.view
{
    partial class frmcntciclo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenPeri = new System.Windows.Forms.Button();
            this.dtgPeriodos = new System.Windows.Forms.DataGridView();
            this.txtEntNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnaceptar = new System.Windows.Forms.Button();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aniociclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPeriodos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGenPeri);
            this.groupBox1.Controls.Add(this.dtgPeriodos);
            this.groupBox1.Controls.Add(this.txtEntNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 296);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            // 
            // btnGenPeri
            // 
            this.btnGenPeri.Location = new System.Drawing.Point(206, 12);
            this.btnGenPeri.Name = "btnGenPeri";
            this.btnGenPeri.Size = new System.Drawing.Size(132, 23);
            this.btnGenPeri.TabIndex = 60;
            this.btnGenPeri.Text = "Generar periodos";
            this.btnGenPeri.UseVisualStyleBackColor = true;
            this.btnGenPeri.Click += new System.EventHandler(this.btnGenPeri_Click);
            // 
            // dtgPeriodos
            // 
            this.dtgPeriodos.AllowUserToAddRows = false;
            this.dtgPeriodos.AllowUserToDeleteRows = false;
            this.dtgPeriodos.AllowUserToOrderColumns = true;
            this.dtgPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPeriodos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mes,
            this.estado,
            this.aniociclo});
            this.dtgPeriodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgPeriodos.Location = new System.Drawing.Point(17, 41);
            this.dtgPeriodos.MultiSelect = false;
            this.dtgPeriodos.Name = "dtgPeriodos";
            this.dtgPeriodos.ReadOnly = true;
            this.dtgPeriodos.RowHeadersWidth = 20;
            this.dtgPeriodos.Size = new System.Drawing.Size(456, 247);
            this.dtgPeriodos.TabIndex = 59;
            // 
            // txtEntNo
            // 
            this.txtEntNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtEntNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEntNo.Location = new System.Drawing.Point(52, 12);
            this.txtEntNo.Name = "txtEntNo";
            this.txtEntNo.Size = new System.Drawing.Size(139, 20);
            this.txtEntNo.TabIndex = 47;
            this.txtEntNo.Text = "2020";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(17, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Año:";
            // 
            // btnaceptar
            // 
            this.btnaceptar.Location = new System.Drawing.Point(211, 316);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(75, 23);
            this.btnaceptar.TabIndex = 98;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.UseVisualStyleBackColor = true;
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // mes
            // 
            this.mes.DataPropertyName = "periodo";
            this.mes.HeaderText = "Mes";
            this.mes.Name = "mes";
            this.mes.ReadOnly = true;
            this.mes.Width = 150;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 200;
            // 
            // aniociclo
            // 
            this.aniociclo.DataPropertyName = "anociclo";
            this.aniociclo.HeaderText = "Ciclo";
            this.aniociclo.Name = "aniociclo";
            this.aniociclo.ReadOnly = true;
            // 
            // frmcntciclo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 356);
            this.Controls.Add(this.btnaceptar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmcntciclo";
            this.Text = "Crear ciclo contable";
            this.Load += new System.EventHandler(this.frmcntciclo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPeriodos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEntNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgPeriodos;
        private System.Windows.Forms.Button btnGenPeri;
        private System.Windows.Forms.Button btnaceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn aniociclo;
    }
}