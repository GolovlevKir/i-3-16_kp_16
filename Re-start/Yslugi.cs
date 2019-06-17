using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Yslugi : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        public Yslugi()
        {
            InitializeComponent();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void Yslugi_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(DetailsLoad);
            thread.Start();
            Thread thread2 = new Thread(YslLoad);
            thread2.Start();
            switch (Program.PoiskSotr)
            {
                case 0:
                    button3.Enabled = true;
                    break;
                case 1:
                    panel6.Height = 150;
                    break;
            }
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
                        dataComb.dtDetailsFill();
                        dataComb.dependency.OnChange += Detailsonchange;
                        comboBox1.DataSource = dataComb.dtDetails;
                        comboBox1.ValueMember = "ID_Details";
                        comboBox1.DisplayMember = "Деталь";
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

        public void YslLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtServices.Clear();
                        switch (Program.PoiskSotr)
                        {
                            case 0:
                                dataComb.qrServices += " CROSS JOIN dbo.Sklad where Count_Det >= 0 group by ID_Services, Naim_Services, Stoimost_Serv, Dlitelnost, dbo.Services.Details_ID, ID_Details, Naim_Model, Naim_Proizvod";
                                break;
                            case 1:
                                switch (Program.Roles)
                                {
                                    case 0:
                                        dataComb.qrServices += " where Services_Logical_Delete = 0";
                                        break;
                                }
                                break;
                        }
                        dataComb.dtServicesFill();
                        dataComb.dependency.OnChange += Yslonchange;
                        dataGridView1.DataSource = dataComb.dtServices;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].HeaderText = "Стоимость";
                        dataGridView1.Columns[3].HeaderText = "Длительность (дней)";
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.Columns[6].HeaderText = "Наименование услуги";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Yslonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                YslLoad();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value;
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                numericUpDown2.Value = (decimal)dataGridView1.CurrentRow.Cells[2].Value;
                numericUpDown1.Value = (int)dataGridView1.CurrentRow.Cells[3].Value;
            }
            catch
            {

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            procedure.spADD_Store_Basket(Program.prof, (int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            procedure.spADD_Services(textBox2.Text, numericUpDown2.Value, (int)numericUpDown1.Value, (int)comboBox1.SelectedValue);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            procedure.spUpd_Services((int)dataGridView1.CurrentRow.Cells[0].Value, textBox2.Text, numericUpDown2.Value, (int)numericUpDown1.Value, (int)comboBox1.SelectedValue);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            procedure.spServices_Logical_Delete((int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //"where dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model like '%%'";
                DataBaseTables dataComb = new DataBaseTables();
                dataComb.dtServices.Clear();
                switch (Program.PoiskSotr)
                {
                    case 0:
                        dataComb.qrServices += " CROSS JOIN dbo.Sklad where Count_Det >= 0 and dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model like '%" + textBox1.Text + "%' or Naim_Services like '%" + textBox1.Text + "%' group by ID_Services, Naim_Services, Stoimost_Serv, Dlitelnost, dbo.Services.Details_ID, ID_Details, Naim_Model, Naim_Proizvod";
                        break;
                    case 1:
                        switch (Program.Roles)
                        {
                            case 0:
                                dataComb.qrServices += " where Services_Logical_Delete = 0 and dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model like '%" + textBox1.Text + "%' or Naim_Services like '%" + textBox1.Text + "%'";
                                break;
                            case 1:
                                dataComb.qrServices += " where dbo.Proizvod_Device.Naim_Proizvod + ' ' + dbo.Model_Device.Naim_Model like '%" + textBox1.Text + "%' or Naim_Services like '%" + textBox1.Text + "%'";
                                break;
                        }
                        break;
                }
                dataComb.dtServicesFill();
                dataComb.dependency.OnChange += Yslonchange;
                dataGridView1.DataSource = dataComb.dtServices;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Стоимость";
                dataGridView1.Columns[3].HeaderText = "Длительность (дней)";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "Наименование услуги";
            }
            catch { }

        }
    }
}
