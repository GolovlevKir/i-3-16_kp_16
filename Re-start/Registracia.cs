using System;
using System.Drawing;
using System.Windows.Forms;

namespace Re_start
{
    public partial class Registracia : Form
    {
        DataBaseProcedure procedure = new DataBaseProcedure();
        OpenFileDialog ofd = new OpenFileDialog();
        public Registracia()
        {
            InitializeComponent();
            DataR.CustomFormat = "dd.MM.yyyy";
            DataR.Format = DateTimePickerFormat.Custom;
            ofd.FileName = "-";
            Pass.UseSystemPasswordChar = true;
            PovPass.UseSystemPasswordChar = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Hide();
            Autoriz autoriz = new Autoriz();
            autoriz.Show();
        }

        public void CvetPolei()
        {
            Fam.BackColor = Color.White;
            Im.BackColor = Color.White;
            Otch.BackColor = Color.White;
            DataR.BackColor = Color.White;
            Login.BackColor = Color.White;
            Pass.BackColor = Color.White;
            PovPass.BackColor = Color.White;
            email.BackColor = Color.White;
            phone.BackColor = Color.White;
        }

        private void Zareg_Click(object sender, EventArgs e)
        {
            switch (Login.Text == "")
            {
                case true:
                    MessageBox.Show("Не заполнено поле Логин!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CvetPolei();
                    Login.BackColor = Color.Red;
                    break;
                case false:
                    switch (Pass.Text == "")
                    {
                        case true:
                            MessageBox.Show("Не заполнено поле Пароль!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CvetPolei();
                            Pass.BackColor = Color.Red;
                            break;
                        case false:
                            switch (Fam.Text == "")
                            {
                                case true:
                                    MessageBox.Show("Не заполнено поле Фамилия!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CvetPolei();
                                    Fam.BackColor = Color.Red;
                                    break;
                                case false:
                                    switch (Im.Text == "")
                                    {
                                        case true:
                                            MessageBox.Show("Не заполнено поле Имя!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            CvetPolei();
                                            Im.BackColor = Color.Red;
                                            break;
                                        case false:
                                            switch (Otch.Text == "")
                                            {
                                                case true:
                                                    MessageBox.Show("Не заполнено поле Отчество!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    CvetPolei();
                                                    Otch.BackColor = Color.Red;
                                                    break;
                                                case false:
                                                    switch (DataR.Text == DateTime.Now.ToString("d"))
                                                    {
                                                        case true:
                                                            MessageBox.Show("Не заполнено поле Дата рождения!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            CvetPolei();
                                                            DataR.BackColor = Color.Red;
                                                            break;
                                                        case false:
                                                            switch (PovPass.Text == "")
                                                            {
                                                                case true:
                                                                    MessageBox.Show("Не заполнено поле Повторение пароля!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                    CvetPolei();
                                                                    PovPass.BackColor = Color.Red;
                                                                    break;
                                                                case false:
                                                                    switch (PovPass.Text != Pass.Text)
                                                                    {
                                                                        case true:
                                                                            MessageBox.Show("Пароли не совпадают!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                            CvetPolei();
                                                                            PovPass.BackColor = Color.Red;
                                                                            Pass.BackColor = Color.Red;
                                                                            break;
                                                                        case false:
                                                                            switch (phone.Text == "8(___)___-__-__")
                                                                            {
                                                                                case true:
                                                                                    MessageBox.Show("Не заполнено поле Номер телефона!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                    CvetPolei();
                                                                                    phone.BackColor = Color.Red;
                                                                                    break;
                                                                                case false:
                                                                                    switch (email.Text == "")
                                                                                    {
                                                                                        case true:
                                                                                            MessageBox.Show("Не заполнено поле Email!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                            CvetPolei();
                                                                                            email.BackColor = Color.Red;
                                                                                            break;
                                                                                        case false:
                                                                                            procedure.SpADD_Profile(Login.Text, Cript.Hash(Pass.Text), phone.Text, email.Text, 5, ofd.FileName, 1);
                                                                                            procedure.SpADD_Klient(Login.Text, Fam.Text, Im.Text, Otch.Text, DataR.Text);
                                                                                            Autoriz autoriz = new Autoriz();
                                                                                            autoriz.Show();
                                                                                            Hide();
                                                                                            break;
                                                                                    }
                                                                                    break;
                                                                            }
                                                                            break;
                                                                    }
                                                                    break;
                                                            }
                                                            break;
                                                    }
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        private void LoadAva_Click(object sender, EventArgs e)
        {
            Ava.SizeMode = PictureBoxSizeMode.Zoom;
            if (ofd.ShowDialog(this) == DialogResult.OK)
                try
                {
                    Ava.Image = Image.FromFile(ofd.FileName);
                }
                catch { }
        }
    }
}
