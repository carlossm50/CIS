using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Contabilidad.Properties;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using Contabilidad.controler;

namespace Contabilidad
{
    public partial class CNTMenu : Form
    {
        
        public CNTMenu()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void Releasecapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd,int wmsg, int wparam,int lparam);

        

        public static string coneccion() {
            return Settings.Default.cntstting;
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();                        
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox4.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBox4.Visible = true;
            pictureBox3.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Releasecapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void CNTMenu_Load(object sender, EventArgs e)
        {
            
            //ctrlcntcta jo = new ctrlcntcta();
            //if (jo.insert()) MessageBox.Show("Conectado");
             
        }
    }
}
