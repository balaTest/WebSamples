using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Utilities;

namespace ExtensionMethodSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "1234";
            int i = s.ToInt32();               // Same as Extensions.ToInt32(s)
            Console.WriteLine("i = {0}", i);

            int[] digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] a = digits.Slice(4, 3);      // Same as Extensions.Slice(digits, 4, 3)
            Console.WriteLine("a = {0}", String.Join(", ", a));


        }
    }
}
