using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampiro_Gym
{
    class SystemSupportMail : MasterEmailServer
    {
        public SystemSupportMail()
        {
            senderMail = "soportevampirogym@gmail.com";
            password = "VampiroAdmin";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            initializeSmtpClient();
        }
    }
}
