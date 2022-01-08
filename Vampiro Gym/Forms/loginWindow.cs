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
        private bool passwordRecuperado;

        private const int CAMPOSAOBTENER = 2;
        private const string TABLA = "Usuarios";

        private string resultadoConsulta;
        private string query;
        private string[] datos;

        public static string tipoUsuario;
        private string password;
        public static bool inicializandoSistema;
        public static bool inicializado;

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
                    this.resultadoConsulta = consult.Select(query,CAMPOSAOBTENER);
                }
                catch(Exception err)
                {
                    MessageBox.Show("Se ha presentado el siguiente error al consultar la base de datos: " + err.Message);
                }
                if (!resultadoConsulta.Contains("La consulta no genero resultados"))
                {
                    datos = resultadoConsulta.Split(',');
                    tipoUsuario = datos[0];
                    usuario = userBox.Text;
                    this.password = datos[1];
                    if (this.password == passwordBox.Text)
                    {
                        if (passwordRecuperado)
                        {
                            ChangePassordWindow changePassword = new ChangePassordWindow(userBox.Text, passwordBox.Text);
                            changePassword.ShowDialog();
                        }
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

        private void loginWindow_Load(object sender, EventArgs e)
        {
            while (!inicializado)
            {
                ConsultaBaseInicializada();
                if (this.resultadoConsulta.Contains("La consulta no genero resultados"))
                {
                    MessageBox.Show("Inicializando sistema por primera vez, es necesario crear un usuario tipo administrador", "Inicializando sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    usuarioRegistroForm registroUsuario = new usuarioRegistroForm("alta","","","","","","","");
                    inicializandoSistema = true;
                    registroUsuario.ShowDialog();
                }
                else
                {
                    inicializado = true;
                }
            }
            this.ActiveControl = button1;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString()=="Tab" || keyData.ToString() == "TAB")
            {
                switch(ActiveControl.Name)
                {
                    case "button1":
                        userBox.Focus();
                        break;
                    case "userBox":
                        passwordBox.Focus();
                        break;
                    default:
                        userBox.Focus();
                        break;
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ConsultaBaseInicializada()
        {
            this.query = "SELECT Usuario FROM Usuarios";
            dataBaseControl verificaUsuarios = new dataBaseControl();
            this.resultadoConsulta = verificaUsuarios.Select(query, 1);
        }

        private void userBox_Enter(object sender, EventArgs e)
        {
            if (userBox.Text.Contains("Ingrese"))
            {
                userBox.Text = "";
            }
        }

        private void passwordBox_Enter(object sender, EventArgs e)
        {
            if (passwordBox.Text.Contains("Ingrese"))
            {
                passwordBox.Text = "";
            }
            passwordBox.UseSystemPasswordChar = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (userBox.Text!="" && !userBox.Text.Contains("Ingrese Usuario"))
            {
                string query = "SELECT Nombre,Apellido,Correo,Contrasena FROM Usuarios WHERE Usuario ='" + userBox.Text + "'";
                dataBaseControl customerTableConsult = new dataBaseControl();
                string resQuery = customerTableConsult.Select(query, 4);
                string[] datos = resQuery.Split(',');
                string name = "";
                string lastName = "";
                string email = "";
                string password = "";
                foreach(string dato in datos)
                {
                    if(dato!="")
                    {
                        if (!dato.Contains("La consulta"))
                        {
                            if (name=="")
                            {
                                name = dato;
                                continue;
                            }

                            if(lastName == "")
                            {
                                lastName = dato;
                                continue;
                            }

                            if(email == "")
                            {
                                email = dato;
                                continue;
                            }

                            if(password == "")
                            {
                                password = dato;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No existe información para el usuario ingresado verifiquelo e intentelo nuevamente", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                var mailService = new SystemSupportMail();
                mailService.sendMail(
                    subject: "SISTEMA: Solicitud de recuperación de password",
                    body: "Hola " + name + " " + lastName + "\n Este es un correo en respuesta a la solicitud de password del sistema de accesos Vampiro Gym.\n" +
                    "A continuación encontraras la información de tu cuenta: \n" +
                    "Tu actual constraseña es: " + password +
                    "\n De cualquier manera, te solicitamos cambies tu password inmediatamente entres al sistema",
                    recipientMail: new List<string> { email }
                    );
                MessageBox.Show("Hola " + name + "\n Tu solicitud de recuperación de password ha sido atendida exitosamente" +
                    "\n Por favor revisa tu correo " + email +" en caso de no encontrarlo en la bandeja de entrada revisa la bandeja de SPAM" + 
                    "\n De cualquier manera te solicitamos realices el cambio de tu password una vez entres al sistema", "Contraseña recuperada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                passwordRecuperado = true;
            }
            else
            {
                MessageBox.Show("Es necesario introducir el nombre de usuario para la recuperación del password", "Usuario no intruducido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
