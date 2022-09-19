using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;       //PERMITE UTILIZAR EL DATA SET PARA LLENAR DATA GRIG
using System.Data.SqlClient; //PARA PODER USAR LAS VARIABLES SqlConnection ... 
namespace CIS
{
    public partial class frmClientes : Form
    {
        Datos BtnEjecutado = new Datos();  //PARA USAR UNA VARIABLE QUE ESTA DEFINIDA EN UNA CLASE
        BindingSource BsCliente = new BindingSource();
        BindingSource BsTelCliente = new BindingSource();
        BindingSource BsDirCliente = new BindingSource();
        BindingSource BsContacCliente = new BindingSource();
        DataTable tblTel = new DataTable();
        DataTable tblDir = new DataTable();
        DataTable tblContac = new DataTable();
        int clientePosicion = -1;

        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            StringBuilder SqlQuery = new StringBuilder();
            Datos _datos = new Datos();

            //****************************************************************************************************
            //******** EJECUTAR SI SE PRESIONO EL BOTON BUSCAR ***************************************************
            //****************************************************************************************************
            if (BtnEjecutado.BotonEjecutado == "btnBuscar")
            {
                //**************************************************
                //****PARA BUSCAR LA INFORMACION GENERAL DEL CLIENTE
                //**************************************************
                SqlQuery.Append(
                "select  cgrlentm.grlent_ID,        "   +
                "        cgrlentm.grlent_nombre,    " +
                "        cgrlentm.grlent_apellido,  " +
                "        cgrlentm.grlent_tipo,      " +
                "        cgrlentm.grlent_tipoide,   " +
                "        cgrlentm.grlent_identif,   " +
                "        cgrlentm.grlpai_codigo,    " +
                "        cgrlentm.grlsts_codigo ,   " +
                "        ccxcclim.grlent_ID,        " +
                "        ccxcclim.cxccli_nombre,    " +
                "        ccxcclim.cxccli_fecing,    " +
                "        ccxcclim.grlsts_codigo,    " +
                "        ccxcclim.cxcvin_codigo,    " +
                "        ccxcclim.grlstcv_codigo,   " +
                "        ccxcclim.cxccli_sexo,      " +
                "        cgrlidem.grlide_abrev+'-'+ cgrlidem.grlide_nombre Tipo_Ident,  " +
		        "        ccxcvinm.cxcvin_codigo +'-'+ccxcvinm.cxcvin_nombre cxccli_Vinc,    " +
		        "        cgrlstcvm.grlstcv_codigo+'-'+cgrlstcvm.grlstcv_nombre sts_civil,   " +
		        "        case when ccxcclim.cxccli_sexo = 'M' then 'M-MASCULINO'            " +
		        "        when ccxcclim.cxccli_sexo = 'F' then 'F-FEMENINO'                  " +
		        "         end as sexo,                                                      " +
                "        cast(cgrlstsm.grlsts_codigo as char(1))+'-'+cgrlstsm.grlsts_descrip estado, "+
                "        ccxctclim.cxctcli_codigo,  " +
                "        ccxctclim.cxctcli_nombre,  " +
                "        cgrlpaim.grlpai_nombre, " +
                "        ccxcclim.cxccli_Codigo" +
                "  from cgrlentm                                                            " +
	            "       inner join ccxcclim on cgrlentm.grlent_ID = ccxcclim.grlent_ID      " +
                "       inner join cgrlidem on cgrlidem.grlide_abrev = cgrlentm.grlent_tipoide  " +
	            "       inner join ccxcvinm on ccxcvinm.cxcvin_codigo = ccxcclim.cxcvin_codigo      " +
                "       inner join cgrlstsm on cgrlstsm.grlsts_codigo = ccxcclim.grlsts_codigo and cgrlstsm.grltbl_codigo = 'cgrlentm'" +
                "       inner join ccxctclim on ccxctclim.cxctcli_codigo = ccxcclim.cxctcli_codigo"+
                "       inner join cgrlpaim on cgrlpaim.grlpai_codigo = cgrlentm.grlpai_codigo "+
                "       left join cgrlstcvm on cgrlstcvm.grlstcv_codigo = ccxcclim.grlstcv_codigo  " +
                " where cgrlentm.grlent_ID "+ Datos.OperadorBusqueda(txtID.Text)+
                //"   and ccxctclim.cxctcli_codigo " + Datos.OperadorBusqueda(txtTipoCliente.Text)
                "   and cgrlentm.grlsts_codigo = 1 "+
                "   order by cgrlentm.grlent_ID ");

                if (_datos.ConsultarNoEstatic(SqlQuery.ToString()).Rows.Count > 0)
                {
                    BsCliente.DataSource = _datos.ConsultarNoEstatic(SqlQuery.ToString());

                    txtID.DataBindings.Clear();
                    txtCliCodigo.DataBindings.Clear();
                    txtFullName.DataBindings.Clear();
                    cbxsexo.DataBindings.Clear();
                    cbxTipoIdentificacion.DataBindings.Clear();
                    cbxestadoCivil.DataBindings.Clear();
                    cbxTipoVinculo.DataBindings.Clear();
                    mtxtIdentificacion.DataBindings.Clear();
                    cbxestado.DataBindings.Clear();
                    txtCodigoPais.DataBindings.Clear();
                    txtNombrePais.DataBindings.Clear();
                    txtTipoCliente.DataBindings.Clear();
                    txtTipoclinombre.DataBindings.Clear();
                    dateTimePicker1.DataBindings.Clear();
                    BsCliente.MoveFirst();
                    dateTimePicker1.DataBindings.Add("Value", BsCliente, "cxccli_fecing");
                    cbxestado.DataBindings.Add("Text", BsCliente, "estado");
                    txtID.DataBindings.Add("Text", BsCliente, "grlent_ID");
                    txtCliCodigo.DataBindings.Add("Text", BsCliente, "cxccli_Codigo");
                    txtFullName.DataBindings.Add("Text", BsCliente, "cxccli_nombre");
                    //txtnombresCliente.DataBindings.Add("Text", BsCliente, "grlent_nombre");
                    
                    cbxTipoIdentificacion.DataBindings.Add("Text", BsCliente, "Tipo_Ident");
                    cbxsexo.DataBindings.Add("Text", BsCliente, "sexo");
                    cbxestadoCivil.DataBindings.Add("Text", BsCliente, "sts_civil");
                    cbxTipoVinculo.DataBindings.Add("Text", BsCliente, "cxccli_Vinc");
                    mtxtIdentificacion.DataBindings.Add("Text", BsCliente, "grlent_identif");
                    txtCodigoPais.DataBindings.Add("Text", BsCliente, "grlpai_codigo");
                    txtNombrePais.DataBindings.Add("Text", BsCliente, "grlpai_nombre");
                    txtTipoCliente.DataBindings.Add("Text", BsCliente, "cxctcli_codigo");
                    txtTipoclinombre.DataBindings.Add("Text", BsCliente, "cxctcli_nombre");

                    clientePosicion = BsCliente.Position; //Indica la posicion del registro;
                    this.ActivaEntradasCli(false);
                    
                    //********************************************************************************//////////////////


                    //************************************************************************************
                    //BUSCAR LA INFORMACION DE TELEFONO DIRECCIONES Y CONTACTO ***************************
                    //************************************************************************************
                    this.BuscarTelefono();
                    this.BuscarDireccion();
                    this.BuscarContacto();
                    //********************************************************************************//////////////////


                    btnEditar.Enabled = true;

                }
                else
                {
                    clientePosicion = -1;
                    this.DesconectaEntradasCli();
                    this.LimpiarEntradasCli();
                    this.ActivaEntradasCli(false);
                }
                //********************************************************************************//////////////////

                dtgTelCliente.Enabled = true;
                dtgDircliente.Enabled = true;
                dtgConCliente.Enabled = true;

                //PARA HABILITAR BOTONES**********
                if (BsCliente.Count <= 1)
                {
                    btnPrimero.Enabled = false;
                    btnAtras.Enabled = false;
                    btnSiguiente.Enabled = false;
                    btnUltimo.Enabled = false;
                }
                else
                {
                    btnPrimero.Enabled = false;
                    btnAtras.Enabled = false;
                    btnSiguiente.Enabled = true;
                    btnUltimo.Enabled = true;
                }
                
                if (clientePosicion < 0) this.HabilitaDesplazamiento(false);

                btnBuscar.Enabled = true;
                btnNuevo.Enabled = true;
                btnAceptar.Enabled = false;
                btnImprimir.Enabled = true;
                btnCancelar.Enabled = false;
                btnAdjuntar.Enabled = true;
                btnNotas.Enabled = true;
                btnBuscaPais.Enabled = false;
                btnTipocli.Enabled = false;

                btnTelpais.Enabled = false;
                btnTelAgregar.Enabled = false;
                btnTelEditar.Enabled = false;
                btnTelAceptar.Enabled = false;
                btnTelBorrar.Enabled = false;
                btnTelCancelar.Enabled = false;

                btnDirPais.Enabled = false;
                btnDirAgregar.Enabled = false;
                btnDirEditar.Enabled = false;
                btnDirAceptar.Enabled = false;
                btnDirBorrar.Enabled = false;
                btnDirCancelar.Enabled = false;

                btnConAgregar.Enabled = false;
                btnConEditar.Enabled = false;
                btnConAceptar.Enabled = false;
                btnConBorrar.Enabled = false;
                btnConCancelar.Enabled = false;

                txtID.Enabled = false;
                /*txtEstadoCod.Enabled = false;
                txtDescrip.Enabled = false;
                dtmFechaReg.Enabled = false;
                txtCodFamilia.Enabled = false;*/
                btnBuscaPais.Enabled = false;
                btnTipocli.Enabled = false;
                //Datos.DeshabilitarTexboxTabPage(TabDatos);
                foreach (var Look in TabDatos.Controls)
                {
                    if (Look is TextBox) { ((TextBox)Look).Enabled = false; }
                    if (Look is ComboBox) { ((ComboBox)Look).Enabled = false; }
                    if (Look is DateTimePicker) { ((DateTimePicker)Look).Enabled = false; }
                }
                
                //*************************************************
                //BUSCAR EL TIPO DE PERSONA SI ES FISICA O JURIDICA
                //*************************************************
                if (!string.IsNullOrEmpty(txtID.Text.Trim()))
                {
                    Bucarpersona(txtID.Text);
                    
                }
                
            }

