using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Testirovaniya : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        public Testirovaniya()
        {
            InitializeComponent();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void Testirovaniya_Load(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(ContractLoad);
            thread1.Start();
            Thread thread2 = new Thread(ContractsLoad);
            thread2.Start();
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
                        dataComb.dtTests.Clear();
                        dataComb.qrTests += " where dbo.Tests.Zaversh = 0";
                        dataComb.dtTestsFill();
                        dataComb.dependency.OnChange += Contractonchange;
                        dataGridView1.DataSource = dataComb.dtTests;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].HeaderText = "Наименование договора";
                        dataGridView1.Columns[4].Visible = false;
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

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            DataBaseTables dataComb = new DataBaseTables();
            string currentButton = radioBtn.Name;
            if (radioBtn.Checked == true)
            {
                switch (currentButton)
                {
                    case "radioButton1":

                        dataComb.dtTests.Clear();
                        dataComb.dtTestsFill();
                        dataComb.dependency.OnChange += Contractonchange;
                        dataGridView1.DataSource = dataComb.dtTests;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].HeaderText = "Наименование договора";
                        dataGridView1.Columns[4].Visible = false;
                        break;
                    case "radioButton2":
                        dataComb.dtTests.Clear();
                        dataComb.qrTests += " where dbo.Tests.Zaversh = 1";
                        dataComb.dtTestsFill();
                        dataComb.dependency.OnChange += Contractonchange;
                        dataGridView1.DataSource = dataComb.dtTests;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].HeaderText = "Наименование договора";
                        dataGridView1.Columns[4].Visible = false;
                        break;
                    case "radioButton3":
                        dataComb.dtTests.Clear();
                        dataComb.qrTests += " where dbo.Tests.Zaversh = 0";
                        dataComb.dtTestsFill();
                        dataComb.dependency.OnChange += Contractonchange;
                        dataGridView1.DataSource = dataComb.dtTests;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].HeaderText = "Наименование договора";
                        dataGridView1.Columns[4].Visible = false;
                        break;
                }
            }
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

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                checkBox1.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);
            }
            catch { }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            procedure.spADD_Tests((int)comboBox1.SelectedValue, Convert.ToInt32(checkBox1.Checked));
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            procedure.spUpd_Tests((int)dataGridView1.CurrentRow.Cells[0].Value, (int)comboBox1.SelectedValue, Convert.ToInt32(checkBox1.Checked));
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            procedure.spDel_Tests((int)dataGridView1.CurrentRow.Cells[0].Value);
            
        }

    }
}
