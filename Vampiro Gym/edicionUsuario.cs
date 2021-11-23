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
        private bool actualizado; 

        public edicionUsuario()
        {
            InitializeComponent();
        }

        private void saveButton_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(saveButton, "Realizar cambios");
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
                            try
                            {
                                datos = propiedadesComboBox.Text == "Password" ? new string[] { "Contrasena='" + valorNuevoTextBox.Text + "'" } : new string[] { "Correo='" + valorNuevoTextBox.Text + "'" };
                                nombre = new string[] { nombreTextBox.Text.ToLower(), apellidoTextBox.Text.ToLower() };
                                dataBaseControl update = new dataBaseControl();
                                this.actualizado = update.ActualizaUsuariosClientes("Usuarios", datos, nombre);
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show("Ha ocurrido el siguiente error al consultar la base de datos: " + err.Message);
                                clearTextBox();
                            }
                            if(actualizado)
                            {
                                MessageBox.Show("!SE HA ACTUALIZADO LA BASE DE DATOS CORRECTAMENTE!", "Base de datos actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearTextBox();
                            }
                            else
                            {
                                MessageBox.Show("El usuario especificado no existe en la base de datos, por lo cual no se puede actualizar, favor de creearlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                clearTextBox();
                            }
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

        private void clearTextBox()
        {
            nombreTextBox.Text = "Ingrese Nombre:";
            apellidoTextBox.Text = "Ingrese Apellidos:";
            propiedadesComboBox.SelectedIndex = 0;
            valorActualTextBox.Text = "";
            valorNuevoTextBox.Text = "Ingrese valor deseado";
        }

        private void nombreTextBox_Enter(object sender, EventArgs e)
        {
            nombreTextBox.Text = "";
        }

        private void apellidoTextBox_Enter(object sender, EventArgs e)
        {
            apellidoTextBox.Text = "";
        }

        private void valorNuevoTextBox_Enter(object sender, EventArgs e)
        {
            valorNuevoTextBox.Text = "";
        }

        private void propiedadesComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Utilities drawBox = new Utilities();
            drawBox.comboBoxDrawing(sender, e);
        }

        private void edicionUsuario_Load(object sender, EventArgs e)
        {
            propiedadesComboBox.SelectedIndex = 0;
            this.Focus();
        }

        private void propiedadesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (propiedadesComboBox.SelectedItem.ToString() == "--Selecciona opcion deseada--")
            {
                MessageBox.Show("Es necesario seleccionar una opcion a editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if ((!nombreTextBox.Text.Contains("Ingrese Nombre:") && nombreTextBox.Text != "") && (!apellidoTextBox.Text.Contains("Ingrese Apellidos:") && apellidoTextBox.Text != ""))
                {
                    datos = propiedadesComboBox.Text == "Password" ? new string[] { "Contrasena='" + valorNuevoTextBox.Text + "'" } : new string[] { "Correo='" + valorNuevoTextBox.Text + "'" };
                    nombre = new string[] { nombreTextBox.Text.ToLower(), apellidoTextBox.Text.ToLower() };
                    dataBaseControl select = new dataBaseControl();
                    select.consulta(datos,"Usuarios",)
                }
                else
                {
                    MessageBox.Show("Es necesario especificar nombre completo del usuaro a editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
    }
}