            if (BtnEjecutado.BotonEjecutado == "btnNuevo")
            {
                char persona=' ';
                
                Datos.Conectar();
                switch (rbtFisica.Checked == true || rbtJuridica.Checked == true)
                {

                    case true:
                        {
                            switch (rbtFisica.Checked == true)
                            {
                                case true: { persona = 'F'; }
                                    break;

                                case false: { persona = 'J'; }
                                    break;

                            }
                        }
                        break;
                    case false:
                        {
                            MessageBox.Show("Debe definir el tipo de persona.");
                            return;
                        }
                        break;

                }
                if (!this.ValidaDatosGenerales())
                {
                    return; 
                }
                SqlQuery.Clear();
                try
                {
                    string Nombre = "";
                    string Apellido = "";
                    string sexo = "";
                    string estadocivil = "";
                    if (rbtFisica.Checked)
                    {
                        Nombre   = txtnombresCliente.Text;
                        Apellido =  txtApellidosClientes.Text ;
                        sexo = cbxsexo.Text.Substring(0, 1) ;
                        estadocivil = cbxestadoCivil.Text.Substring(0, 1) ;
                    }
                    else
                    {
                        Nombre = txtFullName.Text;
                        Apellido = null;
                        sexo = null;
                        estadocivil = null;
                    }

                    SqlQuery.Append("Begin transaction ;" );
                    SqlQuery.Append( " declare @grlent_ID int;" );
                    SqlQuery.Append( " declare @cxccli_Codigo int;" );
                    SqlQuery.Append( " insert into cgrlentm (grlent_nombre,grlent_apellido,grlent_tipo,grlent_tipoide,grlent_identif,grlpai_codigo,grlsts_codigo)" );
                    SqlQuery.Append(" values('" + Nombre + "','" + Apellido + "','" + persona + "','" + cbxTipoIdentificacion.Text.Substring(0, 3) + "','" + mtxtIdentificacion.Text + "','" + txtCodigoPais.Text + "'," + "1" + ");");
                    
                    SqlQuery.Append( " set @grlent_ID = scope_identity(); " );
                    SqlQuery.Append( " update cgrlseqs set grlseq_Ultseq = grlseq_Ultseq + 1 where grltbl_codigo='cgrlentm' ; " );
                    SqlQuery.Append( " set @cxccli_Codigo = (select grlseq_Ultseq from cgrlseqs where grltbl_codigo='cgrlentm');" );
                    SqlQuery.Append(" insert into ccxcclim(grlent_ID,cxccli_nombre,cxccli_fecing,grlsts_codigo,cxcvin_codigo,grlstcv_codigo,cxccli_sexo,cxctcli_codigo,cxccli_Codigo,cxccli_fecnac)");
                    SqlQuery.Append(" values(@grlent_ID,'" + txtFullName.Text + "','" + dtmFechNac.Value.ToString("yyyy-MM-dd") + "'," + "1,'" + cbxTipoVinculo.Text.Substring(0, 2) + "','" + estadocivil+ "','" + sexo+ "','" + txtTipoCliente.Text + "',@cxccli_Codigo ,'" + dtmFechNac.Value.ToString("yyyy-MM-dd") + "');");
                    SqlQuery.Append( "Commit transaction"); 
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                int respuesta = Datos.Insertar(SqlQuery);
                
                //dtmFechNac.Value.ToString("yyyy-MM-dd").Replace(" a.m.", "") + "'"
                if (respuesta == 0)
                {
                    btnImprimir.Enabled = true;
                    btnNotas.Enabled = true;
                    btnAdjuntar.Enabled = true;
                }
                else
                {
                    btnImprimir.Enabled = false;
                    btnNotas.Enabled = false;
                    btnAdjuntar.Enabled = false;
                }

                Datos.Desconectar();

                mtxtIdentificacion.Enabled = false;
                txtFullName.Enabled = false;
                txtApellidosClientes.Enabled = false;
                btnCancelar.Enabled = false;
                btnNuevo.Enabled = true;
                btnSalir.Enabled = true;
                Datos.Desconectar();
            }
            if (BtnEjecutado.BotonEjecutado == "btnEditar")
            {
                //Insertar los registros que nuevos con sqldataadapter Para los Telefonos ///////////////////////////
                {
                    char persona = ' ';

                    Datos.Conectar();
                    switch (rbtFisica.Checked == true || rbtJuridica.Checked == true)
                    {

                        case true:
                            {
                                switch (rbtFisica.Checked == true)
                                {
                                    case true: { persona = 'F'; }
                                        break;

                                    case false: { persona = 'J'; }
                                        break;

                                }
                            }
                            break;
                        case false:
                            {
                                MessageBox.Show("Debe definir el tipo de persona.");
                                return;
                            }
                            break;

                    }
                    if (this.ValidaDatosGenerales() == false) { return; }

                    if (btnTelAceptar.Enabled == true)
                    {
                        if (this.btnTelAceptarClic() == false) { return; };
                    }
                    if (btnDirAceptar.Enabled == true)
                    {
                        if (this.btnDirAceptarClic() == false) { return;  };
                    }
                    if (btnConAceptar.Enabled == true)
                    {
                        if (this.btnConAceptarClic() == false) { return; };
                    }

                    try
                    {
                        string Nombre = "";
                        string Apellido = "";
                        string sexo = "";
                        string estadocivil = "";
                        if (rbtFisica.Checked)
                        {
                            Nombre = txtnombresCliente.Text;
                            Apellido = txtApellidosClientes.Text;
                            sexo = cbxsexo.Text.Substring(0, 1);
                            estadocivil = cbxestadoCivil.Text.Substring(0, 1);
                        }
                        else
                        {
                            Nombre = txtFullName.Text;
                            Apellido = null;
                            sexo = null;
                            estadocivil = null;
                        }

                        SqlQuery.Append(" Begin transaction ;");
                        SqlQuery.Append(" update cgrlentm set grlent_nombre='" + Nombre + "',grlent_apellido='" + Apellido + "',grlent_tipo='" + persona + "',grlent_tipoide='" + cbxTipoIdentificacion.Text.Substring(0, 3) + "',grlent_identif='" + mtxtIdentificacion.Text + "',grlpai_codigo='" + txtCodigoPais.Text + "' ");
                        SqlQuery.Append(" where grlent_ID = "+txtID.Text);
                        SqlQuery.Append(" update ccxcclim set cxccli_nombre='" + txtFullName.Text + "',cxccli_fecing='" + dtmFechNac.Value.ToString("yyyy-MM-dd") + "',cxcvin_codigo='" + cbxTipoVinculo.Text.Substring(0, 2) + "',grlstcv_codigo='" + estadocivil + "',cxccli_sexo='" + sexo + "',cxctcli_codigo='" + txtTipoCliente.Text + "',cxccli_fecnac='"+dtmFechNac.Value.ToString("yyyy-MM-dd")+"' ");
                        SqlQuery.Append(" where grlent_ID = " + txtID.Text);
                        SqlQuery.Append("Commit transaction");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    int respuesta = Datos.Insertar(SqlQuery);
                
                    Datos.UpdateTelTable(Convert.ToInt32(txtID.Text), tblTel);
                    dtgTelCliente.Enabled = true;

                    Datos.UpdateDirTable(Convert.ToInt32(txtID.Text), tblDir);
                    dtgDircliente.Enabled = true;
                    
                    Datos.UpdateConTable(Convert.ToInt32(txtID.Text), tblContac);
                    dtgConCliente.Enabled = true;

                    foreach (var Look in TabPConCli.Controls)
                    {
                        if (Look is TextBox) { ((TextBox)Look).Enabled = false; }
                        if (Look is ComboBox) { ((ComboBox)Look).Enabled = false; }
                        if (Look is Button) { ((Button)Look).Enabled = false; }
                    }
                    foreach (var Look in TabPDirCli.Controls)
                    {
                        if (Look is TextBox) { ((TextBox)Look).Enabled = false; }
                        if (Look is ComboBox) { ((ComboBox)Look).Enabled = false; }
                        if (Look is Button) { ((Button)Look).Enabled = false; }
                    }
                    foreach (var Look in TabPTelCli.Controls)
                    {
                        if (Look is TextBox) { ((TextBox)Look).Enabled = false; }
                        if (Look is ComboBox) { ((ComboBox)Look).Enabled = false; }
                        if (Look is Button) { ((Button)Look).Enabled = false; }
                    }
                    
                    ActivaEntradasCli(false);

                    btnBuscar.Enabled = true;
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnAdjuntar.Enabled = true;
                    btnNotas.Enabled = true;
                    btnBuscaPais.Enabled = false;
                    btnTipocli.Enabled = false;

                    btnTelpais.Enabled = false;
                    btnTelAgregar.Enabled = false;
                    btnTelEditar.Enabled = false;
                    btnTelAceptar.Enabled = false;
                    btnTelBorrar.Enabled = false;
                    btnTelCancelar.Enabled = false;

                    //PARA HABILITAR BOTONES DE DESPLAZAMIENTO**********
                    if (BsCliente.Count <= 1)
                    {
                        btnPrimero.Enabled = false;
                        btnAtras.Enabled = false;
                        btnSiguiente.Enabled = false;
                        btnUltimo.Enabled = false;
                    }
                    else
                    {
                        btnPrimero.Enabled = false;
                        btnAtras.Enabled = false;
                        btnSiguiente.Enabled = true;
                        btnUltimo.Enabled = true;
                    }
                }
                //*********************************************************//////////////////////
            }

            BtnEjecutado.BotonEjecutado = ""; //LINPIAMOS LA VARIABLE QUE INDICA EL BOTON EJECUTADO
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            BtnEjecutado.BotonEjecutado = "btnNuevo";


            this.DesconectaEntradasCli();
            this.LimpiarEntradasCli();

            this.ActivaEntradasCli(true);
            this.txtID.Enabled = false;
            this.cbxestado.Enabled = false;
            this.txtCliCodigo.Enabled = false;

            Datos.LimpiaControlTabPage(TabPConCli);
            foreach (var Look in TabPConCli.Controls)
            {
                if (Look is TextBox) { ((TextBox)Look).DataBindings.Clear(); }
                if (Look is ComboBox) { ((ComboBox)Look).DataBindings.Clear(); }
            }

            Datos.LimpiaControlTabPage(TabPDirCli);
            foreach (var Look in TabPDirCli.Controls)
            {
                if (Look is TextBox) { ((TextBox)Look).DataBindings.Clear(); }
                if (Look is ComboBox) { ((ComboBox)Look).DataBindings.Clear(); }
            }

            Datos.LimpiaControlTabPage(TabPTelCli);
            foreach (var Look in TabPTelCli.Controls)
            {
                if (Look is TextBox) { ((TextBox)Look).DataBindings.Clear(); }
                if (Look is ComboBox) { ((ComboBox)Look).DataBindings.Clear(); }
            }
            dtgConCliente.DataSource = null;
            dtgDircliente.DataSource = null;
            dtgTelCliente.DataSource = null;

            HabilitaDesplazamiento(false);


            HabilitaDesplazamiento(false);
            btnBuscar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnAceptar.Enabled = true;
            btnImprimir.Enabled = false;
            btnCancelar.Enabled = true;
            btnAdjuntar.Enabled = false;
            btnNotas.Enabled = false;
            btnBuscaPais.Enabled = true;
            btnTipocli.Enabled = true;

            btnTelpais.Enabled = false;
            btnTelAgregar.Enabled = false;
            btnTelEditar.Enabled = false;
            btnTelAceptar.Enabled = false;
            btnTelBorrar.Enabled = false;
            btnTelCancelar.Enabled = false;
        }

        private void btnBusar_Click(object sender, EventArgs e)
        {
            BtnEjecutado.BotonEjecutado = "btnBuscar";
            
            this.DesconectaEntradasCli();
            this.LimpiarEntradasCli();

            this.ActivaEntradasCli(true);
            rbtJuridica.Checked = false;
            rbtFisica.Checked = false;

            Datos.LimpiaControlTabPage(TabPConCli);
            foreach (var Look in TabPConCli.Controls)
            {
                if (Look is TextBox) { ((TextBox)Look).DataBindings.Clear(); }
                if (Look is ComboBox) { ((ComboBox)Look).DataBindings.Clear(); }
            }

            Datos.LimpiaControlTabPage(TabPDirCli);
            foreach (var Look in TabPDirCli.Controls)
            {
                if (Look is TextBox) { ((TextBox)Look).DataBindings.Clear(); }
                if (Look is ComboBox) { ((ComboBox)Look).DataBindings.Clear(); }
            }
            
            Datos.LimpiaControlTabPage(TabPTelCli);
            foreach (var Look in TabPTelCli.Controls)
            {
                if (Look is TextBox) { ((TextBox)Look).DataBindings.Clear(); }
                if (Look is ComboBox) { ((ComboBox)Look).DataBindings.Clear(); }
            }
            dtgConCliente.DataSource = null;
            dtgDircliente.DataSource = null;
            dtgTelCliente.DataSource = null;

            HabilitaDesplazamiento(false);

            btnBuscar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnAceptar.Enabled = true;
            btnImprimir.Enabled = false;
            btnCancelar.Enabled = true;
            btnAdjuntar.Enabled = false;
            btnNotas.Enabled = false;
            btnBuscaPais.Enabled = true;
            btnTipocli.Enabled = true;

            //btnTelpais.Enabled = false;
            //btnTelAgregar.Enabled = false;
            //btnTelEditar.Enabled = false;
            //btnTelAceptar.Enabled = false;
            //btnTelBorrar.Enabled = false;
            //btnTelCancelar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            BtnEjecutado.BotonEjecutado = "btnEditar";
            HabilitaDesplazamiento(false);
            ActivaEntradasCli(true);
            this.txtID.Enabled = false;
            this.cbxestado.Enabled = false;
            this.txtCliCodigo.Enabled = false;

            btnBuscar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnAceptar.Enabled = true;
            btnImprimir.Enabled = false;
            btnCancelar.Enabled = true;
            btnAdjuntar.Enabled = false;
            btnNotas.Enabled = false;
            btnBuscaPais.Enabled = true;
            btnTipocli.Enabled = true;


            btnTelpais.Enabled = false;
            btnTelAgregar.Enabled = true;
            btnTelEditar.Enabled = false;
            btnTelAceptar.Enabled = false;
            btnTelBorrar.Enabled = true;
            btnTelCancelar.Enabled = false;

            btnDirPais.Enabled = false;
            btnDirAgregar.Enabled = true;
            btnDirEditar.Enabled = false;
            btnDirAceptar.Enabled = false;
            btnDirBorrar.Enabled = true;
            btnDirCancelar.Enabled = false;

            btnConAgregar.Enabled = true;
            btnConEditar.Enabled = false;
            btnConAceptar.Enabled = false;
            btnConBorrar.Enabled = true;
            btnConCancelar.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
             
            
            //para buscar parametros
            //Datos.Conectar();
            //MessageBox.Show(dt.BucarParametro("JODER"));
            //Datos.Desconectar();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            
            List<string> Lista = new List<string>();
            Datos dt = new Datos();
            Lista = dt.BucarCBO("select grlsts_codigo,grlsts_descrip,grltbl_codigo from cgrlstsm where grltbl_codigo = 'cgrlentm'");
            foreach (string s in Lista)
            {
                cbxestado.Items.Add(s);
            }
            Lista = dt.BucarCBO("SELECT grlide_abrev, grlide_nombre, grlsts_codigo FROM cgrlidem where grlsts_codigo =1 ");
            foreach (string s in Lista)
            {
                cbxTipoIdentificacion.Items.Add(s);
            }
            Lista = dt.BucarCBO("select cxcvin_codigo,cxcvin_nombre from ccxcvinm");
            foreach (string s in Lista)
            {
                cbxTipoVinculo.Items.Add(s);
            }
            Lista = dt.BucarCBO("select grlstcv_codigo,grlstcv_nombre,grlstcv_Id from cgrlstcvm");
            foreach (string s in Lista)
            {
                cbxestadoCivil.Items.Add(s);
            }

            Lista = dt.BucarCBO("SELECT grluso_codigo, grluso_nombre FROM cgrlusom");
            foreach (string s in Lista)
            {
                cbxDirTipo.Items.Add(s);
            }
            

            Lista = dt.BucarCBO("SELECT grltipt_codigo, grltipt_nombre FROM cgrltiptm");
            foreach (string s in Lista)
            {
                cbxTelTipo.Items.Add(s);
            }
            
        }

        private void frmClientes_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            BsCliente.MoveFirst();
            Bucarpersona(txtID.Text);
            clientePosicion = BsCliente.Position; //Indica la posicion del registro;
            this.BuscarTelefono();
            this.BuscarDireccion();
            this.BuscarContacto();

            if (BsCliente.Position <= 1)
            {
                btnPrimero.Enabled = false;
                btnAtras.Enabled = false;
                btnSiguiente.Enabled = true;
                btnUltimo.Enabled = true;
            }
            else
            {
                btnPrimero.Enabled = true;
                btnAtras.Enabled = true;
                btnSiguiente.Enabled = true;
                btnUltimo.Enabled = true;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            BsCliente.MovePrevious();
            Bucarpersona(txtID.Text);
            clientePosicion = BsCliente.Position; //Indica la posicion del registro;
            
            this.BuscarTelefono();
            this.BuscarDireccion();
            this.BuscarContacto();

            if (BsCliente.Position <= 1)
            {
                btnPrimero.Enabled = false;
                btnAtras.Enabled = false;
                btnSiguiente.Enabled = true;
                btnUltimo.Enabled = true;
            }
            else
            {
                btnPrimero.Enabled = true;
                btnAtras.Enabled = true;
                btnSiguiente.Enabled = true;
                btnUltimo.Enabled = true;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            BsCliente.MoveNext();
            Bucarpersona(txtID.Text);
            clientePosicion = BsCliente.Position; //Indica la posicion del registro;

            this.BuscarTelefono();
            this.BuscarDireccion();
            this.BuscarContacto();

            if ((BsCliente.Count - 1) == BsCliente.Position)
            {
                btnPrimero.Enabled = true;
                btnAtras.Enabled = true;
                btnSiguiente.Enabled = false;
                btnUltimo.Enabled = false;
            }
            else
            {
                btnPrimero.Enabled = true;
                btnAtras.Enabled = true;
                btnSiguiente.Enabled = true;
                btnUltimo.Enabled = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            BsCliente.MoveLast();
            Bucarpersona(txtID.Text);
            clientePosicion = BsCliente.Position; //Indica la posicion del registro;
            this.BuscarTelefono();
            this.BuscarDireccion();
            this.BuscarContacto();

            if ((BsCliente.Count - 1) == BsCliente.Position)
            {
                btnPrimero.Enabled = true;
                btnAtras.Enabled = true;
                btnSiguiente.Enabled = false;
                btnUltimo.Enabled = false;
            }
            else
            {
                btnPrimero.Enabled = true;
                btnAtras.Enabled = true;
                btnSiguiente.Enabled = true;
                btnUltimo.Enabled = true;
            }
        }

        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtFechaReg.Text = dtmFechNac.Value.ToString();
            txtFechaReg.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBuscaTipoCliente frmBuscaTipoCliente = new frmBuscaTipoCliente();
            frmBuscaTipoCliente.StartPosition = FormStartPosition.CenterScreen;
            frmBuscaTipoCliente.ShowDialog();
            if (frmBuscaTipoCliente.LookupOk == 1)
            {
                txtTipoCliente.Text = frmBuscaTipoCliente.Code.ToString();
                txtTipoclinombre.Text = frmBuscaTipoCliente.Description.ToString();
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            
            
        }
        public void Bucarpersona (string str)
        {
            Datos  _datos = new Datos();
            if (_datos.BucarValor("select grlent_tipo from cgrlentm where grlent_ID =  " + str) == "F")
            { rbtFisica.Checked = true; }
            if (_datos.BucarValor("select grlent_tipo from cgrlentm where grlent_ID =  " + str) == "J")
            { rbtJuridica.Checked = true; }

            if (rbtFisica.Checked)
            {
                txtnombresCliente.DataBindings.Clear();
                txtApellidosClientes.DataBindings.Clear();
                txtnombresCliente.DataBindings.Add("Text", BsCliente, "grlent_nombre");
                txtApellidosClientes.DataBindings.Add("Text", BsCliente, "grlent_apellido");
            }
            else
            {
                if (rbtJuridica.Checked)
                {
                    txtnombresCliente.DataBindings.Clear();
                    txtApellidosClientes.DataBindings.Clear();
                    txtnombresCliente.Clear();
                    txtApellidosClientes.Clear();
                }
            }
        
        }

        private void btnBuscaPais_Click_1(object sender, EventArgs e)
        {
            frmBuscarPais frmBuscarPais = new frmBuscarPais();
            frmBuscarPais.StartPosition = FormStartPosition.CenterScreen;
            frmBuscarPais.ShowDialog();
            if (frmBuscarPais.LookupOk == 1)
            {
                txtCodigoPais.Text = frmBuscarPais.Code.ToString();
                txtNombrePais.Text = frmBuscarPais.Description.ToString();
            }
        }

        private void btnTelpais_Click(object sender, EventArgs e)
        {
            frmBuscarPais frmBuscarPais = new frmBuscarPais();
            frmBuscarPais.StartPosition = FormStartPosition.CenterScreen;
            frmBuscarPais.ShowDialog();
            if (frmBuscarPais.LookupOk == 1)
            {
                txtTelCodPais.Text = frmBuscarPais.Code.ToString();
                txtTelNomPais.Text = frmBuscarPais.Description.ToString();
            }
        }

        private void btnDirPais_Click(object sender, EventArgs e)
        {
            frmBuscarPais frmBuscarPais = new frmBuscarPais();
            frmBuscarPais.StartPosition = FormStartPosition.CenterScreen;
            frmBuscarPais.ShowDialog();
            if (frmBuscarPais.LookupOk == 1)
            {
                txtDirCodPais.Text = frmBuscarPais.Code.ToString();
                txtDirNomPais.Text = frmBuscarPais.Description.ToString();
            }
        }

        private void btnTelAgregar_Click(object sender, EventArgs e)
        {

            //Limpiar la tabla tbtTel
            //foreach (DataRow row in tbtTel.Rows)
            //{
            //    tbtTel.Rows.Remove(row);
            //}

           /* for (int i = 0; i < tbtTel.Rows.Count; i++)
            {
                
                    DataRow row = tbtTel.Rows[i];
                    tbtTel.Rows.Remove(row);      //Update happen here
                    tbtTel.DefaultView.Sort = "grltel_numero DESC";
                    dtgTelCliente.DataSource = tbtTel;
                
            }*/
           
            
            //LIMPIAR ENTRADA DE DATOS
            txtTelCodPais.DataBindings.Clear();
            txtTelNomPais.DataBindings.Clear();
            txtTelArea.DataBindings.Clear();
            txtTelNumero.DataBindings.Clear();
            txtTelExtencion.DataBindings.Clear();
            cbxTelTipo.Text=string.Empty;
            txtTelCodPais.Clear();
            txtTelNomPais.Clear();
            txtTelArea.Clear();
            txtTelNumero.Clear();
            txtTelExtencion.Clear();

            dtgTelCliente.Enabled = false;
            //HABILITAR ENTRADA DE DATOS
            cbxTelTipo.Enabled = true;
            txtTelCodPais.Enabled = true;
            txtTelArea.Enabled = true;
            txtTelNumero.Enabled = true;
            txtTelExtencion.Enabled = true;
            
            //HABILITAR Y DESHABILITAR BOTONES
            btnTelAgregar.Enabled = false;
            btnTelBorrar.Enabled = false;
            btnTelAceptar.Enabled = true;
            btnTelCancelar.Enabled = true;
            btnTelEditar.Enabled = false;
            btnTelpais.Enabled = true;
        }

        private void btnTelCancelar_Click(object sender, EventArgs e)
        {
            this.btnTelCancelarCli();
        }

        private void btnTelAceptar_Click(object sender, EventArgs e)
        {
            this.btnTelAceptarClic();
            
        }

        private void dtgTelCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dtgTelCliente_RowEnter(object sender, DataGridViewCellEventArgs e)
        {/*
            Datos.Conectar();
            DataView DatView = new DataView();
            DatView = Datos.Lookup("select cgrlteld.grlpai_codigo,cgrlpaim.grlpai_nombre,cgrltiptm.grltipt_codigo+'-'+cgrltiptm.grltipt_nombre Tipo,cgrltiptm.*" +
                                     " from cgrlteld "+
	                                       " inner join cgrlpaim on cgrlpaim.grlpai_codigo = cgrlteld.grlpai_codigo"+
	                                       " inner join cgrltiptm on cgrltiptm.grltipt_codigo = cgrlteld.grltipt_codigo"+
                                   " where cgrlteld.grlent_ID = "+ txtID.Text +
                                     " and cgrlteld.grltel_area = '"+txtTelArea.Text +"'"+
                                     " and cgrlteld.grltel_numero = '"+txtTelNumero.Text +"'");
            Datos.Desconectar();
            //txtTelNomPais.Text = DatView.Table.Rows[].
            if (DatView.Table.Rows.Count >0)
            {
             for (int i = 0; i < DatView.Table.Rows.Count; i++)
                {
                    DataRow row = DatView.Table.Rows[i];
                    txtTelNomPais.Text = row[1].ToString();
                    cbxTelTipo.Text = row[2].ToString();
                }
            } */
        }

        private void btnTelEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTelBorrar_Click(object sender, EventArgs e)
        {
            StringBuilder SqlQuery = new StringBuilder();
            try
            {
                Datos.Conectar();
                SqlQuery.Append(" Begin transaction ;");
                SqlQuery.Append(" delete cgrlteld where grlent_ID =" + txtID.Text + " and grltel_area='" + txtTelArea.Text + "' and  grltel_numero = '" + txtTelNumero.Text + "';"); 
                SqlQuery.Append(" Commit transaction ;");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            int respuesta = Datos.Insertar(SqlQuery);
            
            Datos.Desconectar();
            //BsTelCliente.Position
        }

        private void btnConEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnConAgregar_Click(object sender, EventArgs e)
        {
            Datos.LimpiaControlTabPage(TabPConCli);
            foreach (var Look in TabPConCli.Controls)
            {
                if (Look is TextBox) { ((TextBox)Look).DataBindings.Clear(); }
                if (Look is ComboBox) { ((ComboBox)Look).DataBindings.Clear(); }
            }

            //HABILITAR ENTRADA DE DATOS
            txtConCodigo.Enabled = true;
            
            txtConCodCiudad.Enabled = false;
            txtConCodProvincia.Enabled = false;
            txtConCodSector.Enabled = false;
            cbxConParentesco.Enabled = true;
            //HABILITAR Y DESHABILITAR BOTONES
            btnConAgregar.Enabled = false;
            btnConBorrar.Enabled = false;
            btnConAceptar.Enabled = true;
            btnConCancelar.Enabled = true;
            btnConEditar.Enabled = false;
            btnConCli.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            if (btnTelCancelar.Enabled == true)
            {
                this.btnTelCancelarCli();
            }
            if (btnDirCancelar.Enabled == true)
            {
                this.btnDirCancelarClic();
            }
            if (btnConCancelar.Enabled == true)
            {
                this.btnConCancelarClic();
            }
            
                    //BsCliente.DataSource = _datos.ConsultarNoEstatic(SqlQuery.ToString());
            if (clientePosicion >= 0)
            {
                txtID.DataBindings.Clear();
                txtCliCodigo.DataBindings.Clear();
                txtFullName.DataBindings.Clear();
                txtnombresCliente.DataBindings.Clear();
                txtApellidosClientes.DataBindings.Clear();
                cbxsexo.DataBindings.Clear();
                cbxTipoIdentificacion.DataBindings.Clear();
                cbxestadoCivil.DataBindings.Clear();
                cbxTipoVinculo.DataBindings.Clear();
                mtxtIdentificacion.DataBindings.Clear();
                cbxestado.DataBindings.Clear();
                txtCodigoPais.DataBindings.Clear();
                txtNombrePais.DataBindings.Clear();
                txtTipoCliente.DataBindings.Clear();
                txtTipoclinombre.DataBindings.Clear();
                dateTimePicker1.DataBindings.Clear();
                BsCliente.Position = clientePosicion;
                dateTimePicker1.DataBindings.Add("Value", BsCliente, "cxccli_fecing");
                cbxestado.DataBindings.Add("Text", BsCliente, "estado");
                txtID.DataBindings.Add("Text", BsCliente, "grlent_ID");
                txtCliCodigo.DataBindings.Add("Text", BsCliente, "cxccli_Codigo");
                txtFullName.DataBindings.Add("Text", BsCliente, "cxccli_nombre");
                txtnombresCliente.DataBindings.Add("Text", BsCliente, "grlent_nombre");
                txtApellidosClientes.DataBindings.Add("Text", BsCliente, "grlent_apellido");
                cbxTipoIdentificacion.DataBindings.Add("Text", BsCliente, "Tipo_Ident");
                cbxsexo.DataBindings.Add("Text", BsCliente, "sexo");
                cbxestadoCivil.DataBindings.Add("Text", BsCliente, "sts_civil");
                cbxTipoVinculo.DataBindings.Add("Text", BsCliente, "cxccli_Vinc");
                mtxtIdentificacion.DataBindings.Add("Text", BsCliente, "grlent_identif");
                txtCodigoPais.DataBindings.Add("Text", BsCliente, "grlpai_codigo");
                txtNombrePais.DataBindings.Add("Text", BsCliente, "grlpai_nombre");
                txtTipoCliente.DataBindings.Add("Text", BsCliente, "cxctcli_codigo");
                txtTipoclinombre.DataBindings.Add("Text", BsCliente, "cxctcli_nombre");
                Bucarpersona(txtID.Text);
                //********************************************************************************//////////////////


                //************************************************************************************
                //BUSCAR LA INFORMACION DE TELEFONO DIRECCIONES Y CONTACTO ***************************
                //************************************************************************************
                this.BuscarTelefono();
                this.BuscarDireccion();
                this.BuscarContacto();
                //********************************************************************************//////////////////
                this.ActivaEntradasCli(false);
            }
            else
            {
                this.DesconectaEntradasCli();
                this.LimpiarEntradasCli();
                this.ActivaEntradasCli(false);
            }
            dtgTelCliente.Enabled = true;
            dtgDircliente.Enabled = true;
            dtgConCliente.Enabled = true;


            foreach (var Look in TabPDirCli.Controls)
            {
                if (Look is TextBox) { ((TextBox)Look).Enabled=false; }
                if (Look is ComboBox) { ((ComboBox)Look).Enabled = false; }
                if (Look is Button) { ((Button)Look).Enabled = false; }
            }
            foreach (var Look in TabPTelCli.Controls)
            {
                if (Look is TextBox) { ((TextBox)Look).Enabled = false; }
                if (Look is ComboBox) { ((ComboBox)Look).Enabled = false; }
                if (Look is Button) { ((Button)Look).Enabled = false; }
            }
            txtConCodigo.Enabled = false;
            cbxConParentesco.Enabled = false;
            btnConCli.Enabled = false;

            btnBuscar.Enabled = true;
            btnNuevo.Enabled = true;
            btnAceptar.Enabled = false;
            btnEditar.Enabled = true;
            btnImprimir.Enabled = true;
            btnCancelar.Enabled = false;
            btnAdjuntar.Enabled = true;
            btnNotas.Enabled = true;
            btnBuscaPais.Enabled = false;
            btnTipocli.Enabled = false;

            //PARA HABILITAR BOTONES DE DESPLAZAMIENTO**********
            if (BsCliente.Count <= 1)
            {
                btnPrimero.Enabled = false;
                btnAtras.Enabled = false;
                btnSiguiente.Enabled = false;
                btnUltimo.Enabled = false;
            }
            else
            {
                btnPrimero.Enabled = false;
                btnAtras.Enabled = false;
                btnSiguiente.Enabled = true;
                btnUltimo.Enabled = true;
            }

            btnTelpais.Enabled = false;
            btnTelAgregar.Enabled = false;
            btnTelEditar.Enabled = false;
            btnTelAceptar.Enabled = false;
            btnTelBorrar.Enabled = false;
            btnTelCancelar.Enabled = false;

            btnDirPais.Enabled = false;
            btnDirAgregar.Enabled = false;
            btnDirEditar.Enabled = false;
            btnDirAceptar.Enabled = false;
            btnDirBorrar.Enabled = false;
            btnDirCancelar.Enabled = false;

            btnConAgregar.Enabled = false;
            btnConEditar.Enabled = false;
            btnConAceptar.Enabled = false;
            btnConBorrar.Enabled = false;
            btnConCancelar.Enabled = false;
            BtnEjecutado.BotonEjecutado = ""; //LINPIAMOS LA VARIABLE QUE INDICA EL BOTON EJECUTADO
        }

        private void btnDirAgregar_Click(object sender, EventArgs e)
        {

            dtgDircliente.Enabled = false;
            Datos.LimpiaControlTabPage(TabPDirCli);
            foreach (var Look in TabPDirCli.Controls)
            {
                if (Look is TextBox) {((TextBox)Look).DataBindings.Clear();}
                if (Look is ComboBox){((ComboBox)Look).DataBindings.Clear();}
            }
            //HABILITAR ENTRADA DE DATOS
            cbxDirTipo.Enabled = true;
            txtDirCalle.Enabled = true;
            txtDirNumero.Enabled = true;
            txtDirEdificio.Enabled = true;
            txtDirCodPais.Enabled = true;
            txtDirNomPais.Enabled = false;
            txtDirCodProvincia.Enabled = true;
            txtDirNomProvincia.Enabled = false;
            txtDirCodCiudad.Enabled = true;
            txtDirNomCiudad.Enabled = false;
            txtDirCodSector.Enabled = true;
            txtDirNomSector.Enabled = false;
            //HABILITAR Y DESHABILITAR BOTONES
            btnDirAgregar.Enabled = false;
            btnDirBorrar.Enabled = false;
            btnDirAceptar.Enabled = true;
            btnDirCancelar.Enabled = true;
            btnDirEditar.Enabled = false;
            btnDirPais.Enabled = true;
            btnDirProv.Enabled = true;
            btnDirCiudad.Enabled = true;
            btnDirSector.Enabled = true;
        }

        private void btnDirAceptar_Click(object sender, EventArgs e)
        {
            this.btnDirAceptarClic();
        }

        private void btnDirCancelar_Click(object sender, EventArgs e)
        {
            this.btnDirCancelarClic();
        }

        private void btnDirProv_Click(object sender, EventArgs e)
        {
            string query = "";
            if (string.IsNullOrEmpty(txtDirCodPais.Text.Trim()))
                query = "SELECT grlprv_codigo Codigo, grlprv_nombre Descripción  FROM cgrlprvm WHERE 1=2";
            else
            {
                query = "SELECT grlprv_codigo Codigo, grlprv_nombre Descripción  FROM cgrlprvm WHERE grlpai_codigo = " + txtDirCodPais.Text + " ORDER BY grlpai_codigo,grlprv_codigo";
            }
            {
                frmBuscaDireccion frmBuscarDirecc = new frmBuscaDireccion(query);
                frmBuscarDirecc.StartPosition = FormStartPosition.CenterScreen;
                frmBuscarDirecc.ShowDialog();
                if (frmBuscarDirecc.LookupOk == 1)
                {
                    txtDirCodProvincia.Text = frmBuscarDirecc.Code.ToString();
                    txtDirNomProvincia.Text = frmBuscarDirecc.Description.ToString();
                }
            }
        }

        private void btnDirCiudad_Click(object sender, EventArgs e)
        {
            string query = "";
            if (string.IsNullOrEmpty(txtDirCodProvincia.Text.Trim()))
                query = "SELECT grlcui_codigo Codigo, grlcui_nombre Descripción  FROM cgrlcium WHERE 1=2";
            else 
            {
                query = "SELECT grlcui_codigo Codigo, grlcui_nombre Descripción  FROM cgrlcium where grlprv_codigo = " + txtDirCodProvincia.Text + " ORDER BY grlpai_codigo,grlcui_codigo";
            }
            {
                frmBuscaDireccion frmBuscarDirecc = new frmBuscaDireccion(query);
                frmBuscarDirecc.StartPosition = FormStartPosition.CenterScreen;
                frmBuscarDirecc.ShowDialog();
                if (frmBuscarDirecc.LookupOk == 1)
                {
                    txtDirCodCiudad.Text = frmBuscarDirecc.Code.ToString();
                    txtDirNomCiudad.Text = frmBuscarDirecc.Description.ToString();
                }
            }
        }

        private void btnDirSector_Click(object sender, EventArgs e)
        {
            string query = "";
            if (string.IsNullOrEmpty(txtDirCodCiudad.Text.Trim()))
                query = "SELECT distinct grlset_codigo Codigo, grlset_nombre Descripción ,grlpai_codigo FROM cgrlsetm WHERE 1=2";
            else
            {
                query = "SELECT distinct grlset_codigo Codigo, grlset_nombre Descripción ,grlciu_codigo FROM cgrlsetm cgrlsetm WHERE grlciu_codigo = " + txtDirCodCiudad .Text+ " ORDER BY grlciu_codigo,Codigo";
            }
            {
                frmBuscaDireccion frmBuscarDirecc = new frmBuscaDireccion(query);
                frmBuscarDirecc.StartPosition = FormStartPosition.CenterScreen;
                frmBuscarDirecc.ShowDialog();
                if (frmBuscarDirecc.LookupOk == 1)
                {
                    txtDirCodSector.Text = frmBuscarDirecc.Code.ToString();
                    txtDirNomSector.Text = frmBuscarDirecc.Description.ToString();
                }
            }
        }

        private void btnConAceptar_Click(object sender, EventArgs e)
        {
            this.btnConAceptarClic();
        }

        private void btnConCancelar_Click(object sender, EventArgs e)
        {
            btnConCancelarClic();
        }
        /// <summary>
        /// Bucas el/los telefono/s del un cliente por el numero de ID.
        /// </summary>
        private void BuscarTelefono() 
        {
            //****************************************************************************************************
            //******** PARA BUSCAR EL DETALLE DE LOS TELEFONOS ***************************************************
            //****************************************************************************************************
            if (!string.IsNullOrEmpty(txtID.Text.Trim()))
            {
                tblTel = Datos.MakeNamesTable("select  cgrlteld.grlent_ID," +
                                                      "cgrlteld.grltipt_codigo," +
                                                       "(cgrlteld.grltipt_codigo +'-'+cgrltiptm.grltipt_nombre) as Tipo," +
                                                       "cgrlteld.grltel_area," +
                                                       "cgrlteld.grltel_numero," +
                                                       "cgrlteld.grltel_ext," +
                                                       "cgrlteld.grluso_codigo," +
                                                       "cgrlteld.grlpai_codigo ," +
                                                       "cgrlpaim.grlpai_nombre" +
                                               " from cgrlteld " +
                                                    " inner join cgrlpaim on cgrlteld.grlpai_codigo =  cgrlpaim.grlpai_codigo " +
                                                    " inner join cgrltiptm on cgrltiptm.grltipt_codigo = cgrlteld.grltipt_codigo " +
                                              " where grlent_ID =" + txtID.Text);
                if (tblTel.Rows.Count > 0)
                {
                    BsTelCliente.DataSource = tblTel;
                    dtgTelCliente.AutoGenerateColumns = false;
                    BsTelCliente.MoveFirst();
                    Datos.DesconectaControlTabPage(TabPTelCli);

                    dtgTelCliente.DataSource = BsTelCliente;
                    cbxTelTipo.DataBindings.Add("Text", BsTelCliente, "Tipo");
                    txtTelCodPais.DataBindings.Add("Text", BsTelCliente, "grlpai_codigo");
                    txtTelNomPais.DataBindings.Add("Text", BsTelCliente, "grlpai_nombre");
                    txtTelArea.DataBindings.Add("Text", BsTelCliente, "grltel_area");
                    txtTelNumero.DataBindings.Add("Text", BsTelCliente, "grltel_numero");
                    txtTelExtencion.DataBindings.Add("Text", BsTelCliente, "grltel_ext");
                }
                else
                {
                    Datos.LimpiaControlTabPage(TabPTelCli);
                    Datos.DesconectaControlTabPage(TabPTelCli);
                }
            }
            else 
            {
                tblTel = Datos.MakeNamesTable("select  cgrlteld.grlent_ID," +
                                                      "cgrlteld.grltipt_codigo," +
                                                       "(cgrlteld.grltipt_codigo +'-'+cgrltiptm.grltipt_nombre) as Tipo," +
                                                       "cgrlteld.grltel_area," +
                                                       "cgrlteld.grltel_numero," +
                                                       "cgrlteld.grltel_ext," +
                                                       "cgrlteld.grluso_codigo," +
                                                       "cgrlteld.grlpai_codigo ," +
                                                       "cgrlpaim.grlpai_nombre" +
                                               " from cgrlteld " +
                                                    " inner join cgrlpaim on cgrlteld.grlpai_codigo =  cgrlpaim.grlpai_codigo " +
                                                    " inner join cgrltiptm on cgrltiptm.grltipt_codigo = cgrlteld.grltipt_codigo " +
                                              " where 1 = 2" );
                if (tblTel.Rows.Count > 0)
                {
                    BsTelCliente.DataSource = tblTel;
                    dtgTelCliente.AutoGenerateColumns = false;
                    BsTelCliente.MoveFirst();

                    Datos.DesconectaControlTabPage(TabPTelCli);

                    dtgTelCliente.DataSource = BsTelCliente;
                    cbxTelTipo.DataBindings.Add("Text", BsTelCliente, "Tipo");
                    txtTelCodPais.DataBindings.Add("Text", BsTelCliente, "grlpai_codigo");
                    txtTelNomPais.DataBindings.Add("Text", BsTelCliente, "grlpai_nombre");
                    txtTelArea.DataBindings.Add("Text", BsTelCliente, "grltel_area");
                    txtTelNumero.DataBindings.Add("Text", BsTelCliente, "grltel_numero");
                    txtTelExtencion.DataBindings.Add("Text", BsTelCliente, "grltel_ext");
                }
                else
                {
                    Datos.LimpiaControlTabPage(TabPTelCli);
                    Datos.DesconectaControlTabPage(TabPTelCli);
                }
            }
            //********************************************************************************//////////////////
        }
        /// <summary>
        /// Bucas la/s direccion/es del un cliente por el numero de ID.
        /// </summary>
        private void BuscarDireccion() 
        {
            //****************************************************************************************************
            //******** PARA BUSCAR EL DETALLE DE LAS DIRECCIONES**************************************************
            //****************************************************************************************************
            if (!string.IsNullOrEmpty(txtID.Text.Trim()))
            {
                tblDir = Datos.MakeNamesTable("select cgrldird.grlent_ID," +
                                                   "		cgrldird.grluso_codigo," +
                                                   "		(cgrldird.grluso_codigo +'-'+cgrlusom.grluso_nombre) as Tipo," +
                                                   "		cgrldird.grldir_numero," +
                                                   "		cgrldird.grldir_calle," +
                                                   "       cgrldird.grldir_edificio," +
                                                   "		cgrldird.grlpai_codigo," +
                                                   "		cgrlpaim.grlpai_nombre," +
                                                   "		cgrlprvm.grlprv_codigo," +
                                                   "		cgrlprvm.grlprv_nombre," +
                                                   "		cgrlcium.grlcui_codigo," +
                                                   "		cgrlcium.grlcui_nombre," +
                                                   "		cgrlsetm.grlset_codigo," +
                                                   "		cgrlsetm.grlset_nombre" +
                                                   " from cgrldird " +
                                                   " inner join cgrlpaim on cgrldird.grlpai_codigo =  cgrlpaim.grlpai_codigo " +
                                                   " inner join cgrlusom on cgrlusom.grluso_codigo = cgrldird.grluso_codigo " +
                                                   " left join cgrlprvm on cgrlprvm.grlpai_codigo = cgrlpaim.grlpai_codigo and cgrlprvm.grlprv_codigo = cgrldird.grlprv_codigo " +
                                                   " left join cgrlcium on cgrlcium.grlprv_codigo = cgrlprvm.grlprv_codigo and cgrlcium.grlcui_codigo = cgrldird.grlcui_codigo " +
                                                   " left join cgrlsetm on cgrlsetm.grlciu_codigo = cgrlcium.grlcui_codigo and cgrlsetm.grlset_codigo = cgrldird.grlpai_codigo " +
                                                   " where grlent_ID =" + txtID.Text);
                if (tblDir.Rows.Count > 0)
                {
                    BsDirCliente.DataSource = tblDir;
                    dtgDircliente.AutoGenerateColumns = false;
                    BsDirCliente.MoveFirst();

                    Datos.DesconectaControlTabPage(TabPDirCli);

                    dtgDircliente.DataSource = BsDirCliente;
                    cbxDirTipo.DataBindings.Add("Text", BsDirCliente, "Tipo");
                    txtDirCalle.DataBindings.Add("Text", BsDirCliente, "grldir_calle");
                    txtDirNumero.DataBindings.Add("Text", BsDirCliente, "grldir_numero");
                    txtDirEdificio.DataBindings.Add("Text", BsDirCliente, "grldir_edificio");
                    txtDirCodPais.DataBindings.Add("Text", BsDirCliente, "grlpai_codigo");
                    txtDirNomPais.DataBindings.Add("Text", BsDirCliente, "grlpai_nombre");
                    txtDirCodProvincia.DataBindings.Add("Text", BsDirCliente, "grlprv_codigo");
                    txtDirNomProvincia.DataBindings.Add("Text", BsDirCliente, "grlprv_nombre");
                    txtDirCodCiudad.DataBindings.Add("Text", BsDirCliente, "grlcui_codigo");
                    txtDirNomCiudad.DataBindings.Add("Text", BsDirCliente, "grlcui_nombre");
                    txtDirCodSector.DataBindings.Add("Text", BsDirCliente, "grlset_codigo");
                    txtDirNomSector.DataBindings.Add("Text", BsDirCliente, "grlset_nombre");
                }
                else
                {
                    Datos.LimpiaControlTabPage(TabPDirCli);
                    Datos.DesconectaControlTabPage(TabPDirCli);
                }
            }
            else
            {
                tblDir = Datos.MakeNamesTable("select cgrldird.grlent_ID," +
                                                   "		cgrldird.grluso_codigo," +
                                                   "		(cgrldird.grluso_codigo +'-'+cgrlusom.grluso_nombre) as Tipo," +
                                                   "		cgrldird.grldir_numero," +
                                                   "		cgrldird.grldir_calle," +
                                                   "       cgrldird.grldir_edificio," +
                                                   "		cgrldird.grlpai_codigo," +
                                                   "		cgrlpaim.grlpai_nombre," +
                                                   "		cgrlprvm.grlprv_codigo," +
                                                   "		cgrlprvm.grlprv_nombre," +
                                                   "		cgrlcium.grlcui_codigo," +
                                                   "		cgrlcium.grlcui_nombre," +
                                                   "		cgrlsetm.grlset_codigo," +
                                                   "		cgrlsetm.grlset_nombre" +
                                                   " from cgrldird " +
                                                   " inner join cgrlpaim on cgrldird.grlpai_codigo =  cgrlpaim.grlpai_codigo " +
                                                   " inner join cgrlusom on cgrlusom.grluso_codigo = cgrldird.grluso_codigo " +
                                                   " left join cgrlprvm on cgrlprvm.grlpai_codigo = cgrlpaim.grlpai_codigo and cgrlprvm.grlprv_codigo = cgrldird.grlprv_codigo " +
                                                   " left join cgrlcium on cgrlcium.grlprv_codigo = cgrlprvm.grlprv_codigo and cgrlcium.grlcui_codigo = cgrldird.grlcui_codigo " +
                                                   " left join cgrlsetm on cgrlsetm.grlciu_codigo = cgrlcium.grlcui_codigo and cgrlsetm.grlset_codigo = cgrldird.grlpai_codigo " +
                                                   " where 1 = 2" );
                if (tblDir.Rows.Count > 0)
                {
                    BsDirCliente.DataSource = tblDir;
                    dtgDircliente.AutoGenerateColumns = false;
                    BsDirCliente.MoveFirst();

                    Datos.DesconectaControlTabPage(TabPDirCli);

                    dtgDircliente.DataSource = BsDirCliente;
                    cbxDirTipo.DataBindings.Add("Text", BsDirCliente, "Tipo");
                    txtDirCalle.DataBindings.Add("Text", BsDirCliente, "grldir_calle");
                    txtDirNumero.DataBindings.Add("Text", BsDirCliente, "grldir_numero");
                    txtDirEdificio.DataBindings.Add("Text", BsDirCliente, "grldir_edificio");
                    txtDirCodPais.DataBindings.Add("Text", BsDirCliente, "grlpai_codigo");
                    txtDirNomPais.DataBindings.Add("Text", BsDirCliente, "grlpai_nombre");
                    txtDirCodProvincia.DataBindings.Add("Text", BsDirCliente, "grlprv_codigo");
                    txtDirNomProvincia.DataBindings.Add("Text", BsDirCliente, "grlprv_nombre");
                    txtDirCodCiudad.DataBindings.Add("Text", BsDirCliente, "grlcui_codigo");
                    txtDirNomCiudad.DataBindings.Add("Text", BsDirCliente, "grlcui_nombre");
                    txtDirCodSector.DataBindings.Add("Text", BsDirCliente, "grlset_codigo");
                    txtDirNomSector.DataBindings.Add("Text", BsDirCliente, "grlset_nombre");
                }
                else
                {
                    Datos.LimpiaControlTabPage(TabPDirCli);
                    Datos.DesconectaControlTabPage(TabPDirCli);
                }
            }
            //*******************************************************************//////
            //*******************************************************************//////
        }
        /// <summary>
        /// Busca el/los contacto/s un cliente especificado por el numero de ID. 
        /// </summary>
        private void BuscarContacto() 
        {
            //****************************************************************************************************
            //******** PARA BUSCAR EL DETALLE DE LOS CONTACTOS**************************************************
            //****************************************************************************************************
            if (!string.IsNullOrEmpty(txtID.Text.Trim()))
            {
                tblContac = Datos.MakeNamesTable("select cgrlentm.grlent_ID," +
                                                 "      cgrlcond.grlcon_id," +
                                                 "		cgrldird.grluso_codigo," +
                                                 "		(cgrldird.grluso_codigo +'-'+cgrlusom.grluso_nombre) as Tipo," +
                                                 "		cgrldird.grldir_numero," +
                                                 "		cgrldird.grldir_calle," +
                                                 "		cgrldird.grldir_edificio," +
                                                 "		cgrldird.grlpai_codigo," +
                                                 "		cgrlpaim.grlpai_nombre," +
                                                 "		cgrlprvm.grlprv_codigo," +
                                                 "		cgrlprvm.grlprv_nombre," +
                                                 "		cgrlcium.grlcui_codigo," +
                                                 "		cgrlcium.grlcui_nombre," +
                                                 "		cgrlsetm.grlset_codigo," +
                                                 "		cgrlsetm.grlset_nombre," +
                                                 "		cgrlentm.grlent_nombre+' '+cgrlentm.grlent_apellido cont_nombre," +
                                                 "      cgrlcond.grlcon_parentesco " +
                                                   " from cgrlentm" +
                                                   "	  inner join cgrlcond on cgrlcond.grlcon_id = cgrlentm.grlent_ID" +
                                                   "	  inner join cgrldird on cgrldird.grlent_ID = cgrlcond.grlcon_id" +
                                                   "	  inner join cgrlpaim on cgrldird.grlpai_codigo =  cgrlpaim.grlpai_codigo" +
                                                   "	  inner join cgrlusom on cgrlusom.grluso_codigo = cgrldird.grluso_codigo" +
                                                   "	  left join cgrlprvm on cgrlprvm.grlpai_codigo = cgrlpaim.grlpai_codigo and cgrlprvm.grlprv_codigo = cgrldird.grlprv_codigo " +
                                                   "	  left join cgrlcium on cgrlcium.grlprv_codigo = cgrlprvm.grlprv_codigo and cgrlcium.grlcui_codigo = cgrldird.grlcui_codigo " +
                                                   "	  left join cgrlsetm on cgrlsetm.grlciu_codigo = cgrlcium.grlcui_codigo and cgrlsetm.grlset_codigo = cgrldird.grlset_codigo " +
                                                   " where cgrldird.grluso_codigo = 'RES' and cgrlcond.grlent_ID  =" + txtID.Text);
                if (tblContac.Rows.Count > 0)
                {
                    BsContacCliente.DataSource = tblContac;
                    dtgConCliente.AutoGenerateColumns = false;
                    BsContacCliente.MoveFirst();

                    Datos.DesconectaControlTabPage(TabPConCli);

                    dtgConCliente.DataSource = BsContacCliente;
                    txtConCodigo.DataBindings.Add("Text", BsContacCliente, "grlcon_id");
                    txtConNombre.DataBindings.Add("Text", BsContacCliente, "cont_nombre");
                    txtConCodProvincia.DataBindings.Add("Text", BsContacCliente, "grlprv_codigo");
                    txtConNomProvincia.DataBindings.Add("Text", BsContacCliente, "grlprv_nombre");
                    txtConCodCiudad.DataBindings.Add("Text", BsContacCliente, "grlcui_codigo");
                    txtConNomCiudad.DataBindings.Add("Text", BsContacCliente, "grlcui_nombre");
                    txtConCodSector.DataBindings.Add("Text", BsContacCliente, "grlset_codigo");
                    txtConNomSector.DataBindings.Add("Text", BsContacCliente, "grlset_nombre");
                    cbxConParentesco.DataBindings.Add("Text", BsContacCliente, "grlcon_parentesco");
                }
                else
                {
                    Datos.LimpiaControlTabPage(TabPConCli);
                    Datos.DesconectaControlTabPage(TabPConCli);
                }
            }
            else
            {
                tblContac = Datos.MakeNamesTable("select cgrlentm.grlent_ID," +
                                                 "      cgrlcond.grlcon_id," +
                                                 "		cgrldird.grluso_codigo," +
                                                 "		(cgrldird.grluso_codigo +'-'+cgrlusom.grluso_nombre) as Tipo," +
                                                 "		cgrldird.grldir_numero," +
                                                 "		cgrldird.grldir_calle," +
                                                 "		cgrldird.grldir_edificio," +
                                                 "		cgrldird.grlpai_codigo," +
                                                 "		cgrlpaim.grlpai_nombre," +
                                                 "		cgrlprvm.grlprv_codigo," +
                                                 "		cgrlprvm.grlprv_nombre," +
                                                 "		cgrlcium.grlcui_codigo," +
                                                 "		cgrlcium.grlcui_nombre," +
                                                 "		cgrlsetm.grlset_codigo," +
                                                 "		cgrlsetm.grlset_nombre," +
                                                 "		cgrlentm.grlent_nombre+' '+cgrlentm.grlent_apellido cont_nombre," +
                                                 "      cgrlcond.grlcon_parentesco " +
                                                   " from cgrlentm" +
                                                   "	  inner join cgrlcond on cgrlcond.grlcon_id = cgrlentm.grlent_ID" +
                                                   "	  inner join cgrldird on cgrldird.grlent_ID = cgrlcond.grlcon_id" +
                                                   "	  inner join cgrlpaim on cgrldird.grlpai_codigo =  cgrlpaim.grlpai_codigo" +
                                                   "	  inner join cgrlusom on cgrlusom.grluso_codigo = cgrldird.grluso_codigo" +
                                                   "	  left join cgrlprvm on cgrlprvm.grlpai_codigo = cgrlpaim.grlpai_codigo and cgrlprvm.grlprv_codigo = cgrldird.grlprv_codigo " +
                                                   "	  left join cgrlcium on cgrlcium.grlprv_codigo = cgrlprvm.grlprv_codigo and cgrlcium.grlcui_codigo = cgrldird.grlcui_codigo " +
                                                   "	  left join cgrlsetm on cgrlsetm.grlciu_codigo = cgrlcium.grlcui_codigo and cgrlsetm.grlset_codigo = cgrldird.grlset_codigo " +
                                                   " where 1 = 2");
                if (tblContac.Rows.Count > 0)
                {
                    BsContacCliente.DataSource = tblContac;
                    dtgConCliente.AutoGenerateColumns = false;
                    BsContacCliente.MoveFirst();

                    Datos.DesconectaControlTabPage(TabPConCli);

                    dtgConCliente.DataSource = BsContacCliente;
                    txtConCodigo.DataBindings.Add("Text", BsContacCliente, "grlcon_id");
                    txtConNombre.DataBindings.Add("Text", BsContacCliente, "cont_nombre");
                    txtConCodProvincia.DataBindings.Add("Text", BsContacCliente, "grlprv_codigo");
                    txtConNomProvincia.DataBindings.Add("Text", BsContacCliente, "grlprv_nombre");
                    txtConCodCiudad.DataBindings.Add("Text", BsContacCliente, "grlcui_codigo");
                    txtConNomCiudad.DataBindings.Add("Text", BsContacCliente, "grlcui_nombre");
                    txtConCodSector.DataBindings.Add("Text", BsContacCliente, "grlset_codigo");
                    txtConNomSector.DataBindings.Add("Text", BsContacCliente, "grlset_nombre");
                    cbxConParentesco.DataBindings.Add("Text", BsContacCliente, "grlcon_parentesco");
                }
                else
                {
                    Datos.LimpiaControlTabPage(TabPConCli);
                    Datos.DesconectaControlTabPage(TabPConCli);
                }
            }
            //*******************************************************************//////
        }

        private void btnConCli_Click(object sender, EventArgs e)
        {
            frmContactoClient frmContactoClient = new frmContactoClient();
            frmContactoClient.StartPosition = FormStartPosition.CenterScreen;
            frmContactoClient.ID = txtID.Text;
            frmContactoClient.ShowDialog();
            if (frmContactoClient.LookupOk == 1)
            {
                txtConCodigo.Text = frmContactoClient.Code.ToString();
                txtConNombre.Text = frmContactoClient.Description.ToString();
                txtConCodProvincia.Text = frmContactoClient.CondCodProvincia.ToString();
                txtConNomProvincia.Text = frmContactoClient.CondNomProvincia.ToString();
                txtConCodCiudad.Text = frmContactoClient.CondCodCiudad.ToString();
                txtConNomCiudad.Text = frmContactoClient.CondNomCiudad.ToString();
                txtConCodSector.Text = frmContactoClient.CondCodSetor.ToString();
                txtConNomSector.Text = frmContactoClient.CondNomSetor.ToString();
            }
        }
        private void HabilitaDesplazamiento(bool habil) 
        {
            this.btnPrimero.Enabled = habil;
            this.btnAtras.Enabled = habil;
            this.btnSiguiente.Enabled = habil;
            this.btnUltimo.Enabled = habil;
        }
        private void LimpiarEntradasCli()
        {
            txtID.Clear();
            txtCliCodigo.Clear();
            mtxtIdentificacion.Clear();
            txtFullName.Clear();
            txtApellidosClientes.Clear();
            txtCodigoPais.Clear();
            txtnombresCliente.Clear();
            txtApellidosClientes.Clear();
            cbxTipoIdentificacion.Text = "";
            cbxTipoVinculo.Text = "";
            cbxestadoCivil.Text = "";
            cbxsexo.Text = "";
            cbxestado.Text = "";
            txtNombrePais.Clear();
            txtTipoCliente.Clear();
            txtTipoclinombre.Clear();
        }
        private void DesconectaEntradasCli()
        {
            txtID.DataBindings.Clear();
            txtCliCodigo.DataBindings.Clear();
            mtxtIdentificacion.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtApellidosClientes.DataBindings.Clear();
            txtCodigoPais.DataBindings.Clear();
            txtnombresCliente.DataBindings.Clear();
            txtApellidosClientes.DataBindings.Clear();
            cbxTipoIdentificacion.DataBindings.Clear();
            cbxTipoVinculo.DataBindings.Clear();
            cbxestadoCivil.DataBindings.Clear();
            cbxsexo.DataBindings.Clear();
            cbxestado.DataBindings.Clear();
            txtNombrePais.DataBindings.Clear();
            txtTipoCliente.DataBindings.Clear();
            txtTipoclinombre.DataBindings.Clear();
        }
        /// <summary>
        /// Activa o Desactiva los TextBox, ComboBox, Button de los datos Generales del Cliente 
        /// </summary>
        /// <param name="activ"></param>
        private void ActivaEntradasCli(bool activ)
        {
            rbtFisica.Enabled = activ;
            rbtJuridica.Enabled = activ;
            txtID.Enabled = activ;
            txtCliCodigo.Enabled = activ;
            mtxtIdentificacion.Enabled = activ;
            txtFullName.Enabled = activ;
            txtApellidosClientes.Enabled = activ;
            cbxTipoIdentificacion.Enabled = activ;
            cbxTipoVinculo.Enabled = activ;
            txtCodigoPais.Enabled = activ;
            cbxestado.Enabled = activ;
            txtNombrePais.Enabled = activ;
            txtTipoCliente.Enabled = activ;
            txtTipoclinombre.Enabled = activ;
            if (rbtFisica.Checked == true)
            {
                txtnombresCliente.Enabled = activ;
                txtApellidosClientes.Enabled = activ;
                cbxestadoCivil.Enabled = activ;
                cbxsexo.Enabled = activ;
            }
            else
                if (rbtJuridica.Checked == true)
            {
                txtnombresCliente.Enabled = false;
                txtApellidosClientes.Enabled = false;
                cbxestadoCivil.Enabled = false;
                cbxsexo.Enabled = false;
            }
        }

        private void rbtFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtFisica.Checked && BtnEjecutado.BotonEjecutado == "btnNuevo")
            {
                foreach (var Look in TabDatos.Controls)
                {
                    if (Look is TextBox) { ((TextBox)Look).Enabled = true; }
                    if (Look is ComboBox) { ((ComboBox)Look).Enabled = true; }
                    if (Look is DateTimePicker) { ((DateTimePicker)Look).Enabled = true; }
                }
            }
        }

        private void rbtJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtJuridica.Checked && BtnEjecutado.BotonEjecutado == "btnNuevo")
            {
                foreach (var Look in TabDatos.Controls)
                {
                    if (Look is TextBox) { ((TextBox)Look).Enabled = false; }
                    if (Look is ComboBox) { ((ComboBox)Look).Enabled = false; }
                    if (Look is DateTimePicker) { ((DateTimePicker)Look).Enabled = false; }
                }

            }
        }
        /// <summary>
        /// Accion que se ejecuta cuan se hace click en Acaptar del Tab Direccion
        /// </summary>
        /// <returns></returns>
        private bool btnDirAceptarClic() 
        {
            if (string.IsNullOrEmpty(cbxDirTipo.Text.Trim()))
            {
                MessageBox.Show("Favor indique el tipo de dirección.");
                cbxDirTipo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDirCalle.Text.Trim()))
            {
                MessageBox.Show("Favor indique la calle donde vive.");
                txtDirCalle.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDirNumero.Text.Trim()))
            {
                MessageBox.Show("Favor indique el número de casa.");
                txtDirNumero.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDirCodPais.Text.Trim()) || string.IsNullOrEmpty(txtDirNomPais.Text.Trim()))
            {
                MessageBox.Show("Favor indique el país.");
                txtDirCodPais.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDirCodProvincia.Text.Trim()) || string.IsNullOrEmpty(txtDirNomProvincia.Text.Trim()))
            {
                MessageBox.Show("Favor indique la Provincia.");
                txtDirCodProvincia.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDirCodCiudad.Text.Trim()) || string.IsNullOrEmpty(txtDirNomCiudad.Text.Trim()))
            {
                MessageBox.Show("Favor indique la Ciudad.");
                txtDirCodCiudad.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDirCodSector.Text.Trim()) || string.IsNullOrEmpty(txtDirNomSector.Text.Trim()))
            {
                MessageBox.Show("Favor indique el donde vive.");
                txtDirCodSector.Focus();
                return false;
            }
            // Una vez a sido creada la tabla tbtTel en el evento Load de Form,  
            // se usa el siguiente codigo para crear un DataRow.
            DataRow row;
            row = tblDir.NewRow();

            // Usar el siguiente codigo para agragar el nuevo row al collection.
            row["grlent_ID"] = System.Convert.ToInt32(txtID.Text);
            row["Tipo"] = cbxDirTipo.Text;
            row["grluso_codigo"] = cbxDirTipo.Text.Substring(0, 3);
            row["grldir_calle"] = txtDirCalle.Text;
            row["grldir_numero"] = txtDirNumero.Text; ;
            row["grldir_edificio"] = txtDirEdificio.Text;
            row["grlpai_codigo"] = System.Convert.ToInt32(txtDirCodPais.Text);
            row["grlpai_nombre"] = txtDirNomPais.Text;
            row["grlprv_codigo"] = System.Convert.ToInt32(txtDirCodProvincia.Text);
            row["grlprv_nombre"] = txtDirNomProvincia.Text;
            row["grlcui_codigo"] = System.Convert.ToInt32(txtDirCodCiudad.Text);
            row["grlcui_nombre"] = txtDirNomCiudad.Text;
            row["grlset_codigo"] = System.Convert.ToInt32(txtDirCodSector.Text);
            row["grlset_nombre"] = txtDirNomSector.Text;
            tblDir.Rows.Add(row);
            //*****************************************************///////////////////////

            //El siguiente bloke se estara evaluando para ver si es necesaria esta parte //////////////////////
            {
                BsDirCliente.DataSource = tblDir;

                dtgDircliente.AutoGenerateColumns = false;
                BsDirCliente.MoveLast();

                Datos.DesconectaControlTabPage(TabPDirCli);

                dtgDircliente.DataSource = BsDirCliente;

                dtgDircliente.DataSource = BsDirCliente;
                cbxDirTipo.DataBindings.Add("Text", BsDirCliente, "Tipo");
                txtDirCalle.DataBindings.Add("Text", BsDirCliente, "grldir_calle");
                txtDirNumero.DataBindings.Add("Text", BsDirCliente, "grldir_numero");
                txtDirEdificio.DataBindings.Add("Text", BsDirCliente, "grldir_edificio");
                txtDirCodPais.DataBindings.Add("Text", BsDirCliente, "grlpai_codigo");
                txtDirNomPais.DataBindings.Add("Text", BsDirCliente, "grlpai_nombre");
                txtDirCodProvincia.DataBindings.Add("Text", BsDirCliente, "grlprv_codigo");
                txtDirNomProvincia.DataBindings.Add("Text", BsDirCliente, "grlprv_nombre");
                txtDirCodCiudad.DataBindings.Add("Text", BsDirCliente, "grlcui_codigo");
                txtDirNomCiudad.DataBindings.Add("Text", BsDirCliente, "grlcui_nombre");
                txtDirCodSector.DataBindings.Add("Text", BsDirCliente, "grlset_codigo");
                txtDirNomSector.DataBindings.Add("Text", BsDirCliente, "grlset_nombre");
            }
            //*********************************************************//////////////////////

            ////Insertar los registros que nuevos con sqldataadapter ///////////////////////////
            //{

            //    Datos.UpdateTelTable(Convert.ToInt32(txtID.Text),tbtTel);
            //    dtgTelCliente.Enabled = true;
            //}
            ////*********************************************************//////////////////////

            dtgDircliente.Enabled = true;
            cbxDirTipo.Enabled = false;
            txtDirCalle.Enabled = false;
            txtDirNumero.Enabled = false;
            txtDirEdificio.Enabled = false;
            txtDirCodPais.Enabled = false;
            txtDirNomPais.Enabled = false;
            txtDirCodProvincia.Enabled = false;
            txtDirNomProvincia.Enabled = false;
            txtDirCodCiudad.Enabled = false;
            txtDirNomCiudad.Enabled = false;
            txtDirCodSector.Enabled = false;
            txtDirNomSector.Enabled = false;
            //HABILITAR Y DESHABILITAR BOTONES
            btnDirAgregar.Enabled = true;
            btnDirBorrar.Enabled = true;
            btnDirAceptar.Enabled = false;
            btnDirCancelar.Enabled = false;
            btnDirPais.Enabled = false;
            return true;
        }
        /// <summary>
        /// Accion que se ejecuta cuan se hace click en Cancelar del Tab Direccion
        /// </summary>
        /// <returns></returns>
        private bool btnDirCancelarClic() 
        {
            this.BuscarDireccion();

            dtgDircliente.Enabled = true;

            //DESHABILITAR ENTRADA DE DATOS
            cbxDirTipo.Enabled = false;
            txtDirCalle.Enabled = false;
            txtDirNumero.Enabled = false;
            txtDirEdificio.Enabled = false;
            txtDirCodPais.Enabled = false;
            txtDirNomPais.Enabled = false;
            txtDirCodProvincia.Enabled = false;
            txtDirNomProvincia.Enabled = false;
            txtDirCodCiudad.Enabled = false;
            txtDirNomCiudad.Enabled = false;
            txtDirCodSector.Enabled = false;
            txtDirNomSector.Enabled = false;


            //HABILITAR Y DESHABILITAR BOTONES
            btnDirAgregar.Enabled = true;
            btnDirBorrar.Enabled = true;
            btnDirAceptar.Enabled = false;
            btnDirCancelar.Enabled = false;
            btnDirPais.Enabled = false;
            btnDirProv.Enabled = false;
            btnDirCiudad.Enabled = false;
            btnDirSector.Enabled = false;
            return true;
 
        }
        /// <summary>
        /// Accion que se ejecuta cuan se hace click en Acaptar del Tab Telefono
        /// </summary>
        /// <returns></returns>
        private bool btnTelAceptarClic() 
        {
            {



                if (string.IsNullOrEmpty(txtID.Text.Trim()))
                {
                    MessageBox.Show("Id invalido");
                    return false;
                }
                if (string.IsNullOrEmpty(cbxTelTipo.Text.Trim()))
                {
                    MessageBox.Show("Tipo invalido");
                    cbxTelTipo.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtTelCodPais.Text.Trim()))
                {
                    MessageBox.Show("Pais invalida");
                    txtTelCodPais.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtTelArea.Text.Trim()))
                {
                    MessageBox.Show("Area invalida");
                    cbxTelTipo.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtTelNumero.Text.Trim()))
                {
                    MessageBox.Show("Numero invalida");
                    txtTelNumero.Focus();
                    return false;
                }


                // Una vez a sido creada la tabla tbtTel en el evento Load de Form,  
                // se usa el siguiente codigo para crear un DataRow.
                DataRow row;
                row = tblTel.NewRow();

                // Usar el siguiente codigo para agragar el nuevo row al collection.
                row["grlent_ID"] = System.Convert.ToInt32(txtID.Text);
                row["grltipt_codigo"] = cbxTelTipo.Text.Substring(0, 3);
                row["grltel_area"] = txtTelArea.Text;
                row["grltel_numero"] = txtTelNumero.Text; ;
                row["grltel_ext"] = txtTelExtencion.Text;
                row["grluso_codigo"] = cbxTelTipo.Text.Substring(0, 3);
                row["grlpai_codigo"] = System.Convert.ToInt32(txtTelCodPais.Text);
                row["grlpai_nombre"] = txtNombrePais.Text;
                row["Tipo"] = cbxTelTipo.Text;
                tblTel.Rows.Add(row); 
                
                //*****************************************************///////////////////////

                //El siguiente bloke se estara evaluando para ver si es necesaria esta parte //////////////////////
                {
                    BsTelCliente.DataSource = tblTel;

                    dtgTelCliente.AutoGenerateColumns = false;
                    BsTelCliente.MoveLast();

                    Datos.DesconectaControlTabPage(TabPTelCli);

                    dtgTelCliente.DataSource = BsTelCliente;

                    cbxTelTipo.DataBindings.Add("Text", BsTelCliente, "Tipo");
                    txtTelCodPais.DataBindings.Add("Text", BsTelCliente, "grlpai_codigo");
                    txtTelNomPais.DataBindings.Add("Text", BsTelCliente, "grlpai_nombre");
                    txtTelArea.DataBindings.Add("Text", BsTelCliente, "grltel_area");
                    txtTelNumero.DataBindings.Add("Text", BsTelCliente, "grltel_numero");
                    txtTelExtencion.DataBindings.Add("Text", BsTelCliente, "grltel_ext");
                }
                //*********************************************************//////////////////////

                ////Insertar los registros que nuevos con sqldataadapter ///////////////////////////
                //{

                //    Datos.UpdateTelTable(Convert.ToInt32(txtID.Text),tbtTel);
                //    dtgTelCliente.Enabled = true;
                //}
                ////*********************************************************//////////////////////
            }
            //DESHABILITAR ENTRADA DE DATOS
            cbxTelTipo.Enabled = false;
            txtTelCodPais.Enabled = false;
            txtTelArea.Enabled = false;
            txtTelNumero.Enabled = false;
            txtTelExtencion.Enabled = false;

            //HABILITAR Y DESHABILITAR BOTONES
            btnTelAgregar.Enabled = true;
            btnTelBorrar.Enabled = true;
            btnTelAceptar.Enabled = false;
            btnTelCancelar.Enabled = false;
            btnTelpais.Enabled = false;
            // btnTelEditar.Enabled = true;
            return true;
        }
        /// <summary>
        /// Accion que se ejecuta cuan se hace click en Cancelar del Tab Telefono
        /// </summary>
        /// <returns></returns>
        private bool btnTelCancelarCli()
        {
            dtgTelCliente.Enabled = true;
            try
            {
                this.BuscarTelefono();
            }
            catch 
            {
                return false;
            }

            //DESHABILITAR ENTRADA DE DATOS
            cbxTelTipo.Enabled = false;
            txtTelCodPais.Enabled = false;
            txtTelArea.Enabled = false;
            txtTelNumero.Enabled = false;
            txtTelExtencion.Enabled = false;
            
            //HABILITAR Y DESHABILITAR BOTONES
            btnTelAgregar.Enabled = true;
            btnTelBorrar.Enabled = true;
            btnTelAceptar.Enabled = false;
            btnTelCancelar.Enabled = false;
            btnTelpais.Enabled = false;
            //btnTelEditar.Enabled = true;
            return true ;
        }
        /// <summary>
        /// Accion que se ejecuta cuan se hace click en Acaptar del Tab Contacto
        /// </summary>
        /// <returns></returns>
        private bool btnConAceptarClic() 
        {
            if (string.IsNullOrEmpty(txtConCodigo.Text.Trim()) || string.IsNullOrEmpty(txtConNombre.Text.Trim()))
            {
                MessageBox.Show("Favor indique el contacto.");
                txtConCodigo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtConCodProvincia.Text.Trim()) || string.IsNullOrEmpty(txtConNomProvincia.Text.Trim()))
            {
                MessageBox.Show("Favor indique la provincia.");
                txtConCodProvincia.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtConCodCiudad.Text.Trim()) || string.IsNullOrEmpty(txtConNomCiudad.Text.Trim()))
            {
                MessageBox.Show("Favor indique la ciudad.");
                txtConCodCiudad.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtConCodSector.Text.Trim()) || string.IsNullOrEmpty(txtConNomSector.Text.Trim()))
            {
                MessageBox.Show("Favor indique el sector.");
                txtConCodSector.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbxConParentesco.Text.Trim()))
            {
                MessageBox.Show("Favor indique el parentesco.");
                cbxConParentesco.Focus();
                return false;
            }

            // Una vez a sido creada la tabla tbtTel en el evento Load de Form,  
            // se usa el siguiente codigo para crear un DataRow.
            DataRow row;
            row = tblContac.NewRow();
            try
            {
                // Usar el siguiente codigo para agragar el nuevo row al collection.
                row["grlent_ID"] = System.Convert.ToInt32(txtID.Text);
                row["grlcon_id"] = System.Convert.ToInt32(txtConCodigo.Text);
                row["grlcon_parentesco"] = cbxConParentesco.Text;
                row["cont_nombre"] = txtConNombre.Text;
                row["grlprv_codigo"] = System.Convert.ToInt32(txtConCodProvincia.Text);
                row["grlprv_nombre"] = txtConNomProvincia.Text;
                row["grlcui_codigo"] = System.Convert.ToInt32(txtConCodCiudad.Text);
                row["grlcui_nombre"] = txtConNomCiudad.Text;
                row["grlset_codigo"] = System.Convert.ToInt32(txtConCodSector.Text);
                row["grlset_nombre"] = txtConNomSector.Text;
                tblContac.Rows.Add(row);
                //*****************************************************///////////////////////

                //El siguiente bloke se estara evaluando para ver si es necesaria esta parte //////////////////////
                {
                    BsContacCliente.DataSource = tblContac;
                    dtgConCliente.AutoGenerateColumns = false;
                    BsContacCliente.MoveFirst();

                    Datos.DesconectaControlTabPage(TabPConCli);

                    dtgConCliente.DataSource = BsContacCliente;
                    txtConCodigo.DataBindings.Add("Text", BsContacCliente, "grlcon_id");
                    txtConNombre.DataBindings.Add("Text", BsContacCliente, "cont_nombre");
                    txtConCodProvincia.DataBindings.Add("Text", BsContacCliente, "grlprv_codigo");
                    txtConNomProvincia.DataBindings.Add("Text", BsContacCliente, "grlprv_nombre");
                    txtConCodCiudad.DataBindings.Add("Text", BsContacCliente, "grlcui_codigo");
                    txtConNomCiudad.DataBindings.Add("Text", BsContacCliente, "grlcui_nombre");
                    txtConCodSector.DataBindings.Add("Text", BsContacCliente, "grlset_codigo");
                    txtConNomSector.DataBindings.Add("Text", BsContacCliente, "grlset_nombre");
                }
            }
            catch 
            {
                return false;
            }
            //HABILITAR ENTRADA DE DATOS
            txtConCodigo.Enabled = false;
            txtConCodCiudad.Enabled = false;
            txtConCodProvincia.Enabled = false;
            txtConCodSector.Enabled = false;
            cbxConParentesco.Enabled = false;

            //HABILITAR Y DESHABILITAR BOTONES
            btnConAgregar.Enabled = true;
            btnConBorrar.Enabled = true;
            btnConAceptar.Enabled = false;
            btnConCancelar.Enabled = false;
            btnConCli.Enabled = false;
            return true;
        }
        /// <summary>
        /// Accion que se ejecuta cuan se hace click en Cancelar del Tab Contacto
        /// </summary>
        /// <returns></returns>
        private bool btnConCancelarClic()
        {
            try
            {
                this.BuscarContacto();
            }
            catch { 
                return false; 
            }
            //HABILITAR ENTRADA DE DATOS
            txtConCodigo.Enabled = false;
            txtConCodCiudad.Enabled = false;
            txtConCodProvincia.Enabled = false;
            txtConCodSector.Enabled = false;
            cbxConParentesco.Enabled = false;

            //HABILITAR Y DESHABILITAR BOTONES
            btnConAgregar.Enabled = true;
            btnConBorrar.Enabled = true;
            btnConAceptar.Enabled = false;
            btnConCancelar.Enabled = false;
            btnConCli.Enabled = false;
            return true;
        }
        private bool ValidaDatosGenerales() 
        {
            int index = 0;
            string cedula = String.Empty;
            int inicio = 0;
            if (string.IsNullOrEmpty(txtTipoCliente.Text) || string.IsNullOrEmpty(txtTipoclinombre.Text))
            {
                MessageBox.Show("Favor indicar el tipo de cliente.");
                txtTipoCliente.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbxTipoIdentificacion.Text))
            {
                MessageBox.Show("Favor indicar el tipo de identificación.");
                cbxTipoIdentificacion.Focus();
                return false;
            }
            else
            {
                if (cbxTipoIdentificacion.Text.Substring(0, 3) == "CED")
                {
                    if (mtxtIdentificacion.Text.Trim().Length == 13)
                    {

                        //VALIDA LA CEDULA 

                        while (mtxtIdentificacion.Text.IndexOf('-', index) > 0)
                        {
                            index = mtxtIdentificacion.Text.IndexOf('-', index) + 1;
                            cedula = cedula + mtxtIdentificacion.Text.Substring(inicio, index - inicio - 1).Trim();
                            inicio = index;
                        }
                        cedula = cedula + mtxtIdentificacion.Text.Substring(inicio, 1);
                        if (Datos.ValidaCedula(cedula) == false)
                        {
                            MessageBox.Show("Cédula invalidar.");
                            mtxtIdentificacion.Focus();
                            return false;

                        };
                    }
                    else
                    {
                        MessageBox.Show("Cedula Incompleta.");
                        mtxtIdentificacion.Focus();
                        return false;
                    }
                }
                else
                {
                    if (cbxTipoIdentificacion.Text.Substring(0, 3) == "PAS")
                    {
                        if (string.IsNullOrEmpty(mtxtIdentificacion.Text))
                        {
                            MessageBox.Show("Identificación no valida.");
                            mtxtIdentificacion.Focus();
                            return false;
                        }

                    }
                }
            }

            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("El nombre no debe estar en blanco.");
                txtFullName.Focus();
                return false;

            }

            if (string.IsNullOrEmpty(cbxTipoVinculo.Text))
            {
                MessageBox.Show("Favor indicar el tipo de vinculo.");
                cbxTipoVinculo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCodigoPais.Text))//|| string.IsNullOrEmpty(txtNombrePais.Text))
            {
                MessageBox.Show("Favor indicar el Pais.");
                txtCodigoPais.Focus();
                return false;

            }
            //Casillas obligatorias si el tipo de persona es Fisica
            if (rbtFisica.Checked)
            {
                if (string.IsNullOrEmpty(txtnombresCliente.Text))
                {
                    MessageBox.Show("El nombre de no debe estar en blanco.");
                    txtnombresCliente.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtApellidosClientes.Text))
                {
                    MessageBox.Show("El apellido de no debe estar en blanco.");
                    txtApellidosClientes.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cbxsexo.Text))
                {
                    MessageBox.Show("Favor indicar el género.");
                    cbxsexo.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cbxestadoCivil.Text))
                {
                    MessageBox.Show("Favor indicar el estado civil.");
                    cbxestadoCivil.Focus();
                    return false;
                }

            }
            return true;
        }
        private void txtnombresCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void txtApellidosClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtApellidosClientes_TextChanged(object sender, EventArgs e)
        {
            if (rbtFisica.Checked)
            {
                txtFullName.Text = txtnombresCliente.Text + " " + txtApellidosClientes.Text;
            }
        }

        private void txtnombresCliente_TextChanged(object sender, EventArgs e)
        {
            if (rbtFisica.Checked)
            {
                txtFullName.Text = txtnombresCliente.Text + " " + txtApellidosClientes.Text;
            }
        }

        private void btnConBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnDirBorrar_Click(object sender, EventArgs e)
        {

        }
                 
    }
}
