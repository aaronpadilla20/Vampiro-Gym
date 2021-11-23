using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    public partial class usuarioRegistroForm : Form
    {
        private bool emailValido;
        private string usuario;
        Utilities utilidades = new Utilities();

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
                                try
                                {
                                    usuario = nombreBox.Text.Substring(0, 2).ToLower() + apellidoTextBox.Text.Substring(0, 5).ToLower();
                                    MessageBox.Show("Se ha creado el usuario: " + usuario + " con privilegios de " + tipoUsuarioCombo.Text + " comparta el usuario al empleado y solicite que guarde su password en un lugar seguro");
                                }
                                catch (Exception er)
                                {
                                    MessageBox.Show("Ha ocurrido el siguiente error al crear el usuario" + er.ToString());
                                }
                            }
                            else
                            {
                                MessageBox.Show("No coinciden los password compruebelo e intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Es necesario especificar un passowrd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void emailBox_Enter(object sender, EventArgs e)
        {
            if (emailBox.Text.Contains("Ingrese correo de usuario"))
                emailBox.Text = "";
        }

        private void passwordBox_Enter(object sender, EventArgs e)
        {
            if (passwordBox.Text.Contains("Ingrese Password"))
                passwordBox.Text = "";
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
    }
}
