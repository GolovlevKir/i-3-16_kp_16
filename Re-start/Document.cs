using LibraryForSQLCon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Document : Form
    {
        decimal TM, RM, BM, LM;

        private void BtApplye_Click(object sender, EventArgs e)
        {
            //применение настроек
            switch (tcConfig.SelectedIndex)
            {
                case (0):
                    OrganizationSave();
                    break;
                case (1):
                    DocumentSave();
                    break;
            }
        }

        private void NudLeftMerg_ValueChanged(object sender, EventArgs e)
        {
            //изменение левого колонтитула
            if (nudLeftMerg.Value > LM)
            {
                pnText.Width -= (int)nudLeftMerg.Value;
                pnText.Left += (int)nudLeftMerg.Value;
            }
            else
            {
                pnText.Width += (int)nudLeftMerg.Value;
                pnText.Left -= (int)nudLeftMerg.Value;
            }
            LM = nudLeftMerg.Value;
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            //закрытие
            Program.fff.Close();
            Close();
        }

        private void NudRightMerg_ValueChanged(object sender, EventArgs e)
        {
            //настройка правого колонтитула
            if (nudRightMerg.Value > RM)
                pnText.Width -= (int)nudRightMerg.Value;
            else
                pnText.Width += (int)nudRightMerg.Value;
            RM = nudRightMerg.Value;
        }

        private void NudTopMerg_ValueChanged(object sender, EventArgs e)
        {
            //настройка верхнево колонтитула
            if (nudTopMerg.Value > TM)
            {
                pnText.Height -= (int)nudTopMerg.Value;
                pnText.Top += (int)nudTopMerg.Value;
            }
            else
            {
                pnText.Height += (int)nudTopMerg.Value;
                pnText.Top -= (int)nudTopMerg.Value;
            }
            TM = nudTopMerg.Value;
        }

        private void NudBottomMerg_ValueChanged(object sender, EventArgs e)
        {
            //настройка нижнего колонтитула
            if (nudBottomMerg.Value > BM)
                pnText.Height -= (int)nudBottomMerg.Value;
            else
                pnText.Height += (int)nudBottomMerg.Value;
            BM = nudBottomMerg.Value;
        }

        public void Document_Load(object sender, EventArgs e)
        {
            registry.ConfigurationGet();
            rtbOrganizationName.Text = Registry_Class.OrganizationName;
            tbPath.Text = Registry_Class.DirPath;
            nudTopMerg.Value = (decimal)Registry_Class.DocTM;
            nudRightMerg.Value = (decimal)Registry_Class.DocRM;
            nudBottomMerg.Value = (decimal)Registry_Class.DocBM;
            nudLeftMerg.Value = (decimal)Registry_Class.DocLM;
            TM = nudTopMerg.Value;
            RM = nudRightMerg.Value;
            BM = nudBottomMerg.Value;
            LM = nudLeftMerg.Value;
            pnText.Top += (int)TM * 10;
            pnText.Height -= (int)TM * 10;
            pnText.Width -= (int)RM * 10;
            pnText.Height -= (int)BM * 10;
            pnText.Left += (int)LM * 10;
            pnText.Width -= (int)LM * 10;
        }

        private void BtBrowse_Click(object sender, EventArgs e)
        {
            //Окрытие проводника
            folderBrowserDialog1.ShowDialog();
            tbPath.Text = folderBrowserDialog1.SelectedPath + "\\Отчёты сервисного центра Re-start\\";
        }

        Registry_Class registry = new Registry_Class();

        public Document()
        {
            InitializeComponent();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            //Сохранение 
            OrganizationSave();
            DocumentSave();
            Close();
        }

        private void DocumentSave()
        {
            //параметры сохранения
            string document_default_path = "";
            switch (tbPath.Text == "")
            {
                case (true):
                    document_default_path =
                        "C:\\Users\\" + SystemInformation.UserName
                        + "\\Documents\\Отчёты сервисного центра Re-start";
                    if (!Directory.Exists(document_default_path))
                        Directory.CreateDirectory(document_default_path);
                    break;
                case (false):
                    document_default_path = tbPath.Text;
                    if (!Directory.Exists(document_default_path))
                        Directory.CreateDirectory(document_default_path);
                    break;
            }
            registry.DocumentConfigurationSet(tbPath.Text, nudLeftMerg.Value,
                nudTopMerg.Value,
                nudRightMerg.Value, nudBottomMerg.Value);
        }

        private void OrganizationSave()
        {
            registry.MajorConfigurationSet(rtbOrganizationName.Text);
        }
    }
}
