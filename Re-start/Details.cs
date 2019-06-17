using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Details : Form
    {
        int sch = 1;
        DataBaseProcedure procedure = new DataBaseProcedure();
        public Details()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = checkBox1.Checked;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            switch (sch)
            {
                case 0:
                    timer1.Enabled = true;
                    sch = 1;
                    button3.Text = "+";
                    break;
                case 1:
                    timer1.Enabled = true;
                    sch = 0;
                    button3.Text = "-";
                    break;
            }
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            if (sch == 0)
            {
                new Thread(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        while (panel2.Width <= 150)
                        {
                            panel2.Width += 20;
                            Refresh();
                        }
                    }));
                }).Start();
            }
            else
            {
                new Thread(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        while (panel2.Width > 0)
                        {
                            panel2.Width -= 20;
                            Refresh();
                        }
                    }));
                }).Start();
            }
        }

        public void GarantLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtGarant.Clear();
                        dataComb.dtGarantFill();
                        dataComb.dependency.OnChange += Garantonchange;
                        listBox1.DataSource = dataComb.dtGarant;
                        listBox1.ValueMember = "ID_Garant";
                        listBox1.DisplayMember = "Dlitelnost";
                        comboBox1.DataSource = dataComb.dtGarant;
                        comboBox1.ValueMember = "ID_Garant";
                        comboBox1.DisplayMember = "Dlitelnost";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Garantonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                GarantLoad();
        }

        public void ModelLoad()
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
                        dataComb.dependency.OnChange += Modelonchange;
                        comboBox2.DataSource = dataComb.dtModel_Device;
                        comboBox2.ValueMember = "ID_Model";
                        comboBox2.DisplayMember = "Модели";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Modelonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                ModelLoad();
        }

        public void DetailsLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtDetails.Clear();
                        dataComb.qrDetails += " where Details_Logical_Delete = 0";
                        dataComb.dtDetailsFill();
                        dataComb.dependency.OnChange += Detailsonchange;
                        dataGridView1.DataSource = dataComb.dtDetails;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].HeaderText = "Наименование детали";
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[4].HeaderText = "Гарантия";
                        dataGridView1.Columns[5].HeaderText = "Модель";
                        dataGridView1.Columns[6].Visible = false;
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Detailsonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                DetailsLoad();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            Thread threadGarant = new Thread(GarantLoad);
            threadGarant.Start();
            Thread threadModel = new Thread(ModelLoad);
            threadModel.Start();
            Thread threadDetails = new Thread(DetailsLoad);
            threadDetails.Start();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.Text; 
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value;
            comboBox2.SelectedValue = dataGridView1.CurrentRow.Cells[7].Value;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            procedure.spADD_Details(textBox2.Text, (int)comboBox1.SelectedValue, (int)comboBox2.SelectedValue);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            procedure.spUpd_Details((int)dataGridView1.CurrentRow.Cells[0].Value, textBox2.Text, (int)comboBox1.SelectedValue, (int)comboBox2.SelectedValue);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            procedure.spLogical_Delete_Details((int)dataGridView1.CurrentRow.Cells[0].Value);
            //procedure.spLogical_Delete_Details((int)dataGridView1.CurrentRow.Cells[0].Value);
        }
    }
}
