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
    public partial class edicionUsuario : Form
    {
        Utilities utilidades = new Utilities();
        private bool emailValido;
        private string[] datos;
        private string[] nombre;

        public edicionUsuario()
        {
            InitializeComponent();
        }

        private void cancelButton_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(cancelButton, "Cancelar edicion");
        }

        private void saveButton_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(saveButton, "Realizar cambios");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool isEmail = false;
            if (!nombreTextBox.Text.Contains("Ingrese Nombre:") && nombreTextBox.Text != "")
            {
                if (!apellidoTextBox.Text.Contains("Ingrese Apellidos:") && apellidoTextBox.Text != "")
                {
                    if (propiedadesComboBox.Text.Contains("Email"))
                    {
                        isEmail = true;
                    }
                    if (!valorNuevoTextBox.Text.Contains("Ingrese valor deseado") && valorNuevoTextBox.Text != "")
                    {
                        if (isEmail)
                        {
                            emailValido = utilidades.validaEmail(valorNuevoTextBox.Text);
                            if (!emailValido)
                            {
                                MessageBox.Show("Por favor ingresa un email valido", "Email invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }                      
                        }
                        if (valorNuevoTextBox.Text != valorActualTextBox.Text)
                        {
                            datos = propiedadesComboBox.Text == "Password" ? new string[] { "Contrasena='" + valorNuevoTextBox.Text + "'" } : new string[] { "Correo='" + valorNuevoTextBox.Text + "'" };
                            nombre = new string[] { nombreTextBox.Text, apellidoTextBox.Text };
                            dataBaseControl update = new dataBaseControl();
                            update.Actualizaregistro("Usuarios",datos,nombre);
                        }
                        else
                        {
                            MessageBox.Show("El valor de parametro nuevo debe de ser diferente al valor actual", "Valores iguales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Es necesario especificar el nuevo valor deseado", "Sin valor de parametro especificado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario especificar el apellido del usuario a modificar", "Apellido no especificado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Es necesario especificar el nombre de usuario a modificar", "Nombre no especificado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
