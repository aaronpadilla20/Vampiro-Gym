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
        private string resultadoOperacion;
        private string resRegistro;
        string resConexionSensor;


        public RegistroDeHuella()
        {
            InitializeComponent();
        }

        private async void capturarHuella_Click(object sender, EventArgs e)
        {
            #region ----------CONECTA SENSOR---------
            LectorZKTecoSLK20R ConexionSensor = new LectorZKTecoSLK20R();
            this.resConexionSensor = ConexionSensor.ConnectDevice();
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
            LectorZKTecoSLK20R.bIsTimeToDie = false;
            LectorZKTecoSLK20R captura = new LectorZKTecoSLK20R();
            this.resultadoOperacion = captura.PreparaLectura();
            if (resultadoOperacion.Contains("Lista para obtener lectura"))
            {
                capturaHuella = new Thread(new ThreadStart(captura.AcquireFinger));
                capturaHuella.IsBackground = true;
                capturaHuella.Start();
            }
            string registrado = await EnrolandoHuella();
            if (registrado.Contains("Registro exitoso") && stopCapture.Enabled == false)
            {
                MessageBox.Show(LectorZKTecoSLK20R.fingerPrintTemplate); //Este string se debera de almacenar en la base de datos
            }
            else if (!registrado.Contains("Registro exitoso") && stopCapture.Enabled == false)
            {
                MessageBox.Show(registrado);
            }
            else if (!registrado.Contains("Registro exitoso") && stopCapture.Enabled == true)
            {
                MessageBox.Show("Se ha abortado el registro de huella");
            }
            else
            {
                MessageBox.Show("Se presento un error");
            }
            #endregion
        }

        private async Task<string> EnrolandoHuella()
        {
            string res = await Task.Run(ProcesandoRegistro);
            return res;
        }

        private string ProcesandoRegistro()
        {
            LectorZKTecoSLK20R.remainingCount = 3;
            LectorZKTecoSLK20R regProcess = new LectorZKTecoSLK20R();
            EstadoConexion.BackColor = Color.AliceBlue;
            while (LectorZKTecoSLK20R.remainingCount!=0)
            {
                EstadoConexion.Text = "Coloque el dedo " + LectorZKTecoSLK20R.remainingCount.ToString() + " veces mas para registrar el usuario";
                this.resRegistro = regProcess.Registrando();
                MessageBox.Show(resRegistro); //Para ver que regresa en cada ciclo
            }
            return this.resRegistro;
        }

        private void stopCapture_Click(object sender, EventArgs e)
        {
            int count = 0;
            while (true)
            {
                if (count>=3)
                {
                    MessageBox.Show("ERROR FATAL, FINALIZANDO EL PROGRAMA", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                LectorZKTecoSLK20R closeConexion = new LectorZKTecoSLK20R();
                this.resConexionSensor = closeConexion.CloseConnection();
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
            EstadoConexion.Text = "Dispositivo desconectado";
            EstadoConexion.BackColor = Color.Red;
            capturarHuella.Enabled = true;
            stopCapture.Enabled = false;
            LectorZKTecoSLK20R.remainingCount = 0;
            MessageBox.Show("Se ha cancelado el registro de huella dactilar");
            this.resRegistro = "";
        }
    }
}
