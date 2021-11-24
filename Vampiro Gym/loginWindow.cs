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

        private const int CAMPOSAOBTENER = 2;
        private const string TABLA = "Usuarios";

        private string resultadoConsulta;
        private string query;
        private string[] datos;

        public static string tipoUsuario;
        private string password; 

        public loginWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userBox.Text != "" && passwordBox.Text != "")
            {
                try
                {
                    dataBaseControl consult = new dataBaseControl();
                    this.query = "SELECT Tipo_de_usuario,Contrasena FROM " + TABLA + " WHERE Usuario='" + userBox.Text + "'";
                    this.resultadoConsulta = consult.Select(query, TABLA,CAMPOSAOBTENER);
                }
                catch(Exception err)
                {
                    MessageBox.Show("Se ha presentado el siguiente error al consultar la base de datos: " + err.Message);
                }
                if (!resultadoConsulta.Contains("No existe el usuario favor de verificarlo"))
                {
                    datos = resultadoConsulta.Split(',');
                    tipoUsuario = datos[0];
                    this.password = datos[1];
                    if (this.password == passwordBox.Text)
                    {
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El password ingresado no es correcto verifiquelo e intentelo nuevamente", "Password incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        userBox.Text = "";
                        passwordBox.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("El usuario ingresado no existe, verifiquelo e intentelo nuevamente", "Usuario Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    userBox.Text = "";
                    passwordBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("No ha ingresado Usuario y/o password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
