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
    public partial class membresiasForm : Form
    {
        private const string TABLA = "Membresias";
        public static string tipoMembresia;
        public static string duracionMembresia;
        public static string costoMembresia;

        private string membershipType;
        private string membershipDuration;
        private string membershipCost;
        private string deletingMembership;

        private string query;
        private bool deleted;

        public membresiasForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            addingMembreshipForm registro = new addingMembreshipForm("creacion");
            registro.ShowDialog();
            // Esto se debe de reemplazar por la query a la base de datos y cargar desde la base la información
            if (addingMembreshipForm.created)
            {
                CargaDatos();
            }
                
        }

        private void dtgvMembresias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            dibujaButton("edit","..\\Images\\editButton.ico",e);
            dibujaButton("delete","..\\Images\\delete.ico",e);
        }

        private void dibujaButton(string name, string path, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgvMembresias.Columns[e.ColumnIndex].Name == name && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell editButton = this.dtgvMembresias.Rows[e.RowIndex].Cells[name] as DataGridViewButtonCell;
                Icon icoEdit = new Icon(path);
                e.Graphics.DrawIcon(icoEdit, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgvMembresias.Rows[e.RowIndex].Height = icoEdit.Height + 8;
                this.dtgvMembresias.Columns[e.ColumnIndex].Width = icoEdit.Width + 8;

                e.Handled = true;
            }
        }

        private void membresiasForm_Load(object sender, EventArgs e)
        {
            if (loginWindow.tipoUsuario != "Administrador")
                agregarMembresiaButton.Enabled = false;
            dtgvMembresias.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvMembresias.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvMembresias.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvMembresias.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvMembresias.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvMembresias.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CargaDatos();
        }

        private void dtgvMembresias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            if (loginWindow.tipoUsuario == "Administrador")
            {
                if (this.dtgvMembresias.Columns[e.ColumnIndex].Name == "edit")
                {
                    tipoMembresia = dtgvMembresias.Rows[n].Cells[2].Value.ToString();
                    duracionMembresia = dtgvMembresias.Rows[n].Cells[3].Value.ToString();
                    costoMembresia = dtgvMembresias.Rows[n].Cells[4].Value.ToString();
                    addingMembreshipForm editaValor = new addingMembreshipForm("edicion");
                    editaValor.ShowDialog();
                    CargaDatos();
                }

                if (this.dtgvMembresias.Columns[e.ColumnIndex].Name == "delete")
                {
                    this.deletingMembership = dtgvMembresias.Rows[e.RowIndex].Cells[2].Value.ToString();
                    DialogResult res = MessageBox.Show("¿Esta seguro de querer eliminar la membresia?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            this.query = "DELETE FROM " + TABLA + " WHERE Tipo_de_membresia='" + this.deletingMembership + "'";
                            dataBaseControl deleteCommand = new dataBaseControl();
                            this.deleted = deleteCommand.Delete(query);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Se presento el siguiente problema al intentar eliminar el registro: " + err.Message);
                        }
                        if (deleted)
                        {
                            MessageBox.Show("Se elimino la membresia exitosamente", "Membresia eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargaDatos();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Solamente un usuario con privilegios de administrador puede editar o eliminar el registro", "Privilegios insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargaDatos()
        {
            dtgvMembresias.Rows.Clear();
            this.query = "SELECT * FROM " + TABLA;
            try
            {
                SqlCommand command = new SqlCommand(query, dataBaseControl.connection);
                SqlDataReader filas = command.ExecuteReader();
                while (filas.Read())
                {
                    membershipType = filas.GetString(0).ToString();
                    membershipDuration = filas.GetInt32(1).ToString();
                    membershipCost = filas.GetDecimal(2).ToString();
                    dtgvMembresias.Rows.Add("","",membershipType,Convert.ToString(membershipDuration) + " días","$ " + Convert.ToString(membershipCost));
                }
                filas.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha presentado el siguiente error al consultar la base de datos: " + err.Message);
            }
            
        }
    }
}
