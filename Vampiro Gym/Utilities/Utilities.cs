using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Vampiro_Gym
{
    class Utilities
    {
        public static Document document;
        public void ReportePdfIndividual(string carpetaReporte, string nombreArchivo, string encabezado,string footer,string[] datos)
        {
            FileStream fs = new FileStream("..\\Reportes\\"+carpetaReporte+"\\"+nombreArchivo+DateTime.Now.ToString("dd_MM_yyyy")+".pdf",FileMode.Create);
            document = new Document(iTextSharp.text.PageSize.LETTER,30f,20f,50f,40f);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);
            pw.PageEvent = new HeaderFooter(encabezado, footer, "..\\Images\\logo (2).png");

            document.Open();
            PdfPTable table = new PdfPTable(5);
            foreach(string dato in datos)
            {
                PdfPCell _cell = new PdfPCell(new Paragraph(dato));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(_cell);
            }
            document.Add(table);
            document.Close();
        }

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

        public void CellPrinting(object sender, DataGridViewCellPaintingEventArgs e,string columna,System.Drawing.Icon icon)
        {
            DataGridView datagrid = sender as DataGridView;
            if (e.ColumnIndex >= 0 && datagrid.Columns[e.ColumnIndex].Name == columna && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell editButton = datagrid.Rows[e.RowIndex].Cells[columna] as DataGridViewButtonCell;
                e.Graphics.DrawIcon(icon, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                datagrid.Rows[e.RowIndex].Height = icon.Height + 8;
                datagrid.Columns[e.ColumnIndex].Width = icon.Width + 8;

                e.Handled = true;
            }
        }

        public bool validaEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email) ? true : false;
        }
    }
}
