using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Vampiro_Gym
{
    public partial class takePictureForm : Form
    {
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        Thread camera;
        bool isCameraRunning;
        public string file;
        protected string name;
        protected string lastName;

        public takePictureForm(string name, string lastName)
        {
            InitializeComponent();
            this.name = name;
            this.lastName = lastName;
        }

        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {
            try
            {
                while(true)
                {
                    frame = new Mat();
                    capture = new VideoCapture();
                    capture.Open(0);

                    if (capture.IsOpened())
                    {
                        button1.Text = "Detener";
                        button2.Text = "Guardar";
                        isCameraRunning = true;
                        Thread.Sleep(1000);
                        while (isCameraRunning)
                        {
                            capture.Read(frame);
                            image = BitmapConverter.ToBitmap(frame);
                            if (pictureBox1.Image != null)
                            {
                                pictureBox1.Image.Dispose();
                            }
                            pictureBox1.Image = image;
                        }
                        break;
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Tiene conectada una web cam a la PC?", "Verificando Conexion de web cam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            continue;
                        }
                        else
                        {
                            MessageBox.Show("Imposible capturar imagen en tiempo real si no tiene conectada una web cam, cerrando ventana", "Cerrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Imposible inicializar web cam, verifique que tenga conectada una al sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Tomar Foto"))
            {
                CaptureCamera();
            }
            else
            {
                capture.Release();
                button1.Text = "Tomar Foto";
                button2.Text = "Cancelar";
                isCameraRunning = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text.Equals("Cancelar"))
            {
                if (pictureBox1.Image != null)
                    pictureBox1.Image = null;
                this.Close();
            }
            else
            {
                file = "..\\Images\\"+name+"_"+lastName+"_"+DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss")+".png";
                Bitmap snapshot = new Bitmap(pictureBox1.Image);
                snapshot.Save(string.Format(file), ImageFormat.Png);
                isCameraRunning = false;
                capture.Release();
                MessageBox.Show("Se ha guardado la imagen exitosamente");
                this.Close();
            }
        }
    }
}
