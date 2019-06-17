using LibraryForSQLCon;
using Microsoft.Office.Interop.Word;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Drawing.Imaging;

namespace Re_start
{
    class WordDocument
    {
        SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
        public System.Data.DataTable table = new System.Data.DataTable();
        public string file_name;
        public void PrihOtch()
        {
            word.Application application = new word.Application();
            word.Document document = application.Documents.Add(Visible: true);
            word.Range range = document.Range(0, 0);
            file_name = Registry_Class.DirPath + "\\ПрД_" + "Приход деталей за"
                + DateTime.Now.ToString("_hh_mm_ss_dd_MM_yyyy") + ".docx";
            try
            {
                document.Sections.PageSetup.LeftMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocLM));
                document.Sections.PageSetup.RightMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocRM));
                document.Sections.PageSetup.TopMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocTM));
                document.Sections.PageSetup.BottomMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocBM));
                range.Text = Registry_Class.OrganizationName;
                range.ParagraphFormat.Alignment
                    = word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.ParagraphFormat.SpaceAfter = 1;
                range.ParagraphFormat.SpaceBefore = 1;
                range.ParagraphFormat.LineSpacingRule = word.WdLineSpacing.wdLineSpaceSingle;
                range.Font.Name = "Times New Roman";
                range.Font.Size = 16;
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                word.Paragraph Name_Doc = document.Paragraphs.Add();
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Range.Font.Size = 14;
                Name_Doc.Range.Text = "Приход деталей за: " + DateTime.Now.ToLongDateString();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                word.Paragraph pTable = document.Paragraphs.Add();
                word.Table tbDanTab = document.Tables.Add(pTable.Range, table.Rows.Count + 1,
                    table.Columns.Count);
                tbDanTab.Borders.InsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                tbDanTab.Borders.OutsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                tbDanTab.Cell(1, 1).Range.Text = "Наименование детали";
                tbDanTab.Cell(1, 2).Range.Text = "Количество (шт.)";
                tbDanTab.Range.Font.Size = 12;
                tbDanTab.Range.Font.Name = "Times New Roman";
                tbDanTab.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                tbDanTab.Columns[1].Width = 250;
                tbDanTab.Columns[2].Width = 150;
                for (int i = 2; i <= tbDanTab.Rows.Count; i++)
                    for (int j = 1; j <= tbDanTab.Columns.Count; j++)
                    {
                        tbDanTab.Cell(i, j).Range.Text
                            = table.Rows[i - 2][j - 1].ToString();
                    }
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Range.Font.Size = 14;
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphRight;
                Name_Doc.Range.Text = "Кладовщик ____________ (_________________)";
                document.Paragraphs.Add();
                Name_Doc.Range.Text = "Менеджер по продажам ____________ (_________________)";
                document.Paragraphs.Add();
                Name_Doc.Range.Text = "Бухгалтер ____________ (_________________)";
                document.Paragraphs.Add();
                Name_Doc.Range.Text = "Директор ____________ (_________________)";
            }
            catch (Exception ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + " " + ex.Message;
            }
            finally
            {
                document.SaveAs2(file_name, word.WdSaveFormat.wdFormatDocumentDefault);
                document.Close();
                application.Quit();
            }
        }

        public void PrihZaDen()
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
                    data.qrChek = "SELECT dbo.Details.Naim_Details + ' для ' + dbo.Type_Device.Naim_type + ' ' +" +
                        " dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model, dbo.Prihod_Details.Count_Prih FROM dbo.Prihod_Details JOIN dbo.Details ON dbo.Prihod_Details.Details_ID = dbo.Details.ID_Details JOIN dbo.Model_Device ON dbo.Details.Model_ID = dbo.Model_Device.ID_Model JOIN dbo.Proizvod_Device ON dbo.Model_Device.Proizvod_ID = dbo.Proizvod_Device.ID_Proizvod JOIN dbo.Type_Device ON dbo.Proizvod_Device.Type_ID = dbo.Type_Device.ID_Type where DATEDIFF(day,Convert(Datetime,Data_Prih,104),getdate()) = 0";
                    data.dtChekFill();
                    table = data.dtChek;
                    PrihOtch();
                    break;
            }
        }

        System.Data.DataTable che, DanChe;
        public void ChekOtch()
        {
            word.Application application = new word.Application();
            word.Document document = application.Documents.Add(Visible: true);
            word.Range range = document.Range(0, 0);
            string file_name = Registry_Class.DirPath + "\\Чек за"
                + DateTime.Now.ToString("_hh_mm_ss_dd_MM_yyyy") + ".docx";
            try
            {
                document.Sections.PageSetup.LeftMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocLM));
                document.Sections.PageSetup.RightMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocRM));
                document.Sections.PageSetup.TopMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocTM));
                document.Sections.PageSetup.BottomMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocBM));
                range.Text = Registry_Class.OrganizationName;
                range.ParagraphFormat.Alignment
                    = word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.ParagraphFormat.SpaceAfter = 1;
                range.ParagraphFormat.SpaceBefore = 1;
                range.ParagraphFormat.LineSpacingRule = word.WdLineSpacing.wdLineSpaceSingle;
                range.Font.Name = "Times New Roman";
                range.Font.Size = 16;
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                word.Paragraph Name_Doc = document.Paragraphs.Add();
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Range.Font.Size = 14;
                Name_Doc.Range.Text = "Отчет о продажах за: " + DateTime.Now.ToLongDateString();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                foreach (DataRow row in che.Rows)
                {
                    DataBaseTables data = new DataBaseTables();
                    data.qrDan_Check = "SELECT dbo.Contracts.Num_Contr, dbo.Dan_Check.Stoimost FROM dbo.Dan_Check JOIN dbo.Repairs ON dbo.Dan_Check.Repairs_ID = dbo.Repairs.ID_Repairs JOIN dbo.Chek ON dbo.Dan_Check.Chek_ID = dbo.Chek.ID_Chek JOIN dbo.Contracts ON dbo.Repairs.Contr_ID = dbo.Contracts.ID_Contr where Num_Check = '" + row["Num_Check"].ToString() + "'";
                    data.dtDan_CheckFill();
                    DanChe = data.dtDan_Check;
                    Name_Doc.Range.Font.Name = "Times New Roman";
                    Name_Doc.Range.Text = "Чек №: " + row["Num_Check"].ToString();
                    document.Paragraphs.Add();
                    word.Paragraph pTable = document.Paragraphs.Add();
                    word.Table tbDanTab = document.Tables.Add(pTable.Range, DanChe.Rows.Count + 1,
                        DanChe.Columns.Count);
                    tbDanTab.Borders.InsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                    tbDanTab.Borders.OutsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                    tbDanTab.Cell(1, 1).Range.Text = "Наименование контракта";
                    tbDanTab.Cell(1, 2).Range.Text = "Стоимость (руб.)";
                    tbDanTab.Range.Font.Size = 12;
                    tbDanTab.Range.Font.Name = "Times New Roman";
                    tbDanTab.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                    tbDanTab.Columns[1].Width = 250;
                    tbDanTab.Columns[2].Width = 150;
                    for (int i = 2; i <= tbDanTab.Rows.Count; i++)
                        for (int j = 1; j <= tbDanTab.Columns.Count; j++)
                        {
                            tbDanTab.Cell(i, j).Range.Text
                                = DanChe.Rows[i - 2][j - 1].ToString();
                        }
                    document.Paragraphs.Add();
                    document.Paragraphs.Add();
                }

                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Range.Font.Size = 14;
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphRight;
                Name_Doc.Range.Text = "Менеджер по продажам ____________ (_________________)";
                document.Paragraphs.Add();
                Name_Doc.Range.Text = "Бухгалтер ____________ (_________________)";
                document.Paragraphs.Add();
                Name_Doc.Range.Text = "Директор ____________ (_________________)";
            }
            catch (Exception ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + " " + ex.Message;
            }
            finally
            {
                document.SaveAs2(file_name, word.WdSaveFormat.wdFormatDocumentDefault);
                document.ExportAsFixedFormat(file_name + ".pdf", WdExportFormat.wdExportFormatPDF);
                document.Close();
                application.Quit();
                File.Delete(@file_name);
            }
        }

        public void CheZaDen()
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
                    data.qrChek = "SELECT dbo.Chek.Num_Check FROM dbo.Chek where Chek_logical_Delete = 0 and DATEDIFF(day,Convert(Datetime,dbo.Chek.Data_Prod,104),getdate()) = 0";
                    data.dtChekFill();
                    che = data.dtChek;
                    ChekOtch();
                    break;
            }
        }

        public void VakantiOtch()
        {
            word.Application application = new word.Application();
            word.Document document = application.Documents.Add(Visible: true);
            word.Range range = document.Range(0, 0);
            file_name = Registry_Class.DirPath + "\\ВакМ_" + "Вакантные места на "
                + DateTime.Now.ToString("_hh_mm_ss_dd_MM_yyyy") + ".docx";
            try
            {
                document.Sections.PageSetup.LeftMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocLM));
                document.Sections.PageSetup.RightMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocRM));
                document.Sections.PageSetup.TopMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocTM));
                document.Sections.PageSetup.BottomMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocBM));
                range.Text = Registry_Class.OrganizationName;
                range.ParagraphFormat.Alignment
                    = word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.ParagraphFormat.SpaceAfter = 1;
                range.ParagraphFormat.SpaceBefore = 1;
                range.ParagraphFormat.LineSpacingRule = word.WdLineSpacing.wdLineSpaceSingle;
                range.Font.Name = "Times New Roman";
                range.Font.Size = 16;
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                word.Paragraph Name_Doc = document.Paragraphs.Add();
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Range.Font.Size = 14;
                Name_Doc.Range.Text = "Таблица вакантных мест на " + DateTime.Now.ToLongDateString();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                word.Paragraph pTable = document.Paragraphs.Add();
                word.Table tbDanTab = document.Tables.Add(pTable.Range, table.Rows.Count + 1,
                    table.Columns.Count);
                tbDanTab.Borders.InsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                tbDanTab.Borders.OutsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                tbDanTab.Cell(1, 1).Range.Text = "Наименование детали";
                tbDanTab.Cell(1, 2).Range.Text = "Количество (шт.)";
                tbDanTab.Range.Font.Size = 12;
                tbDanTab.Range.Font.Name = "Times New Roman";
                tbDanTab.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
                tbDanTab.Columns[1].Width = 250;
                tbDanTab.Columns[2].Width = 150;
                for (int i = 2; i <= tbDanTab.Rows.Count; i++)
                    for (int j = 1; j <= tbDanTab.Columns.Count; j++)
                    {
                        tbDanTab.Cell(i, j).Range.Text
                            = table.Rows[i - 2][j - 1].ToString();
                    }
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Range.Font.Size = 14;
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphRight;
                Name_Doc.Range.Text = "Главный директор ____________ (_________________)";
                document.Paragraphs.Add();
                Name_Doc.Range.Text = "Заместитель директора ____________ (_________________)";
                document.Paragraphs.Add();
                Name_Doc.Range.Text = "Сотрудник отдела кадров ____________ (_________________)";
            }
            catch (Exception ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + " " + ex.Message;
            }
            finally
            {
                document.SaveAs2(file_name, word.WdSaveFormat.wdFormatDocumentDefault);
                document.Close();
                application.Quit();
            }
        }

        public void Vakanti()
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
                    data.qrChek = "SELECT Naim_Otdela, Count_Chel FROM dbo.Otdel where Count_Chel > 0";
                    data.dtChekFill();
                    table = data.dtChek;
                    VakantiOtch();
                    break;
            }
        }

        public void Dogovor(string dog, string fiokl, string fiost, string ystr)
        {
            Document configurationForm = new Document();
            configurationForm.Document_Load(null, null);
            word.Application application = new word.Application();
            word.Document document = application.Documents.Add(Visible: true);
            word.Range range = document.Range(0, 0);
            file_name = Registry_Class.DirPath + "\\Д_" + "Договор клиента №" + dog + ".docx";
            MessageBox.Show(file_name);
            try
            {
                document.Sections.PageSetup.LeftMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocLM));
                document.Sections.PageSetup.RightMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocRM));
                document.Sections.PageSetup.TopMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocTM));
                document.Sections.PageSetup.BottomMargin
                    = application.CentimetersToPoints(Convert.ToSingle(Registry_Class.DocBM));
                range.Text = Registry_Class.OrganizationName;
                range.ParagraphFormat.Alignment
                    = word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.ParagraphFormat.SpaceAfter = 1;
                range.ParagraphFormat.SpaceBefore = 1;
                range.ParagraphFormat.LineSpacingRule = word.WdLineSpacing.wdLineSpaceSingle;
                range.Font.Name = "Times New Roman";
                range.Font.Size = 16;
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                word.Paragraph Name_Doc = document.Paragraphs.Add();
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Range.Font.Size = 14;
                Name_Doc.Range.Text = "Договор №" + dog;
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                Name_Doc.Range.Font.Name = "Times New Roman";
                Name_Doc.Range.Font.Size = 14;
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphLeft;
                Name_Doc.Range.Text = "Клиент: " + fiokl;
                document.Paragraphs.Add();
                Name_Doc.Range.Text = "Устройство: " + ystr;
                document.Paragraphs.Add();
                Name_Doc.Range.Text = "Сотрудник: " + fiost;
                document.Paragraphs.Add();
                Name_Doc.Range.Text = "Дата договора: " + DateTime.Now.ToLongDateString();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                document.Paragraphs.Add();
                Name_Doc.Format.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                string qrtext = dog;
                QRCodeEncoder encoder = new QRCodeEncoder();
                Bitmap qrcode = encoder.Encode(qrtext);
                qrcode.Save(file_name + ".jpeg", ImageFormat.Jpeg);
                var pPicture = document.Paragraphs.Last.Range;
                document.InlineShapes.AddPicture(@file_name + ".jpeg", Range: pPicture);

            }
            catch (Exception ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + " " + ex.Message;
            }
            finally
            {
                document.SaveAs2(file_name, word.WdSaveFormat.wdFormatDocumentDefault);
                document.Close();
                application.Quit();
            }
        }
    }
}
