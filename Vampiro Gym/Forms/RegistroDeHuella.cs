using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    public partial class RegistroDeHuella : Form
    {
        Thread capturaHuella;
        bool editandoHuella;
        private string resultadoOperacion;
        private string resRegistro;
        string resConexionSensor;
        private bool aborted;
        public static  bool registrada;
        public static string customerID;

        public RegistroDeHuella(bool editandoHuella)
        {
            this.editandoHuella = editandoHuella;
            InitializeComponent();
        }

        private async void capturarHuella_Click(object sender, EventArgs e)
        {
            aborted = false;
            #region ----------CONECTA SENSOR---------
            this.resConexionSensor = ConnectDevice();
            if (resConexionSensor.Contains("El lector de huellas esta siendo utilizado por otra aplicación cierrela e intentelo de nuevo"))
            {
                cierraConexion();
            }
            if (!resConexionSensor.Contains("Conexion exitos"))
            {
                MessageBox.Show("Se ha presentado el siguiente error al intentar establecer comunicacion con el sensor: " + resConexionSensor,"Error Comunicacion Sensor",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            #endregion --------------------------------
            EstadoConexion.Text = "Dispositivo Conectado";
            EstadoConexion.BackColor = Color.Green;
            capturarHuella.Enabled = false;
            stopCapture.Enabled = true;

            #region --REGISTRO DE HUELLA--
            bIsTimeToDie = false;
            isRegister = false;
            registrada = false;
            this.resultadoOperacion = PreparaLectura();
            if (resultadoOperacion.Contains("Lista para obtener lectura"))
            {
                capturaHuella = new Thread(new ThreadStart(AcquireFinger));
                capturaHuella.IsBackground = true;
                capturaHuella.Start();
            }
            bool res = await HuellaRegistrada();
            if (res)
            {
                EstadoConexion.BackColor = Color.Green;
                dataBaseControl Consult = new dataBaseControl();
                string query = "SELECT NoCliente From Customers";
                string resConsulta = Consult.Select(query, 1);
                string[] datos = resConsulta.Split(',');
                string lastCustomerNumber = string.Empty;
                foreach(string dato in datos)
                {
                    if (dato != "")
                    {
                        lastCustomerNumber = dato;
                    }
                }
                
                if (editandoHuella)
                {
                    customerID = lastCustomerNumber;
                }
                else
                {
                    if (lastCustomerNumber.Contains("La consulta"))
                    {
                        customerID = "1";
                    }
                    else
                    {
                        int consecutivo = Int32.Parse(lastCustomerNumber) + 1;
                        customerID = consecutivo.ToString();
                    }
                }
                EstadoConexion.Text = "Huella registrada exitosamente";
                cierraConexion();
                DialogResult ok = MessageBox.Show("La huella se ha registrado exitosamente, regresando a formulario de registro", "Huella Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ok == DialogResult.OK)
                {
                    registrada = true;
                    bIsTimeToDie = true;
                    this.Close();
                }
            }
            else
            {
                EstadoConexion.BackColor = Color.Orange;
                EstadoConexion.Text = "Captura abortada";
            }
            #endregion
        }

        private async Task<bool> HuellaRegistrada()
        {
            bool res = await Task.Run(registrando);
            if (res)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool registrando()
        {
            while (!isRegister)
            {
                if (aborted)
                {
                    return false;
                }
                Thread.Sleep(100);
            }
            return true;
        }

        private void cierraConexion()
        {
            int count = 0;
            bIsTimeToDie = true;
            aborted = true;
            while (true)
            {
                if (count >= 3)
                {
                    MessageBox.Show("ERROR FATAL, FINALIZANDO EL PROGRAMA", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                this.resConexionSensor = CloseConnection();
                if (!resConexionSensor.Contains("Comunicación cerrada exitosamente"))
                {
                    count++;
                    MessageBox.Show("Se ha presentado el siguiente error al intentar cerra la comunicación con el sensor de huellas: " + resConexionSensor, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    break;
                }
            }
        }

        private void stopCapture_Click(object sender, EventArgs e)
        {
            cierraConexion();
            EstadoConexion.Text = "Dispositivo desconectado";
            EstadoConexion.BackColor = Color.Red;
            capturarHuella.Enabled = true;
            stopCapture.Enabled = false;
            remainingCount = 0;
            MessageBox.Show("Se ha cancelado el registro de huella dactilar");
            this.resRegistro = "";
        }

        private void RegistroDeHuella_Load(object sender, EventArgs e)
        {
            FormHandle = this.Handle;
        }

        private void RegistroDeHuella_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!registrada)
            {
                if (!capturarHuella.Enabled)
                {
                    DialogResult res = MessageBox.Show("Actualmente esta enrolando un cliente, ¿esta seguro de querer cerrar esta ventana?", "Cerrando formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        aborted = true;
                        bIsTimeToDie = true;
                        this.resConexionSensor = CloseConnection();
                    }
                }
            }
        }
    }
}
