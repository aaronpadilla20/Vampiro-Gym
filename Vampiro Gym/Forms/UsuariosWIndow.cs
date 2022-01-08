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

    public partial class UsuariosWIndow : Form
    {
        private string tipoUsuario;
        private string nombre;
        private string apellido;
        private string correo;
        private string usuario;
        private string deletedUser;
        private DataTable dt;

        public UsuariosWIndow()
        {
            InitializeComponent();
        }

        private void altaClienteButton_Click(object sender, EventArgs e)
        {
            if (loginWindow.tipoUsuario == "Administrador" || loginWindow.tipoUsuario == "administrador")
            {
                usuarioRegistroForm newUser = new usuarioRegistroForm("alta","","","","","","","");
                newUser.ShowDialog();
                if (newUser.getInsertado)
                {
                    cargaDatos();
                }
            }
            else
            {
                MessageBox.Show("Error: solamente un usuario con privilegios de administrador puede dar de alta un nuevo usuario","Privilegios insuficientres",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void dtgvUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Utilerias paintDataGrid = new Utilerias();
            paintDataGrid.CellPrinting(sender, e, "edit", Properties.Resources.edit);
            paintDataGrid.CellPrinting(sender, e, "delete", Properties.Resources.delete);
        }

        private void UsuariosWIndow_Load(object sender, EventArgs e)
        {
            cargaDatos();
            columnComboBox.SelectedIndex = 0;

            dtgvUsuarios.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvUsuarios.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvUsuarios.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvUsuarios.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvUsuarios.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvUsuarios.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            dtgvUsuarios.Columns.Add(btnEditar);
            btnEditar.Name = "edit";
            btnEditar.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            dtgvUsuarios.Columns.Add(btnEliminar);
            btnEliminar.Name = "delete";
            btnEliminar.UseColumnTextForButtonValue = true;
        }

        private void dtgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            if (loginWindow.tipoUsuario == "Administrador")
            {
                if (dtgvUsuarios.Columns[e.ColumnIndex].Name == "edit")
                {
                    tipoUsuario = dtgvUsuarios.Rows[n].Cells[2].Value.ToString();
                    nombre = dtgvUsuarios.Rows[n].Cells[3].Value.ToString();
                    apellido = dtgvUsuarios.Rows[n].Cells[4].Value.ToString();
                    correo = dtgvUsuarios.Rows[n].Cells[5].Value.ToString();
                    usuario = dtgvUsuarios.Rows[n].Cells[6].Value.ToString();
                    string query = "SELECT Contrasena FROM Usuarios WHERE Usuario = '" + usuario + "'";
                    dataBaseControl getPassword = new dataBaseControl();
                    string password = getPassword.Select(query, 1);
                    password = password.Trim(',');
                    usuarioRegistroForm editUser = new usuarioRegistroForm("edicion",tipoUsuario,nombre,apellido,correo,usuario,password,password);
                    editUser.ShowDialog();
                    cargaDatos();
                }

                if (dtgvUsuarios.Columns[e.ColumnIndex].Name == "delete")
                {
                    deletedUser = dtgvUsuarios.Rows[e.RowIndex].Cells[6].Value.ToString();
                    DialogResult res = MessageBox.Show("¿Esta seguro de querer eliminar el usuario seleccionado?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        bool deleted = false;
                        try
                        {
                            string query = "DELETE FROM Usuarios WHERE Usuario='" + deletedUser + "'";
                            dataBaseControl deleteCommand = new dataBaseControl();
                            deleted = deleteCommand.Delete(query);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Se presento el siguiente problema al intentar eliminar el registro: " + err.Message);
                        }
                        if (deleted)
                        {
                            MessageBox.Show("Se elimino el usuario exitosamente", "Usuario eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargaDatos();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Solamente un usuario con privilegios de administrador puede editar o eliminar el registro", "Privilegios insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cargaDatos()
        {
            dt = new DataTable();
            dt.Columns.Add("Tipo_Usuario");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido");
            dt.Columns.Add("Correo");
            dt.Columns.Add("Usuario");
            string query = "SELECT * FROM Usuarios";
            try
            {
                dataBaseControl getInfo = new dataBaseControl();
                SqlDataReader filas = getInfo.getDataTable(query);
                while (filas.Read())
                {
                    tipoUsuario = filas.GetString(1);
                    nombre = filas.GetString(2);
                    apellido = filas.GetString(3);
                    correo = filas.GetString(4);
                    usuario = filas.GetString(6);
                    dt.Rows.Add(tipoUsuario, nombre, apellido, correo, usuario);
                }
                dtgvUsuarios.DataSource = dt;
                filas.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Se ha presentado el siguiente error al consultar la base de datos: " + ex.Message);
            }
        }

        private void botonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void valueTextBox_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", columnComboBox.Text, valueTextBox.Text);
        }
    }
}
