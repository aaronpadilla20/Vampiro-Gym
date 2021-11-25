using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libzkfpcsharp;

namespace Vampiro_Gym
{
    class Utilities
    {
        private const int REGISTER_FINGER_COUNT = 3;
        private int sensorResponse;
        private int nCount;
        private int registerCount;
        private int regTempLen;
        private int iFid;
        private int size;
        private int mfpWidth = 0;
        private int mfpHeight = 0;

        private byte[][] regTemps = new byte [REGISTER_FINGER_COUNT][];
        private byte[] paramValue;
        private byte[] FPBuffer;

        public static int deviceIndex;
        public static zkfp fpInstance;

        public string InitializeDevice()
        {
            fpInstance = new zkfp();
            this.sensorResponse = fpInstance.Initialize();
            if (zkfp.ZKFP_ERR_OK == this.sensorResponse)
            {
                nCount = fpInstance.GetDeviceCount();
                if (nCount >0)
                {
                    for (int index = 1;index<=nCount;index++)
                    {
                        deviceIndex = index;
                    }
                }
                return "Inicializacion exitosa";
            }
            else
            {
                switch (sensorResponse)
                {
                    case 1:
                        return "El dispositivo se encuentra inicializado";
                    case -1:
                        return "Problema al inicializar el dispositivo, verifique la correcta conexion del mismo con el equipo de computo";
                    default:
                        return "Se ha presentado un error desconocido al intentar inicializar el lector, contacte al proveedor del lector para mas información\nEl error presentado tiene el codigo: " + sensorResponse.ToString();
                }
            }
        }

        public string ConnectDevice()
        {
            this.sensorResponse = fpInstance.OpenDevice(deviceIndex);
            if (zkfp.ZKFP_ERR_OK != this.sensorResponse)
            {
                switch (this.sensorResponse)
                {
                    case -25:
                        return "El lector de huellas esta siendo utilizado por otra aplicación cierrela e intentelo de nuevo";
                    case -6:
                        return "Se presento un error al momento de crear la comunicación con el lector de huellas, intentelo nuevamente";
                    default:
                        return "Error desconocido contacte al proveedor del lector para mayor informacion, el codigo de error es: " + this.sensorResponse.ToString();
                }
            }
            else
            {
                return "Conexion exitosa";
            }
        }

        public string CloseConnection()
        {
            this.sensorResponse = fpInstance.CloseDevice();
            if (sensorResponse == zkfp.ZKFP_ERR_OK)
            {
                return "Comunicación cerrada exitosamente";  
            }
            else
            {
                switch(sensorResponse)
                {
                    case -23:
                        return "Imposible cerrar la comunicación debido a que no existe una comunicación activa";
                    default:
                        return "Se ha presentado un error inesperado al intentar cerrar la comunicación el codigo de error es: " + sensorResponse.ToString();
                }
            }
        }

        public string FinalizaSesion()
        {
            this.sensorResponse = fpInstance.Finalize();
            if (this.sensorResponse == zkfp.ZKFP_ERR_OK)
            {
                clearVariables();
                return "Comunicacion cerrada con exito";
            }
            else
            {
                switch (sensorResponse)
                {
                    default:
                        return "Se ha presentado un error inesperado al intentar finalizar la sesion por favor contacte al proveedor del lector de huellas, el codigo devuelto es " + sensorResponse.ToString();
                }
            }
        }

        private void clearVariables()
        {
            this.registerCount = 0;
            this.regTempLen = 0;
        }

        public string PreparaLectura()
        {
            this.registerCount = 0;
            this.regTempLen = 0;
            this.iFid = 1;

            for (int i = 0; i < REGISTER_FINGER_COUNT; i++)
            {
                this.regTemps[i] = new byte[2048];
            }
            this.paramValue = new byte[4];
            this.size = 4;
            fpInstance.GetParameters(1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            this.size = 4;
            fpInstance.GetParameters(2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            this.FPBuffer = new byte[mfpWidth * mfpHeight];

            return "Lista para obtener lectura";
        }
        public void comboBoxDrawing(object sender,DrawItemEventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                e.DrawBackground();
                if (e.Index >= 0)
                {
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    Brush brush = new SolidBrush(cbx.ForeColor);
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }

        public bool validaEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email) ? true : false;
        }
    }
}
