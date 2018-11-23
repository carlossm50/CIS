using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;       //PERMITE UTILIZAR EL DATA SET PARA LLENAR DATA GRIG
using System.Data.SqlClient; //PARA PODER USAR LAS VARIABLES SqlConnection ... 
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CIS
{
    public class Datos
    {
        static SqlDataAdapter Adactador = new SqlDataAdapter();
        static SqlConnection Conexion = new SqlConnection();
        static DataTable Tabla = new DataTable();
        static SqlCommand Comando = new SqlCommand();
        static string CadenaConexion = "user id =admin ;Data Source=NB-CAM-SEVERINO;Initial Catalog=CIS;password=hola;Integrated Security=false"; 
        MySqlConnection mysqlconexion = new MySqlConnection();
        public string BotonEjecutado;

        static string mysqlcadena = "DataSource=127.0.0.1;Database=cis; Uid=root;Pwd=casm09;";
        //"Database=cis;Data Source=localhost;User Id=root; Password=casm09"; Este formato tambien funciona //
        
        
        /// <summary>
        /// Conexion para Sql server
        /// </summary>
        public static void Conectar()
        {
            try
            {
                Conexion.ConnectionString = CadenaConexion;
                Conexion.Open(); 
                
               
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Desconectado" + Ex.ToString());
            }
        }
        /// <summary>
        /// Conexion para MySql Server
        /// </summary>
        /// <returns>Retorna true si se realiza la conexion y false si no.</returns>
        public Boolean conectado() {
            mysqlconexion.ConnectionString = mysqlcadena;
            mysqlconexion.Open();
            if (mysqlconexion.State == ConnectionState.Open)
            return true;

            return false;
        }

        public static void Desconectar()
        {
            Conexion.Close();
        }

        public static int Insertar(string insert)
        {
            int reply = 1;  //reply = Respuesta 
            try
            {
                string Sql = insert;
                SqlCommand cmd = new SqlCommand(Sql, Conexion);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    reply = 0;
                    MessageBox.Show("Registro Insertado Satisfactoriamente");
                }
                else
                {
                    reply = 1;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            return reply;
        } 

        public static DataTable Consultar(string select)
        {
            string sql = select;
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            SqlDataAdapter Adactador = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            try
            {
                Adactador.Fill(tbl);
                if (tbl.Rows.Count == 0)
                {
                    MessageBox.Show("No existen registros con esa condición");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            finally
            {
            }

            return tbl;
        }

        //*** HACER LA MISMA FUNCION QUE EL MOTODO Consultar ANTERIOR LA UNICA DIFERENCIA ES QUE ESTE NO ES STATIC *****//
        //*** PARA PODERLO USAR CUANDO SE INSTANCIE LA CLASE DATOS EN UNA VARIABLE.****************************************//
        public DataTable ConsultarNoEstatic(string select)
        {
            
            string sql = select;
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            SqlDataAdapter Adactador = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            try
            {
                Conectar();
                Adactador.Fill(tbl);
                if (tbl.Rows.Count == 0)
                {
                    MessageBox.Show("No existen registros con esa condición");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            finally
            {
                Desconectar();
            }

            return tbl;
        }


        public static int Modificar(string update)
        {
            int reply = 1;  //reply = Respuesta 
            try
            {
                string Sql = update;
                SqlCommand cmd = new SqlCommand(Sql, Conexion);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    reply = 0;
                    MessageBox.Show("Registro Actualizado Satisfactoriamente");
                }
                else
                {
                    reply = 1;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            return reply;
        }

        public static string OperadorBusqueda(string operador)
        {
            string replay = "";
            try
            {
                if (string.IsNullOrEmpty(operador.Trim()))
                {
                    replay = " LIKE '%'"; 
                }
                else
                    if (operador.Contains("*") == true)
                    {
                       replay = " LIKE '" + operador.Replace("'", "").Replace("*", "%") + "'"; 
                    }
                    else
                        if (operador.Contains("..") == true)
                        {
                           replay = " BETWEEN '" + operador.Replace("..", "' AND '") + "'"; 
                        }
                        else
                            if (operador.Contains("|") == true)
                            {
                                replay = " IN('" + operador.Replace("'", "").Replace("|", "', '") + "')"; 
                            }
                            else
                            {
                                replay = " = '" + operador + "'"; 
                            } 
            }
            catch (Exception Ex)
            { 
                MessageBox.Show(Ex.ToString());
            }
            return replay;
        }


        public static int Insertar(string table, string column, string values)
        {
            int reply = 1;  //reply = Respuesta 
            try
            {
                string Sql = "INSERT INTO " + table + " (" + column + ") VALUES(" + values + ")";
                SqlCommand cmd = new SqlCommand(Sql, Conexion);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    reply = 0;
                    MessageBox.Show("Registro Insertado Satisfactoriamente");
                }
                else
                {
                    reply = 1;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            return reply;
        }
        
        //*********SOBRE CARGA DEL METODO Insertar CON PARAMETRO DE TIPO StringBuilder PARA QUE SOPORTE MAYOR CANTIDAD DE CARACTERES.**********//
        public static int Insertar(StringBuilder Sql)
        {
            int reply = 1;  //reply = Respuesta 
            try
            {

                SqlCommand cmd = new SqlCommand(Sql.ToString(), Conexion);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    reply = 0;
                    MessageBox.Show("Acción ejecutada satisfactoriamente");
                }
                else
                {
                    reply = 1;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            return reply;
        }
        public static DataTable ConsultarArticulo(string tables, string condicion)
        {
            string sql = "SELECT grlcia_codigo,invart_codigo,invart_descrip,invart_exist,invart_separ,invart_fechreg,invfam_codigo from " + tables + " WHERE 1 = 1 " + condicion;
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            SqlDataAdapter Adactador = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            try
            {
                Adactador.Fill(tbl);

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            finally
            {
            }

            return tbl;
        }
        public static int Modificar(string column, string table, string condicion)
        {
            int reply = 1;  //reply = Respuesta 
            try
            {
                string Sql = "UPDATE " + table + " SET " + column + " FROM " + table + " WHERE 1 = 1 " + condicion;
                SqlCommand cmd = new SqlCommand(Sql, Conexion);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    reply = 0;
                    MessageBox.Show("Registro Actualizado Satisfactoriamente");
                }
                else
                {
                    reply = 1;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            return reply;
        }
        public string BucarParametro(string Nomb_Parametro)
        {
            string valor = String.Empty;
            string sql = "SELECT * from cgrlparm WHERE 1 = 1 and grlpar_nombre = '" + Nomb_Parametro + "'";
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            //SqlDataAdapter Adactador = new SqlDataAdapter(cmd);
            SqlDataReader Registro;
            try
            {
                Registro = cmd.ExecuteReader();
                if (Registro.HasRows)
                {
                    if (Registro.Read() == true)
                    //while (Registro.Read() )
                    {
                        valor = Registro.GetString(1);

                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            finally
            {
            }
            return valor;
        }

        //*********BUSCA EL PRIMER VALOR DEL SELECT ENVIADO COMO PARAMETRO. EJEMPLO DE USO: PARA BUSCAR EL TIPO DE PERSONA(F ó J)**********//
        public string BucarValor(string str)
        {
            string valor = String.Empty;
            string sql = str;
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            //SqlDataAdapter Adactador = new SqlDataAdapter(cmd);
            SqlDataReader Registro;
            try
            {
                Conectar();
                Registro = cmd.ExecuteReader();
                if (Registro.HasRows)
                {
                    if (Registro.Read() == true)
                    //while (Registro.Read() )
                    {
                        valor = Registro.GetString(0);

                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            finally
            {
                Desconectar();
            }
            return valor;
        }

        // *** PARA BUSCAR LOS VALORES DE UN COMBOBOX Y DEVOLVERLO EN UNA LISTA  ***  //
        public List<string> BucarCBO(string sql)
        {
            List<string> Lista = new List<string>();
            string valor = String.Empty;
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            //SqlDataAdapter Adactador = new SqlDataAdapter(cmd);
            SqlDataReader Registro;
            try
            {
                Conectar();
                Registro = cmd.ExecuteReader();
                if (Registro.HasRows)
                {
                    if (Registro.Read() == true)
                    //while (Registro.Read() )
                    {
                        Lista.Add("");

                        do

                            Lista.Add(Registro.GetValue(0).ToString() + "-" + Registro.GetValue(1).ToString());
                        while (Registro.Read());
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            finally
            {
                Desconectar();
            }
            return Lista;
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< LOOKUP >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  
        public static DataView Lookup(string select)
        {
            DataView DatView = new DataView();
            try
            {
                string Sql = select;
                SqlDataAdapter Adaptador = new SqlDataAdapter(Sql, Conexion);
                DataSet DatSet = new DataSet();
                Adaptador.Fill(DatSet);
                DatView.Table = DatSet.Tables[0];
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            return DatView;
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< HABILITAR LOOLUPS DENTRO DE UN TabPage >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
        public static void HabilitarLookupTabPage(TabPage TabP)
        {
            foreach (var Look in TabP.Controls)
            {
                if (Look is Button)
                {
                    ((Button)Look).Enabled = true; ;

                }
            }
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DESHABILITAR LOOLUPS DENTRO DE UN TabPage >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
        public static void DeshabilitarLookupTabPage(TabPage TabP)
        {
            foreach (var Look in TabP.Controls)
            {
                if (Look is Button)
                {
                    ((Button)Look).Enabled = false; ; ;

                }
            }
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DESHABILITAR TEXTBOX DENTRO DE UN TabPage >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
        public static void DeshabilitarTexboxTabPage(TabPage TabP)
        {
            foreach (var Look in TabP.Controls)
            {
                if (Look is TextBox)
                {
                    ((TextBox)Look).Enabled = false; ; ;

                }
            }
        }
        public static void DeshabilitarButtomTabPage(TabPage TabP,bool EDB)
        {
            foreach (var Look in TabP.Controls)
            {
                if (Look is Button)
                {
                    ((Button)Look).Enabled = EDB; 

                }
            }
        }
        public static void LimpiaControlTabPage(TabPage TabP)
        {
            foreach (var Look in TabP.Controls)
            {
                if (Look is TextBox)
                {
                    ((TextBox)Look).Clear();

                }
                if (Look is ComboBox)
                {
                    ((ComboBox)Look).Text = "";

                }
                if (Look is DataGridView)
                {
                    ((DataGridView)Look).Refresh();

                }
            }
        }
        public static void DesconectaControlTabPage(TabPage TabP)
        {
            foreach (var Look in TabP.Controls)
            {
                if (Look is TextBox)
                {
                    ((TextBox)Look).DataBindings.Clear();

                }
                if (Look is ComboBox)
                {
                    ((ComboBox)Look).DataBindings.Clear();

                }
                if (Look is DataGridView)
                {
                    ((DataGridView)Look).DataSource = null;

                }
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< LIMPIAR CAMPOS EN FORMULARIO >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
        //Datos.LimpiarCamposFormulario(this);
        public static void LimpiarCamposFormulario(Control control)
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
                else if (txt is ComboBox)
                {
                    ((ComboBox)txt).SelectedIndex = 0;
                }
            }
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< LIMPIAR CAMPOS DENTRO DE UN GROUPBOX >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
        public static void LimpiarCamposGroupBox(GroupBox cbo)
        {
            foreach (var GropB in cbo.Controls)
            {
                if (GropB is TextBox)
                {
                    ((TextBox)GropB).Clear();
                }
                else if (GropB is ComboBox)
                {
                    ((ComboBox)GropB).SelectedIndex = 0;
                }
            }
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< LIMPIAR CAMPOS DENTRO DE UN TabPage >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
        //Datos.LimpiarCamposTabPage(TabDatos);
        public static void LimpiarCamposTabPage(TabPage TabP)
        {
            foreach (var Tab in TabP.Controls)
            {
                if (Tab is TextBox)
                {
                    ((TextBox)Tab).Clear();
                }
                else if (Tab is ComboBox)
                {
                    ((ComboBox)Tab).SelectedIndex = 0;
                }
            }
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< LIMPIAR RADIO BUTTON DENTRO DE UN GroupBok >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
        //Datos.LimpiarCamposTabPage(TabDatos);
        public static void LimpiarRadioButtonGroupBok(GroupBox GrgBok)
        {
            foreach (var Grb in GrgBok.Controls)
            {
                if (Grb is RadioButton)
                {
                    ((RadioButton)Grb).Checked = false;
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< PARA QUE EL TEXTBOX SOLO ACEPTE LETRAS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
        //EN EL EVENTO KeyPress DEL TEXTBOX LLAMAMOS EL METODO Y COMO PARAMETRO LE PASAMOS LA VARIABLE QUE LE SIGUE A KeyPressEventArgs e Ej: Datos.SoloLetras(e);
        public static void SoloLetras(KeyPressEventArgs Letra)
        {
            try
            {
                if (Char.IsLetter(Letra.KeyChar))
                {
                    Letra.Handled = false;
                }
                else if (Char.IsSeparator(Letra.KeyChar))
                {
                    Letra.Handled = false;
                }
                else if (Char.IsControl(Letra.KeyChar))
                {
                    Letra.Handled = false;
                }
                else
                {
                    Letra.Handled = true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< PARA QUE EL TEXTBOX SOLO ACEPTE NUMEROS ENTEROS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
        public static void SoloNumEnteros(KeyPressEventArgs Num)
        {
            try
            {
                if (Char.IsDigit(Num.KeyChar))
                {
                    Num.Handled = false;
                }
                else if (Char.IsControl(Num.KeyChar))
                {
                    Num.Handled = false;
                }
                else
                {
                    Num.Handled = true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }
        public static void SoloNumDecimal(KeyPressEventArgs Num)
        {
            try
            {
                if (Char.IsDigit(Num.KeyChar))
                {
                    Num.Handled = false;
                }
                else if (Char.IsControl(Num.KeyChar))
                {
                    Num.Handled = false;
                }
                else if (Num.KeyChar.ToString().Equals("."))
                {
                    Num.Handled = false;
                }
                else
                {
                    Num.Handled = true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }
        public static string BucarParametro(string Parametro, string Modulo, string Sucursal, string Alm_Bco)
        {
            string tipo = String.Empty;
            string valor = String.Empty;
            string sql = "SELECT grlpar_tipo      " +
                         "  FROM cgrlparm         " +
                         " WHERE grlpar_codigo = '" + Parametro + "'" +
                         "   AND grlmod_codigo = '" + Modulo + "'";
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            SqlDataReader Registro;
            try
            {
                Registro = cmd.ExecuteReader();
                if (Registro.HasRows)
                {
                    if (Registro.Read() == true)
                    {
                        tipo = Registro.GetValue(0).ToString();
                        if (tipo == "1")                            //SI EL TIPO DE PARAMETRO ES GENERAL
                        {
                            Registro.Close();
                            sql = "SELECT grlpar_valor     " +
                                  "  FROM cgrlpard         " +
                                  " WHERE grlpar_codigo = '" + Parametro + "'" +
                                  "   AND grlmod_codigo = '" + Modulo + "'";
                            cmd = new SqlCommand(sql, Conexion);
                            SqlDataReader Reg;
                            try
                            {
                                Reg = cmd.ExecuteReader();
                                if (Reg.Read() == true)
                                {
                                    valor = Reg.GetString(0);
                                }
                                else
                                {
                                    MessageBox.Show("No existe valor para el Parametro: " + Parametro + " Modulo: " + Modulo);
                                }
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.ToString());
                            }
                        }
                        else if (tipo == "2")                      //SI EL TIPO DE PARAMETRO ES POR SUCURSAL
                        {
                            Registro.Close();
                            sql = "SELECT grlpar_valor     " +
                                  "  FROM cgrlpard         " +
                                  " WHERE grlpar_codigo = '" + Parametro + "'" +
                                  "   AND grlmod_codigo = '" + Modulo + "'" +
                                  "   AND admsuc_codigo = '" + Sucursal + "'";
                            cmd = new SqlCommand(sql, Conexion);
                            SqlDataReader Reg;
                            try
                            {
                                Reg = cmd.ExecuteReader();
                                if (Reg.Read() == true)
                                {
                                    valor = Reg.GetString(0);
                                }
                                else
                                {
                                    MessageBox.Show("No existe valor para el Parametro: " + Parametro + " Modulo: " + Modulo + "Sucursal: " + Sucursal);
                                }
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.ToString());
                            }
                        }
                        else if (tipo == "3" && Modulo == "INV")        //SI EL TIPO DE PARAMETRO ES POR ALMACEN  
                        {
                            Registro.Close();
                            sql = "SELECT grlpar_valor     " +
                                  "  FROM cgrlpard         " +
                                  " WHERE grlpar_codigo = '" + Parametro + "'" +
                                  "   AND grlmod_codigo = '" + Modulo + "'" +
                                  "   AND invalm_codigo = '" + Alm_Bco + "'";
                            cmd = new SqlCommand(sql, Conexion);
                            SqlDataReader Reg;
                            try
                            {
                                Reg = cmd.ExecuteReader();
                                if (Reg.Read() == true)
                                {
                                    valor = Reg.GetString(0);
                                }
                                else
                                {
                                    MessageBox.Show("No existe valor para el Parametro: " + Parametro + " Modulo: " + Modulo + "Almacén: " + Alm_Bco);
                                }
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.ToString());
                            }
                        }
                        else if (tipo == "3" && Modulo == "EFT")              //SI EL TIPO DE PARAMETRO ES POR CUENTA BANCARIA  
                        {
                            Registro.Close();
                            sql = "SELECT grlpar_valor     " +
                                  "  FROM cgrlpard         " +
                                  " WHERE grlpar_codigo = '" + Parametro + "'" +
                                  "   AND grlmod_codigo = '" + Modulo + "'" +
                                  "   AND eftbco_codigo = '" + Alm_Bco + "'";
                            cmd = new SqlCommand(sql, Conexion);
                            SqlDataReader Reg;
                            try
                            {
                                Reg = cmd.ExecuteReader();
                                if (Reg.Read() == true)
                                {
                                    valor = Reg.GetString(0);
                                }
                                else
                                {
                                    MessageBox.Show("No existe valor para el Parametro: " + Parametro + " Modulo: " + Modulo + "Cuenta Bancaria: " + Alm_Bco);
                                }
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.ToString());
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("El Parametro: " + Parametro + " Modulo: " + Modulo + " no existe");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            finally
            {
            }
            return valor;
        }
        //************** Método o función para validar una cédula dominicana*******************//
        public static bool ValidaCedula(string cedula)
           {
               //Declaración de variables a nivel de método o función.
                int verificador = 0;
                int digito = 0;
              int digitoVerificador=0;
               int digitoImpar = 0;
                int sumaPar = 0;
                int sumaImpar = 0;
               int longitud = Convert.ToInt32(cedula.Length);
               /*Control de errores en el código*/
               try
               {
                   //verificamos que la longitud del parametro sea igual a 11
                   if (longitud == 11)
                  {
                   digitoVerificador = Convert.ToInt32(cedula.Substring(10, 1));
                     //recorremos en un ciclo for cada dígito de la cédula
                     for (int i = 9; i >= 0; i--)
                      {
                          //si el digito no es par multiplicamos por 2
                          digito = Convert.ToInt32(cedula.Substring(i, 1));
                         if ((i % 2) != 0)
                          {
                              digitoImpar = digito * 2;
                              //si el digito obtenido es mayor a 10, restamos 9
                              if (digitoImpar >= 10)
                              {
                                  digitoImpar = digitoImpar - 9;
                              }
                              sumaImpar = sumaImpar + digitoImpar;
                          }
                          /*En los demás casos sumamos el dígito y lo aculamos 
                           en la variable */
                          else
                           {
                               sumaPar = sumaPar + digito;
                          }
                       }
                     /*Obtenemos el verificador restandole a 10 el modulo 10 
                     de la suma total de los dígitos*/
                      verificador = 10 - ((sumaPar + sumaImpar) % 10);
                   /*si el verificador es igual a 10 y el dígito verificador
                     es igual a cero o el verificador y el dígito verificador 
                      son iguales retorna verdadero*/
                 if (((verificador == 10) && (digitoVerificador == 0))
                     || (verificador == digitoVerificador))
                     {
                           return true;
                      }
                 }
                  else
                 {
                 
                 }
              }
            catch
             {
                 MessageBox.Show("Cédula invalidar.");
             }
             return false;
         }
        
        public static DataTable MakeNamesTable()
        {
            // Create a new DataTable titled 'Names.'
            DataTable namesTable = new DataTable("TblTel");

            // Add three column objects to the table.
            DataColumn grlent_ID = new DataColumn();
            grlent_ID.DataType = System.Type.GetType("System.Int32");
            grlent_ID.ColumnName = "grlent_ID";
            //grlent_ID.AutoIncrement = true;
            namesTable.Columns.Add(grlent_ID);

            DataColumn grltipt_codigo = new DataColumn();
            grltipt_codigo.DataType = System.Type.GetType("System.String");
            grltipt_codigo.ColumnName = "grltipt_codigo";
            grltipt_codigo.DefaultValue = string.Empty;
            namesTable.Columns.Add(grltipt_codigo);

            DataColumn grltel_area = new DataColumn();
            grltel_area.DataType = System.Type.GetType("System.String");
            grltel_area.ColumnName = "grltel_area";
            namesTable.Columns.Add(grltel_area);

            DataColumn grltel_numero = new DataColumn();
            grltel_numero.DataType = System.Type.GetType("System.String");
            grltel_numero.ColumnName = "grltel_numero";
            namesTable.Columns.Add(grltel_numero);

            DataColumn grltel_ext = new DataColumn();
            grltel_ext.DataType = System.Type.GetType("System.String");
            grltel_ext.ColumnName = "grltel_ext";
            namesTable.Columns.Add(grltel_ext);

            DataColumn grluso_codigo = new DataColumn();
            grluso_codigo.DataType = System.Type.GetType("System.String");
            grluso_codigo.ColumnName = "grluso_codigo";
            namesTable.Columns.Add(grluso_codigo);

            DataColumn grlpai_codigo = new DataColumn();
            grlpai_codigo.DataType = System.Type.GetType("System.Int32");
            grlpai_codigo.ColumnName = "grlpai_codigo";
            namesTable.Columns.Add(grlpai_codigo);

            // Create an array for DataColumn objects.
            DataColumn[] keys = new DataColumn[1];
            keys[0] = grlent_ID;
            namesTable.PrimaryKey = keys;

            // Return the new DataTable.
            return namesTable;
        }
        
        //Crear una tabla uso atual
        public static DataTable MakeNamesTable(string query)
        {
            DataTable namesTable = new DataTable();
            SqlCommand cmd = new SqlCommand(query, Conexion);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            adt.Fill(namesTable);
            return namesTable;
        }

        public static void UpdateTelTable(int grlent_ID,DataTable namesTable)
        {
            SqlCommand cmdInsertUpdate = new SqlCommand();
            SqlCommand cmdvalidar = new SqlCommand();
            SqlDataReader reader;
            cmdInsertUpdate.Connection = Conexion;
            cmdvalidar.Connection = Conexion;

           for (int i = 0; i < namesTable.Rows.Count; i++)
            {
                try
                {
                    Conectar();
                    DataRow row = namesTable.Rows[i];
                    cmdvalidar.CommandText = "Select 1 from cgrlteld where grltel_area = '" + row["grltel_area"] + "' and " + "grltel_numero = '" + row["grltel_numero"] + "'";
                    reader = cmdvalidar.ExecuteReader();
                    if (!reader.HasRows)
                    {

                        reader.Close();
                        cmdInsertUpdate.CommandText = "Insert into cgrlteld(grlent_ID, grltipt_codigo, grltel_area, grltel_numero, grltel_ext, grluso_codigo, grlpai_codigo)" +
                                               "values(" + row["grlent_ID"] + ",'" + row["grltipt_codigo"].ToString().Substring(0, 3) + "','" + row["grltel_area"] + "','" + row["grltel_numero"] + "','" + row["grltel_ext"] + "','" + row["grluso_codigo"].ToString().Substring(0, 3) + "'," + row["grlpai_codigo"] + ")";
                        if (cmdInsertUpdate.ExecuteNonQuery() > 0)
                        {
                        }
                    }
                   

                }
               catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
               }
               finally
                {
                    Desconectar();
                }
            }
            
        }
        public static void UpdateDirTable(int grlent_ID, DataTable namesTable)
        {
            SqlCommand cmdInsertUpdate = new SqlCommand();
            SqlCommand cmdvalidar = new SqlCommand();
            SqlDataReader reader;
            cmdInsertUpdate.Connection = Conexion;
            cmdvalidar.Connection = Conexion;

            for (int i = 0; i < namesTable.Rows.Count; i++)
            {
                try
                {
                    Conectar();
                    DataRow row = namesTable.Rows[i];
                    cmdvalidar.CommandText = "Select 1 from cgrldird where grlent_ID = " + row["grlent_ID"] + " and " + "grlpai_codigo = " + row["grlpai_codigo"] + " and grlcui_codigo = " + row["grlcui_codigo"] + "";
                    reader = cmdvalidar.ExecuteReader();
                    if (!reader.HasRows)
                    {

                        reader.Close();
                        cmdInsertUpdate.CommandText = "insert into cgrldird (grlent_ID,grluso_codigo,grlpai_codigo,grlprv_codigo,grlcui_codigo,grlset_codigo,grldir_calle,grldir_numero,grldir_edificio)" +
                                               "values(" + row["grlent_ID"] + ",'" + row["grluso_codigo"].ToString().Substring(0, 3) + "'," + row["grlpai_codigo"] + "," + row["grlprv_codigo"] + "," + row["grlcui_codigo"] + "," + row["grlset_codigo"] + ",'" + row["grldir_calle"] + "'," + row["grldir_numero"] + ",'" + row["grldir_edificio"] + "')";
                        if (cmdInsertUpdate.ExecuteNonQuery() > 0)
                        {
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    Desconectar();
                }
            }

        }
        public static void UpdateConTable(int grlent_ID, DataTable namesTable)
        {
            SqlCommand cmdInsertUpdate = new SqlCommand();
            SqlCommand cmdvalidar = new SqlCommand();
            SqlDataReader reader;
            cmdInsertUpdate.Connection = Conexion;
            cmdvalidar.Connection = Conexion;

            for (int i = 0; i < namesTable.Rows.Count; i++)
            {
                try
                {
                    Conectar();
                    DataRow row = namesTable.Rows[i];
                    cmdvalidar.CommandText = "Select 1 from cgrlcond where grlent_ID = " + row["grlent_ID"] + " and " + "grlcon_id = " + row["grlcon_id"] ;
                    reader = cmdvalidar.ExecuteReader();
                    if (!reader.HasRows)
                    {

                        reader.Close();
                        cmdInsertUpdate.CommandText = "insert into cgrlcond (grlent_ID,grlcon_id,grlcon_parentesco) " +
                                               "values(" + row["grlent_ID"] + "," + row["grlcon_id"] + ",'" + row["grlcon_parentesco"] + "')";
                        if (cmdInsertUpdate.ExecuteNonQuery() > 0)
                        {
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    Desconectar();
                }
            }

        }
    }
}

