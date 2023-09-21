using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class ServiceFunction
    {
        public static int? Get_Int_Positive()
        {
            string? a = Console.ReadLine();

            if (a != "")
            {
                //char[] digits = { '1', '2', '3', '4', '5', '6','7', '8', '9', '0'};
                //if ((FindFirstNotOf(a, "0123456789") == -1))
                if (FindFirstNotOf(a, "0123456789") == null)
                {
                    try
                    {
                        return Convert.ToInt32(a);
                    }
                    catch (OverflowException)
                    {
                        Console.Write("Input Error: overflow. Positive [INTEGER] expected.\n");
                    }
                }
                else
                {
                    Console.Write("Input Error: Positive [INTEGER] expected.\n");
                    return Get_Int_Positive();
                }
            }
            else
                Console.Write("Input Error: NULL input. Positive [INTEGER] expected.\n");
            return Get_Int_Positive();
        }

        //public static int? FindFirstNotOf(this string source, string chars)
        public static int? FindFirstNotOf(string source, string chars)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (chars == null) throw new ArgumentNullException("chars");
            if (source.Length == 0) return null;
            if (chars.Length == 0) return 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (chars.IndexOf(source[i]) == -1) return i;
            }
            return null;
        }
    }













}


