using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    public partial class usuarioRegistroForm : Form
    {
        private bool emailValido;
        private string usuario;
        private string query;
        private string resultadoConsulta1;
        private string resultadoConsulta2;
        private string resultadoConsulta3;
        private string[] datos;
        private string lastSimilarUser;
        private string num;
        private int newNum;
        private bool insertado;

        private const string TABLA = "Usuarios";
        private const int CAMPOSAOBTENER = 1;

        Utilities utilidades = new Utilities();
        Match m;

        public usuarioRegistroForm()
        {
            InitializeComponent();
        }

        private void botonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void tipoUsuarioCombo_DrawItem(object sender, DrawItemEventArgs e)
        {
            Utilities drawBox = new Utilities();
            drawBox.comboBoxDrawing(sender, e);
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            if (confirmePasswordBox.Text.Contains("Confirme"))
            {
                confirmePasswordBox.Text = "";
                confirmePasswordBox.UseSystemPasswordChar = true;
            }
        }

        private void validarFormularioButton_Click(object sender, EventArgs e)
        {
            dataBaseControl consult = new dataBaseControl();
            if ((!nombreBox.Text.Contains("Ingrese nombre completo") && nombreBox.Text!="") || (apellidoTextBox.Text != "Ingrese apellido:" && apellidoTextBox.Text != ""))
            {
                if (!emailBox.Text.Contains("Ingrese correo de usuario") && emailBox.Text != "")
                {
                    emailValido = utilidades.validaEmail(emailBox.Text);
                    if (emailValido)
                    {
                        if (!passwordBox.Text.Contains("Ingrese Password") && passwordBox.Text != "")
                        {
                            if (!confirmePasswordBox.Text.Contains("Confirme Password") && confirmePasswordBox.Text != "" && passwordBox.Text == confirmePasswordBox.Text)
                            {
                                DialogResult res = MessageBox.Show("Se creara un usuario con los siguientes datos:\n" +
                                    "Tipo de usuario: " + tipoUsuarioCombo.Text + "\n" +
                                    "Nombre: " + nombreBox.Text + "\n" + 
                                    "Apellido: " + apellidoTextBox.Text + "\n" +
                                    "Correo: " + emailBox.Text + "\n" +
                                    "Password: " + passwordBox.Text + "\n" +
                                    "¿Esta seguro de crear el usuario con los datos anteriormente especificados?","Confirmacion",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                                if (res == DialogResult.Yes)
                                {
                                    datos = new string[] { };
                                    try
                                    {
                                        consult = new dataBaseControl();
                                        usuario = nombreBox.Text.Substring(0, 2).ToLower() + apellidoTextBox.Text.Substring(0, 4).ToLower();
                                        this.query = "SELECT Usuario FROM " + TABLA + " WHERE Usuario LIKE '" + usuario + "%'";
                                        this.resultadoConsulta1 = consult.Select(query, TABLA, 1);
                                        if (!resultadoConsulta1.Contains("No existe el usuario favor de verificarlo")) //Si el usuario existe
                                        {
                                            this.resultadoConsulta1 = this.resultadoConsulta1.TrimEnd(',');
                                            datos = resultadoConsulta1.Split(',');
                                            foreach (string dato in datos)
                                            {
                                                this.lastSimilarUser = dato;
                                            }
                                            this.query = "SELECT Nombre,Apellido FROM " + TABLA + " WHERE (Nombre='" + nombreBox.Text + "') AND (Apellido='" + apellidoTextBox.Text + "')"; //Consulta de nombre y apellido
                                            this.resultadoConsulta2 = consult.Select(query, TABLA, 2); // Realizamos consulta
                                            if (resultadoConsulta2.Contains("No existe el usuario favor de verificarlo")) // Si el usuario no existe
                                            {
                                                this.m = Regex.Match(this.lastSimilarUser, "(\\d)"); //Verificamos si el usario ya tiene un numero
                                                num = string.Empty; //Inicializamos variable donde capturaremos numero
                                                if (m.Success) //Si el usuario ya tiene un numero
                                                {
                                                    num = m.Value; //Obtenemos el numero
                                                    newNum = Int32.Parse(num); //Lo convertimos a int
                                                    newNum++; //Incrementamos su valor en 1
                                                    usuario += newNum.ToString(); //Cocatenamos el numero al usuario
                                                }
                                                else
                                                {
                                                    usuario += "1";
                                                }
                                                this.query = "SELECT Correo FROM " + TABLA + " WHERE Correo='" + emailBox.Text + "'";
                                                this.resultadoConsulta3 = consult.Select(query, TABLA, 1);
                                                if (resultadoConsulta3.Contains("No existe el usuario favor de verificarlo"))
                                                {
                                                    RegistraUsuario();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Imposible crear el usuario debido a que el correo especificado ya esta dado de alta con otro usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("El usuario ya se encuentra registrado no se puede duplicar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                clearWindow();
                                            }
                                        }
                                        else
                                        {
                                            RegistraUsuario();
                                        }
                                    }
                                    catch (Exception er)
                                    {
                                        MessageBox.Show("Ha ocurrido el siguiente error al crear el usuario" + er.ToString());
                                    }
                                }
                                else
                                {
                                    clearWindow();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No coinciden los password compruebelo e intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Es necesario especificar un password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El email ingresado no es valido, ingrese uno valido e intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario ingresar un correo de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No ha especificado nombre de usuario y/o apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistraUsuario()
        {
            this.query = "INSERT INTO " + TABLA + " (Tipo_de_usuario,Nombre,Apellido,Correo,Contrasena,Usuario) VALUES ('" + tipoUsuarioCombo.Text + "','" + nombreBox.Text + "','" + apellidoTextBox.Text + "','" + emailBox.Text + "','" + passwordBox.Text + "','" + usuario + "')";
            dataBaseControl insert = new dataBaseControl();
            this.insertado = insert.Insert(query);
            MessageBox.Show("Se ha creado el usuario " + usuario + " exisosamente", "Usuario creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearWindow();
        }

        private void clearWindow()
        {
            tipoUsuarioCombo.SelectedIndex = 0;
            nombreBox.Text = "Ingrese Nombre:";
            apellidoTextBox.Text = "Ingrese apellido:";
            emailBox.Text = "Ingrese correo de usuario";
            passwordBox.Text = "Ingrese Password";
            passwordBox.UseSystemPasswordChar = false;
            confirmePasswordBox.Text = "Confirme Password";
            confirmePasswordBox.UseSystemPasswordChar = false;
            tipoUsuarioCombo.Focus();
        }

        private void emailBox_Enter(object sender, EventArgs e)
        {
            if (emailBox.Text.Contains("Ingrese correo de usuario"))
                emailBox.Text = "";
        }

        private void passwordBox_Enter(object sender, EventArgs e)
        {
            if (passwordBox.Text.Contains("Ingrese"))
            {
                passwordBox.Text = "";
                passwordBox.UseSystemPasswordChar = true;
            }


        }

        private void nombreUsuarioText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void nombreBox_Enter(object sender, EventArgs e)
        {
            if (nombreBox.Text == "Ingrese Nombre:")
                nombreBox.Text = "";
        }

        private void apellidoTextBox_Enter(object sender, EventArgs e)
        {
            if (apellidoTextBox.Text == "Ingrese apellido:")
                apellidoTextBox.Text = "";
        }

        private void validarFormularioButton_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(validarFormularioButton, "Alta Usuario");
        }

        private void editButton_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(editButton, "Modificar Usuario");
        }

        private void deleteUserButton_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(deleteUserButton, "Eliminar usuario");
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            edicionUsuario editWindow = new edicionUsuario();
            editWindow.ShowDialog();
        }

        private void usuarioRegistroForm_Load(object sender, EventArgs e)
        {
            tipoUsuarioCombo.SelectedIndex = 0;
        }

        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            eliminaUsuario deleteWindow = new eliminaUsuario();
            deleteWindow.ShowDialog();
        }
    }
}
