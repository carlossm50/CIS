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
    public partial class frmContactoClient : Form
    {
        public DataView DatView = new DataView();
        public DataGridViewRow Filas = new DataGridViewRow();
        public string Description;
        public string Code;
        public string CondCodProvincia;
        public string CondNomProvincia;
        public string CondCodCiudad;
        public string CondNomCiudad;
        public string CondCodSetor;
        public string CondNomSetor;
        public int LookupOk;  //PARA SABER SI SE ELIGIO ALGUN DATO EN EL LOOKUP    
        public string ID = "";
        public frmContactoClient()
        {
            InitializeComponent();
        }

        private void dtgContacto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Filas = dtgContacto.CurrentRow;
            DataRow row = DatView.Table.Rows[dtgContacto.CurrentRow.Index];
            Code = row[0].ToString(); //Filas.Cells[0].Value.ToString();
            Description = row[1].ToString();//Filas.Cells[1].Value.ToString();
            CondCodProvincia = row[8].ToString();
            CondNomProvincia = row[9].ToString();
            CondCodCiudad = row[10].ToString();
            CondNomCiudad = row[11].ToString();
            CondCodSetor = row[12].ToString();
            CondNomSetor = row[13].ToString();
            LookupOk = 1;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DataRow row = DatView.Table.Rows[dtgContacto.CurrentRow.Index];
            Code = row[0].ToString(); //Filas.Cells[0].Value.ToString();
            Description = row[1].ToString();//Filas.Cells[1].Value.ToString();
            CondCodProvincia = row[8].ToString();
            CondNomProvincia = row[9].ToString();
            CondCodCiudad = row[10].ToString();
            CondNomCiudad = row[11].ToString();
            CondCodSetor = row[12].ToString();
            CondNomSetor = row[13].ToString();
            LookupOk = 1;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmContactoClient_Load(object sender, EventArgs e)
        {
            Datos.Conectar();
            //DatView = Datos.Lookup("select grlent_ID Codigo, grlent_nombre + ' '+ grlent_apellido  as Nombre from cgrlentm  order by grlent_ID");
            DatView = Datos.Lookup("select "+
                                    "        cgrlentm.grlent_ID Codigo,"+
                                    "        cgrlentm.grlent_nombre+' '+cgrlentm.grlent_apellido Nombre,"+
                                    "        cgrldird.grluso_codigo,"+
                                    "        cgrldird.grldir_numero,"+
                                    "        cgrldird.grldir_calle,"+
                                    "        cgrldird.grldir_edificio,"+
                                    "        cgrldird.grlpai_codigo,"+
                                    "        cgrlpaim.grlpai_nombre,"+
                                    "        cgrlprvm.grlprv_codigo,"+
                                    "        cgrlprvm.grlprv_nombre,"+
                                    "        cgrlcium.grlcui_codigo,"+
                                    "        cgrlcium.grlcui_nombre,"+
                                    "        cgrlsetm.grlset_codigo,"+
                                    "        cgrlsetm.grlset_nombre"+
		
                                    "    from cgrlentm	  "+
                                    "    inner join cgrldird on cgrldird.grlent_ID = cgrlentm.grlent_ID "+
                                    "    inner join cgrlpaim on cgrldird.grlpai_codigo =  cgrlpaim.grlpai_codigo "+
                                    "    inner join cgrlusom on cgrlusom.grluso_codigo = cgrldird.grluso_codigo "+
                                    "    left join  cgrlprvm on cgrlprvm.grlpai_codigo = cgrlpaim.grlpai_codigo and cgrlprvm.grlprv_codigo = cgrldird.grlprv_codigo "+
                                    "    left join  cgrlcium on cgrlcium.grlprv_codigo = cgrlprvm.grlprv_codigo and cgrlcium.grlcui_codigo = cgrldird.grlcui_codigo "+
                                    "    left join  cgrlsetm on cgrlsetm.grlciu_codigo = cgrlcium.grlcui_codigo and cgrlsetm.grlset_codigo = cgrldird.grlset_codigo "+
                                    "    where cgrldird.grluso_codigo = 'RES' and cgrlentm.grlent_ID <> "+ID);
            dtgContacto.DataSource = DatView;
            Datos.Desconectar();
            LookupOk = 0;
        }
    }
}
