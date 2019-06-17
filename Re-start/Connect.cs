using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using LibraryForSQLCon;

namespace Re_start
{
    public partial class Connect : Form
    {
        //Создание экземпляра класса
        private DataBase_Configuration configuration = new DataBase_Configuration();
        //Добавление переменной
        private Int32 status;

        public Connect()
        {
            InitializeComponent();
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            switch (DataBase_Configuration.logCon)
            {
                case (true):
                    //Запись имени сервера
                    cbDataSource.Text = Registry_Class.DS;
                    //Запись базы
                    cbInitialCatalog.Text = Registry_Class.IC;
                    //Делаем активным компонент
                    cbDataSource.Enabled = true;
                    //Делаем активным компонент
                    cbInitialCatalog.Enabled = true;
                    //Делаем активным компонент
                    tbUserID.Enabled = true;
                    //Делаем активным компонент
                    tbPassword.Enabled = true;
                    //Делаем активным компонент
                    btCheck.Enabled = true;
                    break;
                case (false):
                    //Присвоение значения
                    status = 1;
                    //Создаем поток по поиску сервера
                    Thread threadMessage = new Thread(tsslMessage);
                    threadMessage.Start();
                    //Заполнение данными найденных серверов
                    configuration.dtServers += dtservers;
                    //Получаем данные серверов
                    Thread thread = new Thread(configuration.Servers_get);
                    thread.Start();
                    break;
            }
        }

        private void dtservers(DataTable table)
        {
            try
            {
                Action action = () =>
                {
                    foreach (DataRow r in table.Rows)
                    {
                    //Заполнение найденными серверами
                    cbDataSource.Items.Add(r[0] + @"\" + r[1]);
                    }
                //Присвоение значения
                status = 0;
                //Делаем активным компонент
                cbDataSource.Enabled = true;
                //Делаем активным компонент
                tbUserID.Enabled = true;
                //Делаем активным компонент
                tbPassword.Enabled = true;
                //Делаем активным компонент
                btCheck.Enabled = true;
                };
                Invoke(action);
            }
            catch { }
        }

        private void tsslMessage()
        {
            try
            {
                //Делаем активным компонент
                tsslStatus.Visible = true;
                switch (status)
                {
                    case (1):
                        //Если 1 то Поиск серверов
                        tsslStatus.Text = "Поиск серверов";
                        break;
                    case (2):
                        //Если 2 то Поиск источников данных
                        tsslStatus.Text = "Поиск источников данных";
                        break;
                }
                do
                {
                    //Приостанавливаем поток
                    Thread.Sleep(750);
                    switch (status)
                    {
                        //Имитация поиска
                        case (1):
                            if (tsslStatus.Text == "Поиск серверов...")
                                tsslStatus.Text = "Поиск серверов";
                            else tsslStatus.Text = tsslStatus.Text + ".";
                            break;
                        case (2):
                            if (tsslStatus.Text == "Поиск источников данных...")
                                tsslStatus.Text = "Поиск источников данных";
                            else tsslStatus.Text = tsslStatus.Text + ".";
                            break;
                    }

                } while (status != 0);
                //Присвоение значения
                tsslStatus.Text = "-";
                //Невидимый объект
                tsslStatus.Visible = false;
                Thread.CurrentThread.Abort();
            }
            catch { }
        }

        private void BtCheck_Click(object sender, EventArgs e)
        {
            //Присваиваем значения
            configuration.cds = cbDataSource.Text;
            configuration.cui = tbUserID.Text;
            configuration.cpw = tbPassword.Text;
            configuration.dtDatabases += databases;
            status = 2;
            //Создаем поток для поиска таблиц
            Thread threadMessage = new Thread(tsslMessage);
            Thread thread = new Thread(configuration.Databases_get);
            threadMessage.Start();
            thread.Start();
        }

        private void databases(DataTable table)
        {
            Action action = () =>
            {
                //Очистка комбобокса
                cbInitialCatalog.Items.Clear();
                foreach (DataRow r in table.Rows)
                {
                    //Заполнение
                    cbInitialCatalog.Items.Add(r[0]);
                }
                status = 0;
                //Делаем активными элементы
                cbInitialCatalog.Enabled = true;
                btConect.Enabled = true;
            };
            Invoke(action);
        }

        private void BtConect_Click(object sender, EventArgs e)
        {
            Registry_Class registry = new Registry_Class();
            //Заносим данные в реестр
            registry.Registry_Set(cbDataSource.Text,
                cbInitialCatalog.Text, tbUserID.Text, tbPassword.Text);
            DataBase_Configuration.logCon = true;
            //Открываем главное меню приложения
            Autoriz main = new Autoriz();
            main.Show();
            Visible = false;
        }

        private void Connect_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                switch (DataBase_Configuration.logCon)
                {
                    case (true):
                        e.Cancel = false;
                        break;
                    case (false):
                        //Сообщение
                        switch (MessageBox.Show("Подключение не было уствновлено! " +
                            "\n Завершить работу приложения?", "Re-store",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            case DialogResult.Yes:
                                e.Cancel = false;

                                break;
                            case DialogResult.No:
                                e.Cancel = true;
                                break;
                        }
                        break;
                }
                Program.fff.Close();
                Hide();
            }
            catch { }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Program.fff.Close();
                Hide();
            }
            catch
            {

            }
        }
    }
}
