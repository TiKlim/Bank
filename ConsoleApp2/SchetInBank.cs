using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class SchetInBank
    {
        private int nomchet; //Номер счёта
        private string? fio; //ФИО владельца счёта
        private float sum; //Сумма на счету (начальная)
        private float sumtek; //Сумма на счету (текущая)

        private int nomchet2; 
        private string? fio2; 
        private float sum2; 
        private float sumtek2;

        private float perenos; //Перенос средств
        private float perenos2;

        public void Info1(int nomchet, string? fio, float sum)
        {
            this.nomchet = nomchet;
            this.fio = fio;
            this.sum = sum;

            if (nomchet < 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                //Console.Clear();
                Console.Read();
            }
            if (sum < 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Read();
            }

            Console.WriteLine("x-----------------------------");
            Console.WriteLine($"|Информация по текущему счёту: \n|Номер счёта: {nomchet}; \n|Фамилия: {fio}; \n|Сумма на счету: {sum}.");
            Console.WriteLine("x-----------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("> Счёт открыт.");
            Console.ForegroundColor = ConsoleColor.White;

            

            Console.WriteLine("> Что Вы хотите сделать? 1 - Добавить деньги на счёт; 2 - Снять деньги со счёта; 3 - Закрыть счёт; 4 - Выбрать иной счёт; 5 - Перевод средств.");
            string vybor = Console.ReadLine();
            switch (vybor)
            {
                case "1":
                    this.Dob1(sum);
                    break;
                case "2":
                    this.Umen1(sum);
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("> Счёт закрыт.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "4":
                    this.Info2(nomchet2, sum2);
                    break;
                case "5":
                    this.Perenos1(perenos);
                    break;
            }
        }

        public void Out1() //Вывод информации о счёте
        {
            sum = sumtek;
            Console.WriteLine("x-----------------------------");
            Console.WriteLine($"|Информация по текущему счёту: \n|Номер счёта: {nomchet}; \n|Фамилия: {fio}; \n|Сумма на счету: {sumtek}.");
            Console.WriteLine("x-----------------------------");

            Console.WriteLine("> Что Вы хотите сделать? 1 - Добавить деньги на счёт; 2 - Снять деньги со счёта; 3 - Закрыть счёт; 4 - Выбрать иной счёт; 5 - Перевод средств");
            string vybor = Console.ReadLine();
            switch (vybor)
            {
                case "1":
                    this.Dob1(sum);
                    break;
                case "2":
                    this.Umen1(sum);
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("> Счёт закрыт.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "4":
                    this.Info2(nomchet2, sum2);
                    break;
                case "5":
                    this.Perenos1(perenos);
                    break;
            }
        }
        public void Dob1(float sum) //Положить на счёт
        {
            Console.WriteLine("> Сколько Вы хотите положить на счёт?");
            float dob = float.Parse(Console.ReadLine());
            if (dob < 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Read();
            }
            sumtek = dob += sum;
            this.Out1();
        }
        public void Umen1(float sum) //Снять со счёта
        {
            Console.WriteLine("> Сколько Вы хотите снять со счёта?");
            float umen = float.Parse(Console.ReadLine());
            if (umen < 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Read();
            }
            if (umen < sum)
            {
                sumtek = sum -= umen;
            }
            else if (umen > sum)
            {
                //this.Obnul(sum);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                this.Info1(nomchet, fio, sum);
            }
            else if (umen == sum)
            {
                this.Obnul1(sum);
            }
            this.Out1();  
        }
        public void Obnul1(float sum) //Взять всю сумму
        {
            sumtek = sum - sum;
        }


//******************************************************************************************************************************************************************\\

        public void Info2(int nomchet2, float sum2)
        {
            this.nomchet2 = nomchet2;
            this.sum2 = sum2;

            if (nomchet2 < 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                //Console.Clear();
                Console.Read();
            }
            if (sum2 < 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.Read();
            }

            nomchet2 = nomchet + 1;
            Console.WriteLine("x-----------------------------");
            Console.WriteLine($"|Информация по текущему счёту: \n|Номер счёта: {nomchet2}; \n|Фамилия: {fio}; \n|Сумма на счету: {sum2}.");
            Console.WriteLine("x-----------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("> Счёт открыт.");
            Console.ForegroundColor = ConsoleColor.White;

            
            Console.WriteLine("> Что Вы хотите сделать? 1 - Добавить деньги на счёт; 2 - Снять деньги со счёта; 3 - Закрыть счёт; 4 - Выбрать изначальный счёт; 5 - Перевод средств.");
            string vybor2 = Console.ReadLine();
            switch (vybor2)
            {
                case "1":
                    this.Dob2(sum2);
                    break;
                case "2":
                    this.Umen2(sum2);
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("> Счёт закрыт.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "4":
                    this.Info1(nomchet, fio, sum);
                    break;
                case "5":
                    this.Perenos2(perenos2);
                    break;
            }
        }

        public void Out2() //Вывод информации о счёте
        {
            sum2 = sumtek2;
            nomchet2 = nomchet + 1;
            fio2 = fio;
            Console.WriteLine("x-----------------------------");
            Console.WriteLine($"|Информация по текущему счёту: \n|Номер счёта: {nomchet2}; \n|Фамилия: {fio2}; \n|Сумма на счету: {sumtek2}.");
            Console.WriteLine("x-----------------------------");

            Console.WriteLine("> Что Вы хотите сделать? 1 - Добавить деньги на счёт; 2 - Снять деньги со счёта; 3 - Закрыть счёт; 4 - Выбрать изначальный счёт; 5 - Перевод средств.");
            string vybor2 = Console.ReadLine();
            switch (vybor2)
            {
                case "1":
                    this.Dob2(sum2);
                    break;
                case "2":
                    this.Umen2(sum2);
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("> Счёт закрыт.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "4":
                    this.Out1();
                    break;
                case "5":
                    this.Perenos2(perenos2);
                    break;
            }
        }
        public void Dob2(float sum2) //Положить на счёт
        {
            Console.WriteLine("> Сколько Вы хотите положить на счёт?");
            float dob2 = float.Parse(Console.ReadLine());
            if (dob2 < 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Read();
            }
            sumtek2 = dob2 += sum2;
            this.Out2();
        }
        public void Umen2(float sum2) //Снять со счёта
        {
            Console.WriteLine("> Сколько Вы хотите снять со счёта?");
            float umen2 = float.Parse(Console.ReadLine());
            if (umen2 < sum2)
            {
                sumtek2 = sum2 -= umen2;
            }
            else if (umen2 > sum2)
            {
                //this.Obnul(sum);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                this.Info2(nomchet2, sum2);
            }
            else if (umen2 == sum2)
            {
                this.Obnul2(sum2);
            }
            this.Out2();
        }
        public void Obnul2(float sum2) //Взять всю сумму
        {
            sumtek2 = sum2 - sum2;
        }


//******************************************************************************************************************************************************************\\


        public void Perenos1(float perenos) //Перенести сумму с одного счёта на другой
        {
            Console.WriteLine("|Перевод на другой счёт. \n|Сколько Вы хотите перевести?");
            perenos = float.Parse(Console.ReadLine());
            if (sumtek > perenos)
            {
                sumtek -= perenos;
                sumtek2 = perenos + sumtek2;


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Совершена операция перевода средств на счёт {nomchet2} в размере {perenos}");
                Console.ForegroundColor = ConsoleColor.White;
                this.Out2();
            }
            else if (sumtek < perenos)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                this.Perenos1(perenos);
            }
            else if (sumtek == perenos)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                this.Perenos1(perenos);
            }
        }
        public void Perenos2(float perenos2) //Перенести сумму с одного счёта на другой
        {
            Console.WriteLine("|Перевод на другой счёт. \n|Сколько Вы хотите перевести?");
            perenos2 = float.Parse(Console.ReadLine());
            if (sumtek2 > perenos2)
            {
                sumtek2 -= perenos2;
                sumtek = perenos2 + sumtek;


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Совершена операция перевода средств на счёт {nomchet} в размере {perenos2}");
                Console.ForegroundColor = ConsoleColor.White;
                this.Out2();
            }
            else if (sumtek2 < perenos2)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                this.Perenos1(perenos2);
            }
            else if (sumtek2 == perenos2)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("! ОШИБКА !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                this.Perenos1(perenos2);
            }
        }  
    }
}


