using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zkemkeeper;

namespace Vampiro_Gym.SDKs_Lectores
{
    class SupportBiometricType
    {
        public bool fp_available { get; set; }
        public bool face_available { get; set; }
        public bool fingerVein_available { get; set; }
        public bool palm_available { get; set; }
    }
}
