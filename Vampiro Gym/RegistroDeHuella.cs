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


        public RegistroDeHuella()
        {
            InitializeComponent();
        }

        private async void capturarHuella_Click(object sender, EventArgs e)
        {
            capturarHuella.Enabled = false;
            stopCapture.Enabled = true;
            LectorHuella.bIsTimeToDie = false;
            LectorHuella captura = new LectorHuella();
            this.resultadoOperacion = captura.PreparaLectura();
            if (resultadoOperacion.Contains("Lista para obtener lectura"))
            {
                capturaHuella = new Thread(new ThreadStart(captura.AcquireFinger));
                capturaHuella.IsBackground = true;
                capturaHuella.Start();
            }
        }
    }
}
