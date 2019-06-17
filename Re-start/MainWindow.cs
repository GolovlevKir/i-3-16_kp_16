using LibraryForSQLCon;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class MainWindow : Form
    {
        int sch = 1;
        Shtat st = new Shtat();
        Ystroistva st1 = new Ystroistva();
        DataBaseProcedure procedure = new DataBaseProcedure();
        OpenFileDialog ofd = new OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();

            textBox1.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;

        }

        public void Zatemn()
        {
            Program.fff = new Form();
            Program.fff.ControlBox = false;
            Program.fff.MinimizeBox = false;
            Program.fff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Program.fff.Text = "";
            Program.fff.Size = Size;
            Program.fff.BackColor = Color.Black;
            Program.fff.Opacity = 0.8f;
            Program.fff.Show();
            Program.fff.Location = this.Location;
            Program.fff.Enabled = false;

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
            command.CommandText = "SELECT count(*) FROM dbo.Sotr where Login_St = '" + Program.prof + "'";
            Registry_Class.sqlConnection.Open();
            Program.PoiskSotr = (int)command.ExecuteScalar();
            switch (Program.PoiskSotr == 0)
            {
                case true:
                    command.CommandText = "SELECT Familiya FROM dbo.Klient where Login_Kl = '" + Program.prof + "'";
                    label6.Text = "Фамилия: " + command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT Imya FROM dbo.Klient where Login_Kl = '" + Program.prof + "'";
                    label7.Text = "Имя: " + command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT Otchestvo FROM dbo.Klient where Login_Kl = '" + Program.prof + "'";
                    try
                    {
                        label8.Text = "Отчество: " + command.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        label8.Text = "Отчество: -";
                    }
                    command.CommandText = "SELECT Data_Rojd FROM dbo.Klient where Login_Kl = '" + Program.prof + "'";
                    label9.Text = "Дата рождения: " + command.ExecuteScalar().ToString();
                    break;
                case false:
                    command.CommandText = "SELECT Familiya FROM dbo.Sotr where Login_St = '" + Program.prof + "'";
                    label6.Text = "Фамилия: " + command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT Imya FROM dbo.Sotr where Login_St = '" + Program.prof + "'";
                    label7.Text = "Имя: " + command.ExecuteScalar().ToString();
                    command.CommandText = "SELECT Otchestvo FROM dbo.Sotr where Login_St = '" + Program.prof + "'";
                    try
                    {
                        label8.Text = "Отчество: " + command.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        label8.Text = "Отчество: -";
                    }
                    command.CommandText = "SELECT DateOfRojd FROM dbo.Sotr where Login_St = '" + Program.prof + "'";
                    label9.Text = "Дата рождения: " + command.ExecuteScalar().ToString();
                    break;
            }
            command.CommandText = "SELECT Profile_Photo FROM dbo.Profile where Login = '" + Program.prof + "'";
            string ph = command.ExecuteScalar().ToString();
            System.IO.FileInfo FI = new System.IO.FileInfo(@ph);
            try
            {
                pictureBox1.Image = Image.FromFile(FI.FullName);
            }
            catch
            {
                pictureBox1.Image = Re_start.Properties.Resources.no_image;
            }
            Registry_Class.sqlConnection.Close();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            prava();
            Thread thread = new Thread(BasketLoad);
            thread.Start();

        }

        public void prava()
        {
            SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
            Registry_Class.sqlConnection.Open();
            command.CommandText = "Select Role_ID from Profile where Login = '" + Program.prof + "'";
            int ID = (int)command.ExecuteScalar();
            command.CommandText = "Select Roles from Role where ID_Role = " + ID.ToString();
            Program.Roles = (int)command.ExecuteScalar();
            switch (Program.Roles)
            {
                case 0:
                    button18.Height = 0;
                    break;
                case 1:
                    button18.Height = 54;
                    break;
            }
            command.CommandText = "Select Profiles from Role where ID_Role = " + ID.ToString();
            Program.Profiles = (int)command.ExecuteScalar();
            command.CommandText = "Select Yslugi from Role where ID_Role = " + ID.ToString();
            Program.Yslugi = (int)command.ExecuteScalar();
            switch (Program.Yslugi)
            {
                case 0:
                    button2.Height = 0;
                    break;
                case 1:
                    button2.Height = 38;
                    break;
            }
            command.CommandText = "Select Dogovora from Role where ID_Role = " + ID.ToString();
            Program.Dogovora = (int)command.ExecuteScalar();
            switch (Program.Dogovora)
            {
                case 0:
                    button5.Height = 0;
                    break;
                case 1:
                    button5.Height = 38;
                    break;
            }
            command.CommandText = "Select Klients from Role where ID_Role = " + ID.ToString();
            Program.Klients = (int)command.ExecuteScalar();
            switch (Program.Klients)
            {
                case 0:
                    button8.Height = 0;
                    break;
                case 1:
                    button8.Height = 38;
                    break;
            }
            command.CommandText = "Select Remonti from Role where ID_Role = " + ID.ToString();
            Program.Remonti = (int)command.ExecuteScalar();
            switch (Program.Remonti)
            {
                case 0:
                    button12.Height = 0;
                    break;
                case 1:
                    button12.Height = 38;
                    break;
            }
            command.CommandText = "Select Statusi from Role where ID_Role = " + ID.ToString();
            Program.Statusi = (int)command.ExecuteScalar();
            switch (Program.Statusi)
            {
                case 0:
                    button3.Height = 0;
                    break;
                case 1:
                    button3.Height = 38;
                    break;
            }
            command.CommandText = "Select Prihodi from Role where ID_Role = " + ID.ToString();
            Program.Prihodi = (int)command.ExecuteScalar();
            switch (Program.Prihodi)
            {
                case 0:
                    button10.Height = 0;
                    break;
                case 1:
                    button10.Height = 38;
                    break;
            }
            command.CommandText = "Select Sklad from Role where ID_Role = " + ID.ToString();
            Program.Sklad = (int)command.ExecuteScalar();
            switch (Program.Sklad)
            {
                case 0:
                    button13.Height = 0;
                    break;
                case 1:
                    button13.Height = 38;
                    break;
            }
            command.CommandText = "Select Lich_Dela from Role where ID_Role = " + ID.ToString();
            Program.Lich_Dela = (int)command.ExecuteScalar();
            switch (Program.Lich_Dela)
            {
                case 0:
                    button11.Height = 0;
                    break;
                case 1:
                    button11.Height = 38;
                    break;
            }
            command.CommandText = "Select Doljnosti from Role where ID_Role = " + ID.ToString();
            Program.Doljnosti = (int)command.ExecuteScalar();
            switch (Program.Doljnosti)
            {
                case 0:
                    st.panel1.Enabled = false;
                    break;
                case 1:
                    st.panel1.Enabled = true;
                    break;
            }
            command.CommandText = "Select Otdeli from Role where ID_Role = " + ID.ToString();
            Program.Otdeli = (int)command.ExecuteScalar();
            switch (Program.Otdeli)
            {
                case 0:
                    st.panel2.Enabled = false;
                    break;
                case 1:
                    st.panel2.Enabled = true;
                    break;
            }
            switch (Program.Otdeli + Program.Doljnosti)
            {
                case 0:
                    button7.Height = 0;
                    break;
                case 1:
                    button7.Height = 38;
                    break;
            }
            command.CommandText = "Select Detali from Role where ID_Role = " + ID.ToString();
            Program.Detali = (int)command.ExecuteScalar();
            switch (Program.Detali)
            {
                case 0:
                    button6.Height = 0;
                    break;
                case 1:
                    button6.Height = 38;
                    break;
            }
            command.CommandText = "Select Tipi_Ystr from Role where ID_Role = " + ID.ToString();
            Program.Tipi_Ystr = (int)command.ExecuteScalar();
            st1.panel2.Enabled = Convert.ToBoolean(Program.Tipi_Ystr);
            command.CommandText = "Select Proizvodit_Yastr from Role where ID_Role = " + ID.ToString();
            Program.Proizvodit_Yastr = (int)command.ExecuteScalar();
            st1.panel6.Enabled = Convert.ToBoolean(Program.Proizvodit_Yastr);
            command.CommandText = "Select Modeli_Ystr from Role where ID_Role = " + ID.ToString();
            Program.Modeli_Ystr = (int)command.ExecuteScalar();
            st1.panel5.Enabled = Convert.ToBoolean(Program.Modeli_Ystr);
            //switch (Program.Tipi_Ystr + Program.Proizvodit_Yastr + Program.Modeli_Ystr)
            //{
            //    case 0:
            //        button9.Height = 0;
            //        break;
            //    case 1:
            //        button9.Height = 38;
            //        break;
            //}
            command.CommandText = "Select Testirovaniya from Role where ID_Role = " + ID.ToString();
            Program.Testirovaniya = (int)command.ExecuteScalar();
            switch (Program.Testirovaniya)
            {
                case 0:
                    button14.Height = 0;
                    break;
                case 1:
                    button14.Height = 38;
                    break;
            }
            command.CommandText = "Select Cheki from Role where ID_Role = " + ID.ToString();
            Program.Cheki = (int)command.ExecuteScalar();
            switch (Program.Cheki)
            {
                case 0:
                    button4.Height = 0;
                    break;
                case 1:
                    button4.Height = 38;
                    break;
            }
            Registry_Class.sqlConnection.Close();
        }

        public void BasketLoad()
        {
            try
            {
                Action action = () =>
                {
                    try
                    {
                        DataBaseTables dataComb = new DataBaseTables();
                        dataComb.dtStore_Basket.Clear();
                        dataComb.qrStore_Basket += " where Login_Klt = '" + Program.prof + "'";
                        dataComb.dtStore_BasketFill();
                        dataComb.dependency.OnChange += Baskonchange;
                        dataGridView1.DataSource = dataComb.dtStore_Basket;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].HeaderText = "Наименование услуги";
                        //DataGridViewButtonColumn ButtonColumn = new DataGridViewButtonColumn();
                        //ButtonColumn.Visible = true;
                        //ButtonColumn.ToolTipText = "Удалить строку";
                        //ButtonColumn.Text = "Удалить";
                        //ButtonColumn.Name = "DeleteButtonColumn";
                        //ButtonColumn.HeaderText = "Редактирование";
                        //ButtonColumn.UseColumnTextForButtonValue = true;
                        //ButtonColumn.FlatStyle = FlatStyle.Flat;
                        //dataGridView1.Columns.Add(ButtonColumn);
                        //dataGridView1.CellClick += DataGridView1_CellClick;
                    }
                    catch
                    {

                    }

                };
                Invoke(action);

            }
            catch { }
        }

        private void Baskonchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
            {
                BasketLoad();
            }
        }

        private void Button16_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            textBox3.UseSystemPasswordChar = false;
        }

        private void Button16_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer,
            true);
            if (sch == 0)
            {
                while (panel9.Width <= 270)
                {
                    panel9.Width += 20;
                    Refresh();
                    Invalidate();
                }
            }
            else
            {
                while (panel9.Width > 0)
                {
                    panel9.Width -= 20;
                    Refresh();
                }
            }

        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            switch (sch)
            {
                case 0:
                    timer1.Enabled = true;
                    sch = 1;
                    break;
                case 1:
                    timer1.Enabled = true;
                    sch = 0;
                    break;
            }
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            Hide();
            Zatemn();
            Params par = new Params();
            par.panel2.BackColor = panel6.BackColor;
            par.button1.BackColor = button1.BackColor;
            par.panel1.BackColor = panel1.BackColor;
            par.panel3.BackColor = panel3.BackColor;
            par.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Zatemn();
            OKompanii oKompanii = new OKompanii();
            oKompanii.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Zatemn();
            StatusRem st = new StatusRem();
            st.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Chek st = new Chek();
            st.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Zatemn();
            Dogovora st = new Dogovora();
            st.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Zatemn();
            Details st = new Details();
            st.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Zatemn();
            st.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Zatemn();
            Klients st = new Klients();
            st.Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Zatemn();
            Prihod st = new Prihod();
            st.Show();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Zatemn();
            Lich_Dela st = new Lich_Dela();
            st.Show();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Zatemn();
            Remonti st = new Remonti();
            st.Show();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Zatemn();
            Sklad st = new Sklad();
            st.Show();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            Zatemn();
            Testirovaniya st = new Testirovaniya();
            st.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            Zatemn();
            Connect connect = new Connect();
            connect.Show();
        }

        private void Panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button20_Click(object sender, EventArgs e)
        {
            Zatemn();
            Prava prava = new Prava();
            prava.Show();
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            Autoriz autoriz = new Autoriz();
            autoriz.Show();
            Program.prof = "";
            Hide();
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
            command.CommandText = "SELECT count(*) FROM dbo.Profile where Login = '" + Program.prof + "' and Password = '" + Cript.Hash(textBox1.Text) + "'";
            Registry_Class.sqlConnection.Open();
            int Pas = (int)command.ExecuteScalar();
            Registry_Class.sqlConnection.Close();
            if (textBox2.Text == textBox3.Text)
            {
                switch (Pas)
                {
                    case 0:
                        MessageBox.Show("Пароль введен неверно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        textBox2.BackColor = Color.White;
                        textBox3.BackColor = Color.White;
                        DataBaseProcedure procedure = new DataBaseProcedure();
                        procedure.SpUpd_PassProfile(Program.prof, Cript.Hash(textBox2.Text));
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        MessageBox.Show("Пароль изменен!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Введенные пароли не совпадают!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.BackColor = Color.Red;
                textBox3.BackColor = Color.Red;
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == 4)
            //{
            //    procedure.spDel_Store_Basket((int)dataGridView1.CurrentRow.Cells[0].Value);

            //}
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                this.Invoke(new Action(() =>
                {
                    if (dataGridView1.RowCount > 0)
                    {
                        SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
                        command.CommandText = "SELECT email FROM dbo.Profile where Login = '" + Program.prof + "'";
                        Registry_Class.sqlConnection.Open();
                        string komy = command.ExecuteScalar().ToString();
                        foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                        {
                            int countSk = 0;
                            command.CommandText = "SELECT Details_ID FROM dbo.Services where ID_Services = " + dgvr.Cells[2].Value.ToString();
                            int IDDet = (int)command.ExecuteScalar();
                            command.CommandText = "SELECT dbo.Sklad.Count_Det FROM dbo.Sklad where Details_ID = " + IDDet.ToString();
                            try
                            {
                                countSk = (int)command.ExecuteScalar();
                            }
                            catch { countSk = 0; }
                            string mesa;
                            if (countSk <= 0)
                            {
                                mesa = "Детали для ремонта отсутствуют. Узнайте наличие позже!";
                                //dgvr.DefaultCellStyle.ForeColor = Color.Red;
                            }
                            else
                            {
                                mesa = "Детали для ремонта в наличии. Вы можете посетить наш сервисный центр для осуществления ремонта!";
                                //dgvr.DefaultCellStyle.ForeColor = Color.Green;
                            }
                            Messa.MySendMail(mesa, komy, "Сервисный центр Re-start", "Запрос на осуществление услуги: " + dgvr.Cells[3].Value.ToString());

                        }
                        Registry_Class.sqlConnection.Close();
                    }
                    else
                    {
                        MessageBox.Show("У вас пустая корзина", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }));
            }).Start();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Zatemn();
            Yslugi prava = new Yslugi();
            prava.Show();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            procedure.spDel_Store_Basket((int)dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            if (ofd.ShowDialog(this) == DialogResult.OK)
                try
                {
                    procedure.SpUpd_AvaProfile(Program.prof, ofd.FileName);
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
                catch { }
            
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            Zatemn();
            Document document = new Document();
            document.Show();
        }

        private void Button25_Click(object sender, EventArgs e)
        {
            Zatemn();
            Log log = new Log();
            log.Show();
        }
    }
}
