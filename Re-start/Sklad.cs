using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Sklad : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        public Sklad()
        {
            InitializeComponent();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        public void SkladLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtSklad.Clear();
                        dataComb.dtSkladFill();
                        dataComb.dependency.OnChange += Skladonchange;
                        dataGridView1.DataSource = dataComb.dtSklad;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].HeaderText = "Наименование детали";
                        dataGridView1.Columns[4].HeaderText = "Количество";
                        dataGridView1.Columns[5].Visible = false;
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Skladonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                SkladLoad();
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

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            numericUpDown1.Value = (int)dataGridView1.CurrentRow.Cells[5].Value;
        }

        private void Sklad_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(SkladLoad);
            thread.Start();
            Thread thread2 = new Thread(DetailsLoad);
            thread2.Start();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            procedure.spADD_Sklad((int)comboBox1.SelectedValue, (int)numericUpDown1.Value);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            procedure.spUpd_Sklad((int)dataGridView1.CurrentRow.Cells[0].Value, (int)comboBox1.SelectedValue, (int)numericUpDown1.Value);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            procedure.spSklad_Logical_Delete((int)dataGridView1.CurrentRow.Cells[0].Value);
            //procedure.spDel_Sklad((int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ExcelDocument excel = new ExcelDocument();
            new Thread(() => {
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = false;
                }));
                excel.otchPoSkladu();
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = true;
                    MessageBox.Show("Отчет сохранен");
                }));
            }).Start();
        }
    }
}
