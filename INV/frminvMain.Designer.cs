namespace INV
{
    partial class frminvMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frminvMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgInvMain = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.existencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNewOk = new System.Windows.Forms.Button();
            this.btnsync = new System.Windows.Forms.Button();
            this.txtexistencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtprecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcosto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidproducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBuscaEntidad = new System.Windows.Forms.Button();
            this.cbxentidad = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txttotalprod = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtinvinicial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcxp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcxc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtefectivo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtgasto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvMain)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dtgInvMain);
            this.groupBox1.Location = new System.Drawing.Point(182, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1047, 466);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Productos";
            // 
            // dtgInvMain
            // 
            this.dtgInvMain.AllowUserToAddRows = false;
            this.dtgInvMain.AllowUserToDeleteRows = false;
            this.dtgInvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgInvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion,
            this.costo,
            this.precio,
            this.existencia});
            this.dtgInvMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgInvMain.Location = new System.Drawing.Point(6, 19);
            this.dtgInvMain.MultiSelect = false;
            this.dtgInvMain.Name = "dtgInvMain";
            this.dtgInvMain.ReadOnly = true;
            this.dtgInvMain.RowHeadersWidth = 20;
            this.dtgInvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInvMain.Size = new System.Drawing.Size(1035, 441);
            this.dtgInvMain.TabIndex = 59;
            this.dtgInvMain.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgInvMain_RowEnter);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "id_producto";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 60;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "nom_producto";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 350;
            // 
            // costo
            // 
            this.costo.DataPropertyName = "costo_producto";
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Width = 131;
            // 
            // precio
            // 
            this.precio.DataPropertyName = "precio_producto";
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Width = 131;
            // 
            // existencia
            // 
            this.existencia.DataPropertyName = "existencia_producto";
            this.existencia.HeaderText = "Existencia";
            this.existencia.Name = "existencia";
            this.existencia.ReadOnly = true;
            this.existencia.Width = 131;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNewOk);
            this.groupBox2.Controls.Add(this.btnsync);
            this.groupBox2.Controls.Add(this.txtexistencia);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtprecio);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtcosto);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtdescripcion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtidproducto);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(182, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1266, 50);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            // 
            // btnNewOk
            // 
            this.btnNewOk.Image = ((System.Drawing.Image)(resources.GetObject("btnNewOk.Image")));
            this.btnNewOk.Location = new System.Drawing.Point(1096, 13);
            this.btnNewOk.Name = "btnNewOk";
            this.btnNewOk.Size = new System.Drawing.Size(37, 25);
            this.btnNewOk.TabIndex = 81;
            this.btnNewOk.Tag = "0";
            this.btnNewOk.UseVisualStyleBackColor = true;
            this.btnNewOk.Click += new System.EventHandler(this.btnNewOk_Click);
            // 
            // btnsync
            // 
            this.btnsync.Enabled = false;
            this.btnsync.Image = ((System.Drawing.Image)(resources.GetObject("btnsync.Image")));
            this.btnsync.Location = new System.Drawing.Point(1053, 14);
            this.btnsync.Name = "btnsync";
            this.btnsync.Size = new System.Drawing.Size(37, 25);
            this.btnsync.TabIndex = 82;
            this.btnsync.UseVisualStyleBackColor = true;
            this.btnsync.Click += new System.EventHandler(this.btnsync_Click);
            // 
            // txtexistencia
            // 
            this.txtexistencia.Location = new System.Drawing.Point(916, 18);
            this.txtexistencia.Name = "txtexistencia";
            this.txtexistencia.Size = new System.Drawing.Size(131, 20);
            this.txtexistencia.TabIndex = 80;
            this.txtexistencia.TextChanged += new System.EventHandler(this.txtexistencia_TextChanged);
            this.txtexistencia.Validating += new System.ComponentModel.CancelEventHandler(this.txtexistencia_Validating);
            this.txtexistencia.Validated += new System.EventHandler(this.txtexistencia_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(861, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 79;
            this.label5.Text = "Existencia";
            // 
            // txtprecio
            // 
            this.txtprecio.Enabled = false;
            this.txtprecio.Location = new System.Drawing.Point(720, 19);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(131, 20);
            this.txtprecio.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(685, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 77;
            this.label4.Text = "Precio";
            // 
            // txtcosto
            // 
            this.txtcosto.Enabled = false;
            this.txtcosto.Location = new System.Drawing.Point(539, 19);
            this.txtcosto.Name = "txtcosto";
            this.txtcosto.Size = new System.Drawing.Size(142, 20);
            this.txtcosto.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(482, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Costo";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Enabled = false;
            this.txtdescripcion.Location = new System.Drawing.Point(217, 18);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(259, 20);
            this.txtdescripcion.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Descripción";
            // 
            // txtidproducto
            // 
            this.txtidproducto.Enabled = false;
            this.txtidproducto.Location = new System.Drawing.Point(54, 19);
            this.txtidproducto.Name = "txtidproducto";
            this.txtidproducto.Size = new System.Drawing.Size(98, 20);
            this.txtidproducto.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Código";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.groupBox3.Controls.Add(this.btnEntrada);
            this.groupBox3.Controls.Add(this.btnHistorial);
            this.groupBox3.Controls.Add(this.btnSalida);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(4, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 601);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            // 
            // btnEntrada
            // 
            this.btnEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnEntrada.FlatAppearance.BorderSize = 0;
            this.btnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrada.ForeColor = System.Drawing.Color.White;
            this.btnEntrada.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrada.Image")));
            this.btnEntrada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntrada.Location = new System.Drawing.Point(6, 90);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(160, 49);
            this.btnEntrada.TabIndex = 72;
            this.btnEntrada.Text = "NUEVA ENTIDAD";
            this.btnEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEntrada.UseVisualStyleBackColor = false;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnHistorial.FlatAppearance.BorderSize = 0;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.ForeColor = System.Drawing.Color.White;
            this.btnHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorial.Location = new System.Drawing.Point(8, 200);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(158, 49);
            this.btnHistorial.TabIndex = 72;
            this.btnHistorial.Text = "PROCESAR INVENTARIO   ";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnSalida
            // 
            this.btnSalida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnSalida.FlatAppearance.BorderSize = 0;
            this.btnSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalida.ForeColor = System.Drawing.Color.White;
            this.btnSalida.Image = ((System.Drawing.Image)(resources.GetObject("btnSalida.Image")));
            this.btnSalida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalida.Location = new System.Drawing.Point(6, 145);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(160, 49);
            this.btnSalida.TabIndex = 72;
            this.btnSalida.Text = "NUEVA PRODUCTO";
            this.btnSalida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalida.UseVisualStyleBackColor = false;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBuscaEntidad);
            this.groupBox4.Controls.Add(this.cbxentidad);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(186, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1043, 50);
            this.groupBox4.TabIndex = 71;
            this.groupBox4.TabStop = false;
            // 
            // btnBuscaEntidad
            // 
            this.btnBuscaEntidad.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscaEntidad.Image")));
            this.btnBuscaEntidad.Location = new System.Drawing.Point(652, 14);
            this.btnBuscaEntidad.Name = "btnBuscaEntidad";
            this.btnBuscaEntidad.Size = new System.Drawing.Size(37, 25);
            this.btnBuscaEntidad.TabIndex = 84;
            this.btnBuscaEntidad.UseVisualStyleBackColor = true;
            this.btnBuscaEntidad.Click += new System.EventHandler(this.btnBuscaEntidad_Click);
            // 
            // cbxentidad
            // 
            this.cbxentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxentidad.FormattingEnabled = true;
            this.cbxentidad.Location = new System.Drawing.Point(59, 18);
            this.cbxentidad.Name = "cbxentidad";
            this.cbxentidad.Size = new System.Drawing.Size(587, 21);
            this.cbxentidad.TabIndex = 72;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Entidad";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txttotalprod);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtinvinicial);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtcxp);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtcxc);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtefectivo);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtgasto);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(1235, 126);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(216, 255);
            this.groupBox5.TabIndex = 71;
            this.groupBox5.TabStop = false;
            // 
            // txttotalprod
            // 
            this.txttotalprod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalprod.Enabled = false;
            this.txttotalprod.Location = new System.Drawing.Point(84, 197);
            this.txttotalprod.Name = "txttotalprod";
            this.txttotalprod.Size = new System.Drawing.Size(98, 20);
            this.txttotalprod.TabIndex = 82;
            this.txttotalprod.Text = "20000";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(0, 190);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 32);
            this.label12.TabIndex = 81;
            this.label12.Text = "Total productos";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtinvinicial
            // 
            this.txtinvinicial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtinvinicial.Enabled = false;
            this.txtinvinicial.Location = new System.Drawing.Point(84, 163);
            this.txtinvinicial.Name = "txtinvinicial";
            this.txtinvinicial.Size = new System.Drawing.Size(98, 20);
            this.txtinvinicial.TabIndex = 80;
            this.txtinvinicial.Text = "20000";
            this.txtinvinicial.Validating += new System.ComponentModel.CancelEventHandler(this.txtinvinicial_Validating);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 32);
            this.label6.TabIndex = 79;
            this.label6.Text = "Inventario Inicial";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtcxp
            // 
            this.txtcxp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcxp.Location = new System.Drawing.Point(84, 129);
            this.txtcxp.Name = "txtcxp";
            this.txtcxp.Size = new System.Drawing.Size(98, 20);
            this.txtcxp.TabIndex = 78;
            this.txtcxp.Text = "20000";
            this.txtcxp.Validating += new System.ComponentModel.CancelEventHandler(this.txtcxp_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 77;
            this.label7.Text = "CXP";
            // 
            // txtcxc
            // 
            this.txtcxc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcxc.Location = new System.Drawing.Point(84, 95);
            this.txtcxc.Name = "txtcxc";
            this.txtcxc.Size = new System.Drawing.Size(98, 20);
            this.txtcxc.TabIndex = 76;
            this.txtcxc.Text = "20000";
            this.txtcxc.Validating += new System.ComponentModel.CancelEventHandler(this.txtcxc_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "CXC";
            // 
            // txtefectivo
            // 
            this.txtefectivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtefectivo.Location = new System.Drawing.Point(84, 61);
            this.txtefectivo.Name = "txtefectivo";
            this.txtefectivo.Size = new System.Drawing.Size(98, 20);
            this.txtefectivo.TabIndex = 74;
            this.txtefectivo.Text = "20000";
            this.txtefectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtefectivo_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = "Efectivo";
            // 
            // txtgasto
            // 
            this.txtgasto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtgasto.Location = new System.Drawing.Point(84, 27);
            this.txtgasto.Name = "txtgasto";
            this.txtgasto.Size = new System.Drawing.Size(98, 20);
            this.txtgasto.TabIndex = 72;
            this.txtgasto.Text = "20000";
            this.txtgasto.Validating += new System.ComponentModel.CancelEventHandler(this.txtgasto_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 71;
            this.label11.Text = "Gastos";
            // 
            // frminvMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 660);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frminvMain";
            this.Text = "Control de inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frminvMain_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInvMain)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgInvMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNewOk;
        private System.Windows.Forms.Button btnsync;
        private System.Windows.Forms.TextBox txtexistencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcosto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbxentidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBuscaEntidad;
        private System.Windows.Forms.TextBox txtidproducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtinvinicial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtcxp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcxc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtefectivo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtgasto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn existencia;
        private System.Windows.Forms.TextBox txttotalprod;
        private System.Windows.Forms.Label label12;
    }
}

