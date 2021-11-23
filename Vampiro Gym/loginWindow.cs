using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    public partial class loginWindow : Form
    {
        formMain main = new formMain();

        public static string date;
        public static string usuario;
        public loginWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBaseControl consult = new dataBaseControl();
            string[] datos = { "Tipo_de_usuario", "Password" };
            consult.consulta(datos);
            /*if (userBox.Text == "Admin" && passwordBox.Text == "default")
            {
                date = DateTime.Now.ToString("hh:mm tt");
                usuario = userBox.Text;
                main.Show();
                this.Close();
            }*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
