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

        private const string TABLA = "Usuarios";
        private const int CAMPOSAOBTENER = 1;

        Utilities utilidades = new Utilities();

        private string resultadoConsulta;
        private bool actualizado;
        private bool emailValido;
        private bool inicializando;
        
        private string query;
       

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
                                this.query = propiedadesComboBox.Text.Contains("Password") ? "UPDATE Usuarios SET Contrasena='" + valorNuevoTextBox.Text + "' WHERE (Nombre='" + nombreTextBox.Text + "') AND (Apellido ='" + apellidoTextBox.Text + "')" : "UPDATE Usuarios SET Correo='" + valorNuevoTextBox.Text + "' WHERE (Nombre='" + nombreTextBox.Text + "') AND (Apellido ='" + apellidoTextBox.Text + "')";
                                dataBaseControl update = new dataBaseControl();
                                this.actualizado = update.Update(query);
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show("Ha ocurrido el siguiente error al consultar la base de datos: " + err.Message);
                                clearTextBox();
                            }
                            if(actualizado)
                            {
                                DialogResult res = MessageBox.Show("!SE HA ACTUALIZADO LA BASE DE DATOS CORRECTAMENTE!\n¿Desea realizar otra modificación?", "Base de datos actualizada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (res == DialogResult.Yes)
                                {
                                    clearTextBox();
                                }
                                else
                                {
                                    this.Close();
                                }

                                
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
            nombreTextBox.Enabled = true;
            apellidoTextBox.Enabled = true;
            this.inicializando = true;
            propiedadesComboBox.SelectedIndex = 0;
            valorActualTextBox.Text = "";
            valorNuevoTextBox.Text = "Ingrese valor deseado";
            valorNuevoTextBox.Enabled = false;
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
            this.inicializando = true;
            propiedadesComboBox.SelectedIndex = 0;
            this.Focus();
        }

        private void propiedadesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (propiedadesComboBox.SelectedItem.ToString() == "--Selecciona opcion deseada--" && this.inicializando == false)
            {
                MessageBox.Show("Es necesario seleccionar una opcion a editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!inicializando)
                {
                    if ((!nombreTextBox.Text.Contains("Ingrese Nombre:") && nombreTextBox.Text != "") && (!apellidoTextBox.Text.Contains("Ingrese Apellidos:") && apellidoTextBox.Text != ""))
                    {
                        try
                        {
                            this.query = propiedadesComboBox.Text.Contains("Password") ? "SELECT Contrasena FROM " + TABLA + " WHERE (Nombre='" + nombreTextBox.Text + "') AND (Apellido='" + apellidoTextBox.Text + "')" : "SELECT Correo FROM " + TABLA + " WHERE (Nombre='" + nombreTextBox.Text + "') AND (Apellido='" + apellidoTextBox.Text + "')";
                            dataBaseControl consult = new dataBaseControl();
                            this.resultadoConsulta = consult.Select(query, TABLA, CAMPOSAOBTENER);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Se ha presentado el siguiente error al consultar la base de datos: " + err.Message);
                        }
                        if (this.resultadoConsulta.Contains("No existe el usuario favor de verificarlo"))
                        {
                            MessageBox.Show(resultadoConsulta, "Usuario inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            valorActualTextBox.Text = this.resultadoConsulta;
                            nombreTextBox.Enabled = false;
                            apellidoTextBox.Enabled = false;
                            valorNuevoTextBox.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Es necesario especificar nombre completo del usuaro a editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
           
        }

        private void propiedadesComboBox_Click(object sender, EventArgs e)
        {
            this.inicializando = false;
        }

        private void cancelButton_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(cancelButton, "Cancela seleccion de usuario");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }
    }
}
