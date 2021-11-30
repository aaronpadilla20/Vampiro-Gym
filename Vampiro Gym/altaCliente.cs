using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    public partial class formMembresia : Form
    {
        private string file;
        private string query;
        private string resConsulta;
        private string[] datos;
        private byte[] imagen;
        private string fechaAlta;
        public static bool clienteAlta;
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
                    imageCliente.Tag = takePicture.file;
                }
                else
                {
                    OpenFileDialog archivo = new OpenFileDialog();
                    if (archivo.ShowDialog() == DialogResult.OK)
                        file = archivo.FileName;
                    imageCliente.Image = System.Drawing.Image.FromFile(file);
                    imageCliente.Tag = file;
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
            registroHuellaTextBox.Text = "Registrado";
            RegistroDeHuella registroWindow = new RegistroDeHuella();
            registroWindow.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (imageCliente.Tag!= null)
            {
                if (!nombreTextBox.Text.Contains("Nombre(s):") && nombreTextBox.Text !="")
                {
                    if(!apellidoTextBox.Text.Contains("Apellido:") && apellidoTextBox.Text!="")
                    {
                        if (!tipoMembresiasComboBox.Text.Contains("--Seleccione la opcion deseada--"))
                        {
                            if (!registroHuellaTextBox.Text.Contains("No registrado"))
                            {
                                this.imagen = ConvertirImg(imageCliente.Image);
                                this.fechaAlta = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                                this.query = "INSERT INTO Customers (Fotografia,Nombre,Apellido,Huella_dactilar,Tipo_de_membresia,Fecha_de_alta_membresia) VALUES (@imagen,@nombre,@apellido,@huellaDactilar,@tipoMembresia,@fechaAlta)";
                                dataBaseControl altaCliente = new dataBaseControl();
                                clienteAlta = altaCliente.InsertCliente(query,imagen,nombreTextBox.Text,apellidoTextBox.Text,imagen,tipoMembresiasComboBox.Text,fechaAlta);
                                if (clienteAlta)
                                {
                                    MessageBox.Show("Registro exitoso");
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Es necesario registrar la huella del cliente para darlo de alta");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Es necesario seleccionar un tipo de membresia");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Es necesario ingresar el apellido del cliente");
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario ingresar el nombre del cliente");
                }
            }
            else
            {
                MessageBox.Show("Imposible dar de alta al cliente, es necesario capturar una imagen del cliente");
            }
           
        }

        private byte[] ConvertirImg(System.Drawing.Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void tipoMembresiasComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Utilities dibujaBox = new Utilities();
            dibujaBox.comboBoxDrawing(sender, e);
        }

        private void formMembresia_Load(object sender, EventArgs e)
        {
            this.query = "SELECT Tipo_de_membresia FROM Membresias";
            dataBaseControl consult = new dataBaseControl();
            this.resConsulta = consult.Select(this.query, 1);
            if (!resConsulta.Contains("La consulta no genero resultados"))
            {
                this.resConsulta = this.resConsulta.TrimEnd(',');
                this.datos = this.resConsulta.Split(',');
                foreach(string dato in datos)
                {
                    tipoMembresiasComboBox.Items.Add(dato);
                }
                tipoMembresiasComboBox.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Imposible inicializar el registro de clientes ya que no cuenta actualmente con ningun tipo de membresia activa\n" +
                    "solicite al administrador del sistema generar las membresias e intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
