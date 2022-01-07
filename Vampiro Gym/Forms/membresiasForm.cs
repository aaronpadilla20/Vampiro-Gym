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
        private DataTable dt;

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
            Utilerias paintDataGrid = new Utilerias();
            paintDataGrid.CellPrinting(sender, e, "edit", Properties.Resources.edit);
            paintDataGrid.CellPrinting(sender, e, "delete",Properties.Resources.delete);
        }

        private void membresiasForm_Load(object sender, EventArgs e)
        {
            CargaDatos();
            columnaComboBox.SelectedIndex = 0;
            if (loginWindow.tipoUsuario != "Administrador")
                agregarMembresiaButton.Enabled = false;
            dtgvMembresias.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvMembresias.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvMembresias.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvMembresias.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvMembresias.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvMembresias.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            dtgvMembresias.Columns.Add(btnEditar);
            btnEditar.Name = "edit";
            btnEditar.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            dtgvMembresias.Columns.Add(btnEliminar);
            btnEliminar.Name = "delete";
            btnEliminar.UseColumnTextForButtonValue = true;
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
                        this.query = "SELECT Nombre,Apellido FROM Customers WHERE TIpo_de_membresia='" + deletingMembership + "'";
                        dataBaseControl deleteMembership = new dataBaseControl();
                        string membresiaAsignada = deleteMembership.Select(query, 2);
                        if (!membresiaAsignada.Contains("La consulta no genero resultados"))
                        {
                            MessageBox.Show("Imposible eliminar este tipo de membresia ya que actualmente se encuentra asignada al menos a 1 cliente","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }
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
            dt = new DataTable();
            dt.Columns.Add("Membresias");
            dt.Columns.Add("Duracion");
            dt.Columns.Add("Precio");
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
                    dt.Rows.Add(membershipType, Convert.ToString(membershipDuration) + " días", "$ " + Convert.ToString(membershipCost));
                    //dtgvMembresias.Rows.Add("","",membershipType,Convert.ToString(membershipDuration) + " días","$ " + Convert.ToString(membershipCost));
                }
                dtgvMembresias.DataSource = dt;
                filas.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Se ha presentado el siguiente error al consultar la base de datos: " + err.Message);
            }
            
        }

        private void botonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void valueTextBox_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", columnaComboBox.Text, valueTextBox.Text);
        }
    }
}
