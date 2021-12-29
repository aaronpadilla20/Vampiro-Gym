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
    public partial class ChangePassordWindow : Form
    {
        private string user;
        private string oldPassword;
        public ChangePassordWindow(string user, string oldPassword)
        {
            this.user = user;
            this.oldPassword = oldPassword;
            InitializeComponent();
        }

        private void ChangePassordWindow_Load(object sender, EventArgs e)
        {
            userTextBox.Text = this.user;
        }

        private void newPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            newPasswordTextBox.UseSystemPasswordChar = true;
        }

        private void newPasswordTextBox_Enter(object sender, EventArgs e)
        {
            if (newPasswordTextBox.Text.Contains("Ingrese")) newPasswordTextBox.Text = "";
        }

        private void confirmNewPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            confirmNewPasswordTextBox.UseSystemPasswordChar = true;
        }

        private void confirmNewPasswordTextBox_Enter(object sender, EventArgs e)
        {
            if (confirmNewPasswordTextBox.Text.Contains("Ingrese")) confirmNewPasswordTextBox.Text = "";
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (newPasswordTextBox.Text!="" && !newPasswordTextBox.Text.Contains("Ingrese"))
            {
                if (newPasswordTextBox.Text == confirmNewPasswordTextBox.Text)
                {
                    if (newPasswordTextBox.Text != oldPassword)
                    {
                        if (newPasswordTextBox.Text.Length<=10)
                        {
                            string query = "UPDATE Usuarios SET Contrasena ='" + confirmNewPasswordTextBox.Text + "' WHERE Usuario='" + userTextBox.Text + "'";
                            dataBaseControl updateUser = new dataBaseControl();
                            bool resQuery = updateUser.Update(query);
                            if (resQuery)
                            {
                                MessageBox.Show("Se ha actualizado el password correctamente", "Password actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                testc();
                            }
                            else
                            {
                                MessageBox.Show("Se ha presentado un problema al actualizar el password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La longitud del password debe de ser menor o igual a 10 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El password nuevo es el mismo que el anterior, por seguridad de la cuenta es necesario reemplazarlo \n" +
                            "El password debe de tener una longitud maxima de 10 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Los password no coinciden, imposible actualizar el password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Es necesario especificar el nuevo password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void testc()
        {
            Timer t = new Timer();
            t.Interval = 1500;
            t.Tick += new EventHandler(closeWindow_Tick);
            t.Start();
        }

        private void closeWindow_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
