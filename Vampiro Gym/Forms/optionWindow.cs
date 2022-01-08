using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    public partial class OptionWindow : Form
    {
        string selectedOption;
        public OptionWindow()
        {
            InitializeComponent();
        }

        public string getOpcion
        {
            get { return this.selectedOption; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea cerrar sesión?", "Cerrando sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.selectedOption = "sesion";
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Deseas cerra la aplicación?", "Cerrando aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.selectedOption = "app";
                this.Close();
            }
        }
    }
}
