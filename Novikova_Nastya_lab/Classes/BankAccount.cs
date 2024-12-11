using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novikova_Nastya_lab
{
    internal class BankAccount
    {
        /// <summary>
        /// Свойства
        /// </summary>
        public ulong AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public AccountType AccountType { get; private set; }

        public BankAccount(ulong AccountNumber, decimal balance, AccountType accountType)
        {
            this.AccountNumber = AccountNumber;
            this.Balance = balance;
            this.AccountType = accountType;
        }


        //Метод для пополнения счета
        public void Refill(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Баланс был пополнен на {amount}. Текущий баланс:{Balance}");
            }
            else
            {
                Console.WriteLine("Сумма пополнения должна быть положительной");
            }
        }

        //Метод для снятия средств со счета
        public void WithDraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Со счета снято {amount}.Остаток средств на счете:{Balance}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств или неверная сумма для снятия");
            }
        }

        //Метод отображения информации о счете
        public void DisplayInfo()
        {
            Console.WriteLine($"Номер счета:{AccountNumber}");
            Console.WriteLine($"Баланс:{Balance}");
            Console.WriteLine($"Тип банковского счета:{AccountType}");
        }

        //Метод который переводит деньги с одного счета на другой 
        public void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть большеке 0");
                return;
            }
            if (amount > Balance)
            {
                Console.WriteLine("Недостаточно средств на счете");
                return;
            }
            Balance -= amount;
            WithDraw(amount);
            fromAccount.Refill(amount);

            Console.WriteLine($"Переведено {amount} со счета {AccountNumber} на счет {fromAccount.GetType()}");
        }
    }
}

