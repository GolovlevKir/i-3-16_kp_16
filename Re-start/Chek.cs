using LibraryForSQLCon;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Chek : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        int skidka = 0;
        public Chek()
        {
            InitializeComponent();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Chek_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }

        private void Chek_Load(object sender, EventArgs e)
        {
            Thread threadContract = new Thread(ContractsLoad);
            threadContract.Start();
            Thread threadChek = new Thread(ChekLoad);
            threadChek.Start();

        }

        public void ContractsLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        //Вывод контрактов
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtRepairs.Clear();
                        dataComb.dtRepairsFill();
                        dataComb.dependency.OnChange += Contractsonchange;
                        comboBox1.DataSource = dataComb.dtRepairs;
                        comboBox1.ValueMember = "ID_Repairs";
                        comboBox1.DisplayMember = "Num_Contr";
                        comboBox1.SelectedItem = 1;
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Contractsonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                ContractsLoad();
        }

        public void ChekLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        //Заполнение чеков
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtChek.Clear();
                        dataComb.dtChekFill();
                        dataComb.dependency.OnChange += Chekonchange;
                        dataGridView1.DataSource = dataComb.dtChek;
                        Int32 index = dataGridView1.Rows.Count - 1;
                        dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[1];
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].HeaderText = "№ чека";
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[4].HeaderText = "Дата и время продажи";
                        dataGridView1.Columns[5].HeaderText = "Стоимость";
                        


                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Chekonchange(object sender, SqlNotificationEventArgs e)
        {
            try
            {
                //Прослушивание
                if (e.Info != SqlNotificationInfo.Invalid)
                {
                    ChekLoad();
                    Int32 index = dataGridView1.Rows.Count - 1;
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[1];
                    Thread threadChek = new Thread(Dan_CheckLoad);
                    threadChek.Start();
                }
            }
            catch { }
        }

        public void Dan_CheckLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        //Заполнение данных чека
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtDan_Check.Clear();
                        dataComb.qrDan_Check += " where dbo.Dan_Check.Chek_ID = " + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        dataComb.dtDan_CheckFill();
                        dataComb.dependency.OnChange += Dan_Checkonchange;
                        dataGridView2.DataSource = dataComb.dtDan_Check;
                        dataGridView2.Columns[0].Visible = false;
                        dataGridView2.Columns[1].Visible = false;
                        dataGridView2.Columns[2].Visible = false;
                        dataGridView2.Columns[3].Visible = false;
                        dataGridView2.Columns[4].Visible = false;
                        dataGridView2.Columns[5].Visible = false;
                        dataGridView2.Columns[6].HeaderText = "Наименование договора";
                        dataGridView2.Columns[7].HeaderText = "Стоимость";

                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Dan_Checkonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
            {
                Dan_CheckLoad();
                ChekLoad();
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Dan_CheckLoad();
        }

        private void DataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = dataGridView2.CurrentRow.Cells[3].Value;
            numericUpDown1.Value = (decimal)dataGridView2.CurrentRow.Cells[7].Value;

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        string j;
        int i;

        private void Button15_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
            //Поиск максимально значения чека
            command.CommandText = "select Max(Convert(int, SUBSTRING(Num_Check,7,8))) from Chek";
            Registry_Class.sqlConnection.Open();
            try
            {
                i = (int)command.ExecuteScalar();
            }
            catch
            {
                i = 0;
            }
            //Создаем уникальный номер
            command.CommandText = "select CONVERT(varchar(max), datepart(day, getdate())) + CONVERT(varchar(max), datepart(MONTH, getdate())) + CONVERT(varchar(max), datepart(YEAR, getdate()))";
            j = command.ExecuteScalar().ToString();
            Registry_Class.sqlConnection.Close();
            i++;
            //Добавление чека в БД
            procedure.spAdd_Chek(j + i.ToString(), DateTime.Now.ToString("d"), DateTime.Now.ToShortTimeString());
            label6.Text = "Номер: " + j + i.ToString();
            label1.Text = "Дата: " + DateTime.Now.ToString("d");
            label2.Text = "Время: " + DateTime.Now.ToShortTimeString();

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


            }
            catch
            { }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            //Добавление данных чека
            procedure.spADD_Dan_Check((int)dataGridView1.CurrentRow.Cells[0].Value, (int)comboBox1.SelectedValue);
            Dan_CheckLoad();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            //Изменение данных
            procedure.spUpd_Dan_Check((int)dataGridView2.CurrentRow.Cells[0].Value, (int)dataGridView1.CurrentRow.Cells[0].Value, (int)comboBox1.SelectedValue, numericUpDown1.Value);
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            //Удаление данных чека
            procedure.spDel_Dan_Check((int)dataGridView2.CurrentRow.Cells[0].Value);
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            //Удаление чека
            procedure.spDel_Chek((int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            //Скидка
            numericUpDown1.Value = (decimal)numericUpDown1.Value - ((decimal)numericUpDown1.Value * Convert.ToDecimal(0.15));
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //Формирование отчета о закрытии смены
            WordDocument wordDocument = new WordDocument();
            new Thread(() => {
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = false;
                }));
                wordDocument.CheZaDen();
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = true;
                    MessageBox.Show("Отчет сохранен!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Process.Start(@wordDocument.file_name);
                }));
            }).Start();
        }
    }
}
