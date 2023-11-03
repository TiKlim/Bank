using System;

namespace ConsoleApp2
{
    internal class Program
    {
        public static void Main(string[] args)
        {     
            SchetInBank schet1 = new SchetInBank();
            SchetInBank schet2 = new SchetInBank();

            Console.WriteLine("Здравствуйте. Пожалуйста введите информацию по текущему счёту \n(Номер счёта, Фамилия, Сумма на текщем счёте):");
            schet1.Info1(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), float.Parse(Console.ReadLine()));
            schet1.Out1();

            Console.WriteLine("Здравствуйте. Пожалуйста введите информацию по текущему счёту \n(Номер счёта, Фамилия, Сумма на текщем счёте):");
            schet2.Info2(Convert.ToInt32(Console.ReadLine()), float.Parse(Console.ReadLine()));
            schet2.Out2();
        }
    }
}
