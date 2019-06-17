using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(LogLoad);
            thread.Start();
        }

        public void LogLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtCHANGES_LOG.Clear();
                        dataComb.dtCHANGES_LOGFill();
                        dataComb.dependency.OnChange += Logonchange;
                        dataGridView1.DataSource = dataComb.dtCHANGES_LOG;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].HeaderText = "Время изменения";
                        dataGridView1.Columns[2].HeaderText = "Действие";
                        dataGridView1.Columns[3].HeaderText = "Данные";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Logonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                LogLoad();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }
    }
}
