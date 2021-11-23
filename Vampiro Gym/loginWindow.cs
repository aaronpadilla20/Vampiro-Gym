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
        private string[] campos;
        private string resultadoConsulta;
        private string[] datos;

        public static string tipoUsuario;
        private static string password; 

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
                    this.campos = new string[] { "Tipo_de_usuario", "Contrasena" };
                    this.resultadoConsulta = consult.consulta(this.campos, "Usuarios", "Usuario", userBox.Text, false);
                }
                catch(Exception err)
                {
                    MessageBox.Show("Se ha presentado el siguiente error al consultar la base de datos: " + err.Message);
                }
                if (!resultadoConsulta.Contains("No existe el usuario favor de verificarlo"))
                {
                    datos = resultadoConsulta.Split(',');
                    tipoUsuario = datos[0];
                    password = datos[1];
                    if (password == passwordBox.Text)
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
