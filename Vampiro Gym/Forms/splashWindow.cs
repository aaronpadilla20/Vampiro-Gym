using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Vampiro_Gym
{
    public partial class splashWindow : Form
    {
        protected bool loadedSystem;
        loginWindow login = new loginWindow();
        LectorZKTecok30 lectorZKTecok30;



        public splashWindow()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            loadedSystem = await loadSystem();
            if (loadedSystem)
            {
                this.Hide();
                login.Show();
            }
        }

        private async Task<bool> loadSystem()
        {
            await Task.Run(loading);
            return true;
        }

        private void loading()
        {    
            if (InvokeRequired)
            {
                Invoke(new Action(() => this.Show()));
                Invoke(new Action(() => instructionLabel.Text = "Calentando"));
                dataBaseControl conexion = new dataBaseControl();
                string resConexion = conexion.abrir();
                if (!resConexion.Contains("Conexion exitosa"))
                {
                    MessageBox.Show("Se ha presentado el siguiente error al intentar conectar con la base de datos: " + resConexion);
                    Application.Exit();
                }
                Invoke(new Action(() => progressBar1.Value = 20));
                Thread.Sleep(1000);
                Invoke(new Action(() => instructionLabel.Text = "Ejercitando con mancuernas"));

                #region --REGION DE INICIALIZACION DE LECTORES DE HUELLA --
               
                RegistroDeHuella conexionLector = new RegistroDeHuella();
                lectorZKTecok30 = new LectorZKTecok30();

                string resConexionLector = conexionLector.InitializeDevice(); //Realiza conexion con el lector de huellas
                if (!resConexionLector.Contains("Inicializacion exitosa"))
                {
                    MessageBox.Show("Se ha presentado el siguiente error al intentar inicializar el lector de huellas: " + resConexionLector, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                string clearIDs = consultaClientes();
                if (clearIDs.Contains("Error"))
                {
                    Application.Exit();
                }
                int ret = lectorZKTecok30.ConnectDevice();
                if (ret!=1)
                {
                    MessageBox.Show("Se ha presentado un error al conectarse con el dispositivo", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                if (clearIDs!="")
                {
                    lectorZKTecok30.DelFingerPrintTemplate(clearIDs);
                }
                #endregion
                Invoke(new Action(() => progressBar1.Value = 40));
                Thread.Sleep(1000);
                Invoke(new Action(() => instructionLabel.Text = "Ejercitando barra en pecho"));

                #region --REGION DE APERTURA DE COMUNICACION CON LECTORES DE HUELLA DACTILAR --
                resConexionLector = conexionLector.ConnectDevice();
                if (!resConexionLector.Contains("Conexion exitos"))
                {
                    MessageBox.Show("Se ha presentado el siguiente error al intentar establecer comunicacion con el lector de huellas: " + resConexionLector, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                #endregion
                Invoke(new Action(() => progressBar1.Value = 60));
                Thread.Sleep(1000);
                Invoke(new Action(() => instructionLabel.Text = "Haciendo cristos"));

                #region --REGION DE CIERRE DE COMUNICACION CON LECTOR DE HUELLA DACTILAR Y OBTENCION DE DATOS DE LECTOR K30 --
                resConexionLector = conexionLector.CloseConnection();
                if (!resConexionLector.Contains("Comunicación cerrada exitosamente"))
                {
                    MessageBox.Show("Se ha presentado el siguiente error al intentar cerra la comunicación con el sensor de huellas: " + resConexionLector,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Application.Exit();
                }
                ret = getDeviceInfo();
                if (ret != 1)
                {
                    Application.Exit();
                }
                lectorZKTecok30.Disconnect();
                #endregion
                Invoke(new Action(() => progressBar1.Value = 80));
                Thread.Sleep(1000);
                Invoke(new Action(() => instructionLabel.Text = "Ejercicio completado"));
                Invoke(new Action(() => progressBar1.Value = 100));
                Thread.Sleep(1000);
            }
        }

        private string consultaClientes()
        {
            string customerIDs = "";
            DateTime currentDate = DateTime.Now;
            string query = "SELECT * FROM Customers";
            try
            {
                SqlCommand command = new SqlCommand(query, dataBaseControl.connection);
                SqlDataReader filas = command.ExecuteReader();
                while(filas.Read())
                {
                    string startDate = filas.GetString(6);
                    query = "SELECT DuracionMembresia FROM Membresias WHERE Tipo_de_membresia='" + filas.GetString(5) + "'";
                    dataBaseControl consultMembership = new dataBaseControl();
                    string membershipDuration = consultMembership.Select(query, 1);
                    membershipDuration = membershipDuration.TrimEnd(',');
                    DateTime endDate = Convert.ToDateTime(startDate);
                    endDate = endDate.AddDays(Int32.Parse(membershipDuration));
                    int remainingDays = (endDate - currentDate).Days;
                    int remainingHours = (endDate - currentDate).Hours;
                    if (remainingDays<=0 && remainingHours<=0)
                    {
                        customerIDs += filas.GetValue(0).ToString() + ",";
                    }
                }
                return customerIDs;
            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha presentado el siguiente error al consultar la base de datos: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }

        }
       
        private int getDeviceInfo()
        {
            string sIP = "";
            int res = lectorZKTecok30.GetDeviceInfo(out sIP);
            if (res ==1)
            {
                return 1;
            }
            else
            {
                return -1024;
            }
        }
    }
}
