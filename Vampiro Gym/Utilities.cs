using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Vampiro_Gym
{
    class Utilities
    {
        public void comboBoxDrawing(object sender,DrawItemEventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                e.DrawBackground();
                if (e.Index >= 0)
                {
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    Brush brush = new SolidBrush(cbx.ForeColor);
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }

        public void CellPrinting(object sender, DataGridViewCellPaintingEventArgs e,string columna,string pathFirstButton)
        {
            DataGridView datagrid = sender as DataGridView;
            if (e.ColumnIndex >= 0 && datagrid.Columns[e.ColumnIndex].Name == columna && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell editButton = datagrid.Rows[e.RowIndex].Cells[columna] as DataGridViewButtonCell;
                Icon icoEdit = new Icon(pathFirstButton);
                e.Graphics.DrawIcon(icoEdit, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                datagrid.Rows[e.RowIndex].Height = icoEdit.Height + 8;
                datagrid.Columns[e.ColumnIndex].Width = icoEdit.Width + 8;

                e.Handled = true;
            }
        }

        public bool validaEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email) ? true : false;
        }
    }
}
