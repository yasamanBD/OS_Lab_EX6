using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MUTEX
{
    class Program
    {
        static Mutex mutex = new Mutex(); // Mutex object

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
            mutex.WaitOne(); // Entering critical section
            try
            {
                Console.WriteLine($"Account {accountId} is withdrawing money...");
                Thread.Sleep(2000); // Simulate withdrawal
                Console.WriteLine($"Account {accountId} has withdrawn money.");
            }
            finally
            {
                mutex.ReleaseMutex(); // Exiting critical section
            }
        }
    }
}
