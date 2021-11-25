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
        public static string fingerPrintTemplate; //Template a almacenar en base de datos
        private int registerCount; //Contador para registro
        private int cbCapTmp = 2048;
        private int ret;
        private byte[] CapTmp = new byte[2048]; //Capturador de huella dactilar
        private bool bIsTimeToDie = false;
        Thread captureThread; //Hilo para leer constantemente la huella


        public RegistroDeHuella()
        {
            InitializeComponent();
        }

        private void capturarHuella_Click(object sender, EventArgs e)
        {
            capturarHuella.Enabled = false;
            stopCapture.Enabled = true;
        }

        private void DoCapture()
        {
            try
            {
                while (!bIsTimeToDie)
                {
                    cbCapTmp = 2048;
                    //ret = splashWindow.fpInstance.AcquireFingerprint();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha presentado el siguiente error al intentar leer la huella: " + err.Message);
            }
        }
    }
}
