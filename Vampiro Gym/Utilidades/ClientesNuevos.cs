using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampiro_Gym
{
    class ClientesNuevos
    {
        string name;
        string membershipType;
        string startDate;
        string endDate;

        public ClientesNuevos(string name, string membershipType, string startDate, string endDate)
        {
            this.name = name;
            this.membershipType = membershipType;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public string getCustomerInfo
        {
            get { return name + "," + membershipType + "," + startDate + "," + endDate; }
        }
    }
}
