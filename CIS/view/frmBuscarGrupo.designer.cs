﻿namespace CIS
{
    partial class frmBuscarGrupo
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.dtgGrupos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(0, 1);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(19, 20);
            this.textBox3.TabIndex = 48;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(79, 1);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(352, 20);
            this.txtDescripcion.TabIndex = 47;
            this.txtDescripcion.Click += new System.EventHandler(this.txtDescripcion_Click);
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(19, 1);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(61, 20);
            this.txtCodigo.TabIndex = 46;
            this.txtCodigo.Click += new System.EventHandler(this.txtCodigo_Click);
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // dtgGrupos
            // 
            this.dtgGrupos.AllowUserToAddRows = false;
            this.dtgGrupos.AllowUserToDeleteRows = false;
            this.dtgGrupos.AllowUserToOrderColumns = true;
            this.dtgGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion});
            this.dtgGrupos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgGrupos.Location = new System.Drawing.Point(-1, 20);
            this.dtgGrupos.MultiSelect = false;
            this.dtgGrupos.Name = "dtgGrupos";
            this.dtgGrupos.ReadOnly = true;
            this.dtgGrupos.RowHeadersWidth = 20;
            this.dtgGrupos.Size = new System.Drawing.Size(432, 169);
            this.dtgGrupos.TabIndex = 45;
            this.dtgGrupos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGrupo_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 60;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripción";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 350;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::CIS.Properties.Resources._Cancel;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(393, 188);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(39, 33);
            this.btnCancelar.TabIndex = 44;
            this.btnCancelar.Text = " ";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::CIS.Properties.Resources._Accept;
            this.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAceptar.Location = new System.Drawing.Point(356, 188);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(39, 33);
            this.btnAceptar.TabIndex = 43;
            this.btnAceptar.Text = " ";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmBuscarGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 220);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.dtgGrupos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximumSize = new System.Drawing.Size(447, 259);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(447, 259);
            this.Name = "frmBuscarGrupo";
            this.Text = "Lookup Grupo";
            this.Load += new System.EventHandler(this.frmBuscarGrupo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridView dtgGrupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}