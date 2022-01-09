using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    public partial class usuarioRegistroForm : Form
    {
        private string tipoUsuario;
        private string nombre;
        private string apellido;
        private string correo;
        private string user;
        private string password;
        private string confirmPassword;

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
        private string tipoVentana;

        private const string TABLA = "Usuarios";
        private const int CAMPOSAOBTENER = 1;

        Utilerias utilidades = new Utilerias();
        Match m;

        public usuarioRegistroForm(string tipoVentana,string tipoUsuario,string nombre, string apellido, string correo, string user, string password, string confirmPassword)
        {
            this.tipoVentana = tipoVentana;
            this.tipoUsuario = tipoUsuario;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.user = user;
            this.password = password;
            this.confirmPassword = confirmPassword;
            InitializeComponent();
        }

        public bool getInsertado
        {
            get
            {
                return insertado;
            }
        }

        private void botonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void tipoUsuarioCombo_DrawItem(object sender, DrawItemEventArgs e)
        {
            Utilerias drawBox = new Utilerias();
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

        private void RegisterUser()
        {
            datos = new string[] { };
            try
            {
                dataBaseControl consult = new dataBaseControl();
                usuario = userTextBox.Text;
                this.query = "SELECT Usuario FROM " + TABLA + " WHERE Usuario LIKE '" + usuario + "%'";
                this.resultadoConsulta1 = consult.Select(query, 1);
                if (!resultadoConsulta1.Contains("La consulta no genero resultados")) //Si el usuario existe
                {
                    this.resultadoConsulta1 = this.resultadoConsulta1.TrimEnd(',');
                    datos = resultadoConsulta1.Split(',');
                    foreach (string dato in datos)
                    {
                        this.lastSimilarUser = dato;
                    }
                    this.query = "SELECT Nombre,Apellido FROM " + TABLA + " WHERE (Nombre='" + nombreBox.Text + "') AND (Apellido='" + apellidoTextBox.Text + "')"; //Consulta de nombre y apellido
                    this.resultadoConsulta2 = consult.Select(query, 2); // Realizamos consulta
                    if (resultadoConsulta2.Contains("La consulta no genero resultados")) // Si el usuario no existe
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
                        this.resultadoConsulta3 = consult.Select(query, 1);
                        if (resultadoConsulta3.Contains("La consulta no genero resultados"))
                        {
                            RegistraUsuario(usuario);
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
                    RegistraUsuario(usuario);
                    this.Close();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Ha ocurrido el siguiente error al crear el usuario" + er.ToString());
            }
        }

        private void EditUser()
        {
            dataBaseControl updateUserTable = new dataBaseControl();
            string query = "UPDATE Usuarios SET Tipo_de_usuario='" + tipoUsuarioCombo.Text + "',Correo='" + emailBox.Text + "',Contrasena='" + confirmePasswordBox.Text + "' WHERE Usuario='"+userTextBox.Text+"'";
            bool updatedTable = updateUserTable.Update(query);
            if (updatedTable)
            {
                MessageBox.Show("Informacion de usuario modificada correctamente", "Usuario modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Se presento un error al intentar actualizar la información del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (!userTextBox.Text.Contains("Ingrese") && userTextBox.Text != "")
                        {
                            if (!passwordBox.Text.Contains("Ingrese Password") && passwordBox.Text != "")
                            {
                                if (userTextBox.Text != passwordBox.Text)
                                {
                                    if (!confirmePasswordBox.Text.Contains("Confirme Password") && confirmePasswordBox.Text != "" && passwordBox.Text == confirmePasswordBox.Text)
                                    {
                                        string action = "";
                                        string action2 = "";
                                        switch (tipoVentana)
                                        {
                                            case "alta":
                                                action = "crear";
                                                action2 = "creara";
                                                break;
                                            case "edicion":
                                                action = "editar";
                                                action2 = "editara";
                                                break;
                                        }

                                        DialogResult res = MessageBox.Show("Se" + action2 + "un usuario con los siguientes datos:\n" +
                                            "Tipo de usuario: " + tipoUsuarioCombo.Text + "\n" +
                                            "Nombre: " + nombreBox.Text + "\n" +
                                            "Apellido: " + apellidoTextBox.Text + "\n" +
                                            "Correo: " + emailBox.Text + "\n" +
                                            "Usuario: " + userTextBox.Text + "\n" +
                                            "Password: " + passwordBox.Text + "\n" +
                                            "¿Esta seguro de " + action + " el usuario con los datos anteriormente especificados?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (res == DialogResult.Yes)
                                        {
                                            switch (tipoVentana)
                                            {
                                                case "alta":
                                                    RegisterUser();
                                                    break;
                                                case "edicion":
                                                    EditUser();
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            res = MessageBox.Show("¿Desea modificar el tipo de usuario?", "Modifica tipo usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (res == DialogResult.Yes)
                                            {
                                                tipoUsuarioCombo.SelectedIndex = 0;
                                                nombreBox.Enabled = false;
                                                apellidoTextBox.Enabled = false;
                                                emailBox.Enabled = false;
                                                userTextBox.Enabled = false;
                                                passwordBox.Enabled = false;
                                                confirmePasswordBox.Enabled = false;
                                            }
                                            else
                                            {
                                                res = MessageBox.Show("¿Desea modificar el nombre del usuario?", "Modifica nombre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (res == DialogResult.Yes)
                                                {
                                                    tipoUsuarioCombo.Enabled = false;
                                                    nombreBox.Text = "";
                                                    apellidoTextBox.Text = "";
                                                    emailBox.Enabled = false;
                                                    userTextBox.Enabled = false;
                                                    passwordBox.Enabled = false;
                                                    confirmePasswordBox.Enabled = false;
                                                }
                                                else
                                                {
                                                    res = MessageBox.Show("¿Desea modificar el email del usuario?", "Modifica nombre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                    if (res == DialogResult.Yes)
                                                    {
                                                        tipoUsuarioCombo.Enabled = false;
                                                        nombreBox.Enabled = false;
                                                        apellidoTextBox.Enabled = false;
                                                        emailBox.Text = "";
                                                        userTextBox.Enabled = false;
                                                        passwordBox.Enabled = false;
                                                        confirmePasswordBox.Enabled = false;
                                                    }
                                                    else
                                                    {
                                                        res = MessageBox.Show("¿Desea modificar el nombre de usuario del usuario?", "Modifica nombre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                        if (res == DialogResult.Yes)
                                                        {
                                                            tipoUsuarioCombo.Enabled = false;
                                                            nombreBox.Enabled = false;
                                                            apellidoTextBox.Enabled = false;
                                                            emailBox.Enabled = false;
                                                            userTextBox.Text = "";
                                                            passwordBox.Enabled = false;
                                                            confirmePasswordBox.Enabled = false;
                                                        }
                                                        else
                                                        {
                                                            res = MessageBox.Show("¿Desea modificar el password del usuario?", "Modifica nombre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                            if (res == DialogResult.Yes)
                                                            {
                                                                tipoUsuarioCombo.Enabled = false;
                                                                nombreBox.Enabled = false;
                                                                apellidoTextBox.Enabled = false;
                                                                emailBox.Enabled = false;
                                                                userTextBox.Enabled = false;
                                                                passwordBox.Text = "";
                                                                confirmePasswordBox.Text = "";
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Se ha abortado la creacion del usuario", "Creacion de usuario abortada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No coinciden los password compruebelo e intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El usuario y el password deben de ser diferentes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Es necesario especificar un password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Es necesario especificar un usuario para darlo de alta en sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void RegistraUsuario(string user)
        {
            this.query = "INSERT INTO " + TABLA + " (Tipo_de_usuario,Nombre,Apellido,Correo,Contrasena,Usuario) VALUES ('" + tipoUsuarioCombo.Text + "','" + nombreBox.Text + "','" + apellidoTextBox.Text + "','" + emailBox.Text + "','" + passwordBox.Text + "','" + user + "')";
            dataBaseControl insert = new dataBaseControl();
            this.insertado = insert.Insert(query);
            MessageBox.Show("Se ha creado el usuario " + usuario + " exisosamente", "Usuario creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearWindow();
            if (loginWindow.inicializandoSistema == true)
            {
                loginWindow.inicializandoSistema = false;
                this.Close();
            }
            else
            {
                this.Close();
            }
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

        private void editButton_Click(object sender, EventArgs e)
        {
            edicionUsuario editWindow = new edicionUsuario();
            editWindow.ShowDialog();
        }

        private void AltaUsuario()
        {
            tipoUsuarioCombo.SelectedIndex = 0;
            if (loginWindow.inicializandoSistema)
            {
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.StartPosition = FormStartPosition.CenterScreen;
                tipoUsuarioCombo.Enabled = false;
                headerTable.Visible = false;
            }
        }

        private void EditaUsuario()
        {
            tipoUsuarioCombo.Text = tipoUsuario;
            nombreBox.Text = nombre;
            nombreBox.Enabled = false;
            apellidoTextBox.Text = apellido;
            apellidoTextBox.Enabled = false;
            emailBox.Text = correo;
            userTextBox.Text = user;
            userTextBox.Enabled = false;
            passwordBox.Text = password;
            confirmePasswordBox.Text = confirmPassword;
        }

        private void usuarioRegistroForm_Load(object sender, EventArgs e)
        {
            switch (tipoVentana)
            {
                case "edicion":
                    EditaUsuario();
                    break;
                case "alta":
                    AltaUsuario();
                    break;
            }
            this.ActiveControl = tipoUsuarioLogo;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
           
            if (keyData.ToString() == "Tab" || keyData.ToString() == "TAB")
            {
                switch (ActiveControl.Name)
                {
                    case "tipoUsuarioLogo":
                        tipoUsuarioCombo.Focus();
                        break;
                    case "tipoUsuarioCombo":
                        if (nombreBox.Enabled)
                        {
                            nombreBox.Focus();
                        }
                        else
                        {
                            emailBox.Focus();
                        }
                        break;
                    case "nombreBox":
                        apellidoTextBox.Focus();
                        break;
                    case "apellidoTextBox":
                        emailBox.Focus();
                        break;
                    case "emailBox":
                        if (userTextBox.Enabled)
                        {
                            userTextBox.Focus();
                        }
                        else
                        {
                            passwordBox.Focus();
                        }
                        break;
                    case "userTextBox":
                        passwordBox.Focus();
                        break;
                    case "passwordBox":
                        confirmePasswordBox.Focus();
                        break;
                    default:
                        tipoUsuarioCombo.Focus();
                        break;
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void userTextBox_Enter(object sender, EventArgs e)
        {
            if (userTextBox.Text.Contains("Ingrese")) userTextBox.Text = "";
        }
    }
}
