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
    public partial class customerReportWindow : Form
    {
        public customerReportWindow()
        {
            InitializeComponent();
        }

        private void customerReportWindow_Load(object sender, EventArgs e)
        {
            string query = "SELECT Nombre,Apellido FROM Customers";
            dataBaseControl consultCustomerTable = new dataBaseControl();
            string resQuery = consultCustomerTable.Select(query, 2);
            string[] datos = resQuery.Split(',');
            string nombre = "";
            string apellido = "";
            string nombreCompleto = "";
            foreach (string dato in datos)
            {
                if (nombre=="")
                {
                    nombre = dato;
                    continue;
                }
                if (apellido=="")
                {
                    apellido = dato;
                }

                if (nombreCompleto=="")
                {
                    nombreCompleto = nombre + " " + apellido;
                    customerName.Items.Add(nombreCompleto);
                    nombre = "";
                    apellido = "";
                    nombreCompleto = "";
                    continue;
                }
            }
        }

        private void customerName_Click(object sender, EventArgs e)
        {
            customerName.Texts = "";
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (customerName.Texts.Length!=0 && !customerName.Texts.Contains("--"))
            {
                if (commentTextBox.Text == "")
                {
                    DialogResult res = MessageBox.Show("No se ha ingresado un comentario, ¿Desea generar el reporte sin comentarios?", "Reporte sin comentarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        generaReporte("Sin comentarios");
                    }
                    else
                    {
                        customerName.Enabled = false;
                        fromDate.Enabled = false;
                        toDate.Enabled = false;
                    }
                }
                else
                {
                    generaReporte(commentTextBox.Text);
                }
            }
            else
            {
                if (customerName.Texts.Contains("--") || customerName.Texts.Contains(""))
                {
                    MessageBox.Show("Es necesario seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
            }
        }

        private void generaReporte(string comentario)
        {
            DialogResult res = MessageBox.Show("Desea generar el reporte del cliente " + customerName.Texts + " desde la fecha " + fromDate.Text + " hasta la fecha " + toDate.Text + " y agregar el comentario " + comentario + "?", "Generando Reporte", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            toDate.Enabled = true;
            fromDate.Enabled = true;
            customerName.Enabled = true;
            commentTextBox.Enabled = true;
            if (res == DialogResult.Yes)
            {
                DateTime fromDateValue = fromDate.Value;
                TimeSpan fromTs = new TimeSpan(00, 00, 00);
                fromDateValue = fromDateValue.Date + fromTs;


                DateTime toDateValue = toDate.Value;
                TimeSpan toTs = new TimeSpan(23, 00, 00);
                toDateValue = toDateValue.Date + toTs;

                Utilerias generateReport = new Utilerias();
                var (resGenerationReport, ruta) = generateReport.customerReport(fromDateValue, toDateValue, customerName.Texts, commentTextBox.Text);
                if (!resGenerationReport.Contains("El reporte se ha generado exitosamente"))
                {
                    MessageBox.Show(resGenerationReport, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(resGenerationReport, "Reporte generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    res = MessageBox.Show("¿Desea visualizar el reporte generado?", "Visualiza reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        Process.Start(ruta);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Si desea visualizar el reporte posteriormente navegue a la direccion " + ruta);
                        this.Close();
                    }
                }
            }

            if (res == DialogResult.No)
            {
                DialogResult resQuestion = MessageBox.Show("Desea generar el reporte para un cliente diferente?", "Selecciona otro cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resQuestion == DialogResult.Yes)
                {
                    customerName.Texts = "";
                    fromDate.Enabled = false;
                    toDate.Enabled = false;
                    commentTextBox.Enabled = false;
                }
                else
                {
                    DialogResult resQuestion2 = MessageBox.Show("Desea elegir un periodo de tiempo diferente?", "Selección de tiempo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resQuestion2 == DialogResult.Yes)
                    {
                        customerName.Enabled = false;
                        commentTextBox.Enabled = false;
                    }
                    else
                    {
                        DialogResult resQuestion3 = MessageBox.Show("Desea cambiar el comentario?", "Modifique Comentario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resQuestion3 == DialogResult.Yes)
                        {
                            commentTextBox.Text = "";
                            customerName.Enabled = false;
                            fromDate.Enabled = false;
                            toDate.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Se ha abortado la generación del reporte del cliente");
                            this.Close();
                            return;
                        }
                    }
                }
            }

            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("Se ha abortado la generación del reporte del cliente");
                this.Close();
                return;
            }
        }
    }
}
