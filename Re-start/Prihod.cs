using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Prihod : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        public Prihod()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Prihod_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(Prihod_DetailsLoad);
            thread.Start();
            Thread thread2 = new Thread(DetailsLoad);
            thread2.Start();
        }

        public void Prihod_DetailsLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtPrihod_Details.Clear();
                        dataComb.dtPrihod_DetailsFill();
                        dataComb.dependency.OnChange += Prihod_Detailsonchange;
                        dataGridView1.DataSource = dataComb.dtPrihod_Details;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].HeaderText = "Деталь";
                        dataGridView1.Columns[4].HeaderText = "Пришло штук";
                        dataGridView1.Columns[5].HeaderText = "Дата прихода";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Prihod_Detailsonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                Prihod_DetailsLoad();
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
            try
            {
                comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value;
                numericUpDown1.Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch { }
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ПОИСК...")
                textBox1.Text = "";
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataBaseTables dataComb = new DataBaseTables();
                dataComb.dtPrihod_Details.Clear();
                dataComb.qrPrihod_Details += " where Naim_Details like '%" + textBox1.Text + "%' or Count_Prih like '%" + textBox1.Text + "%' or Data_Prih like '%" + textBox1.Text + "%'";
                dataComb.dtPrihod_DetailsFill();
                dataComb.dependency.OnChange += Prihod_Detailsonchange;
                dataGridView1.DataSource = dataComb.dtPrihod_Details;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].HeaderText = "Деталь";
                dataGridView1.Columns[4].HeaderText = "Пришло штук";
                dataGridView1.Columns[5].HeaderText = "Дата прихода";
            }
            catch { }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            procedure.spADD_Prihod_Details((int)numericUpDown1.Value, dateTimePicker1.Text, (int)comboBox1.SelectedValue);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            procedure.spUpd_Prihod_Details((int)dataGridView1.CurrentRow.Cells[0].Value, (int)numericUpDown1.Value, dateTimePicker1.Text, (int)comboBox1.SelectedValue);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            procedure.spDel_Prihod_Details((int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WordDocument wordDocument = new WordDocument();
            new Thread(() => {
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = false;
                }));
                wordDocument.PrihZaDen();
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = true;
                    MessageBox.Show("Отчет сохранен!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }));
            }).Start();
            
        }
    }
}
