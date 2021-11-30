using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    public partial class clientesForm : Form
    {
        private string query;
        private string nombre;
        private string apellido;
        private string tipoMembresia;
        private string fechaAlta;
        DateTime fechaVencimiento;
        DateTime fechaActual;
        private int diasRestantes;
        private int horasRestantes;
        private string resConsult;
        Image imagen;

        public clientesForm()
        {
            InitializeComponent();
        }

        private void altaClienteButton_Click(object sender, EventArgs e)
        {
            formMembresia nuevoCliente = new formMembresia();
            nuevoCliente.ShowDialog();
            if (formMembresia.clienteAlta)
            {
                CargaDatos();
            }
        }

        private void CargaDatos()
        {
            dtgvClientes.Rows.Clear();
            dataBaseControl consultaMembresia = new dataBaseControl();
            this.query = "SELECT * FROM Customers";
            try
            {
                SqlCommand command = new SqlCommand(query,dataBaseControl.connection);
                SqlDataReader filas = command.ExecuteReader();
                while (filas.Read())
                {
                    this.imagen = (Bitmap)((new ImageConverter()).ConvertFrom(filas.GetValue(1)));
                    this.nombre = filas.GetString(2).ToString();
                    this.apellido = filas.GetString(3).ToString();
                    this.tipoMembresia = filas.GetString(5).ToString();
                    this.fechaAlta = filas.GetString(6).ToString();
                    this.query = "SELECT DuracionMembresia FROM Membresias WHERE Tipo_de_membresia='" + tipoMembresia + "'";
                    this.resConsult=consultaMembresia.Select(query, 1);
                    this.resConsult = this.resConsult.TrimEnd(',');
                    this.fechaVencimiento = Convert.ToDateTime(fechaAlta);
                    this.fechaVencimiento = fechaVencimiento.AddDays(Int32.Parse(resConsult));
                    this.fechaActual = DateTime.Now;
                    this.diasRestantes = (fechaVencimiento - fechaActual).Days;
                    this.horasRestantes = (fechaVencimiento - fechaActual).Hours;
                    if (diasRestantes==0 && horasRestantes==0)
                    {
                        dtgvClientes.Rows.Add("", "", this.imagen,nombre,apellido,tipoMembresia,fechaAlta,"Membresia Vencida");
                    }
                    else if (diasRestantes==0 && horasRestantes!=0)
                    {
                        dtgvClientes.Rows.Add("", "", this.imagen, nombre, apellido, tipoMembresia, fechaAlta, "Quedan " + horasRestantes.ToString() + " horas para el vencimiento de la membresia");
                    }
                    else
                    {
                        dtgvClientes.Rows.Add("", "", this.imagen, nombre, apellido, tipoMembresia, fechaAlta, diasRestantes.ToString() + " días");
                    }
                    
                }
                filas.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha presentado el siguiente error al consultar la base de datos: " + err.Message);
            }
        }

        private void clientesForm_Load(object sender, EventArgs e)
        {
            dtgvClientes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvClientes.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvClientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvClientes.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvClientes.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvClientes.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvClientes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvClientes.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvClientes.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvClientes.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvClientes.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvClientes.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CargaDatos();
        }

        private void dtgvClientes_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Utilities printCell = new Utilities();
            printCell.CellPrinting(sender, e, "edit", "..\\Images\\editButton.ico");
            printCell.CellPrinting(sender, e, "delete", "..\\Images\\delete.ico");
        }
    }
}
