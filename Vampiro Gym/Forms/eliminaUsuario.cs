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
    public partial class eliminaUsuario : Form
    {
        public string query;
        public bool deleted;

        public eliminaUsuario()
        {
            InitializeComponent();
        }

        private void nombreTextBox_Enter(object sender, EventArgs e)
        {
            if (nombreTextBox.Text.Contains("Ingrese Nombre:"))
                nombreTextBox.Text = "";
        }

        private void apellidoTextBox_Enter(object sender, EventArgs e)
        {
            if (apellidoTextBox.Text.Contains("Ingrese Apellido:"))
                apellidoTextBox.Text = "";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if ((!nombreTextBox.Text.Contains("Ingrese Nombre:") && nombreTextBox.Text != "") && (!apellidoTextBox.Text.Contains("Ingrese Apellido:") && apellidoTextBox.Text != ""))
            {
                DialogResult res = MessageBox.Show("¿Esta seguro de desear el usuario perteneciente al empleado " + nombreTextBox.Text + " " + apellidoTextBox.Text, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        this.query = "DELETE FROM Usuarios WHERE Nombre='" + nombreTextBox.Text + "' AND Apellido='" + apellidoTextBox.Text + "'";
                        dataBaseControl delete = new dataBaseControl();
                        deleted = delete.Delete(query);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Se ha presentado el siguiente error al intente eliminar el usuario: " + err.Message);
                    }

                    if (deleted)
                    {
                        MessageBox.Show("!Se ha eliminado el usuario con exito", "Usuario eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        res = MessageBox.Show("El usuario especificado no existe, ¿Desea intentar con otro usuario?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.Yes)
                        {
                            ClearWindow();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    res = MessageBox.Show("¿Desea eliminar algun usuario?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        ClearWindow();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Es necesario especificar Nombre y apellido del empleado a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearWindow()
        {
            nombreTextBox.Text = "";
            apellidoTextBox.Text = "";
        }
    }
}
