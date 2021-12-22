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
    public partial class generalReportWindow : Form
    {
        public generalReportWindow()
        {
            InitializeComponent();
        }

        private void pictureBoxIpl1_Click(object sender, EventArgs e)
        {
            DateTime fromDateValue = fromDate.Value;
            TimeSpan fromTs = new TimeSpan(7, 00, 00);
            fromDateValue = fromDateValue.Date + fromTs;

            DateTime toDateValue = toDate.Value;
            TimeSpan toTs = new TimeSpan(23, 00, 00);
            toDateValue = toDateValue.Date + toTs;

        }
    }
}
