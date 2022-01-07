using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Vampiro_Gym
{
    class Utilerias
    {
        public static Document document;
        private bool GenerateGeneralPDF(List<SoldMemberships> listSoldMemberships, List<ClientesProximosVencer> listCustomersCloseToEnd, List<ClientesNuevos> listNewCustomers,DateTime fromDate, DateTime toDate, string comments)
        {
            string tipoReporte = "";
            string ruta = Directory.GetCurrentDirectory();
            string archivo = "Reporte general_" + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf";
            if (!Directory.Exists(ruta + "\\Reportes\\General\\")) Directory.CreateDirectory(ruta + "\\Reportes\\General");
            FileStream fs = new FileStream(ruta + "\\Reportes\\General\\" + archivo, FileMode.Create);
            document = new Document(iTextSharp.text.PageSize.LETTER, 30f, 20f, 50f, 40f);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);
            DateTime now = DateTime.Now;
            int daysPassed = (toDate - fromDate).Days;
            if (daysPassed>=2 && daysPassed <=7)
            {
                tipoReporte = "Semanal";
            }
            else if(daysPassed >=8 && daysPassed <=15)
            {
                tipoReporte = "Quincenal";
            }
            else if(daysPassed >= 16 && daysPassed<=30)
            {
                tipoReporte = "Mensual";
            }
            else if(daysPassed >= 31 && daysPassed <=60)
            {
                tipoReporte = "BiMensual";
            }
            else if(daysPassed >=150 && daysPassed <=360)
            {
                tipoReporte = "Anual";
            }
            else
            {
                tipoReporte = "Rango no especificado";
            }
            pw.PageEvent = new HeaderFooter("Reporte General " + tipoReporte, "Vampiro Gym", ruta + "\\Resources\\logo.png");
            document.Open();
            Paragraph soldMembership = new Paragraph("MEMBRESIAS VENDIDAS EN EL PERIODO");
            soldMembership.SpacingAfter = 20;
            soldMembership.Alignment = 1;
            document.Add(soldMembership);
            PdfPTable table = new PdfPTable(4);
            iTextSharp.text.Font tHeader = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12f, iTextSharp.text.Font.BOLD, new BaseColor(148, 40, 74));
            var tipoMembresia = new PdfPCell(new Phrase("Tipo de membresia", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var costoMembresia = new PdfPCell(new Phrase("Costo de membresia", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var cantidadMembresiasVendidas = new PdfPCell(new Phrase("Cantidad de membresias vendidas", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var gananciaTotal = new PdfPCell(new Phrase("Ganancia Total", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            table.AddCell(tipoMembresia);
            table.AddCell(costoMembresia);
            table.AddCell(cantidadMembresiasVendidas);
            table.AddCell(gananciaTotal);

            foreach(SoldMemberships soldMembershipValue in listSoldMemberships)
            {
                string[] datos = soldMembershipValue.getSoldMembershipsInfo.Split(',');
                foreach(string dato in datos)
                {
                    PdfPCell _cell = new PdfPCell(new Paragraph(dato)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(_cell);
                }
            }
            document.Add(table);

            Paragraph customerCloseToEnd = new Paragraph("MEMBRESIAS PROXIMAS A VENCER");
            customerCloseToEnd.SpacingBefore = 15;
            customerCloseToEnd.SpacingAfter = 20;
            customerCloseToEnd.Alignment = 1;
            document.Add(customerCloseToEnd);

            PdfPTable table2 = new PdfPTable(4);
            var customerName = new PdfPCell(new Phrase("Nombre del cliente", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var membershipType = new PdfPCell(new Phrase("Tipo de membresia", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var startDate = new PdfPCell(new Phrase("Fecha de alta de membresia", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var endDate = new PdfPCell(new Phrase("Fecha de vencimiento de membresia", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            table2.AddCell(customerName);
            table2.AddCell(membershipType);
            table2.AddCell(startDate);
            table2.AddCell(endDate);

            foreach (ClientesProximosVencer cliente in listCustomersCloseToEnd)
            {
                string[] datos = cliente.getCustomerInfo.Split(',');
                foreach (string dato in datos)
                {
                    PdfPCell _cell = new PdfPCell(new Paragraph(dato)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table2.AddCell(_cell);
                }
            }

            document.Add(table2);

            Paragraph newCustomer = new Paragraph("CLIENTES NUEVOS");
            newCustomer.SpacingBefore = 15;
            newCustomer.SpacingAfter = 20;
            newCustomer.Alignment = 1;
            document.Add(newCustomer);

            PdfPTable table3 = new PdfPTable(4);
            var customerName2 = new PdfPCell(new Phrase("Nombre del cliente", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var membershipType2 = new PdfPCell(new Phrase("Tipo de membresia", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var startDate2 = new PdfPCell(new Phrase("Fecha de alta de membresia", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var endDate2 = new PdfPCell(new Phrase("Fecha de vencimiento de membresia", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            table3.AddCell(customerName2);
            table3.AddCell(membershipType2);
            table3.AddCell(startDate2);
            table3.AddCell(endDate2);

            foreach (ClientesNuevos cliente in listNewCustomers)
            {
                string[] datos = cliente.getCustomerInfo.Split(',');
                foreach (string dato in datos)
                {
                    PdfPCell _cell = new PdfPCell(new Paragraph(dato)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table3.AddCell(_cell);
                }
            }

            document.Add(table3);

            Paragraph commentHeader = new Paragraph("COMENTARIOS");
            commentHeader.SpacingBefore = 15;
            commentHeader.SpacingAfter = 15;
            commentHeader.Alignment = 1;
            document.Add(commentHeader);

            Paragraph comment = new Paragraph(comments);
            comment.Alignment = 1;
            document.Add(comment);
            document.Close();
            return true;
        }

        private bool GenerateCustomerPDF(List<historialMembresias> historialMembresias, List<RegistrosVisita> historialVisitas,System.Drawing.Image image, string memberSinceValue, string currentMembershipType,string name, string lastName )
        {
            DateTime fechaAltaClienteValue = Convert.ToDateTime(memberSinceValue);
            string fechaAlta = fechaAltaClienteValue.Day.ToString() + "/" + fechaAltaClienteValue.Month.ToString() + "/" + fechaAltaClienteValue.Year.ToString(); 
            string archivo = name + "_" + lastName + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf";
            string ruta = Directory.GetCurrentDirectory();
            if (!Directory.Exists(ruta + "\\Reportes\\Clientes\\")) Directory.CreateDirectory(ruta + "\\Reportes\\Clientes\\");
            FileStream fs = new FileStream(ruta + "\\Reportes\\Clientes\\" + archivo, FileMode.Create);
            document = new Document(iTextSharp.text.PageSize.LETTER, 30f, 20f, 50f, 40f);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);
            pw.PageEvent = new HeaderFooter("Reporte de cliente", "Vampiro Gym",ruta + "\\Resources\\logo.png");
            PdfWriter imageW = PdfWriter.GetInstance(document, new FileStream("image.pdf", FileMode.Create));
            document.Open();
            iTextSharp.text.Image customerImage = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
            customerImage.ScalePercent(70);
            float positionX = (document.PageSize.Width - customerImage.ScaledWidth) / 2;
            float positionY = (document.PageSize.Height - customerImage.ScaledHeight / 2);
            customerImage.SetAbsolutePosition(positionX+10f, positionY-document.TopMargin-70f);
            document.Add(customerImage);
            Paragraph customerName = new Paragraph("Nombre del cliente: " + name + " " + lastName);
            customerName.SpacingBefore = 135;
            customerName.Alignment = 0;
            document.Add(customerName);
            Paragraph membershipType = new Paragraph("Tipo de membresia activa: " + currentMembershipType);
            membershipType.SpacingBefore = 15;
            membershipType.Alignment = 0;
            document.Add(membershipType);
            Paragraph memberSice = new Paragraph("Miembro desde: " + fechaAlta);
            memberSice.SpacingBefore = 15;
            memberSice.Alignment = 0;
            document.Add(memberSice);

            Paragraph membershipsHistory = new Paragraph("HISTORIAL DE MEMBRESIAS");
            membershipsHistory.SpacingBefore = 20;
            membershipsHistory.SpacingAfter = 20;
            membershipsHistory.Alignment = 1;
            document.Add(membershipsHistory);

            PdfPTable table1 = new PdfPTable(4);
            iTextSharp.text.Font tHeader = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12f, iTextSharp.text.Font.BOLD, new BaseColor(148, 40, 74));
            var fechaAltaMembresia = new PdfPCell(new Phrase("Fecha de alta de membresia", tHeader)) {HorizontalAlignment = Element.ALIGN_CENTER, Border = 0,BorderWidthTop=5f,BorderColor= new BaseColor(148, 40, 74), PaddingTop = 10f} ;
            var tipoMembresia = new PdfPCell(new Phrase("Tipo de membresia",tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var fechaVencimientoMembresia = new PdfPCell(new Phrase("Fecha de vencimiento de membresia",tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var comments = new PdfPCell(new Phrase("Comentarios", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            table1.AddCell(fechaAltaMembresia);
            table1.AddCell(tipoMembresia);
            table1.AddCell(fechaVencimientoMembresia);
            table1.AddCell(comments);

            foreach (historialMembresias registros in historialMembresias)
            {
                string[] datos = registros.Registro.Split(',');
                foreach(string dato in datos)
                {
                    PdfPCell _cell = new PdfPCell(new Paragraph(dato)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table1.AddCell(_cell);
                }
            }
            document.Add(table1);

            Paragraph visitsHistory = new Paragraph("HISTORIAL DE VISITAS");
            visitsHistory.SpacingBefore = 20;
            visitsHistory.SpacingAfter = 20;
            visitsHistory.Alignment = 1;
            document.Add(visitsHistory);

            PdfPTable table2 = new PdfPTable(3);
            var fechaVisita = new PdfPCell(new Phrase("Fecha de visita", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var membresiaTipo = new PdfPCell(new Phrase("Tipo de membresia", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            var comentario = new PdfPCell(new Phrase("Comentarios", tHeader)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0, BorderWidthTop = 5f, BorderColor = new BaseColor(148, 40, 74), PaddingTop = 10f };
            table2.AddCell(fechaVisita);
            table2.AddCell(membresiaTipo);
            table2.AddCell(comentario);

            foreach (RegistrosVisita registro in historialVisitas)
            {
                string[] datosVisita = registro.getRegistroInfo.Split(',');
                foreach (string dato in datosVisita)
                {
                    PdfPCell _cellVisit = new PdfPCell(new Paragraph(dato)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                    _cellVisit.HorizontalAlignment = Element.ALIGN_CENTER;
                    table2.AddCell(_cellVisit);
                }
            }
            document.Add(table2);
            document.Close();   
            return true;
        }

        public string generalReport(DateTime fromDate, DateTime toDate, string comment)
        {
            string soldMembership = "";
            string customerCloseToEnd = "";
            string newCustomers = "";
            string query = "SELECT Tipo_de_membresia,Fecha_de_alta_membresia FROM Customers";
            dataBaseControl customersConsult = new dataBaseControl();
            string resQuery = customersConsult.Select(query, 2);
            string[] datos = resQuery.Split(',');
            List<membershipTypes> listMembershipType = new List<membershipTypes>();
            DateTime fechaAlta = new DateTime();
            string tipoMembresia = "";
            foreach(string dato in datos)
            {
                if (dato!="")
                {
                    if (tipoMembresia=="")
                    {
                        tipoMembresia = dato;
                        continue;
                    }

                    if(fechaAlta==new DateTime())
                    {
                        fechaAlta = Convert.ToDateTime(dato);
                        if (fechaAlta >= fromDate && fechaAlta <= toDate)
                        {
                            membershipTypes newRegister = new membershipTypes(tipoMembresia);
                            listMembershipType.Add(newRegister);
                            tipoMembresia = "";
                            fechaAlta = new DateTime();
                        }
                    }
                }
            }

            int membershipQuantity = 0;
            float membershipCost = 0;
            float totalCost = 0;
            string lastMembershipType = "";
            List<SoldMemberships> listMembership = new List<SoldMemberships>();
            foreach(membershipTypes membershipType in listMembershipType)
            {
                if (lastMembershipType!=membershipType.getMembershipTypeInfo)
                {
                    membershipQuantity = listMembershipType.Where(x => x.getMembershipTypeInfo == membershipType.getMembershipTypeInfo).Count();
                    string membershipTableQuery = "SELECT Costo FROM Membresias WHERE Tipo_de_membresia = '" + membershipType.getMembershipTypeInfo + "'";
                    dataBaseControl consultMembershipTable = new dataBaseControl();
                    string resMembershipQuery = consultMembershipTable.Select(membershipTableQuery, 1);
                    resMembershipQuery = resMembershipQuery.TrimEnd(',');
                    membershipCost = float.Parse(resMembershipQuery);
                    totalCost = membershipQuantity * membershipCost;
                    lastMembershipType = membershipType.getMembershipTypeInfo;
                    SoldMemberships newMembershipType = new SoldMemberships(membershipType.getMembershipTypeInfo, membershipCost.ToString(), membershipQuantity.ToString(), totalCost.ToString());
                    listMembership.Add(newMembershipType);
                }
            }

            if (listMembership.Count<=0)
            {
                soldMembership = "Sin registro para mostrar";
            }

            query = "SELECT Nombre,Apellido,Tipo_de_membresia,Fecha_de_alta_membresia FROM Customers";
            dataBaseControl consultCostumerTable = new dataBaseControl();
            resQuery = consultCostumerTable.Select(query, 4);
            datos = resQuery.Split(',');
            fechaAlta = new DateTime();
            DateTime endDate = new DateTime();
            DateTime currentDate = DateTime.Now;
            string name = "";
            string lastName = "";
            tipoMembresia = "";
            string fullName = "";
            List<ClientesProximosVencer> listCustomerCloseToEnd = new List<ClientesProximosVencer>();
            List<ClientesNuevos> listNewCustomer = new List<ClientesNuevos>();
            foreach(string dato in datos)
            {
                if (dato!="")
                {
                    if (name=="")
                    {
                        name = dato;
                        continue;
                    }

                    if (lastName == "")
                    {
                        lastName = dato;
                        continue;
                    }

                    if (tipoMembresia == "")
                    {
                        tipoMembresia = dato;
                        continue;
                    }

                    if (fechaAlta == new DateTime())
                    {
                        fechaAlta = Convert.ToDateTime(dato);
                        if (fechaAlta>=fromDate && fechaAlta <= toDate)
                        {
                            query = "SELECT DuracionMembresia FROM Membresias WHERE Tipo_de_membresia = '" + tipoMembresia + "'";
                            dataBaseControl consultMembershipTable = new dataBaseControl();
                            resQuery = consultMembershipTable.Select(query, 1);
                            resQuery = resQuery.TrimEnd(',');
                            int membershipDuration = Int32.Parse(resQuery);
                            endDate = fechaAlta;
                            endDate = endDate.AddDays(membershipDuration);
                            int remainingDaysToEnd = (endDate-currentDate).Days;
                            int daysPassed = (currentDate - fechaAlta).Days;
                            if (daysPassed<=7)
                            {
                                fullName = name + " " + lastName;
                                ClientesNuevos newRegister = new ClientesNuevos(name, tipoMembresia, fechaAlta.ToString(), endDate.ToString());
                                listNewCustomer.Add(newRegister);
                            }
                            if (remainingDaysToEnd<=7)
                            {
                                fullName = name + " " + lastName;
                                ClientesProximosVencer newRegister = new ClientesProximosVencer(fullName, tipoMembresia, fechaAlta.ToString(), endDate.ToString());
                                listCustomerCloseToEnd.Add(newRegister);
                            }
                            name = "";
                            lastName = "";
                            tipoMembresia = "";
                            fechaAlta = new DateTime();
                        }
                    }
                }
            }

            if (listCustomerCloseToEnd.Count<=0)
            {
                customerCloseToEnd = "Sin registro para mostrar";
            }

            if (listNewCustomer.Count<=0)
            {
                newCustomers = "Sin registro para mostrar";
            }

            if(soldMembership.Contains("Sin registro para mostrar") && customerCloseToEnd.Contains("Sin registro para mostrar") && newCustomers.Contains("Sin registro para mostrar"))
            {
                return "No existen registros para mostrar en el periodo de tiempo especificado";
            }
            bool successReportCreation = GenerateGeneralPDF(listMembership, listCustomerCloseToEnd, listNewCustomer,fromDate,toDate,comment);
            if (successReportCreation)
            {
                return "El reporte se ha generado exitosamente";
            }
            else
            {
                return "Se ha presentado un problema al generar el reporte";
            }
        }

        public string customerReport(DateTime fromDate, DateTime toDate,string customer,string comments)
        {
            bool historialMembresias = true;
            bool historialVisitas = true;
            string[] nombreCompleto = customer.Split(' ');
            string firstName = "";
            string middleName = "";
            string lastName = "";
            string lastName2 = "";
            foreach(string nombre in nombreCompleto)
            {
                if (firstName == "")
                {
                    firstName = nombre;
                    continue;
                }

                if (nombreCompleto.Length>=4)
                {
                    if (middleName == "")
                    {
                        middleName = nombre;
                        continue;
                    }
                }
                
                if(lastName=="")
                {
                    lastName = nombre;
                    continue;
                }
                if(lastName2=="")
                {
                    lastName2 = nombre;
                    continue;
                }
            }
            string name = "";
            if (nombreCompleto.Length >= 4)
            {
                name = firstName + " " + middleName;
            }
            else
            {
                name = firstName;
            }
            string apellidos = lastName + " " + lastName2;
            string query = "SELECT Fecha_alta_membresia,Tipo_de_membresia,Fecha_vencimiento_membresia FROM Historico_Membresias WHERE Nombre_Cliente='"+name+"' AND Apellido_Cliente='"+apellidos+"'";
            dataBaseControl consultDataBase = new dataBaseControl();
            string resQuery = consultDataBase.Select(query, 3);
            string[] datos = resQuery.Split(',');
            List<historialMembresias> listaDatos = new List<historialMembresias>();
            DateTime fechaAlta = new DateTime();
            string membershipType = "";
            string fechaVencimiento = "";
            bool registra = false;
            foreach(string dato in datos)
            {
                if (dato!="")
                {
                    if (fechaAlta == new DateTime())
                    {
                        fechaAlta = Convert.ToDateTime(dato);
                        if (fechaAlta >= fromDate && fechaAlta <= toDate)
                        {
                            registra = true;
                        }
                        continue;
                    }

                    if (registra)
                    {
                        if (membershipType == "")
                        {
                            membershipType = dato;
                            continue;
                        }
                    }

                    if (registra)
                    {
                        if (fechaVencimiento == "")
                        {
                            fechaVencimiento = dato;
                        }
                    }
                    if (registra)
                    {
                        historialMembresias newRegister = new historialMembresias(fechaAlta.ToString(), membershipType, fechaVencimiento,comments);
                        listaDatos.Add(newRegister);
                        fechaAlta = new DateTime();
                        membershipType = "";
                        fechaVencimiento = "";
                        registra = false;
                    }
                }
            }
            int lenghtList = listaDatos.Count;
            if (lenghtList <= 0)
            {
                historialMembresias = false;                
            }

            query = "SELECT Fecha_de_visita,Tipo_de_membresia FROM Historico_Visitas WHERE Nombre='" + name + "' AND Apellido='" + apellidos + "'";
            dataBaseControl consultVisitTable = new dataBaseControl();
            resQuery = consultVisitTable.Select(query, 2);
            datos = resQuery.Split(',');
            fechaAlta = new DateTime();
            membershipType = "";
            registra = false;
            List<RegistrosVisita> listVisitas = new List<RegistrosVisita>();
            foreach(string dato in datos)
            {
                if (dato.Contains("La consulta")) break;
                if (dato!="")
                {
                    if (fechaAlta==new DateTime())
                    {
                        fechaAlta = Convert.ToDateTime(dato);
                        if (fechaAlta>=fromDate && fechaAlta <= toDate)
                        {
                            registra = true;
                        }
                        continue;
                    }

                    if(registra)
                    {
                        if (membershipType == "")
                        {
                            membershipType = dato;
                        }
                    }

                    if (registra)
                    {
                        RegistrosVisita newRegister = new RegistrosVisita(fechaAlta.ToString(), membershipType, comments);
                        listVisitas.Add(newRegister);
                        fechaAlta = new DateTime();
                        membershipType = "";
                        registra = false;
                    }
                    else
                    {
                        fechaAlta = new DateTime();
                        membershipType = "";
                        registra = false;
                    }
                }
            }
            if (listVisitas.Count<=0)
            {
                historialVisitas = false;
            }
 
            if (!historialMembresias && !historialVisitas) return "No existen elementos a reportar en el periodo de tiempo seleccionado";
            
            System.Drawing.Image imagen = null;
            string memberSince = "";
            string currentMembershipType = "";
            query = "SELECT Fotografia,Fecha_de_alta_cliente,Tipo_de_membresia FROM Customers WHERE Nombre='" + name + "' AND Apellido='" + apellidos + "'";
            SqlCommand command = new SqlCommand(query, dataBaseControl.connection);
            SqlDataReader filas = command.ExecuteReader();
            while(filas.Read())
            {
                imagen = (Bitmap)((new ImageConverter()).ConvertFrom(filas.GetValue(0)));
                memberSince = filas.GetString(1);
                currentMembershipType = filas.GetString(2);
            }
            bool res = GenerateCustomerPDF(listaDatos, listVisitas,imagen, memberSince, currentMembershipType, name, apellidos);
            if (res)
            {
                return "El reporte se ha generado exitosamente";
            }
            else
            {
                return "Se ha presentado un problema al generar el reporte";
            }
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
