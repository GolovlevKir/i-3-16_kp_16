using System;
using System.Windows.Forms;

namespace Re_start
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Autoriz());

        }

        public static Form fff;
        public static string prof;
        public static int Roles, Profiles, Yslugi, Dogovora,
            Klients, Remonti, Statusi, Prihodi, Sklad, Lich_Dela, Doljnosti,
            Otdeli, Detali, Tipi_Ystr, Proizvodit_Yastr, Modeli_Ystr, Testirovaniya,
            Isp_sroki, Cheki, PoiskSotr;
    }
}
