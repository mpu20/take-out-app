using System.Text;

namespace TakeOutApp.API.Common
{
    public class HashPasswordConfig
    {
        public static int keySize = 128;
        public static int iterations = 350000;
        public static byte[] salt = Encoding.UTF8.GetBytes("aaIB0rmaCNIM4ynL6Sgk448qjcktOsTdYhejz1va1XIu9cMTgVdL9GtL6JkNKy5n");
    }
}
