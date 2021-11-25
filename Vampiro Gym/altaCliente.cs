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
    public partial class formMembresia : Form
    {
        protected string file;
        public formMembresia()
        {
            InitializeComponent();
        }

        private void takePictureButton_Click(object sender, EventArgs e)
        {
            if ((nombreTextBox.Text.Contains("Nombre") || nombreTextBox.Text == "") || (apellidoTextBox.Text.Contains("Apellidos") || apellidoTextBox.Text == ""))
            {
                MessageBox.Show("Es necesario ingresar nombre de usuario y apellido previo a la captura de la fotografia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult res = MessageBox.Show("¿Desea utilizar la web cam para capturar la imagen?", "Cargando imagen", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (res == DialogResult.Yes)
                {
                    takePictureForm takePicture = new takePictureForm(nombreTextBox.Text,apellidoTextBox.Text);
                    takePicture.ShowDialog();
                    imageCliente.Image = System.Drawing.Image.FromFile(takePicture.file);
                }
                else
                {
                    OpenFileDialog archivo = new OpenFileDialog();
                    if (archivo.ShowDialog() == DialogResult.OK)
                        file = archivo.FileName;
                    imageCliente.Image = System.Drawing.Image.FromFile(file);
                }
            }
        }

        private void botonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nombreTextBox_Enter(object sender, EventArgs e)
        {
            if (nombreTextBox.Text.Contains("Nombre(s):"))
                nombreTextBox.Text = "";
        }

        private void apellidoTextBox_Enter(object sender, EventArgs e)
        {
            if (apellidoTextBox.Text.Contains("Apellido:"))
                apellidoTextBox.Text = "";
        }

        private void registroDeHuella_Click(object sender, EventArgs e)
        {
            RegistroDeHuella registroWindow = new RegistroDeHuella();
            registroWindow.ShowDialog();
        }
    }
}
