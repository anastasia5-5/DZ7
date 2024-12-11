using System;
using System.IO;

namespace Novikova_Nastya_lab
{

    /// <summary>
    /// Виды банковского счета
    /// </summary>
    enum AccountType
    {
        Saving,  //Сберегательный
        Deposit, //Депозитный
        Currency //Валютный
    }

    internal class Program
    {
        /// <summary>
        /// Метод который принимает строку и возвращает ее в обратном порядке
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ReverseString(string input)
        {
            char[] ArrayOfChar = input.ToCharArray();
            Array.Reverse(ArrayOfChar);

            return new string(ArrayOfChar);
        }
       
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }
        // В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить метод, который переводит деньги с одного счета на другой.
        // У метода два параметра: ссылка на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
        static void Task1()
        {
            Console.WriteLine("Упражнение 8.1");

            Console.WriteLine("\nПервый:");
            BankAccount FirstAccount = new BankAccount(55555555, 10005.0m, AccountType.Saving);
            FirstAccount.DisplayInfo();

            Console.WriteLine("\nВторой:");
            BankAccount SecondAccount = new BankAccount(66666666, 28564.90m, AccountType.Deposit);
            SecondAccount.DisplayInfo();

            Console.WriteLine("\nТретий:");
            BankAccount ThirdAccount = new BankAccount(88888888, 6734.87m, AccountType.Currency);
            ThirdAccount.DisplayInfo();

            FirstAccount.Refill(600.00m);
            Console.WriteLine("\nПосле пополнения:");
            FirstAccount.DisplayInfo();

            FirstAccount.WithDraw(250.00m);
            Console.WriteLine("\nПосле снятия средств:");
            FirstAccount.DisplayInfo();

            SecondAccount.Refill(400.00m);
            Console.WriteLine("\nПосле пополнения:");
            SecondAccount.DisplayInfo();

            SecondAccount.WithDraw(100.50m);
            Console.WriteLine("\nПосле снятия средств:");
            SecondAccount.DisplayInfo();

            ThirdAccount.Refill(750.00m);
            Console.WriteLine("\nПосле пополнения:");
            ThirdAccount.DisplayInfo();

            ThirdAccount.WithDraw(700.00m);
            Console.WriteLine("\nПосле снятия средств:");
            ThirdAccount.DisplayInfo();

            FirstAccount.Transfer(FirstAccount,SecondAccount, 90.0m);
            Console.WriteLine("\nПосле перевода:");
            FirstAccount.DisplayInfo();
            SecondAccount.DisplayInfo();

            SecondAccount.Transfer(SecondAccount, ThirdAccount, 320.0m);
            Console.WriteLine("\nПосле перевода:");
            SecondAccount.DisplayInfo();
            ThirdAccount.DisplayInfo();

            Console.ReadLine();
        }

        //Реализовать метод, который в качестве входного параметра принимает строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
        //Протестировать метод.
        static void Task2()
        {
            Console.WriteLine("Упражнение 8.2");

            //Тестирование метода
            string testingString = "Hello, world!";
            string reversedString = ReverseString(testingString);

            Console.WriteLine($"Исходная строка: {testingString}");
            Console.WriteLine($"Измененная строка: {reversedString}");

            //Дополнительная проверка
            Console.WriteLine(ReverseString("87654"));
            Console.WriteLine(ReverseString(""));
            Console.WriteLine(ReverseString("N"));

            Console.ReadLine();
        }

        //Написать программу, которая спрашивает у пользователя имя файла. Если такого файла не существует, то программа выдает пользователю сообщение и заканчивает работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными буквами.
        static void Task3()
        {
            Console.WriteLine("Упражнение 8.3");

            Console.Write("Введите путь к файлу: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл '{filePath}' не найден");
                return;
            }
            else
            {
                File.Create("output.txt");
            }
            
            string outputFileName = "C:\\Users\\anastasianovikova\\source\\repos\\DZ7\\Novikova_Nastya_lab";

            try
            {
                string content = File.ReadAllText(filePath).ToUpper();

                File.WriteAllText(outputFileName, content);

                Console.WriteLine($"Содержимое файла '{filePath}' успешно записано в файл '{outputFileName}' в верхнем регистре.");
                Console.WriteLine(File.ReadAllText(outputFileName));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Произошла ошибка: {exception.Message}");
            }

            Console.ReadLine() ;
        }
        
    

        //Реализовать метод, который проверяет реализует ли входной параметр метода интерфейс System.IFormattable. Использовать оператор is и as.
        static void Task4()
        {
            Console.WriteLine("Упражнение 8.4");
        }

        
    }
}
