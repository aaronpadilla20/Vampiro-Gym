using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampiro_Gym
{
    class MembresiasVendidasPorEmpleado
    {
        string nombre;
        string tipoMembresia;
        string membershipCost;
        string soldQuantity;
        string totalCost;

        public MembresiasVendidasPorEmpleado(string nombre, string tipoMembresia, string membershipCost,string soldQuantity, string totalCost)
        {
            this.nombre = nombre;
            this.tipoMembresia = tipoMembresia;
            this.membershipCost = membershipCost;
            this.soldQuantity = soldQuantity;
            this.totalCost = totalCost;
        }

        public string getInfo
        {
            get { return nombre + "," + tipoMembresia + "," + membershipCost + "," + soldQuantity + "," + totalCost; }
        }
    }
}
