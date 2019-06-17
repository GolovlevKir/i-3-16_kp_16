using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Klients : Form
    {
        int sch = 1,
        rez = 0;

        DataBaseProcedure procedure = new DataBaseProcedure();
        public Klients()
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            if (sch == 0)
            {
                new Thread(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        while (panel3.Height <= 180)
                        {
                            panel3.Height += 20;
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
                        while (panel3.Height > 0)
                        {
                            panel3.Height -= 20;
                            Refresh();
                        }
                    }));
                }).Start();
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            switch (sch)
            {
                case 0:
                    timer1.Enabled = true;
                    sch = 1;
                    procedure.SpADD_Profile(textBox2.Text, textBox1.Text, maskedTextBox1.Text, textBox7.Text, 5, "-", 1);
                    procedure.SpADD_Klient(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Text);
                    KlientLoad();
                    textBox2.Text = "";
                    textBox1.Text = "";
                    maskedTextBox1.Text = "";
                    textBox7.Text = "";
                    break;
                case 1:
                    timer1.Enabled = true;
                    sch = 0;
                    MessageBox.Show("Для добавления нового клиента, необходимо придумать логин и пароль!");
                    break;
            }


        }

        private void Klients_Load(object sender, EventArgs e)
        {
            Thread threadKlient = new Thread(KlientLoad);
            threadKlient.Start();
        }

        public void KlientLoad()
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
                        dataComb.dependency.OnChange += Klientonchange;
                        dataGridView1.DataSource = dataComb.dtKlient;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[4].HeaderText = "ФИО клиента + Логин";
                        dataGridView1.Columns[5].HeaderText = "Дата рождения";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Klientonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                KlientLoad();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch { }
        }

        private void TextBox6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "ПОИСК...")
                textBox6.Text = "";
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataBaseTables dataComb = new DataBaseTables();
                dataComb.dtKlient.Clear();
                dataComb.qrKlient += " where Login_Kl like '%" + textBox6.Text + "%' or Familiya like '%" + textBox6.Text + "%' or Imya like '%" + textBox6.Text + "%' or Otchestvo like '%" + textBox6.Text + "%' or Data_Rojd like '%" + textBox6.Text + "%'";
                dataComb.dtKlientsFill();
                dataComb.dependency.OnChange += Klientonchange;
                dataGridView1.DataSource = dataComb.dtKlient;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].HeaderText = "ФИО клиента + Логин";
                dataGridView1.Columns[5].HeaderText = "Дата рождения";
            }
            catch { }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            procedure.SpUpd_Klient(dataGridView1.CurrentRow.Cells[0].Value.ToString(), textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Text);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            procedure.SpDel_Klient(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }
    }
}
