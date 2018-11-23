using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 

namespace CIS
{
    public partial class frmArticulos : Form
    {
        //VARIABLES PUBLICAS PARA EL FORMULARIO
        Datos BtnEjecutado = new Datos();  //PARA USAR UNA VARIABLE QUE ESTA DEFINIDA EN UNA CLASE
        BindingSource Query = new BindingSource();

        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            ToolTip ToolTip = new ToolTip();
            ToolTip.ShowAlways = true;

            ToolTip.SetToolTip(btnAgregarPrec, "Agregar");
            ToolTip.SetToolTip(btnEditarPrec, "Editar");
            ToolTip.SetToolTip(btnBorrarPrec, "Borrar"); 
            ToolTip.SetToolTip(btnBuscar, "Buscar");
            ToolTip.SetToolTip(btnPrimero, "Primero");
            ToolTip.SetToolTip(btnAtras, "Atras");
            ToolTip.SetToolTip(btnSiguiente, "Siguiente");
            ToolTip.SetToolTip(btnUltimo, "Ultimo");
            ToolTip.SetToolTip(btnNuevo, "Nuevo");
            ToolTip.SetToolTip(btnEditar, "Editar");
            ToolTip.SetToolTip(btnCancelar, "Cancelar");
            ToolTip.SetToolTip(btnAceptar, "Aceptar");
            ToolTip.SetToolTip(btnImprimir, "Imprimir");
            ToolTip.SetToolTip(btnAdjuntar, "Adjuntar");
            ToolTip.SetToolTip(btnNotas, "Notas");
            ToolTip.SetToolTip(btnSalir, "Salir");

            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;
            btnSalir.Enabled = true;  
            
        }

