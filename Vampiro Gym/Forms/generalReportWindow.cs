using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
            if (commentsTextBox.Text != "")
            {
                DialogResult res = MessageBox.Show("Desea generar un reporte general desde el día " + fromDate.Text + " hasta el día " + toDate.Text + " con el siguiente comentario: " + commentsTextBox.Text+"?", "Generando reporte", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                commentsTextBox.Enabled = true;
                fromDate.Enabled = true;
                toDate.Enabled = true;
                if (res == DialogResult.Yes)
                {
                    DateTime fromDateValue = fromDate.Value;
                    TimeSpan fromTs = new TimeSpan(7, 00, 00);
                    fromDateValue = fromDateValue.Date + fromTs;

                    DateTime toDateValue = toDate.Value;
                    TimeSpan toTs = new TimeSpan(23, 00, 00);
                    toDateValue = toDateValue.Date + toTs;

                    Utilerias generateReport = new Utilerias();
                    var (resGenerationReport,ruta) = generateReport.generalReport(fromDateValue, toDateValue, commentsTextBox.Text);
                    if (!resGenerationReport.Contains("El reporte se ha generado exitosamente"))
                    {
                        MessageBox.Show(resGenerationReport, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(resGenerationReport, "Reporte generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        res = MessageBox.Show("¿Desea visualizar el reporte generado?", "Visualizar archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            Process.Start(ruta);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Si desea visualizar el archivo posteriormente vaya a la siguiente dirección" + ruta);
                            this.Close();
                        }
                    }
                }

                if (res == DialogResult.No)
                {
                    DialogResult resQuestion = MessageBox.Show("Desea ingresar un comentario diferente?", "Corrija comentario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resQuestion == DialogResult.Yes)
                    {
                        commentsTextBox.Text = "";
                        fromDate.Enabled = false;
                        toDate.Enabled = false;
                    }
                    else
                    {
                        DialogResult resQuestion2 = MessageBox.Show("Desea elegir un periodo de tiempo diferente?", "Selección de tiempo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resQuestion2 == DialogResult.Yes)
                        {
                            commentsTextBox.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Se ha abortado la generación del reporte del cliente");
                            this.Close();
                            return;
                        }
                    }
                }

                if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("Se ha abortado la generación del reporte general");
                    this.Close();
                    return;
                }
            }
        }
    }
}
