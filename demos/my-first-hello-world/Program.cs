using System;

namespace my_first_hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is name?");

            string myName = Console.ReadLine();

            Console.WriteLine("What is your age?");

            string myAge = Console.ReadLine();

            Console.WriteLine("Your name is {0} and you are {1} years old", myName, myAge);
        }
    }
}