        private void btnBusar_Click(object sender, EventArgs e)
        {
            BtnEjecutado.BotonEjecutado = "btnBuscar";
            Datos.LimpiarCamposTabPage(TabDatos);
            Datos.HabilitarLookupTabPage(TabDatos);
            Datos.LimpiarRadioButtonGroupBok(grbClaseArt);
            Datos.LimpiarRadioButtonGroupBok(grbMetodoCost);

            txtID.DataBindings.Clear();
            txtCodigo.DataBindings.Clear();
            txtEstadoCod.DataBindings.Clear();
            txtEstadoDescrip.DataBindings.Clear();
            txtDescrip.DataBindings.Clear();
            txtFechaReg.DataBindings.Clear();
            txtFamilaCod.DataBindings.Clear();
            txtExistencia.DataBindings.Clear();
            txtSeparacion.DataBindings.Clear();

             
            txtID.Enabled = true; 
            txtCodigo.Enabled = true; 
            txtEstadoCod.Enabled = true;
            txtDescrip.Enabled = true;
            txtFechaReg.Enabled = true;
            grbClaseArt.Enabled = true;
            grbMetodoCost.Enabled = true;
            txtUnidadCod.Enabled = true;
            txtFamilaCod.Enabled = true;
            txtGrupoCod.Enabled = true;
            txtTipoCod.Enabled = true;
            txtMarcaCod.Enabled = true;
            txtPaisCod.Enabled = true; 
            
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            btnAceptar.Enabled = true;
            btnBuscar.Enabled = false; 
            btnPrimero.Enabled = false;
            btnAtras.Enabled = false;
            btnSiguiente.Enabled = false;
            btnUltimo.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //ASIGNAMOS VALOR A LA VARIABLE BtnEjecutado PARA SABER QUE ACCION TOMAR AL HACER CLIC EN EL BOTON ACEPTAR
            BtnEjecutado.BotonEjecutado = "btnNuevo";            
            Datos.LimpiarCamposTabPage(TabDatos);
            Datos.HabilitarLookupTabPage(TabDatos);

            //HABILITAR Y LIMPIAR LOS TEXBOX
            txtCodigo.Enabled = true; 
            txtCodigo.BackColor = Color.LightCyan; 
            txtEstadoCod.Text = "1"; 
            txtEstadoDescrip.Text = "ACTIVO";
            txtDescrip.Enabled = true; 
            txtDescrip.BackColor = Color.LightCyan;
            txtFechaReg.Enabled = true;
            txtFechaReg.Text = DateTime.Now.ToString("dd-MM-yyyy"); 
            txtFechaReg.BackColor = Color.LightCyan; 
            txtUnidadCod.Enabled = true; 
            txtUnidadCod.BackColor = Color.LightCyan;
            txtFamilaCod.Enabled = true;
            txtGrupoCod.Enabled = true;
            txtTipoCod.Enabled = true;
            txtMarcaCod.Enabled = true;
            txtPaisCod.Enabled = true; 
            txtPaisCod.BackColor = Color.LightCyan;  

            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnFamilia.Enabled = true;
            btnImagen.Enabled = true;
            btnAceptar.Enabled = true;
            btnEstado.Enabled = false;

            //HABILITAR, PASAR VALORES A RADIO BUTTON
            grbClaseArt.Enabled = true;
            rbtArticulo.Enabled = true;
            rbtArticulo.Checked = true;
            rbtServicio.Enabled = true; 
            //ASIGNAR VALOR AL METODO DE COSTO  
            Datos.Conectar();
            string MTC = Datos.BucarParametro("MTC", "INV", "", "");
            if (MTC == "A")
            {
                rbtPromedio.Checked = true;
                rbtPeps.Checked     = false;
                rbtUeps.Checked     = false;
            }
            else
                if (MTC == "U")
                {
                    rbtPromedio.Checked = false;
                    rbtPeps.Checked     = false;
                    rbtUeps.Checked     = true;
                }
                else
                    if (MTC == "P")
                    {
                        rbtPromedio.Checked = false;
                        rbtPeps.Checked     = true;
                        rbtUeps.Checked     = false;
                    }

            Datos.Desconectar(); 

            dtmFechaReg.Value = DateTime.Now;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            BtnEjecutado.BotonEjecutado = "btnEditar";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DataTable pinvartm = new DataTable();

            Datos.DeshabilitarLookupTabPage(TabDatos);
            Datos.DeshabilitarTexboxTabPage(TabDatos);
            grbClaseArt.Enabled = false;
            grbMetodoCost.Enabled = false;

            if (BtnEjecutado.BotonEjecutado == "btnBuscar")
            {
                Datos.Conectar();                   
                //Llena el BindingSource con los datos del DataTable
                Query.DataSource = Datos.Consultar("select art.*, sts.grlsts_descrip " +
                                                          "  from cinvartm art " +
                                                          "       INNER JOIN cgrlstsm sts ON sts.grlsts_codigo = art.grlsts_codigo " +
                                                          "              AND sts.grltbl_codigo = 'cinvartm'"+
                                                          " WHERE art.invart_id "     + Datos.OperadorBusqueda(txtID.Text) + 
                                                          "   AND art.invart_codigo " + Datos.OperadorBusqueda(txtCodigo.Text) +
                                                          "   AND art.grlsts_codigo " + Datos.OperadorBusqueda(txtEstadoCod.Text)) ;
                
                //Se limpia la propiedad DataBindings de los controles para que si se hace una nueva consulta no se cree un excepcion.
                txtID.DataBindings.Clear();
                txtCodigo.DataBindings.Clear();
                txtEstadoCod.DataBindings.Clear();
                txtEstadoDescrip.DataBindings.Clear();
                txtDescrip.DataBindings.Clear();
                txtFechaReg.DataBindings.Clear();
                txtFamilaCod.DataBindings.Clear();
                txtExistencia.DataBindings.Clear();
                txtSeparacion.DataBindings.Clear();
                //Se enlasan los controles BindingSource, indicando que propiedad del control tomará el valor de la columna indicada.
                txtID.DataBindings.Add("Text", Query, "invart_id");
                txtCodigo.DataBindings.Add("Text", Query, "invart_codigo");
                txtEstadoCod.DataBindings.Add("Text", Query, "grlsts_codigo");
                txtEstadoDescrip.DataBindings.Add("Text", Query, "grlsts_descrip");
                txtDescrip.DataBindings.Add("Text", Query, "invart_descrip");
                txtFechaReg.DataBindings.Add("Text", Query, "invart_fechreg");
                txtFamilaCod.DataBindings.Add("Text", Query, "invfam_codigo");
                txtExistencia.DataBindings.Add("Text", Query, "invart_exist");
                txtSeparacion.DataBindings.Add("Text", Query, "invart_separ");


                if (Query.Count == 0)
                {
                    Datos.LimpiarCamposTabPage(TabDatos);
                }
                else if (Query.Count <= 1)
                {
                    btnEditar.Enabled = false;
                    btnPrimero.Enabled = false;
                    btnAtras.Enabled = false;
                    btnSiguiente.Enabled = false;
                    btnUltimo.Enabled = false;
                }
                else
                {
                    btnEditar.Enabled = true;
                    btnPrimero.Enabled = false;
                    btnAtras.Enabled = false;
                    btnSiguiente.Enabled = true;
                    btnUltimo.Enabled = true;
                }

                btnBuscar.Enabled = true;
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = false;
                btnAceptar.Enabled = false;

                txtID.Enabled = false;
                txtCodigo.Enabled = false;
                txtEstadoCod.Enabled = false;
                txtDescrip.Enabled = false;
                dtmFechaReg.Enabled = false;
                txtFamilaCod.Enabled = false;

                Datos.Desconectar(); 
            }

            if (BtnEjecutado.BotonEjecutado == "btnNuevo")
            { 
                Datos.Conectar();
                string cia = "01";
                string fam = "ALC";
                int reply = Datos.Insertar("INSERT INTO cinvartm (grlcia_codigo, invart_codigo, invart_descrip, invart_exist, " + 
                                           "                      invart_separ, invart_fechreg, invfam_codigo, grlsts_codigo)" +
                                           "               VALUES (" + cia + "','" + txtCodigo.Text + "','" + txtDescrip.Text + 
                                                                   "'," + 0 + "," + 0 + ",'" + dtmFechaReg.Value.ToString("yyyy-MM-dd").Replace(" p.m.", "") + 
                                                                   "','" + fam + "'," + 1);
                if (reply == 0)
                {
                    btnImprimir.Enabled = true;
                    btnNotas.Enabled = true;
                    btnAdjuntar.Enabled = true;
                    btnEditar.Enabled = true;
                }
                else
                {
                    btnImprimir.Enabled = false;
                    btnNotas.Enabled = false;
                    btnAdjuntar.Enabled = false;
                }

                Datos.Desconectar();
                 
                btnNuevo.Enabled = true;
                btnSalir.Enabled = true;
                btnBuscar.Enabled = true;
            }

            if (BtnEjecutado.BotonEjecutado == "btnEditar")
            {
                MessageBox.Show("Editar");
            }

            BtnEjecutado.BotonEjecutado = ""; //LINPIAMOS LA VARIABLE QUE INDICA EL BOTON EJECUTADO
            btnAceptar.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (BtnEjecutado.BotonEjecutado == "btnNuevo")
            {
                if (MessageBox.Show("¿Desea cancelar el registro?", "CIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else if (BtnEjecutado.BotonEjecutado == "btnEditar")
            {
               if (MessageBox.Show("¿Desea cancelar la edición?", "CIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               {
                  this.Close();
               }
            }
            else
            {
               this.Close();
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            Query.MoveFirst(); 
            if (Query.Position  == 0)
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
            Query.MovePrevious();
            if (Query.Position == 0)
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
            Query.MoveNext(); 
            if ((Query.Count -1)  == Query.Position)
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
            Query.MoveLast(); 
            if ((Query.Count - 1) == Query.Position)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            if (BtnEjecutado.BotonEjecutado == "btnNuevo")
            {
                if (MessageBox.Show("¿Desea cancelar el registro?", "CIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Datos.DeshabilitarLookupTabPage(TabDatos);
                    Datos.DeshabilitarTexboxTabPage(TabDatos);
                    Datos.LimpiarCamposFormulario(TabDatos);
                    grbClaseArt.Enabled = false;
                    grbMetodoCost.Enabled = false;

                    txtCodigo.BackColor = Color.WhiteSmoke;
                    txtDescrip.BackColor = Color.WhiteSmoke;
                    txtFechaReg.BackColor = Color.WhiteSmoke;
                    txtUnidadCod.BackColor = Color.WhiteSmoke;
                    txtPaisCod.BackColor = Color.WhiteSmoke;                    
                    
                    btnBuscar.Enabled = true;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnAceptar.Enabled = false;
                } 
            }
            else
                if (BtnEjecutado.BotonEjecutado == "btnEditar")
                {
                    if (MessageBox.Show("¿Desea cancelar la edición?", "CIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Datos.DeshabilitarLookupTabPage(TabDatos);
                        Datos.DeshabilitarTexboxTabPage(TabDatos);
                        grbClaseArt.Enabled = false;
                        grbMetodoCost.Enabled = false;

                        txtCodigo.BackColor = Color.WhiteSmoke;
                        txtDescrip.BackColor = Color.WhiteSmoke;
                        txtFechaReg.BackColor = Color.WhiteSmoke;
                        txtUnidadCod.BackColor = Color.WhiteSmoke;
                        txtPaisCod.BackColor = Color.WhiteSmoke;

                        btnBuscar.Enabled = true;
                        btnNuevo.Enabled = true;
                        btnCancelar.Enabled = false;
                        btnAceptar.Enabled = false;
                    } 
                }
                else
                {
                    Datos.DeshabilitarLookupTabPage(TabDatos);
                    Datos.DeshabilitarTexboxTabPage(TabDatos);
                    Datos.LimpiarRadioButtonGroupBok(grbClaseArt);
                    Datos.LimpiarRadioButtonGroupBok(grbMetodoCost);
                    grbClaseArt.Enabled = false;
                    grbMetodoCost.Enabled = false;

                    txtCodigo.BackColor = Color.WhiteSmoke;
                    txtDescrip.BackColor = Color.WhiteSmoke;
                    txtFechaReg.BackColor = Color.WhiteSmoke;
                    txtUnidadCod.BackColor = Color.WhiteSmoke;
                    txtPaisCod.BackColor = Color.WhiteSmoke;


                    btnBuscar.Enabled = true;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnAceptar.Enabled = false;
                }

        }
         

        private void dtmFechaReg_CloseUp(object sender, EventArgs e)
        {

            txtFechaReg.Text = dtmFechaReg.Value.ToString("dd-MM-yyyy"); 
        }
         

        private void btnEstado_Click(object sender, EventArgs e)
        {
            frmBuscarEstado frmBuscarEstados = new frmBuscarEstado();           
            frmBuscarEstados.StartPosition = FormStartPosition.CenterScreen;
            frmBuscarEstados.ShowDialog();
            if (frmBuscarEstados.LookupOk == 1)
            {
               txtEstadoCod.Text = frmBuscarEstados.Code.ToString();
               txtEstadoDescrip.Text = frmBuscarEstados.Description.ToString(); 
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Datos.SoloNumDecimal(e);
        }
 

        private void btnFamilia_Click(object sender, EventArgs e)
        {
            frmBuscarFamilia frmBuscarFamilia = new frmBuscarFamilia();
            frmBuscarFamilia.StartPosition = FormStartPosition.CenterScreen;
            frmBuscarFamilia.ShowDialog();
            if (frmBuscarFamilia.LookupOk == 1)
            {
                txtFamilaCod.Text = frmBuscarFamilia.Code.ToString();
                txtFamiliaDescrip.Text = frmBuscarFamilia.Description.ToString();
            }
        }

        private void txtEstadoCod_Leave(object sender, EventArgs e)
        {
            txtEstadoDescrip.Clear();
        }

        private void txtEstadoCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            Datos.SoloNumEnteros(e);
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            Datos.SoloNumEnteros(e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmBuscarUnidad frmBuscarUnidad = new frmBuscarUnidad();
            frmBuscarUnidad.StartPosition = FormStartPosition.CenterScreen;
            frmBuscarUnidad.ShowDialog();
            if (frmBuscarUnidad.LookupOk == 1)
            {
                txtUnidadCod.Text = frmBuscarUnidad.Code.ToString();
                txtUnidadDescrip.Text = frmBuscarUnidad.Description.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmBuscarGrupo frmBuscarGrupo = new frmBuscarGrupo();
            frmBuscarGrupo.StartPosition = FormStartPosition.CenterScreen;
            frmBuscarGrupo.ShowDialog();
            if (frmBuscarGrupo.LookupOk == 1)
            {
                txtGrupoCod.Text = frmBuscarGrupo.Code.ToString();
                txtGrupoDescrip.Text = frmBuscarGrupo.Description.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmBuscarMarca frmBuscarMarca = new frmBuscarMarca();
            frmBuscarMarca.StartPosition = FormStartPosition.CenterScreen;
            frmBuscarMarca.ShowDialog();
            if (frmBuscarMarca.LookupOk == 1)
            {
                txtMarcaCod.Text = frmBuscarMarca.Code.ToString();
                txtMarcaDescrip.Text = frmBuscarMarca.Description.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmBuscarTipo frmBuscarTipo = new frmBuscarTipo();
            frmBuscarTipo.StartPosition = FormStartPosition.CenterScreen;
            frmBuscarTipo.ShowDialog();
            if (frmBuscarTipo.LookupOk == 1)
            {
                txtTipoCod.Text = frmBuscarTipo.Code.ToString();
                txtTipoDescrip.Text = frmBuscarTipo.Description.ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmArticulos_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void frmArticulos_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (BtnEjecutado.BotonEjecutado == "btnNuevo")
            //{
            //    if (MessageBox.Show("¿Desea cancelar el registro?", "CIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        BtnEjecutado.BotonEjecutado = ""; //LINPIAMOS LA VARIABLE QUE INDICA EL BOTON EJECUTADO
            //        this.Close();
            //    }
            //}
            //else if (BtnEjecutado.BotonEjecutado == "btnEditar")
            //{
            //    if (MessageBox.Show("¿Desea cancelar la edición?", "CIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        BtnEjecutado.BotonEjecutado = ""; //LINPIAMOS LA VARIABLE QUE INDICA EL BOTON EJECUTADO
            //        this.Close();
            //    }
            //} 
        }
    }
}
