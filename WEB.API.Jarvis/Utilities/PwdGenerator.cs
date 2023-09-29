using System.Text;

namespace Jarvis.WEB.API.Utilities
{
    public static class PwdGenerator
    {
        public static string GetRandomPassword()
        {
            int length = 15;

            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ/.=+*@#$%";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
    }
}
