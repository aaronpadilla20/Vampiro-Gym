using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampiro_Gym
{
    public class historialMembresias
    {
        string fechaAlta;
        string tipoMembresia;
        string fechaVencimiento;
        string comment;
        public historialMembresias(string fechaAlta, string tipoMembresia, string fechaVencimiento,string comment)
        {
            this.fechaAlta = fechaAlta;
            this.tipoMembresia = tipoMembresia;
            this.fechaVencimiento = fechaVencimiento;
            this.comment = comment;
        }
        public string Registro
        {
            get{ return fechaAlta + "," + tipoMembresia + "," + fechaVencimiento + "," + comment; }
        }
    }
}
