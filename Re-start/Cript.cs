using System.Security.Cryptography;
using System.Text;

namespace Re_start
{
    class Cript
    {
        public static string Hash(string input)
        {
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Создать новый Stringbuilder для сбора байтов
            // и создаем строку.
            StringBuilder sb = new StringBuilder(hash.Length * 2);
            // Перебираем каждый байт хэшированных данных
            // и форматируем каждый как шестнадцатеричную строку.
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }

            // Возвращаем шестнадцатеричную строку.
            return sb.ToString();
        }
    }
}
