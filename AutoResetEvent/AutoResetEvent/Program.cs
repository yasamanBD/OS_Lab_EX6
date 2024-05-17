using System;
using System.Threading;

namespace AutoResetEventt
{
    class Program
    {
        static AutoResetEvent autoResetEvent = new AutoResetEvent(true); // AutoResetEvent object

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(WithdrawMoney);
                thread.Start(i + 1);
            }
            Console.ReadKey();
        }

        static void WithdrawMoney(object accountId)
        {
            autoResetEvent.WaitOne(); // Entering critical section
            try
            {
                Console.WriteLine($"Account {accountId} is withdrawing money...");
                Thread.Sleep(2000); // Simulate withdrawal
                Console.WriteLine($"Account {accountId} has withdrawn money.");
            }
            finally
            {
                autoResetEvent.Set(); // Exiting critical section
            }
        }
    }
}
