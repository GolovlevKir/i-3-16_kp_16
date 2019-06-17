using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Remonti : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        public Remonti()
        {
            InitializeComponent();
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Remonti_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(ContractsLoad);
            thread.Start();
            Thread thread2 = new Thread(ServicesLoad);
            thread2.Start();
            Thread thread3 = new Thread(RepairsLoad);
            thread3.Start();
        }

        public void ContractsLoad()
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
                        dataComb.dependency.OnChange += Contractsonchange;
                        comboBox1.DataSource = dataComb.dtContracts;
                        comboBox1.ValueMember = "ID_Contr";
                        comboBox1.DisplayMember = "Num_Contr";
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

        public void ServicesLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtServices.Clear();
                        dataComb.dtServicesFill();
                        dataComb.dependency.OnChange += Servicesonchange;
                        comboBox2.DataSource = dataComb.dtServices;
                        comboBox2.ValueMember = "ID_Services";
                        comboBox2.DisplayMember = "Услуга";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Servicesonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                ServicesLoad();
        }

        public void RepairsLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtRepairs.Clear();
                        dataComb.dtRepairsFill();
                        dataComb.dependency.OnChange += Repairsonchange;
                        dataGridView1.DataSource = dataComb.dtRepairs;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[7].Visible = false;
                        dataGridView1.Columns[8].Visible = false;
                        dataGridView1.Columns[3].HeaderText = "№ договора";
                        dataGridView1.Columns[4].HeaderText = "Дата начала";
                        dataGridView1.Columns[5].HeaderText = "Дата окончания";
                        dataGridView1.Columns[6].HeaderText = "Статус";
                        dataGridView1.Columns[9].HeaderText = "Услуга";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Repairsonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                RepairsLoad();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value;
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox2.SelectedValue = dataGridView1.CurrentRow.Cells[8].Value;
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            procedure.spADD_Repairs((int)comboBox1.SelectedValue, dateTimePicker1.Text, dateTimePicker2.Text, richTextBox1.Text, (int)comboBox2.SelectedValue);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            procedure.spUpd_Repairs((int)dataGridView1.CurrentRow.Cells[0].Value, (int)comboBox1.SelectedValue, dateTimePicker1.Text, dateTimePicker2.Text, richTextBox1.Text, (int)comboBox2.SelectedValue);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            procedure.spDel_Repairs((int)dataGridView1.CurrentRow.Cells[0].Value);
        }
    }
}
