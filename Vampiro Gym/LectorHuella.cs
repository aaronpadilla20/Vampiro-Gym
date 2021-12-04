using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libzkfpcsharp;
using System.Threading;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    class LectorHuella
    {
        private const int REGISTER_FINGER_COUNT = 3;
        private int sensorResponse;
        private int nCount;
        private int size;
        private int mfpWidth = 0;
        private int mfpHeight = 0;
        private int fid;
        private int score;

        private static int deviceIndex;
        private static int cbCampTemp;
        private static int registerCount;
        private static int regTempLen;
        private static int iFid;
        public static int remainingCount;

        private static byte[][] regTemps = new byte[REGISTER_FINGER_COUNT][];
        private byte[] paramValue;

        private static byte[] FPBuffer;
        public static byte[] CampTemp;
        public static byte[] RegTemp;

        public static string mensajeCaptura;
        public static string fingerPrintTemplate;

        public static bool bIsTimeToDie = false;

        public static zkfp fpInstance;

        public string InitializeDevice()
        {
            fpInstance = new zkfp();
            this.sensorResponse = fpInstance.Initialize();
            if (zkfp.ZKFP_ERR_OK == this.sensorResponse)
            {
                nCount = fpInstance.GetDeviceCount();
                if (nCount > 0)
                {
                    for (int index = 1; index <= nCount; index++)
                    {
                        deviceIndex = index - 1;
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
                switch (sensorResponse)
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
            registerCount = 0;
            regTempLen = 0;
        }

        public string PreparaLectura()
        {
            fingerPrintTemplate = string.Empty;
            registerCount = 0;
            regTempLen = 0;
            iFid = 1;

            for (int i = 0; i < REGISTER_FINGER_COUNT; i++)
            {
                regTemps[i] = new byte[2048];
            }
            this.paramValue = new byte[4];
            this.size = 4;
            fpInstance.GetParameters(1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            this.size = 4;
            fpInstance.GetParameters(2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];
            CampTemp = new byte[2048];
            RegTemp = new byte[2048];
            cbCampTemp = 2048;

            return "Lista para obtener lectura";
        }

        public void AcquireFinger()
        {
            try
            {
                while (!bIsTimeToDie)
                {
                    cbCampTemp = 2048;
                    this.sensorResponse = fpInstance.AcquireFingerprint(FPBuffer, CampTemp, ref cbCampTemp);
                    if (this.sensorResponse == zkfp.ZKFP_ERR_OK)
                    {
                        mensajeCaptura = "Huella Capturada";
                    }
                    else
                    {
                        switch (sensorResponse)
                        {
                            case -23:
                                mensajeCaptura = "Sin comunicación con sensor activa, inicialice la comunicación e intentelo nuevamente";
                                break;
                            case -7:
                                mensajeCaptura = "El dispositivo seleccionado no soporta la lectura de huellas dactilares";
                                break;
                            default:
                                mensajeCaptura = "Se ha presentado un error desconocido, contacte al proveedor del lector para mayor información, el codigo de error es: " + sensorResponse.ToString();
                                break;

                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha presentado el siguiente error al intentar adquirir la huella dactilar: " + err.Message);
            }
        }

        public string Registrando()
        {
            this.fid = 0;
            this.score = 0;
            this.sensorResponse = fpInstance.Identify(CampTemp, ref this.fid, ref this.score);
            if (zkfp.ZKFP_ERR_OK == sensorResponse)
            {
                this.sensorResponse = fpInstance.DelRegTemplate(this.fid);
                if (this.sensorResponse != zkfp.ZKFP_ERR_OK)
                {
                    switch (this.sensorResponse)
                    {
                        case -24:
                            remainingCount = 0;
                            return "El lector de huellas no se encuentra inicializado";
                        default:
                            remainingCount = 0;
                            return "Se presento un error inesperado contacte al proveedor del lector de huellas, el codigo de error es: " + sensorResponse.ToString();
                    }
                }
            }

            if (registerCount > 0 && fpInstance.Match(CampTemp,regTemps[registerCount-1])<=0)
            {
                remainingCount = 0;
                return "Ya se ha ingresado tres veces la huella dactilar";
            }

            Array.Copy(CampTemp, regTemps[registerCount], cbCampTemp);
            registerCount++;

            if (registerCount >=REGISTER_FINGER_COUNT)
            {
                registerCount = 0;
                this.sensorResponse = fpInstance.GenerateRegTemplate(regTemps[0], regTemps[1], regTemps[2], RegTemp, ref regTempLen);
                if (this.sensorResponse == zkfp.ZKFP_ERR_OK)
                {
                    this.sensorResponse = fpInstance.AddRegTemplate(iFid, RegTemp);
                    if (sensorResponse == zkfp.ZKFP_ERR_OK)
                    {
                        zkfp.Blob2Base64String(RegTemp, regTempLen, ref fingerPrintTemplate);
                        return "Registro exitoso";
                    }
                    else
                    {
                        switch(sensorResponse)
                        {
                            case -24:
                                remainingCount = 0;
                                return "No se encuentra inicializado el sensor de huellas dactilares";
                            case -7:
                                remainingCount = 0;
                                return "El dispositivo seleccionado no tiene capacidad de lector de huellas, verifiquelo e intentelo nuevamente";
                            default:
                                remainingCount = 0;
                                return "Se ha presentado un error desconocido al intentar registrar la huella dactilar, contacte al proveedor del sensor, el codigo de error es: " + sensorResponse.ToString();
                        }
                    }
                }
                else
                {
                    switch (this.sensorResponse)
                    {
                        case -24:
                            remainingCount = 0;
                            return "El lector de huellas no se encuentra inicializado";
                        case -7:
                            remainingCount = 0;
                            return "El dispositivo seleccionado no tiene la capacidad de lector de huellas, verifiquelo e intentlo nuevamente";
                        default:
                            remainingCount = 0;
                            return "Se ha presentado un error desconocido al intentar enrolar la huella dactilar, contacte al proveedor del sensor, el codigo de error es: " + sensorResponse.ToString();
                    }
                }
            }
            else
            {
                remainingCount = REGISTER_FINGER_COUNT - registerCount;
                return "Por favor coloque su huella dactilar " + remainingCount.ToString() + "veces mas";
            }
        }
    }
}
