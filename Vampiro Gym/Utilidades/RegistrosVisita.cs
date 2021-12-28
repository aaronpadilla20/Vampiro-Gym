using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampiro_Gym
{
    class RegistrosVisita
    {
        string fechaVisita;
        string tipoMembresia;
        string comment;

        public RegistrosVisita(string fechaVisita, string tipoMembresia, string comment)
        {
            this.fechaVisita = fechaVisita;
            this.tipoMembresia = tipoMembresia;
            this.comment = comment;
        }

        public string getRegistroInfo
        {
            get { return fechaVisita + "," + tipoMembresia + "," + comment;  }
        }
    }
}
