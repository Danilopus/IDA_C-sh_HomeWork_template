﻿using System;
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
        public static int Get_Int(int lower_bound = Int32.MinValue, int upper_bound = Int32.MaxValue, string comment = "")
        {
            string? a = Console.ReadLine();

            if (a != "")
            {
                if (FindFirstNotOf(a, "-0123456789") == null)
                {


                    for (int i = 1; i < a.Length; i++) // определяем есть ли минусы кроме первого символа
                    {
                        if (a[i] == '-')
                        {
                            Console.WriteLine("Input Error: Minus misstanding. [INTEGER] expected.\n");
                            return Get_Int(lower_bound, upper_bound, comment);
                        }
                    }

                    try
                    {
                        int try_to_get_int = Convert.ToInt32(a);
                        if (try_to_get_int < lower_bound || try_to_get_int > upper_bound)
                        {
                            Console.WriteLine(comment);
                            return Get_Int(lower_bound, upper_bound, comment);
                        }
                    }
                    catch (OverflowException)
                    {
                        Console.Write("Input Error: overflow. [INTEGER] expected.\n");
                    }
                    return Convert.ToInt32(a);
                }
                else
                {
                    Console.Write("Input Error: [INTEGER] expected.\n");
                    return Get_Int(lower_bound, upper_bound, comment);
                }
            }
            else
                Console.Write("Input Error: NULL input. [INTEGER] expected.\n");

            return Get_Int(lower_bound, upper_bound, comment);
        }
        public static double? Get_Double(double lower_bound = Int32.MinValue, double upper_bound = Int32.MaxValue, string comment = "")
        {
            string? a = Console.ReadLine();

            if (a != "")
            {
                if (FindFirstNotOf(a, "-,0123456789") == null)
                {
                    // определяем есть ли минусы кроме первого символа
                    for (int i = 1; i < a.Length; i++)
                    {
                        if (a[i] == '-')
                        {
                            Console.WriteLine("Input Error: Minus misstanding. [DOUBLE] expected.\n");
                            return Get_Double(lower_bound, upper_bound, comment);
                        }
                    }

                    // проверяем отсутсвие лишних точек
                    bool Dot_Flag = false;
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i] == '.')
                        {
                            if (Dot_Flag == true)
                            {
                                Console.WriteLine("\nInput Error: Dot misstandig. [DOUBLE] expected.\n");
                                return Get_Double(lower_bound, upper_bound, comment);
                            }
                            Dot_Flag = true;
                        }

                    }

                    // попытаемся конвертировать строку ввода в double
                    try
                    {

                        double try_convert_to_double = Convert.ToDouble(a);
                        if (try_convert_to_double < lower_bound || try_convert_to_double > upper_bound)
                        {
                            Console.WriteLine(comment);
                            return Get_Double(lower_bound, upper_bound, comment);
                        }

                    }
                    catch (OverflowException)
                    {
                        Console.Write("Input Error: overflow. [DOUBLE] expected.\n");
                    }
                    return Convert.ToDouble(a);

                }
                else
                {
                    Console.Write("Input Error: [DOUBLE] expected. Use [,] instead of [.]\n");
                    return Get_Double(lower_bound, upper_bound, comment);
                }
            }
            else
                Console.Write("Input Error: NULL input. [DOUBLE] expected.\n");

            return Get_Double(lower_bound, upper_bound, comment);
        }
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
        public static string FizzBuzz(int? number_to_check)
        {
            if (number_to_check % 3 == 0 && number_to_check % 5 == 0) { return "FizzBuzz"; }
            if (number_to_check % 3 == 0) { return "Fizz"; }
            if (number_to_check % 5 == 0) { return "Buzz"; }
            else return Convert.ToString(number_to_check);
        }
        public static string Replace_Char_in_String(string original_string, int index_to_change_1, int index_to_change_2)
        {
            if (index_to_change_1 > index_to_change_2)
            {
                int tmp_int = index_to_change_1;
                index_to_change_1 = index_to_change_2;
                index_to_change_2 = tmp_int;
            }
            char tmp_char = original_string[index_to_change_1];
            string tmp_str = original_string.Insert(index_to_change_2, tmp_char.ToString()).Remove(index_to_change_1, 1);
            tmp_char = original_string[index_to_change_2];
            string tmp_str_2 = tmp_str.Insert(index_to_change_1, tmp_char.ToString()).Remove(index_to_change_2 + 1, 1);
            return tmp_str_2;
        }

        public static void swap(ref int num_1, ref int num_2)
        {
            int tmp = num_1;
            num_1 = num_2;
            num_2 = tmp;
        }


    } //    internal class ServiceFunction

} // namespace