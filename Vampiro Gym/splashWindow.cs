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
                }
                Invoke(new Action(() => progressBar1.Value = 20));
                Thread.Sleep(1000);
                Invoke(new Action(() => instructionLabel.Text = "Ejercitando con mancuernas"));
                #region --REGION DE INICIALIZACION DE LECTOR DE HUELLA DACTILAR --
                LectorHuella conexionLector = new LectorHuella();
                string resConexionLector = conexionLector.InitializeDevice(); //Realiza conexion con el lector de huellas
                if (!resConexionLector.Contains("Inicializacion exitosa"))
                {
                    MessageBox.Show("Se ha presentado el siguiente error al intentar inicializar el lector de huellas: " + resConexionLector, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                #endregion
                Invoke(new Action(() => progressBar1.Value = 40));
                Thread.Sleep(1000);
                Invoke(new Action(() => instructionLabel.Text = "Ejercitando barra en pecho"));
                #region --REGION DE APERTURA DE COMUNICACION CON LECTOR DE HUELLA DACTILAR --
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
                #region --REGION DE CIERRE DE COMUNICACION CON LECTOR DE HUELLA DACTILAR --
                resConexionLector = conexionLector.CloseConnection();
                if (!resConexionLector.Contains("Comunicación cerrada exitosamente"))
                {
                    MessageBox.Show("Se ha presentado el siguiente error al intentar cerra la comunicación con el sensor de huellas: " + resConexionLector,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
    }
}
