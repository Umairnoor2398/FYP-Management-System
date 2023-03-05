using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.IO;
using CRUD_Operations;
using System.Data;
using System.Xml.Linq;
using UserControl = System.Windows.Controls.UserControl;
using Microsoft.Win32;
using System.Windows.Forms;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using MessageBox = System.Windows.MessageBox;
using DataGrid = System.Windows.Controls.DataGrid;

namespace ProjectA.UserControls.PDFReports
{
    /// <summary>
    /// Interaction logic for PDFReportUC.xaml
    /// </summary>
    public partial class PDFReportUC : UserControl
    {
        public PDFReportUC()
        {
            InitializeComponent();
        }

        //private void 


        private void AddPDF()
        {
            //var con = Configuration.getInstance().getConnection();
            //SqlCommand cmd = new SqlCommand("Select P.Id, S.RegistrationNo AS [Reg], (FirstName + ' ' + LastName) AS Name,L.Value AS Gender,(SELECT FORMAT(DateOfBirth, 'dd-MM-yyyy')) AS [DoB],Contact,Email from Person P JOIN Student S ON S.Id=P.Id JOIN Lookup L ON L.Id=P.Gender", con);
            //SqlDataReader reader = cmd.ExecuteReader();


            //// Create new PDF document
            //Document document = new Document();
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(sfd.FileName, FileMode.Create));
            //document.Open();

            //// Set page size, margins, and orientation
            //document.SetPageSize(PageSize.A4);
            //document.SetMargins(30, 30, 30, 30);
            ////document.SetPageOrientation(PdfWriter.PageLayoutSinglePage);


            //PdfPTable headerTable = new PdfPTable(1);
            //headerTable.WidthPercentage = 100;
            //PdfPCell headerCell = new PdfPCell(new Phrase("Your report header"));
            ////headerCell.Border = Rectangle.NO_BORDER;
            //headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //headerTable.AddCell(headerCell);
            ////document.SetHeader(headerTable);

            //PdfPTable footerTable = new PdfPTable(1);
            //footerTable.WidthPercentage = 100;
            //PdfPCell footerCell = new PdfPCell(new Phrase("Your report footer"));
            ////footerCell.Border = Rectangle.NO_BORDER;
            //footerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //footerTable.AddCell(footerCell);
            ////document.SetFooter(footerTable);

            //// Create table and add data
            //PdfPTable table = new PdfPTable(reader.FieldCount);
            //table.WidthPercentage = 100;
            //for (int i = 0; i < reader.FieldCount; i++)
            //{
            //    PdfPCell cell = new PdfPCell(new Phrase(reader.GetName(i)));
            //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //    table.AddCell(cell);
            //}

            //while (reader.Read())
            //{
            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        PdfPCell cell = new PdfPCell(new Phrase(reader[i].ToString()));
            //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //        table.AddCell(cell);
            //    }
            //}

            //document.Add(table);

            //// Close PDF document and writer
            //document.Close();
            //writer.Close();
        }


