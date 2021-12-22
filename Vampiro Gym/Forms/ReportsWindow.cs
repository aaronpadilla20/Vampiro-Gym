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
    public partial class ReportsWindow : Form
    {
        public ReportsWindow()
        {
            InitializeComponent();
        }

        private void botonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customerReport_Click(object sender, EventArgs e)
        {
            customerReportWindow customerReport = new customerReportWindow();
            customerReport.ShowDialog();
        }

        private void generalReport_Click(object sender, EventArgs e)
        {
            generalReportWindow generalReportWindow = new generalReportWindow();
            generalReportWindow.ShowDialog();
        }
    }
}
