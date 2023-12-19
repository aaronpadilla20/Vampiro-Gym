using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zkemkeeper;

namespace Vampiro_Gym
{
    public class LectorZKTecok30
    {
        public zkemkeeper.CZKEM lector = new zkemkeeper.CZKEM();

        public static bool isConnected = false;
        public static string fingerPrintTemplate = "";
        private static int iMachineNumber = 1;
        private int idwErrorCode;

        private SupportBiometricType _supportBiometricType = new SupportBiometricType();

        private string _biometricType = string.Empty;

        public int ConnectDevice()
        {
            this.idwErrorCode = 0;
            if (isConnected)
            {
                lector.Disconnect();
                isConnected = false;
                return -2;
            }
            
            if (lector.Connect_Net("192.168.1.80",4370))
            {
                isConnected = true;
                return 1;
            }
            else
            {
                lector.GetLastError(ref this.idwErrorCode);
                return this.idwErrorCode;
            }
        }

        public void Disconnect()
        {
            isConnected = false;
            lector.Disconnect();
        }
       
        public int GetDeviceInfo(out string sIP)
        {
            int ret = 0;
            sIP = "";
            lector.GetDeviceIP(iMachineNumber, sIP);
            ret = 1;
            return ret;
        }

        public int SetUser(string customerID, string customerName)
        {
            lector.EnableDevice(iMachineNumber, false);
            if (!lector.SSR_SetUserInfo(iMachineNumber,customerID.ToString().Trim(),customerName.Trim()," ",0,true))
            {
                while (true)
                {
                    DialogResult res = MessageBox.Show("Se ha presentado un error durante el registro del cliente, intentelo nuevamente", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    if (res == DialogResult.Retry)
                    {
                        if(lector.SSR_SetUserInfo(iMachineNumber, customerID.ToString().Trim(), customerName.Trim(), " ", 0, true))
                        {
                            lector.EnableDevice(iMachineNumber, true);
                            return 1;
                        }
                    }
                    else
                    {
                        lector.EnableDevice(iMachineNumber, true);
                        return -1024;
                    }
                }
            }
            else
            {
                lector.EnableDevice(iMachineNumber, true);
                return 1;
            }
        }

        public int SetFingerPrintTemplate(string customerID,string fingerPrintTemplate)
        {
            int res = 0;
            lector.GetConnectStatus(ref idwErrorCode);
            if (idwErrorCode ==-1)
            {
                if(lector.Connect_Net("192.168.1.80", 4370))
                {
                    MessageBox.Show("ok");
                }
            }
            lector.EnableDevice(iMachineNumber, false);
            if(lector.SetUserTmpExStr(iMachineNumber,customerID,0,1,fingerPrintTemplate))
            {
                lector.EnableDevice(iMachineNumber, true);
                return 1;
            }
            else
            {
                lector.EnableDevice(iMachineNumber, true);
                return -1024;
            }
        }

        public int DelFingerPrintTemplate(string customerIDs)
        {
            string[] customers = customerIDs.Split(',');
            foreach(string customer in customers)
            {
                if (customer!="")
                {
                    if (lector.SSR_DelUserTmpExt(iMachineNumber, customer, 0))
                    {
                        lector.RefreshData(iMachineNumber);
                    }
                    else
                    {
                        MessageBox.Show("Se ha presentado un problema al intentar eliminar al usuario con membresia invalida contacte al desarrollador de la aplicacion","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return -1024;
                    }
                }
            }
            return 1;
        }

        public int OverwriteAction()
        {
            if (lector.RegEvent(iMachineNumber, 65535))
            {
                this.lector.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(verificationPassed);
                return 1;
            }
            else
            {
                return -1024;
            }
        }

        private void verificationPassed(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            lector.PlayVoiceByIndex(0);
            lector.EnableDevice(iMachineNumber, false);
            fingerPrintTemplate = "";
            int tempLenght = 0;
            int flag = 0;
            lector.GetUserTmpExStr(iMachineNumber, EnrollNumber, 0, out flag, out fingerPrintTemplate, out tempLenght);
        }

        public string getFingerPrintTemplate()
        {
            if (fingerPrintTemplate!="")
            {
                fingerPrintTemplate = fingerPrintTemplate.Substring(0,fingerPrintTemplate.Length - 8);
            }
            return fingerPrintTemplate;
        }
    }
}
