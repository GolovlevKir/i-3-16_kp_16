using LibraryForSQLCon;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Autoriz : Form
    {
        public Autoriz()
        {
            InitializeComponent();
            //вместо символов точки
            Password.UseSystemPasswordChar = true;
        }

        private void Autoriz_Load(object sender, EventArgs e)
        {
            try
            {
                //Подключение к серверу
                DataBase_Configuration data = new DataBase_Configuration();
                DoubleBuffered = true;
                data.conState += constate;
                Thread thread = new Thread(data.Connection_check);
                thread.Start();
                Thread.Sleep(100);
            }
            catch { }
        }

        private void constate(bool value)
        {
            Action action = () =>
            {
                switch (value)
                {
                    case (true):
                        //Активные компоненты
                        label4.Enabled = true;
                        button1.Enabled = true;
                        button2.Enabled = true;
                        Login.Enabled = true;
                        Password.Enabled = true;
                        break;
                    case (false):
                        //Окно подключения
                        Connect conection = new Connect();
                        conection.Show();
                        this.Hide();
                        break;
                }
            };
            Invoke(action);
        }

        private void Label4_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void Label4_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Закрытие программы
            Application.Exit();
        }

        private void Label4_MouseEnter_1(object sender, EventArgs e)
        {
            //При наведении - белый
            label4.ForeColor = Color.White;
        }

        private void Label4_MouseLeave_1(object sender, EventArgs e)
        {
            //Без наведения серый
            label4.ForeColor = Color.Gray;
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            //Открытие окна регистрации
            this.Visible = false;
            Registracia registracia = new Registracia();
            registracia.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", Registry_Class.sqlConnection);
            //Поиск профиля по логину и почте
            command.CommandText = "SELECT count(*) FROM dbo.Profile where Login = '" + Login.Text + "' or email = '" + Login.Text + "'";
            Registry_Class.sqlConnection.Open();
            int Log = (int)command.ExecuteScalar();
            switch (Log)
            {
                case 0:
                    //Если такой логин не найден
                    MessageBox.Show("Такого логина не существует!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    //Поиск пользователя по логину и паролю
                    command.CommandText = "SELECT count(*) FROM dbo.Profile where Login = '" + Login.Text + "' and Password = '" + Cript.Hash(Password.Text) + "' or email = '" + Login.Text + "' and Password = '" + Cript.Hash(Password.Text) + "'";
                    int Pas = (int)command.ExecuteScalar();
                    switch (Pas)
                    {
                        case 0:
                            //Неверный пароль
                            MessageBox.Show("Пароль введен неверно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 1:
                            //Открытие главного меню и запоминание логина
                            Registry_Class.sqlConnection.Close();
                            Program.prof = Login.Text;
                            Visible = false;
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            break;
                    }
                    break;
            }
            Registry_Class.sqlConnection.Close();
        }
    }
}
