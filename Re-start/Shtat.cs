using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Shtat : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        public Shtat()
        {
            InitializeComponent();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void Shtat_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(OtdelLoad);
            thread.Start();
        }

        public void OtdelLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtOtdel.Clear();
                        dataComb.dtOtdelFill();
                        dataComb.dependency.OnChange += Otdelonchange;
                        dataGridView1.DataSource = dataComb.dtOtdel;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].HeaderText = "Наименование отдела";
                        dataGridView1.Columns[2].HeaderText = "Количество вакантных мест";
                        comboBox1.DataSource = dataComb.dtOtdel;
                        comboBox1.ValueMember = "ID_Otdel";
                        comboBox1.DisplayMember = "Naim_Otdela";
                        Thread thread = new Thread(DoljLoad);
                        thread.Start();
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Otdelonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                OtdelLoad();
        }

        public void DoljLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtDolj.Clear();
                        dataComb.qrDolj += " where dbo.Dolj.Otdel_ID = " + comboBox1.SelectedValue.ToString();
                        dataComb.dtDoljFill();
                        dataComb.dependency.OnChange += Doljonchange;
                        dataGridView2.DataSource = dataComb.dtDolj;
                        dataGridView2.Columns[0].Visible = false;
                        dataGridView2.Columns[1].Visible = false;
                        dataGridView2.Columns[2].Visible = false;
                        dataGridView2.Columns[3].Visible = false;
                        dataGridView2.Columns[4].HeaderText = "Наименование должности";
                        dataGridView2.Columns[5].HeaderText = "Оклад";
                        dataGridView2.Columns[6].HeaderText = "Дней на испытательный срок";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Doljonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                DoljLoad();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            numericUpDown1.Value = (int)dataGridView1.CurrentRow.Cells[2].Value;
        }

        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoljLoad();
            

        }

        private void DataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                numericUpDown1.Value = (int)dataGridView1.CurrentRow.Cells[2].Value;
            }
            catch { }
        }

        private void DataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                numericUpDown2.Value = Convert.ToDecimal(dataGridView2.CurrentRow.Cells[5].Value);
                numericUpDown3.Value = Convert.ToDecimal(dataGridView2.CurrentRow.Cells[6].Value);
            }
            catch { }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            procedure.SpADD_Otdel(textBox2.Text, (int)numericUpDown1.Value);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            procedure.SpUpd_Otdel((int)dataGridView1.CurrentRow.Cells[0].Value, textBox2.Text, (int)numericUpDown1.Value);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            procedure.SpDel_Otdel((int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            procedure.SpADD_Dolj((int)comboBox1.SelectedValue, textBox1.Text, numericUpDown2.Value, (int)numericUpDown3.Value);
        }

        private void ComboBox1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            button8.Enabled = true;
            button4.Enabled = true;
            button2.Enabled = true;
            dataGridView2.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            procedure.SpDel_Dolj((int)dataGridView2.CurrentRow.Cells[0].Value);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            procedure.SpUpd_Dolj((int)dataGridView2.CurrentRow.Cells[0].Value, (int)comboBox1.SelectedValue, textBox1.Text, numericUpDown2.Value, (int)numericUpDown3.Value);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            WordDocument wordDocument = new WordDocument();
            new Thread(() => {
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = false;
                }));
                wordDocument.Vakanti();
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
