using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampiro_Gym
{
    class SoldMemberships
    {
        string membershipType;
        string membershipCost;
        string soldQuantity;
        string totalCost;

        public SoldMemberships(string membershipType, string membershipCost, string soldQuantity, string totalCost)
        {
            this.membershipType = membershipType;
            this.membershipCost = membershipCost;
            this.soldQuantity = soldQuantity;
            this.totalCost = totalCost;
        }

        public string getSoldMembershipsInfo
        {
            get { return this.membershipType + "," + this.membershipCost + "," + this.soldQuantity + "," + this.totalCost; }
        }
    }
}
