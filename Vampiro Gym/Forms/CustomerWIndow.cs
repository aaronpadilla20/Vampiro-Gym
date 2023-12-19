using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym.Forms
{
    public partial class CustomerWIndow : Form
    {
        private Image imagen;
        private string name;
        private string lastName;
        private string membershipType;
        private string fechaInicio;

        public CustomerWIndow(Image imagen,string name, string lastName, string membershipType,string startDate)
        {
            InitializeComponent();
            this.imagen = imagen;
            this.name = name;
            this.lastName = lastName;
            this.membershipType = membershipType;
            this.fechaInicio = startDate;
        }

        private void CustomerWIndow_Load(object sender, EventArgs e)
        {
            nameLabel.Text = this.name;
            membershipTypeLabel.Text = this.membershipType;
            startDate.Text = this.fechaInicio;
            customerImage.Image = this.imagen;

            string query = "SELECT DuracionMembresia FROM Membresias WHERE Tipo_de_membresia='" + membershipType + "'";
            string membershipDuration = "";
            dataBaseControl consultMembership = new dataBaseControl();
            try
            {
                membershipDuration = consultMembership.Select(query, 1);
                membershipDuration = membershipDuration.TrimEnd(',');
            }
            catch (Exception err)
            {
                MessageBox.Show("Se presento el siguiente error al consultar la base de datos: " + err.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DateTime fechaVencimiento = Convert.ToDateTime(this.fechaInicio);
            fechaVencimiento = fechaVencimiento.AddDays(Int32.Parse(membershipDuration));

            DateTime fechaActual = DateTime.Now;
            int remainingDays = (fechaVencimiento - fechaActual).Days;
            int remainingHours = (fechaVencimiento - fechaActual).Hours;

            if (remainingDays <= 0 && remainingHours <= 0)
            {
                statusCustomerImage.Image = Properties.Resources.invalidCustomer;   
            }
            else if (remainingDays <= 0 && remainingHours != 0)
            {
                statusCustomerImage.Image = Properties.Resources.lastDay;
            }
            else
            {
                statusCustomerImage.Image = Properties.Resources.validCustomer;
                updateUserButton.Visible = false;
                deleteUserButton.Visible = false;
            }

            this.TopMost = true;
        }
    }
}
