using System;
using System.Collections;
using System.IO;

namespace Tumakov_DZ
{
    public class BankAccount : IDisposable
    {
        private Guid accountNumber;       
        private string accountType;           
        private string accountHolder;       
        private decimal balance;              
        private Queue transactions;            

        public Guid AccountNumber => accountNumber;
        public string AccountType => accountType;
        public string AccountHolder
        {
            get => accountHolder;
            set => accountHolder = value;
        }
        public decimal Balance => balance;

        private static Guid GenerateAccountNumber()
        {
            return Guid.NewGuid();
        }

        public BankAccount(string holderName, decimal initialBalance, string type)
        {
            accountNumber = GenerateAccountNumber();
            accountHolder = holderName;
            accountType = type;
            balance = initialBalance >= 0 ? initialBalance : 0;
            transactions = new Queue();  
        }

      
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                var transaction = new BankTransaction(amount);
                transactions.Enqueue(transaction); 
                Console.WriteLine($"Счет {accountNumber}: Пополнен на {amount}. Новый баланс: {balance}");
            }
            else
            {
                Console.WriteLine("Сумма пополнения должна быть больше 0.");
            }
        }

        
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                var transaction = new BankTransaction(-amount);
                transactions.Enqueue(transaction); 
                Console.WriteLine($"Счет {accountNumber}: Снято {amount}. Новый баланс: {balance}");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Недостаточно средств для снятия.");
            }
            else
            {
                Console.WriteLine("Сумма снятия должна быть больше 0.");
            }
        }

 
        public void Dispose()
        {
      
            string filePath = $"{accountNumber}.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"Операции для счета {accountNumber}");
                    writer.WriteLine($"Тип счета: {accountType}");
                    writer.WriteLine($"Владелец: {accountHolder}");
                    writer.WriteLine($"Баланс: {balance}");
                    writer.WriteLine("Детали операций:");

              
                    foreach (BankTransaction transaction in transactions)
                    {
                        writer.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount}");
                    }
                }
                Console.WriteLine($"Информация о проводках записана в файл: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
            }

      
            GC.SuppressFinalize(this);
        }


        public void DisplayInfo()
        {
            Console.WriteLine($"Счет №{accountNumber}, Тип: {accountType}, Владелец: {accountHolder}, Баланс: {balance}");
        }
    }
}







