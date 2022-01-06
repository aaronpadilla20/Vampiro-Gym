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
        private bool registerUser;
        private bool edicionHuella;
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
            registerUser = false;
            edicionHuella = false;
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

        private void registrandoHuella()
        {
            RegistroDeHuella registroWindow = new RegistroDeHuella(edicionHuella);
            registroWindow.ShowDialog();
            if (RegistroDeHuella.registrada)
            {
                registroHuellaTextBox.Text = "Huella Registrada";
            }
        }

        private void registroDeHuella_Click(object sender, EventArgs e)
        {
            if (ventanaTipo == "edicion")
            {
                DialogResult res = MessageBox.Show("¿Desea cambiar la huella dactilar registrada?", "Edicion huella", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    edicionHuella = true;
                    registroHuellaTextBox.Text = "Reemplazando huella dactilar";
                    registrandoHuella();
                }
            }
            else
            {
                registrandoHuella();
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
                                DialogResult res = MessageBox.Show("Se dara de alta el cliente " + nombreTextBox.Text + " " + apellidoTextBox.Text + " con una membresia tipo " + tipoMembresiasComboBox.Text + " ¿Esta seguro de darlo de alta de esta manera?","Confirma Alta",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                                if (res == DialogResult.Yes)
                                {
                                    string costo = cobro();
                                    MessageBox.Show("Realice el cobro de la membresia tipo " + tipoMembresiasComboBox.Text + " por la cantidad de " + costo + " pesos y posteriormente de clic en el botón de aceptar", "Realice Cobro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    res = MessageBox.Show("¿Desea modificar el nombre del cliente?", "Modifica Nombre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (res == DialogResult.Yes)
                                    {
                                        takePictureButton.Enabled = false;
                                        nombreTextBox.Text = " ";
                                        apellidoTextBox.Text = " ";
                                        tipoMembresiasComboBox.Enabled = false;
                                        fingerPrintButton.Enabled = false;
                                        return;
                                    }
                                    else
                                    {
                                        res = MessageBox.Show("¿Desea modificar el tipo de membresia asignada?", "Modifica Membresia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (res == DialogResult.Yes)
                                        {
                                            takePictureButton.Enabled = false;
                                            nombreTextBox.Enabled = false;
                                            apellidoTextBox.Enabled = false;
                                            tipoMembresiasComboBox.SelectedIndex = 0;
                                            fingerPrintButton.Enabled = false;
                                            return;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Se ha abortado el registro del cliente", "Registo abortado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            this.Close();
                                        }
                                    }
                                }
                                switch (this.ventanaTipo)
                                {
                                    case "alta":
                                        this.fechaAlta = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                                        operacionExitosa = NuevoCliente(this.fechaAlta);
                                        if (!operacionExitosa)
                                        {
                                            MessageBox.Show("Se presento un problema durante el enrolamiento del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;    
                                        }
                                        operacionExitosa = AgregaHistorial(fechaAlta);
                                        if(!operacionExitosa)
                                        {
                                            MessageBox.Show("Se presento un problema durante el enrolamiento del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        else
                                        {
                                            registerUser = true;
                                            MessageBox.Show("Cliente dado de alta exitosamente", "Alta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            res = MessageBox.Show("Desea dar de alta un cliente adicional?", "Otro cliente?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (res == DialogResult.Yes)
                                            {
                                                registerUser = false;
                                            }
                                            if (res ==DialogResult.No)
                                            {
                                                this.Close();
                                            }
                                        }
                                        break;

                                    case "edicion":
                                        string fecha = DateTime.Now.ToString("dd / MM / yyyy HH: mm:ss");
                                        operacionExitosa = EdicionCliente(fecha);
                                        if (!operacionExitosa)
                                        {
                                            MessageBox.Show("Se presento un problema al actualizar la informacion del cliente intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        operacionExitosa = AgregaHistorial(fecha);
                                        if(!operacionExitosa)
                                        {
                                            MessageBox.Show("Se presento un problema al actualizar la informacion del cliente intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        else
                                        {
                                            registerUser = true;
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

        private string cobro()
        {
            string query = "SELECT Costo FROM Membresias WHERE Tipo_de_membresia='" + tipoMembresiasComboBox.Text + "'";
            dataBaseControl consultCost = new dataBaseControl();
            string costo = consultCost.Select(query, 1);
            costo = costo.TrimEnd(',');
            return costo;
        }

        private bool AgregaHistorial(string fechaAlta)
        {
            dataBaseControl dataBaseQuery = new dataBaseControl();
            DateTime fechaVencimiento = Convert.ToDateTime(fechaAlta);
            this.query = "SELECT DuracionMembresia FROM Membresias WHERE Tipo_de_membresia='" + tipoMembresiasComboBox.Text + "'";
            string resQuery = dataBaseQuery.Select(query, 1);
            resQuery = resQuery.TrimEnd(',');
            int membershipDuration = Int32.Parse(resQuery);
            fechaVencimiento = fechaVencimiento.AddDays(membershipDuration);
            this.query = "INSERT INTO Historico_Membresias(Fecha_alta_membresia,Tipo_de_membresia,Fecha_vencimiento_membresia,Nombre_Cliente,Apellido_Cliente) VALUES (@fechaAlta,@tipoMembresia,@fechaVencimiento,@nombre,@apellido)";
            return dataBaseQuery.InsertNewHistoricalData(query, fechaAlta, tipoMembresiasComboBox.Text, fechaVencimiento.ToString(), nombreTextBox.Text, apellidoTextBox.Text);
        }

        private bool NuevoCliente(string fechaAlta)
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
            this.query = "INSERT INTO Customers (Fotografia,Nombre,Apellido,Huella_dactilar,Tipo_de_membresia,Fecha_de_alta_membresia,Fecha_de_alta_cliente) VALUES (@imagen,@nombre,@apellido,@huellaDactilar,@tipoMembresia,@fechaAltaMembresia,@fechaAltaCliente)";
            dataBaseControl altaCliente = new dataBaseControl();
            return altaCliente.InsertCliente(query, imagen, nombreTextBox.Text, apellidoTextBox.Text, RegistroDeHuella.fingerPrintTemplate, tipoMembresiasComboBox.Text, fechaAlta);
        }

        private bool EdicionCliente(string fechaNueva)
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
            dataBaseControl updateTable = new dataBaseControl();
            if (edicionHuella)
            {
                lector.DelFingerPrintTemplate(customerID);
                query = "UPDATE Customers SET Tipo_de_membresia='" + tipoMembresiasComboBox.Text + "',Fecha_de_alta_membresia='" + fechaNueva + "',Huella_dactilar='" + RegistroDeHuella.fingerPrintTemplate + "' WHERE Nombre='" + nombreTextBox.Text + "'";
                lector.SetFingerPrintTemplate(customerID, RegistroDeHuella.fingerPrintTemplate);
            }
            else
            {
                query = "UPDATE Customers SET Tipo_de_membresia='" + tipoMembresiasComboBox.Text + "',Fecha_de_alta_membresia='" + fechaNueva + "' WHERE Nombre='" + nombreTextBox.Text + "'";
                lector.SetFingerPrintTemplate(customerID, fingerPrint);
            }
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
            registroHuellaTextBox.Enabled = true;
            fingerPrintButton.Visible =true;
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

        private void formMembresia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (registerUser == false)
            {
                DialogResult res = MessageBox.Show("El cliente aun no ha sido registrado, ¿Desea aborta el registro del cliente?", "Toma de decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
