using System.Text;

namespace Day38
{
    internal class Program
    {
        static string VowelShiftCipher(string s)
        {
            char[] vow = { 'a', 'e', 'i', 'o', 'u' };
            string c = "bcdfghjklmnpqrstvwxyz";
            char[] cons = c.ToCharArray();

            StringBuilder sb = new StringBuilder(s);

            for (int i = 0; i < sb.Length; i++)
            {
                if (vow.Contains(sb[i]))
                {
                    int idx = Array.IndexOf(vow, sb[i]);
                    sb[i] = vow[(idx + 1) % vow.Length];
                }

                if (cons.Contains(sb[i]))
                {
                    int idx = Array.IndexOf(cons, sb[i]);
                    sb[i] = cons[(idx + 1) % cons.Length];
                }
            }
            s = sb.ToString();
            return s;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string :");
            string s = Console.ReadLine();
            Console.WriteLine(VowelShiftCipher(s));
        }
    }
}
