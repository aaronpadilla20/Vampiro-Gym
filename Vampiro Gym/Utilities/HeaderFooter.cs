﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampiro_Gym
{
    class HeaderFooter:PdfPageEventHelper
    {
        private string encabezado;
        private string piePagina;
        private string pathImage;
        public HeaderFooter(string encabezado,string piePagina,string pathImage)
        {
            this.encabezado = encabezado;
            this.piePagina = piePagina;
            this.pathImage = pathImage;
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            //Begin Image
            Image logo = Image.GetInstance(this.pathImage);
            logo.SetAbsolutePosition(Utilities.document.LeftMargin, writer.PageSize.GetTop(Utilities.document.TopMargin) + 2);
            logo.ScaleAbsolute(30f, 30f);
            //End Image

            //base.OnEndPage(writer, document);
            PdfPTable tbHeader = new PdfPTable(3);
            tbHeader.TotalWidth = Utilities.document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tbHeader.DefaultCell.Border = 0;

            PdfPCell _cell = new PdfPCell(logo);
            _cell.Border = 0;
            _cell.VerticalAlignment = Element.ALIGN_TOP;
            _cell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbHeader.AddCell(_cell);

            _cell = new PdfPCell(new Paragraph(this.encabezado));
            _cell.HorizontalAlignment = Element.ALIGN_CENTER;
            _cell.Border = 0;
            tbHeader.AddCell(_cell);

            tbHeader.AddCell(new Paragraph());

            tbHeader.WriteSelectedRows(0, -1, Utilities.document.LeftMargin, writer.PageSize.GetTop(Utilities.document.TopMargin) + 40, writer.DirectContent);

            PdfPTable tbFooter = new PdfPTable(3);
            tbFooter.TotalWidth = Utilities.document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tbFooter.DefaultCell.Border = 0;

            tbFooter.AddCell(new Paragraph());

            _cell = new PdfPCell(new Paragraph(this.piePagina));
            _cell.HorizontalAlignment = Element.ALIGN_CENTER;
            _cell.Border = 0;
            tbFooter.AddCell(_cell);

            _cell = new PdfPCell(new Paragraph("Pagina " + writer.PageNumber));
            _cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _cell.Border = 0;
            tbFooter.AddCell(_cell);

            tbFooter.WriteSelectedRows(0, -1, Utilities.document.LeftMargin, writer.PageSize.GetBottom(Utilities.document.BottomMargin) - 5, writer.DirectContent);

          
        }
    }
}
