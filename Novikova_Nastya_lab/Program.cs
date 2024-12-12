using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
        }

        // В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить метод, который переводит деньги с одного счета на другой.
        // У метода два параметра: ссылка на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
        static void Task1()
        {
            Console.WriteLine("\nУпражнение 8.1");

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
            Console.WriteLine("\nУпражнение 8.2");
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            Console.WriteLine(Reverse(str));
            Console.ReadLine();
        }

        /// <summary>
        /// Считывает строку символов с консоли и преобразует ее к неотрицательному числу. Ввод продолжается до тех пор, 
        /// пока пользователь не введет число.
        /// </summary>
        /// <returns>строка string</returns>
        static string Reverse(string stroka)
        {
            string revsStr = String.Empty;

            for (int i = stroka.Length - 1; i >= 0; i--)
            {
                revsStr += stroka[i];
            }

            return revsStr;
        }
        /// <summary>
        /// Метод который преобразует строку в верхний регистр и возвращает новую
        /// </summary>
        /// <param name="stroka"></param>
        /// <returns></returns>
        static string GetUpper(string stroka)
        {
            string revsStr = String.Empty;
            foreach (char c in stroka)
            {
                revsStr += c.ToString().ToUpper();
            }
            return revsStr;
        }

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


        //Написать программу, которая спрашивает у пользователя имя файла. Если такого файла не существует, то программа выдает пользователю сообщение и заканчивает работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными буквами.
        static void Task3()
        {
            Console.WriteLine("\nУпражнение 8.3");
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

            string outputFileName = "..\\..\\output.txt";

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

            Console.ReadLine();
        }


    
        
        //Реализовать метод, который проверяет реализует ли входной параметр метода интерфейс System.IFormattable. Использовать оператор is и as.
        static void Task4()
        {
            Console.WriteLine("\nУпражнение 8.4");

            object obj1 = 55; // реализует , int
            object obj2 = "Good morning"; // не реализует , string

            Console.WriteLine(IsIFormattable(obj1));
            Console.WriteLine(IsIFormattable(obj2));

            Console.ReadLine();
        }
        /// <summary>
        /// Проверка с is
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsIFormattable(object obj)
        {
            if (obj is IFormattable)
            {
                Console.WriteLine("Объект реализует IFormattable");
                return true;
            }
            else
            {
                Console.WriteLine("Объект не реализует IFormattable");
                return false;
            }
        }
        /// <summary>
        /// Проверка с as
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsFormattableAs ( object obj )
        {
            IFormattable formattable = obj as IFormattable;
            if (formattable != null)
            {
                Console.WriteLine("Объект реализует IFormattable (as)");
                return true;
            }
            else
            {
                Console.WriteLine("Объект не реализует IFormattable");
                return false;   
            }
        }

        //Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail адрес. Разделителем между ФИО и адресом электронной почты является символ #
        //Сформировать новый файл, содержащий список адресов электронной почты.Предусмотреть метод, выделяющий из строки адрес почты.Методу в
        //качестве параметра передается символьная строка s, e-mail возвращается в той же строке s: public void SearchMail(ref string s).

        static void Task5()
        {
            Console.WriteLine("\nДомашнее задание 8.1");

            string inputFile = "..\\..\\inputfile.txt";
            string outputFile = "..\\..\\outputfile.txt";

            try
            {
                string[] lines = File.ReadAllLines(inputFile);
                string[] emails = new string[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    SearchEmail(ref line);
                    emails[i] = line;
                }

                File.WriteAllLines(outputFile, emails);
                Console.WriteLine("Emails успешно записаны в файл:" + outputFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Метод для выделения почты
        /// </summary>
        /// <param name="s"></param>
        public static void SearchEmail( ref string s)
        {
            if (string.IsNullOrEmpty(s))
                return;

            int findIndexPlace = s.IndexOf("#");

            if (findIndexPlace != -1)
            {
                s = s.Substring(findIndexPlace + 1).Trim();  
            }
        }

        //Список песен. В методе Main создать список из четырех песен. В цикле вывести информацию о каждой песне. Сравнить между собой первую и вторую песню в списке.
        //Песня представляет собой класс с методами для заполнения каждого из полей, методом вывода данных о песне на печать, методом, который сравнивает между собой два объекта
        static void Task6()
        {
            Console.WriteLine("\nДомашнее задание 8.2");

            // Создаем список из четырех песен
            Song song1 = new Song();
            song1.SetName("Someone like you");
            song1.SetAuthor("Adele");

            Song song2 = new Song();
            song2.SetName("7 rings");
            song2.SetAuthor("Ariana Grande");
            song2.SetPrev(song1); 

            Song song3 = new Song();
            song3.SetName("Rumour has it");
            song3.SetAuthor("Adele");
            song3.SetPrev(song2); 

            Song song4 = new Song();
            song4.SetName("Thunder");
            song4.SetAuthor("Imagine Dragons");
            song4.SetPrev(song3); 

            Song[] songs = { song1, song2, song3, song4 };

            foreach (Song song in songs)
            {
                song.PrintInfo();
            }

            if (song1.Equals(song2))
            {
                Console.WriteLine($"{song1.Title()} и {song2.Title()} одинаковы.");
            }
            else
            {
                Console.WriteLine($"{song1.Title()} и {song2.Title()} различаются.");
            }
            Console.ReadLine();
        }
    }
}

