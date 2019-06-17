using System;
using System.Windows.Forms;

namespace Re_start
{
    public partial class OKompanii : Form
    {
        public OKompanii()
        {
            InitializeComponent();
        }

        private void OKompanii_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.fff.Close();
            Hide();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Program.fff.Close();
            Hide();
        }
    }
}
