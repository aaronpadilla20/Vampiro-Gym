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
        private string firstName;
        private string file;
        private string query;
        private string resConsulta;
        private string ventanaTipo;
        private string[] datos;
        private byte[] imagen;
        private string fechaAlta;
        public static bool operacionExitosa;

        Image imagenCliente;
        private string nombre;
        private string apellido;
        private string tipoMembresia;

       
        public formMembresia(string tipo,Image imagenCliente, string nombre, string apellido, string tipoMembresia)
        {
            InitializeComponent();
            this.ventanaTipo = tipo;
            this.imagenCliente = imagenCliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.tipoMembresia = tipoMembresia;
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
                    {
                        file = archivo.FileName;
                        imageCliente.Image = System.Drawing.Image.FromFile(file);
                        imageCliente.Tag = file;
                    }
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
            if (RegistroDeHuella.registrada)
            {
                registroHuellaTextBox.Text = "Huella Registrada";
            }
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
                                switch (this.ventanaTipo)
                                {
                                    case "alta":
                                       
                                        operacionExitosa = NuevoCliente();
                                        if (!operacionExitosa)
                                        {
                                            MessageBox.Show("Se presento un problema durante el enrolamiento del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Cliente dado de alta exitosamente", "Alta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        break;

                                    case "edicion":
                                        operacionExitosa = EdicionCliente();
                                        if (!operacionExitosa)
                                        {
                                            MessageBox.Show("Se presento un problema al actualizar la informacion del cliente intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Informacion de cliente actualizada correctamente", "Actualizacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.Close();
                                        }
                                        break;
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

        private bool NuevoCliente()
        {
            int res = 0;
            LectorZKTecok30 lector = new LectorZKTecok30();
            while (res != 1)
            {
                res = lector.ConnectDevice();
                if (res == 1)
                {
                    break;
                }
            }
            string[] nombres = nombreTextBox.Text.Split(' ');

            foreach (string nombre in nombres)
            {
                firstName = nombre;
                if (firstName != "")
                {
                    break;
                }
            }

            string fullName = firstName + " " + apellidoTextBox.Text;

            res = lector.SetUser(RegistroDeHuella.customerID, fullName);
            if (res != 1)
            {
                return false;
            }
            res = lector.SetFingerPrintTemplate(RegistroDeHuella.customerID, RegistroDeHuella.fingerPrintTemplate);
            if (res != 1)
            {
                return false;
            }

            this.query = "INSERT INTO Customers (Fotografia,Nombre,Apellido,Huella_dactilar,Tipo_de_membresia,Fecha_de_alta_membresia) VALUES (@imagen,@nombre,@apellido,@huellaDactilar,@tipoMembresia,@fechaAlta)";
            dataBaseControl altaCliente = new dataBaseControl();
            return altaCliente.InsertCliente(query, imagen, nombreTextBox.Text, apellidoTextBox.Text, RegistroDeHuella.fingerPrintTemplate, tipoMembresiasComboBox.Text, fechaAlta);
        }

        private bool EdicionCliente()
        {
            int res = 0;
            LectorZKTecok30 lector = new LectorZKTecok30();
            while (res != 1)
            {
                res = lector.ConnectDevice();
                if (res == 1)
                {
                    break;
                }
            }
            string query = "SELECT NoCliente,Huella_dactilar FROM Customers WHERE Nombre ='" + nombreTextBox.Text + "'";
            dataBaseControl customerTable = new dataBaseControl();
            string resConsult = customerTable.Select(query, 2);
            string[] datos = resConsult.Split(',');
            string fingerPrint = "";
            string customerID = "";
            foreach(string dato in datos)
            {
                if (customerID=="")
                {
                    customerID = dato;
                    continue;
                }
                if (fingerPrint=="")
                {
                    fingerPrint = dato;
                    continue;
                }
            }
            lector.SetFingerPrintTemplate(customerID, fingerPrint);
            string fechaNueva = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            dataBaseControl updateTable = new dataBaseControl();
            query = "UPDATE Customers SET Tipo_de_membresia='"+tipoMembresiasComboBox.Text+"',Fecha_de_alta_membresia='"+fechaNueva+"' WHERE Nombre='"+nombreTextBox.Text+"'";
            return updateTable.Update(query);
        }

        private byte[] ConvertirImg(System.Drawing.Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void tipoMembresiasComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Utilerias dibujaBox = new Utilerias();
            dibujaBox.comboBoxDrawing(sender, e);
        }

        private void CargaMembresias()
        {
            this.query = "SELECT Tipo_de_membresia FROM Membresias";
            dataBaseControl consult = new dataBaseControl();
            this.resConsulta = consult.Select(this.query, 1);
            if (!resConsulta.Contains("La consulta no genero resultados"))
            {
                this.resConsulta = this.resConsulta.TrimEnd(',');
                this.datos = this.resConsulta.Split(',');
                foreach (string dato in datos)
                {
                    tipoMembresiasComboBox.Items.Add(dato);
                }
            }
            else
            {
                MessageBox.Show("Imposible inicializar el registro de clientes ya que no cuenta actualmente con ningun tipo de membresia activa\n" +
                    "solicite al administrador del sistema generar las membresias e intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void AltaClienteForm()
        {
            CargaMembresias();
            tipoMembresiasComboBox.SelectedIndex = 0;
        }

        private void EditaUsuarioForm()
        {
            CargaMembresias();
            imageCliente.Image = this.imagenCliente;
            imageCliente.Tag = "editando";
            takePictureButton.Visible = false;
            nombreTextBox.Text = this.nombre;
            nombreTextBox.Enabled = false;
            apellidoTextBox.Text = this.apellido;
            apellidoTextBox.Enabled = false;
            tipoMembresiasComboBox.SelectedItem = this.tipoMembresia;
            registroHuellaTextBox.Text = "Registrado";
            registroHuellaTextBox.Enabled = false;
            fingerPrintButton.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString()=="Tab" || keyData.ToString()=="TAB")
            {
                switch(ActiveControl.Name)
                {
                    case "imageCliente":
                        nombreTextBox.Focus();
                        break;
                    case "nombreTextBox":
                        apellidoTextBox.Focus();
                        break;
                    case "apellidoTextBox":
                        tipoMembresiasComboBox.Focus();
                        break;
                    default:
                        nombreTextBox.Focus();
                        break;
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void formMembresia_Load(object sender, EventArgs e)
        {
            switch (ventanaTipo)
            {
                case "edicion":
                    EditaUsuarioForm();
                    break;
                case "alta":
                    AltaClienteForm();
                    break;
            }
            this.ActiveControl = imageCliente;
        }
    }
}
