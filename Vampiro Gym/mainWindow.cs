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
    public partial class formMain : Form
    {
        private Form activeform = null;
        public formMain()
        {
            InitializeComponent();
        }

        public void openChild(Form childForm)
        {
            MessageBox.Show(childForm.Name);
            if (activeform != null)
            {
                activeform.Close();
            }
            activeform = childForm;
            activeform.TopLevel = false;
            activeform.FormBorderStyle = FormBorderStyle.None;
            activeform.Dock = DockStyle.Fill;
            panelContenedorForm.Controls.Add(activeform);
            panelContenedorForm.Tag = activeform;
            activeform.BringToFront();
            activeform.Show();
        }

        private void botonClose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea cerrar la aplicación?", "Cerrando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
                Application.Exit();
        }

        private void membresias_Click(object sender, EventArgs e)
        {
            openChild(new membresiasForm());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openChild(new usuarioRegistroForm());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openChild(new clientesForm());
        }
    }
}
