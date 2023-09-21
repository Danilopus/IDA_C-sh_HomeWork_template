// HomeWork template 1.0 // date: 21.09.2023

using System;

// HomeWork XX : [homework_name] --------------------------------

namespace IDA_C__HomeWork_template_1._0
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
            } while (true);
            //Console.ReadKey();
        }

        public static void Task_1(string work_name)
        {

        }
        public static void Task_2(string work_name)
        {

        }
        public static void Task_3(string work_name)
        {

        }
    }
}

namespace Service
{



}
