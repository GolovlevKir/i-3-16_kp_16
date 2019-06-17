using LibraryForSQLCon;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Lich_Dela : Form
    {
        int sch = 1;
        DataBaseProcedure procedure = new DataBaseProcedure();
        OpenFileDialog ofd = new OpenFileDialog();
        public Lich_Dela()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer,
            true);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            switch (sch)
            {
                case 1:
                    timer1.Enabled = true;
                    sch = 0;
                    MessageBox.Show("Для добаления нового сотрудника, необходимо придумать логин и пароль!");
                    break;
                case 0:
                    timer1.Enabled = true;
                    sch = 1;
                    procedure.SpADD_Profile(textBox2.Text, Cript.Hash(textBox1.Text), maskedTextBox3.Text, textBox7.Text, (int)comboBox2.SelectedValue, "-", 1);
                    SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
                    command.CommandText = "select max(Num_Lich_Dela) from Sotr";
                    Registry_Class.sqlConnection.Open();
                    int i = (int)command.ExecuteScalar();
                    Registry_Class.sqlConnection.Close();
                    i++;
                    MessageBox.Show(i.ToString());
                    procedure.SpADD_Sotr(textBox2.Text, i, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Text, Convert.ToInt32(maskedTextBox1.Text), Convert.ToInt32(maskedTextBox2.Text), richTextBox1.Text, (int)comboBox1.SelectedValue);
                    break;
            }
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
                        while (panel3.Height <= 220)
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

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void Lich_Dela_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(SotrLoad);
            thread.Start();
            Thread thread2 = new Thread(DoljLoad);
            thread2.Start();
            Thread thread3 = new Thread(RoleLoad);
            thread3.Start();
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
                        dataGridView1.DataSource = dataComb.dtSotr;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].HeaderText = "№ личного дела";
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Columns[5].HeaderText = "ФИО (Должность)";
                        dataGridView1.Columns[6].HeaderText = "Дата рождения";
                        dataGridView1.Columns[7].Visible = false;
                        dataGridView1.Columns[8].Visible = false;
                        dataGridView1.Columns[9].HeaderText = "Серия и номер паспорта";
                        dataGridView1.Columns[10].HeaderText = "Адрес проживания";
                        dataGridView1.Columns[11].Visible = false;
                        dataGridView1.Columns[12].Visible = false;
                        dataGridView1.Columns[13].Visible = false;
                        dataGridView1.Columns[14].Visible = false;
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
                        dataComb.dtDoljFill();
                        dataComb.dependency.OnChange += Doljonchange;
                        comboBox1.DataSource = dataComb.dtDolj;
                        comboBox1.ValueMember = "ID_Dolj";
                        comboBox1.DisplayMember = "Naim_Dolj";
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

        public void RoleLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtRole.Clear();
                        dataComb.dtRoleFill();
                        dataComb.dependency.OnChange += Roleonchange;
                        comboBox2.DataSource = dataComb.dtRole;
                        comboBox2.ValueMember = "ID_Role";
                        comboBox2.DisplayMember = "Naim_Role";
                    }
                    catch
                    {

                    }

                };
                Invoke(action);
            }
            catch { }
        }

        private void Roleonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                RoleLoad();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                System.IO.FileInfo FI = new System.IO.FileInfo(@dataGridView1.CurrentRow.Cells[14].Value.ToString());
                pictureBox1.Image = Image.FromFile(FI.FullName);
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                richTextBox1.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                ofd.FileName = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            }
            catch
            {
                pictureBox1.Image = Re_start.Properties.Resources.no_image;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            procedure.SpUpd_Sotr(dataGridView1.CurrentRow.Cells[0].Value.ToString(), (int)dataGridView1.CurrentRow.Cells[1].Value, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Text, Convert.ToInt32(maskedTextBox1.Text), Convert.ToInt32(maskedTextBox2.Text), richTextBox1.Text, (int)comboBox1.SelectedValue);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            procedure.SpDel_Sotr(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            if (ofd.ShowDialog(this) == DialogResult.OK)
                try
                {

                    SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
                    command.CommandText = "update Profile set Profile_Photo = '" + ofd.FileName + "' where Login = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                    Registry_Class.sqlConnection.Open();
                    command.ExecuteScalar();
                    Registry_Class.sqlConnection.Close();
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
                catch { }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            PDFDocument document = new PDFDocument();
            new Thread(() => {
                this.Invoke(new Action(() =>
                {
                    button2.Enabled = false;
                }));
                document.otchLichDelo(dataGridView1);
                this.Invoke(new Action(() =>
                {
                    button2.Enabled = true;
                    MessageBox.Show("Отчет сохранен");
                }));
            }).Start();
        }
    }
}
