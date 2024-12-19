using System;
namespace Tumakov_DZ
{
    public class BankTransaction
    {
        public decimal Amount { get; }     
        public DateTime TransactionDate { get; }

        
        public BankTransaction(decimal amount)
        {
            Amount = amount;
            TransactionDate = DateTime.Now;  
        }
    }
}
