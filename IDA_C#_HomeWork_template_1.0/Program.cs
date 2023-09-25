﻿// HomeWork template 1.1 // date: 25.09.2023

using System;
using System.Linq.Expressions;
using System.Text;
using Service;

/// QUESTIONS ///
/// 1. 

// HomeWork XX : [work_name] --------------------------------

namespace IDA_C_sh_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MainMenu.MainMenu mainMenu = new MainMenu.MainMenu();

            do
            {
                Console.Clear();
                mainMenu.Show_menu();
                if (mainMenu.User_Choice_Handle() == 0) break;
                Console.ReadKey();
            } while (true);
            // Console.ReadKey();
        }

        public static void Task_1(string work_name)
        /*  Пользователь вводит с клавиатуры число в диапа-
        зоне от 1 до 100. Если число кратно 3 (делится на 3 без
        остатка) нужно вывести слово Fizz.Если число кратно 5
        нужно вывести слово Buzz. Если число кратно 3 и 5 нужно
        вывести Fizz Buzz. Если число не кратно не 3 и 5 нужно
        вывести само число.
        Если пользователь ввел значение не в диапазоне от 1
        до 100 требуется вывести сообщение об ошибке.*/
        {
            Console.WriteLine(work_name + "\n");
            Console.Write("Number [1..100] -> ");
            int? user_number = ServiceFunction.Get_Int(1, 100, "Error: range expected [1..100]");
            Console.WriteLine("\nFizzBuzz (" + user_number + ") -> " + ServiceFunction.FizzBuzz(user_number));
        }
        public static void Task_2(string work_name)
        /*    Пользователь вводит с клавиатуры два числа.Первое
      число — это значение, второе число процент, который
      необходимо посчитать.Например, мы ввели с клавиатуры
      90 и 10. Требуется вывести на экран 10 процентов от 90.
      Результат: 9.*/
        {
            Console.WriteLine(work_name + "\n");
            Console.Write("Base -> ");
            double? user_number_1 = ServiceFunction.Get_Double();
            Console.Write("Percent -> ");
            double? user_number_2 = ServiceFunction.Get_Double(0, Double.MaxValue, "percent only positive");
            Console.WriteLine(user_number_1 + " * " + user_number_2 + "% = " + (user_number_1 / 100) * user_number_2);

        }
        public static void Task_3(string work_name)
        /*  Пользователь вводит с клавиатуры четыре цифры.
        Необходимо создать число, содержащее эти цифры.На-
        пример, если с клавиатуры введено 1, 5, 7, 8 тогда нужно
        сформировать число 1578.*/
        {
            Console.WriteLine(work_name + "\n" + "\nEnter 4 digits:\n");
            string tmp_str = new string("");
            //string tmp_str;
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Digit [" + (i + 1) + "] -> ");
                tmp_str += Convert.ToString(ServiceFunction.Get_Int(0, 9, "Error: digits [0..9]"));
            }
            Console.WriteLine("\nresult -> " + Convert.ToInt32(tmp_str));
        }
        public static void Task_4(string work_name)
        /*  Пользователь вводит шестизначное число. После чего
        пользователь вводит номера разрядов для обмена цифр.
        Например, если пользователь ввёл один и шесть — это
        значит, что надо обменять местами первую и шестую
        цифры.
        Число 723895 должно превратиться в 523897.
        Если пользователь ввел не шестизначное число тре-
        буется вывести сообщение об ошибке..*/
        {
            Console.Write(work_name + "\n" + "\nEnter 6-digits number -> ");
            int? user_number = ServiceFunction.Get_Int(Convert.ToInt32(1e5), Convert.ToInt32(1e6 - 1), "Error: range expected [6-digits]");
            Console.Write("\nEnter number of digit_1 to change -> ");
            int digits_to_change_1 = ServiceFunction.Get_Int(1, 6, "Error: range expected [1..6]");
            Console.Write("\nEnter number of digit_2 to change -> ");
            int digits_to_change_2 = ServiceFunction.Get_Int(1, 6, "Error: range expected [1..6]");

            int[] digit_to_index_transform = new int[] { 0, 5, 4, 3, 2, 1, 0 };

            if (digits_to_change_1 != digits_to_change_2)
            {
                int index_to_change_1 = digit_to_index_transform[digits_to_change_1];
                int index_to_change_2 = digit_to_index_transform[digits_to_change_2];

                user_number = Convert.ToInt32(ServiceFunction.Replace_Char_in_String(Convert.ToString(user_number), index_to_change_1, index_to_change_2));
            }

            Console.WriteLine(user_number);
        }
        public static void Task_5(string work_name)
        /*  Пользователь вводит с клавиатуры дату.Приложе-
        ние должно отобразить название сезона и дня недели.
        Например, если введено 22.12.2021, приложение должно
        отобразить Winter Wednesday.
        */
        {
            Console.Write(work_name + "\n" + "\nEnter date -> ");

            string? user_input = Console.ReadLine();

            // Вариант 1 - свой self-made parcing
            char[] splitters = { '.', '/', '\\', '|', '-', ',' };
            string[] user_input_arr = user_input.Split(splitters);
            int[] int_arr = new int[user_input_arr.Length];
            for (int index = 0; index < int_arr.Length; index++)
                int_arr[index] = Convert.ToInt32(user_input_arr[index]);

            try
            {
                DateTime user_date_1 = new DateTime(Convert.ToInt32(int_arr[0]), int_arr[1], int_arr[2]);
                Console.WriteLine("\n* self-made parsing:" +
                 "\nRead date as -> " + user_date_1 +
                 "\nSeason -> " + Season(user_date_1) +
                 "\nDay -> " + user_date_1.DayOfWeek);
            }
            // если не удастся напарсить хотя бы 3 значения будет OutofRange
            // catch (IndexOutOfRangeException || ArgumentOutOfRangeException)
            catch (Exception)

            {
                Console.WriteLine("\nself-made parcing error");
            }

            // Вариант 2 - встройка DateTime built-in parsing
            try
            {
                DateTime user_date_2 = DateTime.Parse(user_input, System.Globalization.CultureInfo.InvariantCulture);
                Console.WriteLine("\n* DateTime built-in parsing:" +
                "\nRead date as -> " + user_date_2 +
                "\nSeason -> " + Season(user_date_2) +
                "\nDay -> " + user_date_2.DayOfWeek);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nDateTime built-in parsing error");
            }

            string Season(DateTime date)
            {
                switch (Convert.ToInt32(date.Month))
                {
                    case 1: case 2: case 12: return "Winter";
                    case 3: case 4: case 5: return "Spring";
                    case 6: case 7: case 8: return "Summer";
                    case 9: case 10: case 11: return "Autumn";
                    default: return "unknown";
                }
            }

        }
        public static void Task_6(string work_name)
        /*  Пользователь вводит с клавиатуры показания тем-
        пературы. В зависимости от выбора пользователя про-
        грамма переводит температуру из Фаренгейта в Цельсий
        или наоборот.*/
        {
            Console.WriteLine(work_name);
            Console.WriteLine("\nTemperature system: " + temp_system);
            Console.Write("\nEnter temprature -> ");
            double? user_temp = ServiceFunction.Get_Double();
            switch (temp_system)
            {
                case Temperature_system.Celcius: user_temp = user_temp + 273.15; break;
                case Temperature_system.Farenheit: user_temp = ((user_temp) - 32) * 5 / 9 + 273.15; break;
            }
            if (user_temp < 0) { throw new Exception("\nAbsolute temperature couldn't be below 0"); }

            Console.Write("\nAvailable temperature systems:\n" +
                "1. Celcius\n" +
                "2. Kelvin\n" +
                "3. Farenheit\n" +
                "choose -> "
                );
            switch (ServiceFunction.Get_Int(1, 3))
            {
                case 1: temp_system = Temperature_system.Celcius; break;
                case 2: temp_system = Temperature_system.Kelvin; break;
                case 3: temp_system = Temperature_system.Farenheit; break;
            }

            void Show_Temprature()
            {
                Console.Write("\n Temperature is ");
                switch (temp_system)
                {
                    case Temperature_system.Celcius: Console.Write(user_temp - 273.15); break;
                    case Temperature_system.Farenheit: Console.Write(((user_temp - 273.15) * 9 / 5) + 32); break;
                    case Temperature_system.Kelvin: Console.Write(user_temp); break;

                }
                Console.WriteLine(temp_system);
            }
            Show_Temprature();
        }
        enum Temperature_system { Celcius, Kelvin, Farenheit };
        static Temperature_system temp_system = Temperature_system.Celcius;
        public static void Task_7(string work_name)
        /*  Пользователь вводит с клавиатуры два числа. Нужно
        показать все четные числа в указанном диапазоне. Если
        границы диапазона указаны неправильно требуется про-
        извести нормализацию границ. Например, пользователь
        ввел 20 и 11, требуется нормализация, после которой
        начало диапазона станет равно 11, а конец 20.
        */
        {
            Console.WriteLine(work_name);
            Console.Write("\nEnter range bound 1 -> ");
            int range_1 = ServiceFunction.Get_Int();
            Console.Write("\nEnter range bound 2 -> ");
            int range_2 = ServiceFunction.Get_Int();
            if (range_1 > range_2) ServiceFunction.swap(ref range_1, ref range_2);
            Console.WriteLine("\nEven numbers in range [" + range_1 + ".." + range_2 + "]:");
            for (int i = range_1; i <= range_2; i++)
            {
                if (i % 2 == 0) { Console.Write(i + " | "); }
            }
        }

    }// class Program
}// namespace