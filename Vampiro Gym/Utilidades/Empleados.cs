using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampiro_Gym
{
    class Empleados
    {
        string nombre;

        public Empleados(string nombre)
        {
            this.nombre = nombre;
        }

        public string getEmployeeName
        {
            get { return nombre; }
        }
    }
}
