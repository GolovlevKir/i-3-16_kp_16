using LibraryForSQLCon;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Dogovora : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        private System.Drawing.Printing.PrintDocument docToPrint =
    new System.Drawing.Printing.PrintDocument();
        public Dogovora()
        {
            InitializeComponent();
        }

        private void Dogovora_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dogovora_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Thread threadContract = new Thread(ContractLoad);
            threadContract.Start();
            Thread threadModel_Device = new Thread(Model_DeviceLoad);
            threadModel_Device.Start();
            Thread threadKl = new Thread(KlientsLoad);
            threadKl.Start();
            Thread threadSt = new Thread(SotrLoad);
            threadSt.Start();
        }

        public void ContractLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtContracts.Clear();
                        dataComb.dtContractsFill();
                        dataComb.dependency.OnChange += Contractonchange;
                        dataGridView1.DataSource = dataComb.dtContracts;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.Columns[7].Visible = false;
                        dataGridView1.Columns[8].Visible = false;
                        dataGridView1.Columns[9].Visible = false;
                        dataGridView1.Columns[11].Visible = false;
                        dataGridView1.Columns[12].Visible = false;
                        dataGridView1.Columns[13].Visible = false;
                        dataGridView1.Columns[1].HeaderText = "№ договора";
                        dataGridView1.Columns[4].HeaderText = "ФИО клиента";
                        dataGridView1.Columns[6].HeaderText = "Наименование устройства";
                        dataGridView1.Columns[10].HeaderText = "ФИО сотрудника";
                        dataGridView1.Columns[14].HeaderText = "Комментарий";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }
        private void Contractonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                ContractLoad();
        }

        public void Model_DeviceLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtModel_Device.Clear();
                        dataComb.dtModel_DeviceFill();
                        dataComb.dependency.OnChange += Model_Deviceonchange;
                        comboBox1.DataSource = dataComb.dtModel_Device;
                        comboBox1.ValueMember = "ID_Model";
                        comboBox1.DisplayMember = "Модели";
                        comboBox3.DataSource = dataComb.dtModel_Device;
                        comboBox3.ValueMember = "ID_Model";
                        comboBox3.DisplayMember = "Модели";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Model_Deviceonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                Model_DeviceLoad();
        }

        public void KlientsLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtKlient.Clear();
                        dataComb.dtKlientsFill();
                        dataComb.dependency.OnChange += Klientsonchange;
                        comboBox2.DataSource = dataComb.dtKlient;
                        comboBox2.ValueMember = "Login_Kl";
                        comboBox2.DisplayMember = "Клиент";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Klientsonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                KlientsLoad();
        }

        public void SotrLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtSotr.Clear();
                        dataComb.dtSotrFill();
                        dataComb.dependency.OnChange += Sotronchange;
                        comboBox4.DataSource = dataComb.dtSotr;
                        comboBox4.ValueMember = "Login_St";
                        comboBox4.DisplayMember = "Сотрудник";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Sotronchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                SotrLoad();
        }

        private void TextBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Поиск производителя...")
                textBox2.Text = "";
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataBaseTables dataComb = new DataBaseTables();
                dataComb.qrModel_Device += " where dbo.Type_Device.Naim_type like '%" + textBox2.Text + "%' or dbo.Proizvod_Device.Naim_Proizvod like '%" + textBox2.Text + "%' or dbo.Model_Device.Naim_Model like '%" + textBox2.Text + "%'";
                dataComb.dtModel_Device.Clear();
                dataComb.dtModel_DeviceFill();
                dataComb.dependency.OnChange += Model_Deviceonchange;
                comboBox1.DataSource = dataComb.dtModel_Device;
                comboBox1.ValueMember = "ID_Model";
                comboBox1.DisplayMember = "Модели";

            }
            catch { }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            checkBox1.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[11].Value);
            checkBox2.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[12].Value);
            checkBox3.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[13].Value);
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            procedure.spDel_Contracts((int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            procedure.spUpd_Contracts((int)dataGridView1.CurrentRow.Cells[0].Value, dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), (int)comboBox1.SelectedValue, dataGridView1.CurrentRow.Cells[9].Value.ToString(), Convert.ToInt32(checkBox1.Checked), Convert.ToInt32(checkBox2.Checked), Convert.ToInt32(checkBox3.Checked), richTextBox1.Text);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
                command.CommandText = "SELECT substring(Login_Kl,1,3) + 'RS' + CONVERT(varchar(max), datepart(day, getdate())) + CONVERT(varchar(max), datepart(MONTH, getdate())) + CONVERT(varchar(max), datepart(YEAR, getdate())) + CONVERT(varchar(max), datepart(HOUR, getdate())) + CONVERT(varchar(max), datepart(MINUTE, getdate())) + CONVERT(varchar(max), datepart(SECOND, getdate())) FROM dbo.Klient where Login_Kl = '" + comboBox2.SelectedValue.ToString() + "'";
                Registry_Class.sqlConnection.Open();
                string NumDogo = command.ExecuteScalar().ToString();
                Registry_Class.sqlConnection.Close();
                label2.Text = NumDogo;
                button5.Enabled = true;
            }
            catch { }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            procedure.spAdd_Contracts(label2.Text, comboBox2.SelectedValue.ToString(), (int)comboBox3.SelectedValue, comboBox4.SelectedValue.ToString(), Convert.ToInt32(checkBox4.Checked), Convert.ToInt32(checkBox5.Checked), Convert.ToInt32(checkBox6.Checked), richTextBox2.Text);
            button5.Enabled = false;
            WordDocument document = new WordDocument();

            document.Dogovor(label2.Text, comboBox2.Text, comboBox4.Text, comboBox3.Text);
            Process.Start(document.file_name);
            label2.Text = "";
        }
    }
}
