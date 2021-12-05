using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zkemkeeper;

namespace Vampiro_Gym.SDKs_Lectores
{
    public class LectorZKTecok30
    {
        public zkemkeeper.CZKEM lector = new zkemkeeper.CZKEM();

        public static bool isConnected = false;
        private static int iMachineNumber = 1;
        private int idwErrorCode;

        private SupportBiometricType _supportBiometricType = new SupportBiometricType();

        private string _biometricType = string.Empty;

        public int ConnectTCP()
        {
            this.idwErrorCode = 0;
            lector.SetCommPassword(0);

            if (isConnected)
            {
                lector.Disconnect();
                isConnected = false;
                return -2;
            }

            if (lector.Connect_Net("192.168.1.80",4370))
            {
                isConnected = true;
                RegRealTime();
                getBiometricType();
                return 1;
            }
            else
            {
                lector.GetLastError(ref this.idwErrorCode);
                return idwErrorCode;
            }
        }

        public void getBiometricType()
        {
            string result = string.Empty;
            result = getSysOptions("BiometricType");
            if (!string.IsNullOrEmpty(result))
            {
                _supportBiometricType.fp_available = result[1] == '1';
                _supportBiometricType.face_available = result[2] == '1';
                if (result.Length>9)
                {
                    _supportBiometricType.fingerVein_available = result[7] == '1';
                    _supportBiometricType.palm_available = result[8] == '1';
                }
            }
            _biometricType = result;
        }

        public int GetCapacityinfo(out int adminCnt, out int userCount, out int fpCnt, out int recordCnt, out int pwdCnt, out int oplogCnt, out int faceCnt)
        {
            int ret = 0;

            adminCnt = 0;
            userCount = 0;
            fpCnt = 0;
            recordCnt = 0;
            pwdCnt = 0;
            oplogCnt = 0;
            faceCnt = 0;

            if (!isConnected)
            {
                MessageBox.Show("Es necesario conectar el dispositivo ZKTecok30 para obtener información desde el dispositivo", "Dispositivo no inicializado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1024;
            }

            lector.EnableDevice(iMachineNumber, false);//disable the device

            lector.GetDeviceStatus(iMachineNumber, 2, ref userCount);
            lector.GetDeviceStatus(iMachineNumber, 1, ref adminCnt);
            lector.GetDeviceStatus(iMachineNumber, 3, ref fpCnt);
            lector.GetDeviceStatus(iMachineNumber, 4, ref pwdCnt);
            lector.GetDeviceStatus(iMachineNumber, 5, ref oplogCnt);
            lector.GetDeviceStatus(iMachineNumber, 6, ref recordCnt);
            lector.GetDeviceStatus(iMachineNumber, 21, ref faceCnt);

            lector.EnableDevice(iMachineNumber, true);//enable the device

            ret = 1;
            return ret;
        }

        public int GetDeviceinfo(out string sFirmver, out string sIP,out string sMac, out string sPlatform, out string sSN, out string sProductTime, out string sDeviceName, out int iFPAlg, out int iFaceAlg, out string sProducter)
        {
            int iRet = 0;

            sFirmver = "";
            sIP = "";
            sMac = "";
            sPlatform = "";
            sSN = "";
            sProducter = "";
            sDeviceName = "";
            iFPAlg = 0;
            iFaceAlg = 0;
            sProductTime = "";
            string strTemp = "";

            if (!isConnected)
            {
                MessageBox.Show("Es necesario establecer comunicación con el dispositivo ZKTecok30 previo a adquirir información del dispositivo", "Dispositivo no conectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1024;
            }

            lector.EnableDevice(iMachineNumber, false);//disable the device

            lector.GetSysOption(iMachineNumber, "~ZKFPVersion", out strTemp);
            iFPAlg = Convert.ToInt32(strTemp);

            lector.GetSysOption(iMachineNumber, "ZKFaceVersion", out strTemp);
            iFaceAlg = Convert.ToInt32(strTemp);

            /*
            axCZKEM1.GetDeviceInfo(GetMachineNumber(), 72, ref iFPAlg);
            axCZKEM1.GetDeviceInfo(GetMachineNumber(), 73, ref iFaceAlg);
            */

            lector.GetVendor(ref sProducter);
            lector.GetProductCode(iMachineNumber, out sDeviceName);
            lector.GetDeviceMAC(iMachineNumber, ref sMac);
            lector.GetFirmwareVersion(iMachineNumber, ref sFirmver);

            /*
            if (sta_GetDeviceType() == 1)
            {
                axCZKEM1.GetDeviceFirmwareVersion(GetMachineNumber(), ref sFirmver);
            }
             */
            //lblOutputInfo.Items.Add("[func GetDeviceFirmwareVersion]Temporarily unsupported");

            lector.GetPlatform(iMachineNumber, ref sPlatform);
            lector.GetSerialNumber(iMachineNumber, out sSN);
            lector.GetDeviceStrInfo(iMachineNumber, 1, out sProductTime);
            lector.GetDeviceIP(iMachineNumber, ref sIP);
            lector.EnableDevice(iMachineNumber, true);//enable the device

            iRet = 1;
            return iRet;
        }

        private string getSysOptions(string option)
        {
            string value = string.Empty;
            lector.GetSysOption(iMachineNumber, option, out value);
            return value;
        }

        public int RegRealTime()
        {
            if (!isConnected)
            {
                return -1024;
            }

            int ret = 0;

            if (lector.RegEvent(iMachineNumber, 65535))
            {
                this.lector.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(lector_OnFinger);
                this.lector.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(lector_OnVerify);
                this.lector.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(lector_OnFingerFeature);
                this.lector.OnDeleteTemplate += new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(lector_OnDeleteTemplate);
                this.lector.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(lector_OnNewUser);
                ret = 1;
            }
            else
            {
                lector.GetLastError(ref this.idwErrorCode);
                ret = this.idwErrorCode;

                if (this.idwErrorCode!=0)
                {

                }
                else
                {

                }
            }
            return ret;
        }
       

        void lector_OnNewUser(int EnrollNumber)
        {

        }
        void lector_OnDeleteTemplate(int EnrollNumber,int FingerIndex)
        {

        }

        void lector_OnFingerFeature(int Score)
        {
            throw new NotImplementedException();
        }
        void lector_OnVerify(int UserID)
        {
            if (UserID != -1)
            {
                //Codigo 
            }
            else
            {
                //Codigo
            }
            throw new NotImplementedException();
        }

        void lector_OnFinger()
        {

        }
    }
}
