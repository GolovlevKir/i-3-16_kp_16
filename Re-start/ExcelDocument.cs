using System;
using excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using LibraryForSQLCon;

namespace Re_start
{
    class ExcelDocument
    {
        public string name = "";
        public System.Data.DataTable dtDannieSklada = new System.Data.DataTable();
        //Список товара на складе
        public void SpisokOnSklad()
        {
            string name = Registry_Class.DirPath + "Список товара на складе "
                + DateTime.Now.ToString("_hh_mm_ss_dd_MM_yyyy") + ".xlsx";
            excel.Application application = new excel.Application();
            excel.Workbook workbook = application.Workbooks.Add();
            excel.Worksheet worksheet =
                (excel.Worksheet)workbook.ActiveSheet;
            try
            {
                worksheet.Name = "Данные склада";
                worksheet.Cells[4, 1] = "Наименование товара";
                worksheet.Cells[4, 2] = "Количество";
                for (int i = 0; i < dtDannieSklada.Rows.Count; i++)
                {
                    worksheet.Cells[i + 5, 1] = dtDannieSklada.Rows[i][0].ToString();
                    worksheet.Cells[i + 5, 2] = dtDannieSklada.Rows[i][1].ToString();
                    worksheet.Columns[1].AutoFit();
                    worksheet.Columns[2].AutoFit();
                }
                worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[4, 2]].Interior.Color = XlRgbColor.rgbLightGray;

                excel.Range conf_cell = worksheet.Cells[3, 3];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;
                conf_cell = worksheet.Cells[4, 1];

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]].Merge();
                worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 2]].Merge();

                worksheet.Cells[2, 1] = "Список товара имеющегося на складе на " + DateTime.Now.ToLongDateString();
                conf_cell = worksheet.Cells[2, 1];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;

                worksheet.Cells[1, 1] = Registry_Class.OrganizationName;
                conf_cell = worksheet.Cells[1, 1];
                conf_cell.HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.VerticalAlignment = excel.XlHAlign.xlHAlignCenter;
                conf_cell.WrapText = true;
                conf_cell.RowHeight = 50;

                worksheet.Cells[dtDannieSklada.Rows.Count + 10, 1]
                    = "Главный директор        __________________";
                worksheet.Cells[dtDannieSklada.Rows.Count + 10, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 11, 1]
                    = "Заместитель директора        __________________";
                worksheet.Cells[dtDannieSklada.Rows.Count + 11, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 12, 1]
                    = "Кладовщик        __________________";
                worksheet.Cells[dtDannieSklada.Rows.Count + 12, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                worksheet.Cells[dtDannieSklada.Rows.Count + 13, 1]
                    = "Дата: " + DateTime.Now.ToLongDateString();
                worksheet.Cells[dtDannieSklada.Rows.Count + 13, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

                application.ActiveWindow.View = XlWindowView.xlPageBreakPreview;

            }
            catch (Exception ex)
            {
                Registry_Class.error_message += "\n"
                    + DateTime.Now.ToLongDateString() + " " + ex.Message;
            }
            finally
            {
                workbook.SaveAs(name, application.DefaultSaveFormat);
                workbook.Close();
                application.Quit();
            }
        }

        public void otchPoSkladu()
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
                    data.qrSklad = "SELECT dbo.Details.Naim_Details + ' для ' + dbo.Type_Device.Naim_type + ' ' + dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model as 'Деталь', Convert(varchar(10), dbo.Sklad.Count_Det) + ' шт.' FROM dbo.Sklad JOIN dbo.Details ON dbo.Sklad.Details_ID = dbo.Details.ID_Details JOIN dbo.Model_Device ON dbo.Details.Model_ID = dbo.Model_Device.ID_Model JOIN dbo.Proizvod_Device ON dbo.Model_Device.Proizvod_ID = dbo.Proizvod_Device.ID_Proizvod JOIN dbo.Type_Device ON dbo.Proizvod_Device.Type_ID = dbo.Type_Device.ID_Type";
                    data.dtSkladFill();
                    dtDannieSklada = data.dtSklad;
                    SpisokOnSklad();
                    break;
            }
        }
    }
}
