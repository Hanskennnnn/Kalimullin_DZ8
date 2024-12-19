
namespace Tumakov_DZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
        }
        static void Task1()
        {          
            var account = new BankAccount("Ivan Ivanov", 1000m, "Checking");

            account.DisplayInfo();       
            account.Deposit(500m);     
            account.Withdraw(200m);         
            account.DisplayInfo();
            account.Dispose();
        }

    }
}
