﻿namespace Contabilidad
{
    partial class frmcntcta
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtdetalle = new System.Windows.Forms.RadioButton();
            this.rbtmaestra = new System.Windows.Forms.RadioButton();
            this.txtcntctama = new System.Windows.Forms.TextBox();
            this.btnTipo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcntctano = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.txtcntctanom = new System.Windows.Forms.TextBox();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnAdjuntar = new System.Windows.Forms.Button();
            this.btnNotas = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtcntctama);
            this.groupBox1.Controls.Add(this.btnTipo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtcntctano);
            this.groupBox1.Controls.Add(this.lbID);
            this.groupBox1.Controls.Add(this.lbCodigo);
            this.groupBox1.Controls.Add(this.txtcntctanom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cuenta contable";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtdetalle);
            this.groupBox2.Controls.Add(this.rbtmaestra);
            this.groupBox2.Location = new System.Drawing.Point(99, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 37);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            // 
            // rbtdetalle
            // 
            this.rbtdetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtdetalle.AutoSize = true;
            this.rbtdetalle.Location = new System.Drawing.Point(87, 11);
            this.rbtdetalle.Name = "rbtdetalle";
            this.rbtdetalle.Size = new System.Drawing.Size(58, 17);
            this.rbtdetalle.TabIndex = 1;
            this.rbtdetalle.TabStop = true;
            this.rbtdetalle.Text = "Detalle";
            this.rbtdetalle.UseVisualStyleBackColor = true;
            // 
            // rbtmaestra
            // 
            this.rbtmaestra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtmaestra.AutoSize = true;
            this.rbtmaestra.Location = new System.Drawing.Point(7, 11);
            this.rbtmaestra.Name = "rbtmaestra";
            this.rbtmaestra.Size = new System.Drawing.Size(63, 17);
            this.rbtmaestra.TabIndex = 0;
            this.rbtmaestra.TabStop = true;
            this.rbtmaestra.Text = "Maestra";
            this.rbtmaestra.UseVisualStyleBackColor = true;
            // 
            // txtcntctama
            // 
            this.txtcntctama.BackColor = System.Drawing.SystemColors.Window;
            this.txtcntctama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcntctama.Enabled = false;
            this.txtcntctama.Location = new System.Drawing.Point(99, 116);
            this.txtcntctama.Name = "txtcntctama";
            this.txtcntctama.Size = new System.Drawing.Size(160, 20);
            this.txtcntctama.TabIndex = 2;
            this.txtcntctama.Tag = "Cuenta Maestra";
            // 
            // btnTipo
            // 
            this.btnTipo.AccessibleDescription = "";
            this.btnTipo.AccessibleName = "";
            this.btnTipo.BackColor = System.Drawing.SystemColors.Menu;
            this.btnTipo.Image = global::Contabilidad.Properties.Resources._Lookup;
            this.btnTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTipo.Location = new System.Drawing.Point(265, 114);
            this.btnTipo.Name = "btnTipo";
            this.btnTipo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnTipo.Size = new System.Drawing.Size(30, 22);
            this.btnTipo.TabIndex = 40;
            this.btnTipo.Tag = " ";
            this.btnTipo.Text = " ";
            this.btnTipo.UseVisualStyleBackColor = false;
            this.btnTipo.Click += new System.EventHandler(this.btnTipo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(8, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Cuenta maestra:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(301, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(8, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cuenta tipo.:";
            // 
            // txtcntctano
            // 
            this.txtcntctano.Location = new System.Drawing.Point(99, 35);
            this.txtcntctano.Name = "txtcntctano";
            this.txtcntctano.Size = new System.Drawing.Size(160, 20);
            this.txtcntctano.TabIndex = 0;
            this.txtcntctano.Tag = "Numero de Cuenta";
            this.txtcntctano.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcntctano_KeyPress);
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbID.Location = new System.Drawing.Point(8, 38);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(64, 13);
            this.lbID.TabIndex = 10;
            this.lbID.Text = "Cuenta No.:";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCodigo.Location = new System.Drawing.Point(271, 38);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(82, 13);
            this.lbCodigo.TabIndex = 11;
            this.lbCodigo.Text = "Cuenta nombre:";
            // 
            // txtcntctanom
            // 
            this.txtcntctanom.BackColor = System.Drawing.SystemColors.Window;
            this.txtcntctanom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcntctanom.Location = new System.Drawing.Point(355, 35);
            this.txtcntctanom.Name = "txtcntctanom";
            this.txtcntctanom.Size = new System.Drawing.Size(209, 20);
            this.txtcntctanom.TabIndex = 1;
            // 
            // btnPrimero
            // 
            this.btnPrimero.Enabled = false;
            this.btnPrimero.Image = global::Contabilidad.Properties.Resources._First_;
            this.btnPrimero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrimero.Location = new System.Drawing.Point(49, 176);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(26, 33);
            this.btnPrimero.TabIndex = 69;
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.Enabled = false;
            this.btnUltimo.Image = global::Contabilidad.Properties.Resources._Last;
            this.btnUltimo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUltimo.Location = new System.Drawing.Point(117, 176);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(26, 33);
            this.btnUltimo.TabIndex = 72;
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Enabled = false;
            this.btnSiguiente.Image = global::Contabilidad.Properties.Resources._Next;
            this.btnSiguiente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSiguiente.Location = new System.Drawing.Point(95, 176);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(24, 33);
            this.btnSiguiente.TabIndex = 71;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Enabled = false;
            this.btnAtras.Image = global::Contabilidad.Properties.Resources._Previous;
            this.btnAtras.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAtras.Location = new System.Drawing.Point(73, 176);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(24, 33);
            this.btnAtras.TabIndex = 70;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.Enabled = false;
            this.btnAdjuntar.Image = global::Contabilidad.Properties.Resources._Attachs;
            this.btnAdjuntar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdjuntar.Location = new System.Drawing.Point(324, 176);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(39, 33);
            this.btnAdjuntar.TabIndex = 78;
            this.btnAdjuntar.Text = " ";
            this.btnAdjuntar.UseVisualStyleBackColor = true;
            // 
            // btnNotas
            // 
            this.btnNotas.Enabled = false;
            this.btnNotas.Image = global::Contabilidad.Properties.Resources._Notes;
            this.btnNotas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNotas.Location = new System.Drawing.Point(358, 176);
            this.btnNotas.Name = "btnNotas";
            this.btnNotas.Size = new System.Drawing.Size(39, 33);
            this.btnNotas.TabIndex = 79;
            this.btnNotas.Text = " ";
            this.btnNotas.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = global::Contabilidad.Properties.Resources._Printer;
            this.btnImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnImprimir.Location = new System.Drawing.Point(287, 176);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(39, 33);
            this.btnImprimir.TabIndex = 77;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Contabilidad.Properties.Resources._Search1;
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(12, 176);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(39, 33);
            this.btnBuscar.TabIndex = 68;
            this.btnBuscar.Text = " ";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Image = global::Contabilidad.Properties.Resources._Accept;
            this.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAceptar.Location = new System.Drawing.Point(250, 176);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(39, 33);
            this.btnAceptar.TabIndex = 76;
            this.btnAceptar.Text = " ";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Contabilidad.Properties.Resources._Close;
            this.btnSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalir.Location = new System.Drawing.Point(395, 176);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(39, 33);
            this.btnSalir.TabIndex = 80;
            this.btnSalir.Text = " ";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = global::Contabilidad.Properties.Resources._Cancel;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(214, 176);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(39, 33);
            this.btnCancelar.TabIndex = 75;
            this.btnCancelar.Text = " ";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Image = global::Contabilidad.Properties.Resources._Edit;
            this.btnEditar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditar.Location = new System.Drawing.Point(177, 176);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(39, 33);
            this.btnEditar.TabIndex = 74;
            this.btnEditar.Text = " ";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Contabilidad.Properties.Resources._New;
            this.btnNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNuevo.Location = new System.Drawing.Point(141, 176);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(39, 33);
            this.btnNuevo.TabIndex = 73;
            this.btnNuevo.Text = " ";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmcntcta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 215);
            this.Controls.Add(this.btnPrimero);
            this.Controls.Add(this.btnUltimo);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnAdjuntar);
            this.Controls.Add(this.btnNotas);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmcntcta";
            this.Text = "Registrar cuenta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnAdjuntar;
        private System.Windows.Forms.Button btnNotas;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtdetalle;
        private System.Windows.Forms.RadioButton rbtmaestra;
        private System.Windows.Forms.TextBox txtcntctama;
        private System.Windows.Forms.Button btnTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcntctano;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox txtcntctanom;
    }
}