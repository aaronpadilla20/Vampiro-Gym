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

                LectorZKTecoSLK20R conexionLector = new LectorZKTecoSLK20R();
                lectorZKTecok30 = new LectorZKTecok30();

                string resConexionLector = conexionLector.InitializeDevice(); //Realiza conexion con el lector de huellas
                if (!resConexionLector.Contains("Inicializacion exitosa"))
                {
                    MessageBox.Show("Se ha presentado el siguiente error al intentar inicializar el lector de huellas: " + resConexionLector, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                int ret = lectorZKTecok30.ConnectTCP();
                if (LectorZKTecok30.isConnected)
                {
                    lectorZKTecok30.getBiometricType();
                }
                if (ret!=1)
                {
                    MessageBox.Show("Se ha presentado un error al conectarse con el dispositivo", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
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
                ret = getCapacityInfo();
                if (ret !=1)
                {
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
                #endregion
                Invoke(new Action(() => progressBar1.Value = 80));
                Thread.Sleep(1000);
                Invoke(new Action(() => instructionLabel.Text = "Ejercicio completado"));
                Invoke(new Action(() => progressBar1.Value = 100));
                Thread.Sleep(1000);
            }
        }

        private int getDeviceInfo()
        {
            string sFirmver = "";
            string sIP = "";
            string sMac = "";
            string sPlatform = "";
            string sSN = "";
            string sProductTime = "";
            string sDeviceName = "";
            int iFPAlg = 0;
            int iFaceAlg = 0;
            string sProducter = "";
            int res = lectorZKTecok30.GetDeviceinfo(out sFirmver, out sIP, out sMac, out sPlatform, out sSN, out sProductTime, out sDeviceName, out iFPAlg, out iFaceAlg, out sProducter);
            if (res ==1)
            {
                MessageBox.Show("Conexion exitosa con el dispositivo " + sDeviceName + " el cual se encuentra conectado a la ip " + sIP,"Conexion exitosa",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return 1;
            }
            else
            {
                return -1024;
            }
        }
        private int getCapacityInfo()
        {
            int adminCnt = 0;
            int userCount = 0;
            int fpCnt = 0;
            int recordCnt = 0;
            int pwdCnt = 0;
            int oplogCnt = 0;
            int faceCnt = 0;
            int res =lectorZKTecok30.GetCapacityinfo(out adminCnt, out userCount, out fpCnt, out recordCnt, out pwdCnt, out oplogCnt, out faceCnt);
            return res;
        }
    }
}
