using System;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AsyncMethodClass amc = new AsyncMethodClass();

            string task1 = await amc.method1();
            System.Console.WriteLine($"Method 1 returned {task1}");
            int task2 = await amc.method2();
            System.Console.WriteLine($"Method 1 returned {task2}");
            string task3 = await amc.method3();
            System.Console.WriteLine($"Method 1 returned {task3}");
            Person task4 = await amc.method4();
            System.Console.WriteLine($"Method 1 returned {task4.Fname} and the age {task4.Age}");

            //return Task.Delay(1000);
        }
    }
}