        private void GetTitlePage()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF (*.pdf)|*.pdf";
            sfd.FileName = "AdvisoryBoard.pdf";
            bool errorMessage = false;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfd.FileName))
                {
                    try
                    {
                        File.Delete(sfd.FileName);


                    }
                    catch (Exception ex)
                    {
                        errorMessage = true;
                        MessageBox.Show("Unable to wride data in disk" + ex.Message);
                    }

                }
                if (!errorMessage)
                {
                    // Create new PDF document
                    Document document = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(sfd.FileName, FileMode.Create));
                    document.Open();

                    // Set page size, margins, author, date, title, header
                    document.SetPageSize(PageSize.A4);
                    document.SetMargins(30, 30, 30, 30);
                    document.AddAuthor("Umair Noor");
                    document.AddCreationDate();
                    document.AddTitle("PDF Report");
                    document.AddHeader("Title", "FYP Management System");

                    // Adding title page
                    document.NewPage();
                    PdfPTable headerTable = new PdfPTable(1);
                    headerTable.WidthPercentage = 100;
                    Chunk headerChunk = new Chunk("FYP Management System", FontFactory.GetFont("Times New Roman"));
                    headerChunk.Font.Size = 28;
                    PdfPCell headerCell = new PdfPCell(new Phrase(headerChunk));
                    headerCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerTable.AddCell(headerCell);
                    document.Add(headerTable);





                    string imageURL = "D:\\Semester4\\Database Lab\\MID Project\\ProjectA\\Assets\\uet_logo.png";
                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                    //Resize image depend upon your need
                    jpg.ScaleToFit(140f, 120f);
                    //Give space before image
                    jpg.SpacingBefore = 10f;
                    //Give some space after the image
                    jpg.SpacingAfter = 1f;
                    jpg.Alignment = Element.ALIGN_CENTER;

                    string imageURL2 = "D:\\Semester4\\Database Lab\\MID Project\\ProjectA\\Assets\\logo.jpeg";
                    iTextSharp.text.Image jpg2 = iTextSharp.text.Image.GetInstance(imageURL2);
                    //Resize image depend upon your need
                    jpg2.ScaleToFit(140f, 120f);
                    //Give space before image
                    jpg2.SpacingBefore = 10f;
                    //Give some space after the image
                    jpg2.SpacingAfter = 1f;
                    jpg2.Alignment = Element.ALIGN_CENTER;

                    PdfPTable titleImg = new PdfPTable(2);
                    titleImg.WidthPercentage = 100;
                    PdfPCell imgCell1 = new PdfPCell();
                    imgCell1.AddElement(jpg);
                    imgCell1.AddElement(jpg2);
                    titleImg.AddCell(imgCell1);
                    document.Add(titleImg);





                    // Close PDF document and writer
                    document.Close();
                    writer.Close();
                }
            }
        }

        private void report1Btn_Click(object sender, RoutedEventArgs e)
        {
            GetTitlePage();
            //PdfPTable pdfTableBlank = new PdfPTable(1);
            ////Footer Section
            //PdfPTable pdfTableFooter = new PdfPTable(1);
            //pdfTableFooter.DefaultCell.BorderWidth = 0;
            //pdfTableFooter.WidthPercentage = 100;
            //pdfTableFooter.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //Chunk cnkFooter = new Chunk("FYP Management System", FontFactory.GetFont("Times New Roman"));
            ////cnkFooter.Font.SetStyle(1);
            //cnkFooter.Font.Size = 10;
            //pdfTableFooter.AddCell(new Phrase(cnkFooter));
            ////End Of Footer Section
            //pdfTableBlank.AddCell(new Phrase(" "));
            //pdfTableBlank.DefaultCell.Border = 0;

            //PdfPTable pdfTable1 = new PdfPTable(1);//Here 1 is Used For Count of Column
            //PdfPTable pdfTable2 = new PdfPTable(1);
            //PdfPTable pdfTable3 = new PdfPTable(2);
            ////Font Style
            //System.Drawing.Font fontH1 = new System.Drawing.Font("Currier", 16);
            ////pdfTable1.DefaultCell.Padding = 5;
            //pdfTable1.WidthPercentage = 80;
            //pdfTable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfTable1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            ////pdfTable1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170);
            //pdfTable1.DefaultCell.BorderWidth = 0;
            ////pdfTable1.DefaultCell.Padding = 5;
            //pdfTable2.WidthPercentage = 80;
            //pdfTable2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfTable2.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            ////pdfTab2e1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170);
            //pdfTable2.DefaultCell.BorderWidth = 0;
            //pdfTable3.DefaultCell.Padding = 5;
            //pdfTable3.WidthPercentage = 80;
            //pdfTable3.DefaultCell.BorderWidth = 0.5f;
            //Chunk c1 = new Chunk("FYP Management System", FontFactory.GetFont("Times New Roman"));
            //c1.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
            //c1.Font.SetStyle(0);
            //c1.Font.Size = 14;
            //Phrase p1 = new Phrase();
            //p1.Add(c1);
            //pdfTable1.AddCell(p1);


            //PdfPTable pdfTable4 = new PdfPTable(4);
            //pdfTable4.DefaultCell.Padding = 5;
            //pdfTable4.WidthPercentage = 80;
            //pdfTable4.DefaultCell.BorderWidth = 0.0f;
            //pdfTable4.AddCell(new Phrase("Bill No "));
            //pdfTable4.AddCell(new Phrase("B001"));
            //pdfTable4.AddCell(new Phrase("Date "));
            //pdfTable4.AddCell(new Phrase("01-01-2017"));
            //pdfTable4.AddCell(new Phrase("Vendor "));
            //pdfTable4.AddCell(new Phrase("Demo Vendor"));
            //pdfTable4.AddCell(new Phrase("Address "));
            //pdfTable4.AddCell(new Phrase("Kolkata"));


            //string imageURL = "D:\\Semester4\\Database Lab\\MID Project\\ProjectA\\Assets\\uet_logo.png";
            //iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            ////Resize image depend upon your need
            //jpg.ScaleToFit(140f, 120f);
            ////Give space before image
            //jpg.SpacingBefore = 10f;
            ////Give some space after the image
            //jpg.SpacingAfter = 1f;
            //jpg.Alignment = Element.ALIGN_CENTER;


            ////Table entering


            //string folderPath = "D:\\PDF\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            ////File Name
            //int fileCount = Directory.GetFiles("D:\\PDF").Length;
            //string strFileName = "DescriptionForm" + (fileCount + 1) + ".pdf";
            //using (FileStream stream = new FileStream(folderPath + strFileName, FileMode.Create))
            //{
            //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //    PdfWriter.GetInstance(pdfDoc, stream);
            //    pdfDoc.Open();

            //    pdfDoc.Add(pdfTable1);
            //    pdfDoc.Add(pdfTable2);
            //    pdfDoc.Add(pdfTableBlank);
            //    pdfDoc.Add(jpg);
            //    pdfDoc.Add(pdfTable3);
            //    pdfDoc.Add(pdfTableFooter);
            //    pdfDoc.NewPage();

            //    // pdfDoc.Add(jpg);
            //    //pdfDoc.Add(pdfTable2);
            //    pdfDoc.Close();
            //    stream.Close();
            //}


            //System.Diagnostics.Process.Start(folderPath + "\\" + strFileName);



        }

        //private void report1Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = "Pdf File |*.pdf";
        //    sfd.FileName = "Students.pdf";

        //    bool ErrorMessage = false;

        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        if (File.Exists(sfd.FileName))
        //        {

        //            try
        //            {

        //                File.Delete(sfd.FileName);

        //            }
        //            catch (Exception ex)
        //            {

        //                ErrorMessage = true;

        //                MessageBox.Show("Unable to wride data in disk" + ex.Message);

        //            }

        //        }

        //        if (!ErrorMessage)
        //        {



        //            //var con = Configuration.getInstance().getConnection();
        //            //SqlCommand cmd = new SqlCommand("Select P.Id, S.RegistrationNo AS [Reg], (FirstName + ' ' + LastName) AS Name,L.Value AS Gender,(SELECT FORMAT(DateOfBirth, 'dd-MM-yyyy')) AS [DoB],Contact,Email from Person P JOIN Student S ON S.Id=P.Id JOIN Lookup L ON L.Id=P.Gender", con);
        //            //SqlDataReader reader = cmd.ExecuteReader();


        //            // Create new PDF document
        //            Document document = new Document();
        //            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(sfd.FileName, FileMode.Create));
        //            document.Open();

        //            // Set page size, margins, and orientation
        //            document.SetPageSize(PageSize.A4);
        //            document.SetMargins(30, 30, 30, 30);
        //            //document.SetPageOrientation(PdfWriter.PageLayoutSinglePage);




        //            //PdfPTable headerTable = new PdfPTable(1);
        //            //headerTable.WidthPercentage = 100;
        //            //PdfPCell headerCell = new PdfPCell(new Phrase("Your report header"));
        //            ////headerCell.Border = Rectangle.NO_BORDER;
        //            //headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            //headerTable.AddCell(headerCell);
        //            ////document.SetHeader(headerTable);

        //            //PdfPTable footerTable = new PdfPTable(1);
        //            //footerTable.WidthPercentage = 100;
        //            //PdfPCell footerCell = new PdfPCell(new Phrase("Your report footer"));
        //            ////footerCell.Border = Rectangle.NO_BORDER;
        //            //footerCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            //footerTable.AddCell(footerCell);
        //            ////document.SetFooter(footerTable);

        //            //// Create table and add data
        //            //PdfPTable table = new PdfPTable(reader.FieldCount);
        //            //table.WidthPercentage = 100;
        //            //for (int i = 0; i < reader.FieldCount; i++)
        //            //{
        //            //    PdfPCell cell = new PdfPCell(new Phrase(reader.GetName(i)));
        //            //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            //    table.AddCell(cell);
        //            //}

        //            //while (reader.Read())
        //            //{
        //            //    for (int i = 0; i < reader.FieldCount; i++)
        //            //    {
        //            //        PdfPCell cell = new PdfPCell(new Phrase(reader[i].ToString()));
        //            //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            //        table.AddCell(cell);
        //            //    }
        //            //}

        //            //document.Add(table);

        //            // Close PDF document and writer
        //            document.Close();
        //            writer.Close();
        //        }

        //    }

        //}


        private void report2Btn_Click(object sender, RoutedEventArgs e)
        {
            DataGrid Students = new DataGrid();
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "PDF (*.pdf)|*.pdf";

            sfd.FileName = "AdvisoryBoard.pdf";

            bool ErrorMessage = false;

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                if (File.Exists(sfd.FileName))
                {

                    try
                    {

                        File.Delete(sfd.FileName);

                    }
                    catch (Exception ex)
                    {

                        ErrorMessage = true;

                        MessageBox.Show("Unable to wride data in disk" + ex.Message);

                    }

                }

                if (!ErrorMessage)
                {

                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("SELECT PA.ProjectId, MAX(P.Title) Title, MAX(CASE WHEN PA.AdvisorRole = 11 THEN CONCAT(Person.FirstName,' ',Person.LastName) END) AS MainAdvisor, MAX(CASE WHEN PA.AdvisorRole = 12 THEN CONCAT(Person.FirstName,' ',Person.LastName) END) AS CoAdvisor, MAX(CASE WHEN PA.AdvisorRole = 14 THEN CONCAT(Person.FirstName,' ',Person.LastName) END) AS IndustryAdvisor FROM  ProjectAdvisor PA INNER JOIN Advisor A ON PA.AdvisorId = A.Id JOIN Project P ON P.Id=PA.ProjectId JOIN Person ON Person.Id=A.Id GROUP BY PA.ProjectId", con);
                    SqlDataReader reader = cmd.ExecuteReader();


                    // Create new PDF document
                    Document document = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(sfd.FileName, FileMode.Create));
                    document.Open();

                    // Set page size, margins, and orientation
                    document.SetPageSize(PageSize.A4);
                    document.SetMargins(30, 30, 30, 30);
                    //document.SetPageOrientation(PdfWriter.PageLayoutSinglePage);


                    PdfPTable headerTable = new PdfPTable(1);
                    headerTable.WidthPercentage = 100;
                    PdfPCell headerCell = new PdfPCell(new Phrase("Your report header"));
                    //headerCell.Border = Rectangle.NO_BORDER;
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerTable.AddCell(headerCell);
                    //document.SetHeader(headerTable);

                    PdfPTable footerTable = new PdfPTable(1);
                    footerTable.WidthPercentage = 100;
                    PdfPCell footerCell = new PdfPCell(new Phrase("Your report footer"));
                    //footerCell.Border = Rectangle.NO_BORDER;
                    footerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    footerTable.AddCell(footerCell);
                    //document.SetFooter(footerTable);

                    // Create table and add data
                    PdfPTable table = new PdfPTable(reader.FieldCount);
                    table.WidthPercentage = 100;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(reader.GetName(i)));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(reader[i].ToString()));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            table.AddCell(cell);
                        }
                    }

                    document.Add(table);

                    // Close PDF document and writer
                    document.Close();
                    writer.Close();

                }

            }

        }
    }
}
