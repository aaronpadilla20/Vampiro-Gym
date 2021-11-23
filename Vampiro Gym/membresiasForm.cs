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
    public partial class membresiasForm : Form
    {
        public static string tipoMembresia;
        public static string duracionMembresia;
        public static string costoMembresia;
        public membresiasForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            addingMembreshipForm registro = new addingMembreshipForm("creacion");
            registro.ShowDialog();
            // Esto se debe de reemplazar por la query a la base de datos y cargar desde la base la información
            if (addingMembreshipForm.validado)
            {
                int n = dtgvMembresias.Rows.Add();
                dtgvMembresias.Rows[n].Cells[2].Value = addingMembreshipForm.tipoMembresia;
                dtgvMembresias.Rows[n].Cells[3].Value = addingMembreshipForm.duracionMembresia + " días";
                dtgvMembresias.Rows[n].Cells[4].Value = "$ " + addingMembreshipForm.costo;
                addingMembreshipForm.validado = false;
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
    
            dtgvMembresias.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvMembresias.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvMembresias.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvMembresias.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvMembresias.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvMembresias.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dtgvMembresias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            if (this.dtgvMembresias.Columns[e.ColumnIndex].Name == "edit")
            {
                tipoMembresia = dtgvMembresias.Rows[n].Cells[2].Value.ToString();
                duracionMembresia = dtgvMembresias.Rows[n].Cells[3].Value.ToString();
                costoMembresia = dtgvMembresias.Rows[n].Cells[4].Value.ToString();
                addingMembreshipForm editaValor = new addingMembreshipForm("edicion");
                editaValor.ShowDialog();
                if (addingMembreshipForm.validado)
                {
                    dtgvMembresias.Rows[n].Cells[2].Value = addingMembreshipForm.tipoMembresia;
                    dtgvMembresias.Rows[n].Cells[3].Value = addingMembreshipForm.duracionMembresia + " días";
                    dtgvMembresias.Rows[n].Cells[4].Value = "$ " + addingMembreshipForm.costo;
                    addingMembreshipForm.validado = false;
                }
            }

            if (this.dtgvMembresias.Columns[e.ColumnIndex].Name == "delete")
            {
                DialogResult res = MessageBox.Show("¿Esta seguro de querer eliminar la membresia?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    dtgvMembresias.Rows.RemoveAt(n);
            }
        }
    }
}
