﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    public partial class clientesForm : Form
    {
        
        private string nombreDb;
        private string apellidoDb;
        private string tipoMembresiaDb;
        private string query;
        private string fechaAltaDb;
        private string resConsult;
        private string deletingNombre;
        private string deletingApellido;
        private string nombre;
        private string apellido;
        private string tipoMembresia;
        private string miembroDesde;
        private string fechaRenovacion;
        private string fechaAlta;
        private string[] datosReporte;
        private string remainingDays;

        private bool deleted;
        Image imagen;

        private int diasRestantes;
        private int horasRestantes;

        private Bitmap imageArray;
        DataGridViewImageCell imagenData;
        Image imagenCliente;
      
        DateTime fechaVencimiento;
        DateTime fechaActual;

        public clientesForm()
        {
            InitializeComponent();
        }

        private void altaClienteButton_Click(object sender, EventArgs e)
        {
            formMembresia nuevoCliente = new formMembresia("alta",Properties.Resources.noPhotoAvailable,"","","");
            nuevoCliente.ShowDialog();
            if (formMembresia.operacionExitosa)
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
                    this.nombreDb = filas.GetString(2).ToString();
                    this.apellidoDb = filas.GetString(3).ToString();
                    this.tipoMembresiaDb = filas.GetString(5).ToString();
                    this.fechaAltaDb = filas.GetString(6).ToString();
                    this.query = "SELECT DuracionMembresia FROM Membresias WHERE Tipo_de_membresia='" + this.tipoMembresiaDb + "'";
                    this.resConsult=consultaMembresia.Select(query, 1);
                    this.resConsult = this.resConsult.TrimEnd(',');
                    this.fechaVencimiento = Convert.ToDateTime(this.fechaAltaDb);
                    this.fechaVencimiento = fechaVencimiento.AddDays(Int32.Parse(resConsult));
                    this.fechaActual = DateTime.Now;
                    this.diasRestantes = (fechaVencimiento - fechaActual).Days;
                    this.horasRestantes = (fechaVencimiento - fechaActual).Hours;
                    if (diasRestantes==0 && horasRestantes==0)
                    {
                        dtgvClientes.Rows.Add("", "","",this.imagen,this.nombreDb,this.apellidoDb,this.tipoMembresiaDb,this.fechaAltaDb,"Membresia Vencida");
                    }
                    else if (diasRestantes==0 && horasRestantes!=0)
                    {
                        dtgvClientes.Rows.Add("", "","",this.imagen,this.nombreDb, this.apellidoDb,this.tipoMembresiaDb,this.fechaAltaDb, "Quedan " + this.horasRestantes.ToString() + " horas para el vencimiento de la membresia");
                    }
                    else
                    {
                        dtgvClientes.Rows.Add("", "","",this.imagen,this.nombreDb,this.apellidoDb,this.tipoMembresiaDb, this.fechaAltaDb,this.diasRestantes.ToString() + " días");
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
            printCell.CellPrinting(sender, e, "edit", Properties.Resources.edit);
            printCell.CellPrinting(sender, e, "delete",Properties.Resources.delete);
        }

        private void dtgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            if (loginWindow.tipoUsuario == "Administrador")
            {
                if (this.dtgvClientes.Columns[e.ColumnIndex].Name == "edit")
                {
                    this.imagenData = dtgvClientes.Rows[n].Cells[3] as DataGridViewImageCell;
                    this.imageArray = (Bitmap)imagenData.Value;
                    imagenCliente = byteArrayToImage(this.imageArray);
                    this.nombre = dtgvClientes.Rows[n].Cells[4].Value.ToString();
                    this.apellido = dtgvClientes.Rows[n].Cells[5].Value.ToString();
                    this.tipoMembresia = dtgvClientes.Rows[n].Cells[6].Value.ToString();
                    formMembresia editaValor = new formMembresia("edicion",imagenCliente,this.nombre,this.apellido,this.tipoMembresia);
                    editaValor.ShowDialog();
                    if (formMembresia.operacionExitosa)
                        CargaDatos();
                }

                if (this.dtgvClientes.Columns[e.ColumnIndex].Name == "delete")
                {
                    this.deletingNombre = dtgvClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
                    this.deletingApellido = dtgvClientes.Rows[e.RowIndex].Cells[5].Value.ToString();
                    DialogResult res = MessageBox.Show("¿Esta seguro de querer eliminar al cliente seleccionado?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            this.query = "DELETE FROM Customers WHERE Nombre='" + this.deletingNombre + "' AND Apellido='" + this.deletingApellido + "'";
                            dataBaseControl deleteCommand = new dataBaseControl();
                            this.deleted = deleteCommand.Delete(query);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Se presento el siguiente problema al intentar eliminar el registro: " + err.Message);
                        }
                        if (deleted)
                        {
                            MessageBox.Show("Se ha eliminado el cliente exitosamente", "Cliente eliminad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargaDatos();
                        }
                    }
                }

                if (this.dtgvClientes.Columns[e.ColumnIndex].Name=="report")
                {
                    this.nombre = dtgvClientes.Rows[n].Cells[4].Value.ToString();
                    this.apellido = dtgvClientes.Rows[n].Cells[5].Value.ToString();
                    this.tipoMembresia = dtgvClientes.Rows[n].Cells[6].Value.ToString();
                    this.miembroDesde = dtgvClientes.Rows[n].Cells[7].Value.ToString();
                    this.remainingDays = dtgvClientes.Rows[n].Cells[8].Value.ToString();
                    this.remainingDays = this.remainingDays.Substring(0, 2); //Validar 
                    this.diasRestantes = Int32.Parse(this.remainingDays);
                    this.fechaVencimiento = Convert.ToDateTime(this.miembroDesde);
                    this.fechaVencimiento = this.fechaVencimiento.AddDays(this.diasRestantes + 1);
                    this.datosReporte = new string[5];
                    this.datosReporte[0] = this.nombre;
                    this.datosReporte[1] = this.apellido;
                    this.datosReporte[2] = this.tipoMembresia;
                    this.datosReporte[3] = this.miembroDesde;
                    this.datosReporte[4] = this.fechaVencimiento.ToString();
                    Utilities reporte = new Utilities();
                    reporte.ReportePdfIndividual("clientes", this.nombre + " " + this.apellido,"Información de " + this.nombre + " " + this.apellido,"Vampiro Gym",this.datosReporte);
                }
            }
            else
            {
                MessageBox.Show("Solamente un usuario con privilegios de administrador puede editar o eliminar el registro", "Privilegios insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Image byteArrayToImage(Bitmap bitMapIn)
        {
            Image returnImage = (Image)bitMapIn;
            return returnImage;
        }
    }
}
