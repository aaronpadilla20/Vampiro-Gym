using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampiro_Gym
{
    class membershipTypes
    {
        string membershipType;
        public membershipTypes(string membershipType)
        {
            this.membershipType = membershipType;
        }
        public string getMembershipTypeInfo
        {
            get { return this.membershipType; }
        }
    }
}
