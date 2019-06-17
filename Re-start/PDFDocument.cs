using iTextSharp.text;
using iTextSharp.text.pdf;
using LibraryForSQLCon;
using System;
using System.IO;
using System.Windows.Forms;

namespace Re_start
{
    class PDFDocument
    {
        public System.Data.DataTable dtDannie = new System.Data.DataTable();
        //Составление личного дела по сотруднику
        public void LichDelo()
        {

            BaseFont baseFont = BaseFont.CreateFont(Application.StartupPath + "/times.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 34, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Document document = new iTextSharp.text.Document();

            FileStream stream = new FileStream(Registry_Class.DirPath + "Личное дело"
                + DateTime.Now.ToString("_hh_mm_ss_dd_MM_yyyy") + ".pdf", FileMode.Create);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            String phrase = "Личное дело №" + dtDannie.Rows[0][0].ToString();
            Paragraph elements = new Paragraph(phrase, font);
            elements.Alignment = Element.ALIGN_CENTER;
            document.Add(elements);
            System.IO.FileInfo FI;
            Image jpg;
            try
            {
                FI = new System.IO.FileInfo(dtDannie.Rows[0][8].ToString());
                jpg = Image.GetInstance(FI.FullName);
            }
            catch
            {
                FI = new System.IO.FileInfo(Application.StartupPath + "/no-image.jpg");
                jpg = Image.GetInstance(FI.FullName);
            }

            jpg.Alignment = Element.ALIGN_CENTER;
            jpg.ScaleToFit(400, 350);
            document.Add(jpg);
            document.Add(new Paragraph("ФИО: " + dtDannie.Rows[0][1].ToString(), font1));
            document.Add(new Paragraph("Дата рождения: " + dtDannie.Rows[0][2].ToString(), font1));
            document.Add(new Paragraph("Серия и номер паспорта: " + dtDannie.Rows[0][3].ToString(), font1));
            document.Add(new Paragraph("Адрес проживания: " + dtDannie.Rows[0][4].ToString(), font1));
            document.Add(new Paragraph("Наименование отдела: " + dtDannie.Rows[0][5].ToString(), font1));
            document.Add(new Paragraph("Должность: " + dtDannie.Rows[0][6].ToString() + " (Оклад: " + dtDannie.Rows[0][7].ToString() + " руб.)", font1));
            document.Close();

        }

        public void otchLichDelo(DataGridView dgv)
        {
            Document configurationForm = new Document();
            configurationForm.Document_Load(null, null);
            switch (Registry_Class.DirPath == "Empry" || Registry_Class.OrganizationName == "Empty"
                || Registry_Class.DocBM == 0.0 || Registry_Class.DocTM == 0.0 ||
                Registry_Class.DocRM == 0.0 || Registry_Class.DocLM == 0.0)
            {
                case (true):

                    configurationForm.ShowDialog();
                    break;
                case (false):
                    DataBaseTables data = new DataBaseTables();
                    data.qrSotr = "SELECT dbo.Sotr.Num_Lich_Dela, dbo.Sotr.Familiya + ' ' + dbo.Sotr.Imya + ' ' + dbo.Sotr.Otchestvo, dbo.Sotr.DateOfRojd, Convert(varchar(4),dbo.Sotr.S_Pas) + ' ' + Convert(varchar(6),dbo.Sotr.N_Pas), dbo.Sotr.Adres_Proj, dbo.Otdel.Naim_Otdela, dbo.Dolj.Naim_Dolj, dbo.Dolj.Oklad FROM dbo.Sotr JOIN dbo.Dolj ON dbo.Sotr.Dolj_ID = dbo.Dolj.ID_Dolj JOIN dbo.Otdel ON dbo.Dolj.Otdel_ID = dbo.Otdel.ID_Otdel where Login_St = '" + (dgv as DataGridView).CurrentRow.Cells[0].Value.ToString() + "'";
                    data.dtSotrFill();
                    dtDannie = data.dtSotr;
                    LichDelo();
                    break;
            }
        }
    }
}
