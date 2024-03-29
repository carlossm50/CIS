﻿namespace Contabilidad
{
    partial class frmcntent
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
            this.txtCtaMonto = new System.Windows.Forms.TextBox();
            this.btnConEditar = new System.Windows.Forms.Button();
            this.btnConCancelar = new System.Windows.Forms.Button();
            this.btnConAceptar = new System.Windows.Forms.Button();
            this.btnConBorrar = new System.Windows.Forms.Button();
            this.btnConAgregar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtcredito = new System.Windows.Forms.RadioButton();
            this.rbtdebito = new System.Windows.Forms.RadioButton();
            this.dtgTipos = new System.Windows.Forms.DataGridView();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCtaNo = new System.Windows.Forms.TextBox();
            this.btnBusCta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCtaNom = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCtaEntValor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConceptoEnt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.txtEntNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCtaMonto);
            this.groupBox2.Controls.Add(this.btnConEditar);
            this.groupBox2.Controls.Add(this.btnConCancelar);
            this.groupBox2.Controls.Add(this.btnConAceptar);
            this.groupBox2.Controls.Add(this.btnConBorrar);
            this.groupBox2.Controls.Add(this.btnConAgregar);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.dtgTipos);
            this.groupBox2.Controls.Add(this.txtCtaNo);
            this.groupBox2.Controls.Add(this.btnBusCta);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCtaNom);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(724, 289);
            this.groupBox2.TabIndex = 110;
            this.groupBox2.TabStop = false;
            // 
            // txtCtaMonto
            // 
            this.txtCtaMonto.BackColor = System.Drawing.SystemColors.Window;
            this.txtCtaMonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtaMonto.Location = new System.Drawing.Point(467, 22);
            this.txtCtaMonto.Name = "txtCtaMonto";
            this.txtCtaMonto.Size = new System.Drawing.Size(165, 20);
            this.txtCtaMonto.TabIndex = 2;
            // 
            // btnConEditar
            // 
            this.btnConEditar.Enabled = false;
            this.btnConEditar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConEditar.Location = new System.Drawing.Point(73, 251);
            this.btnConEditar.Name = "btnConEditar";
            this.btnConEditar.Size = new System.Drawing.Size(59, 23);
            this.btnConEditar.TabIndex = 5;
            this.btnConEditar.Text = "Editar";
            this.btnConEditar.UseVisualStyleBackColor = true;
            // 
            // btnConCancelar
            // 
            this.btnConCancelar.Enabled = false;
            this.btnConCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConCancelar.Location = new System.Drawing.Point(281, 251);
            this.btnConCancelar.Name = "btnConCancelar";
            this.btnConCancelar.Size = new System.Drawing.Size(59, 23);
            this.btnConCancelar.TabIndex = 8;
            this.btnConCancelar.Text = "Cancelar";
            this.btnConCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConAceptar
            // 
            this.btnConAceptar.Enabled = false;
            this.btnConAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConAceptar.Location = new System.Drawing.Point(227, 251);
            this.btnConAceptar.Name = "btnConAceptar";
            this.btnConAceptar.Size = new System.Drawing.Size(53, 23);
            this.btnConAceptar.TabIndex = 7;
            this.btnConAceptar.Text = "Aceptar";
            this.btnConAceptar.UseVisualStyleBackColor = true;
            this.btnConAceptar.Click += new System.EventHandler(this.btnConAceptar_Click);
            // 
            // btnConBorrar
            // 
            this.btnConBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConBorrar.Location = new System.Drawing.Point(135, 251);
            this.btnConBorrar.Name = "btnConBorrar";
            this.btnConBorrar.Size = new System.Drawing.Size(59, 23);
            this.btnConBorrar.TabIndex = 6;
            this.btnConBorrar.Text = "Borrar";
            this.btnConBorrar.UseVisualStyleBackColor = true;
            this.btnConBorrar.Click += new System.EventHandler(this.btnConBorrar_Click);
            // 
            // btnConAgregar
            // 
            this.btnConAgregar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConAgregar.Location = new System.Drawing.Point(17, 251);
            this.btnConAgregar.Name = "btnConAgregar";
            this.btnConAgregar.Size = new System.Drawing.Size(53, 23);
            this.btnConAgregar.TabIndex = 4;
            this.btnConAgregar.Text = "Agregar";
            this.btnConAgregar.UseVisualStyleBackColor = true;
            this.btnConAgregar.Click += new System.EventHandler(this.btnConAgregar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtcredito);
            this.groupBox3.Controls.Add(this.rbtdebito);
            this.groupBox3.Location = new System.Drawing.Point(638, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(80, 67);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // rbtcredito
            // 
            this.rbtcredito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtcredito.AutoSize = true;
            this.rbtcredito.Location = new System.Drawing.Point(7, 34);
            this.rbtcredito.Name = "rbtcredito";
            this.rbtcredito.Size = new System.Drawing.Size(58, 17);
            this.rbtcredito.TabIndex = 1;
            this.rbtcredito.Text = "Credito";
            this.rbtcredito.UseVisualStyleBackColor = true;
            // 
            // rbtdebito
            // 
            this.rbtdebito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtdebito.AutoSize = true;
            this.rbtdebito.Checked = true;
            this.rbtdebito.Location = new System.Drawing.Point(7, 11);
            this.rbtdebito.Name = "rbtdebito";
            this.rbtdebito.Size = new System.Drawing.Size(56, 17);
            this.rbtdebito.TabIndex = 0;
            this.rbtdebito.TabStop = true;
            this.rbtdebito.Text = "Debito";
            this.rbtdebito.UseVisualStyleBackColor = true;
            // 
            // dtgTipos
            // 
            this.dtgTipos.AllowUserToAddRows = false;
            this.dtgTipos.AllowUserToDeleteRows = false;
            this.dtgTipos.AllowUserToOrderColumns = true;
            this.dtgTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cuenta,
            this.Descripcion,
            this.Monto,
            this.origen});
            this.dtgTipos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgTipos.Location = new System.Drawing.Point(17, 57);
            this.dtgTipos.MultiSelect = false;
            this.dtgTipos.Name = "dtgTipos";
            this.dtgTipos.ReadOnly = true;
            this.dtgTipos.RowHeadersWidth = 20;
            this.dtgTipos.Size = new System.Drawing.Size(615, 188);
            this.dtgTipos.TabIndex = 58;
            // 
            // Cuenta
            // 
            this.Cuenta.DataPropertyName = "cntctano";
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.ReadOnly = true;
            this.Cuenta.Width = 200;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "cntctanom";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 200;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "cntctamonto";
            this.Monto.HeaderText = "Momto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // origen
            // 
            this.origen.DataPropertyName = "cntctaOrigen";
            this.origen.HeaderText = "Origen";
            this.origen.Name = "origen";
            this.origen.ReadOnly = true;
            // 
            // txtCtaNo
            // 
            this.txtCtaNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtCtaNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtaNo.Location = new System.Drawing.Point(59, 22);
            this.txtCtaNo.Name = "txtCtaNo";
            this.txtCtaNo.Size = new System.Drawing.Size(146, 20);
            this.txtCtaNo.TabIndex = 0;
            // 
            // btnBusCta
            // 
            this.btnBusCta.AccessibleDescription = "";
            this.btnBusCta.AccessibleName = "";
            this.btnBusCta.BackColor = System.Drawing.SystemColors.Menu;
            this.btnBusCta.Image = global::Contabilidad.Properties.Resources._Lookup;
            this.btnBusCta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBusCta.Location = new System.Drawing.Point(204, 21);
            this.btnBusCta.Name = "btnBusCta";
            this.btnBusCta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBusCta.Size = new System.Drawing.Size(30, 22);
            this.btnBusCta.TabIndex = 44;
            this.btnBusCta.Tag = " ";
            this.btnBusCta.Text = " ";
            this.btnBusCta.UseVisualStyleBackColor = false;
            this.btnBusCta.Click += new System.EventHandler(this.btnBusCta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Cuenta:";
            // 
            // txtCtaNom
            // 
            this.txtCtaNom.BackColor = System.Drawing.SystemColors.Window;
            this.txtCtaNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtaNom.Location = new System.Drawing.Point(235, 22);
            this.txtCtaNom.Name = "txtCtaNom";
            this.txtCtaNom.Size = new System.Drawing.Size(211, 20);
            this.txtCtaNom.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEntNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCtaEntValor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtConceptoEnt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 80);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            // 
            // txtCtaEntValor
            // 
            this.txtCtaEntValor.BackColor = System.Drawing.SystemColors.Window;
            this.txtCtaEntValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtaEntValor.Location = new System.Drawing.Point(543, 37);
            this.txtCtaEntValor.Name = "txtCtaEntValor";
            this.txtCtaEntValor.Size = new System.Drawing.Size(158, 20);
            this.txtCtaEntValor.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(489, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Valor:";
            // 
            // txtConceptoEnt
            // 
            this.txtConceptoEnt.BackColor = System.Drawing.SystemColors.Window;
            this.txtConceptoEnt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConceptoEnt.Location = new System.Drawing.Point(76, 37);
            this.txtConceptoEnt.Name = "txtConceptoEnt";
            this.txtConceptoEnt.Size = new System.Drawing.Size(390, 20);
            this.txtConceptoEnt.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(22, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Concepto:";
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.SystemColors.Window;
            this.txtFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFecha.Location = new System.Drawing.Point(543, 11);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(158, 20);
            this.txtFecha.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(483, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Fecha:";
            // 
            // btnPrimero
            // 
            this.btnPrimero.Enabled = false;
            this.btnPrimero.Image = global::Contabilidad.Properties.Resources._First_;
            this.btnPrimero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrimero.Location = new System.Drawing.Point(52, 392);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(26, 33);
            this.btnPrimero.TabIndex = 98;
            this.btnPrimero.UseVisualStyleBackColor = true;
            // 
            // btnUltimo
            // 
            this.btnUltimo.Enabled = false;
            this.btnUltimo.Image = global::Contabilidad.Properties.Resources._Last;
            this.btnUltimo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUltimo.Location = new System.Drawing.Point(120, 392);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(26, 33);
            this.btnUltimo.TabIndex = 101;
            this.btnUltimo.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Enabled = false;
            this.btnSiguiente.Image = global::Contabilidad.Properties.Resources._Next;
            this.btnSiguiente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSiguiente.Location = new System.Drawing.Point(98, 392);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(24, 33);
            this.btnSiguiente.TabIndex = 100;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAtras
            // 
            this.btnAtras.Enabled = false;
            this.btnAtras.Image = global::Contabilidad.Properties.Resources._Previous;
            this.btnAtras.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAtras.Location = new System.Drawing.Point(76, 392);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(24, 33);
            this.btnAtras.TabIndex = 99;
            this.btnAtras.UseVisualStyleBackColor = true;
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.Enabled = false;
            this.btnAdjuntar.Image = global::Contabilidad.Properties.Resources._Attachs;
            this.btnAdjuntar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdjuntar.Location = new System.Drawing.Point(327, 392);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(39, 33);
            this.btnAdjuntar.TabIndex = 107;
            this.btnAdjuntar.Text = " ";
            this.btnAdjuntar.UseVisualStyleBackColor = true;
            // 
            // btnNotas
            // 
            this.btnNotas.Enabled = false;
            this.btnNotas.Image = global::Contabilidad.Properties.Resources._Notes;
            this.btnNotas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNotas.Location = new System.Drawing.Point(361, 392);
            this.btnNotas.Name = "btnNotas";
            this.btnNotas.Size = new System.Drawing.Size(39, 33);
            this.btnNotas.TabIndex = 108;
            this.btnNotas.Text = " ";
            this.btnNotas.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = global::Contabilidad.Properties.Resources._Printer;
            this.btnImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnImprimir.Location = new System.Drawing.Point(290, 392);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(39, 33);
            this.btnImprimir.TabIndex = 106;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Contabilidad.Properties.Resources._Search1;
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(15, 392);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(39, 33);
            this.btnBuscar.TabIndex = 97;
            this.btnBuscar.Text = " ";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::Contabilidad.Properties.Resources._Accept;
            this.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAceptar.Location = new System.Drawing.Point(253, 392);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(39, 33);
            this.btnAceptar.TabIndex = 105;
            this.btnAceptar.Text = " ";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Contabilidad.Properties.Resources._Close;
            this.btnSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalir.Location = new System.Drawing.Point(397, 392);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(39, 33);
            this.btnSalir.TabIndex = 109;
            this.btnSalir.Text = " ";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = global::Contabilidad.Properties.Resources._Cancel;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(217, 392);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(39, 33);
            this.btnCancelar.TabIndex = 104;
            this.btnCancelar.Text = " ";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Image = global::Contabilidad.Properties.Resources._Edit;
            this.btnEditar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditar.Location = new System.Drawing.Point(180, 392);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(39, 33);
            this.btnEditar.TabIndex = 103;
            this.btnEditar.Text = " ";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Contabilidad.Properties.Resources._New;
            this.btnNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNuevo.Location = new System.Drawing.Point(144, 392);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(39, 33);
            this.btnNuevo.TabIndex = 102;
            this.btnNuevo.Text = " ";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // txtEntNo
            // 
            this.txtEntNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtEntNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEntNo.Enabled = false;
            this.txtEntNo.Location = new System.Drawing.Point(76, 11);
            this.txtEntNo.Name = "txtEntNo";
            this.txtEntNo.Size = new System.Drawing.Size(139, 20);
            this.txtEntNo.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(14, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Entrada No:";
            // 
            // frmcntent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 432);
            this.Controls.Add(this.groupBox2);
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
            this.Name = "frmcntent";
            this.Text = "Entrada de diario";
            this.Load += new System.EventHandler(this.frmcntent_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConEditar;
        private System.Windows.Forms.Button btnConCancelar;
        private System.Windows.Forms.Button btnConAceptar;
        private System.Windows.Forms.Button btnConBorrar;
        private System.Windows.Forms.Button btnConAgregar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtcredito;
        private System.Windows.Forms.RadioButton rbtdebito;
        private System.Windows.Forms.DataGridView dtgTipos;
        private System.Windows.Forms.TextBox txtCtaNo;
        private System.Windows.Forms.Button btnBusCta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCtaNom;
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
        private System.Windows.Forms.TextBox txtConceptoEnt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCtaMonto;
        private System.Windows.Forms.TextBox txtCtaEntValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn origen;
        private System.Windows.Forms.TextBox txtEntNo;
        private System.Windows.Forms.Label label5;
    }
}