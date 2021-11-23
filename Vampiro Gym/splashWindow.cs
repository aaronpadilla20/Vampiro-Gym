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
                conexion.abrir();
                Invoke(new Action(() => progressBar1.Value = 20));
                Thread.Sleep(1000);
                Invoke(new Action(() => instructionLabel.Text = "Ejercitando con mancuernas"));
                Invoke(new Action(() => progressBar1.Value = 40));
                Thread.Sleep(1000);
                Invoke(new Action(() => instructionLabel.Text = "Ejercitando barra en pecho"));
                Invoke(new Action(() => progressBar1.Value = 60));
                Thread.Sleep(1000);
                Invoke(new Action(() => instructionLabel.Text = "Haciendo cristos"));
                Invoke(new Action(() => progressBar1.Value = 80));
                Thread.Sleep(1000);
                Invoke(new Action(() => instructionLabel.Text = "Ejercicio completado"));
                Invoke(new Action(() => progressBar1.Value = 100));
                Thread.Sleep(1000);
            }
        }
    }
}
