using System;

namespace DelegateSimple
{
    public class MethodsClass
    {
        #region this is a region. This region contains methods for a Action Type Delegate
        public void method1()
        {
            Console.WriteLine($"This is method 1.");
        }
        public void method2()
        {
            Console.WriteLine($"This is method 2.");
        }
        public void method3()
        {
            Console.WriteLine($"This is method 3.");
        }

        public void method11(int x)
        {
            Console.WriteLine($"This is method 1.Int x is {x}");
        }
        public void method22(int x)
        {
            Console.WriteLine($"This is method 2. Int x is {x}");
        }
        public void method33(int x)
        {
            Console.WriteLine($"This is method 3. Int x is {x}");
        }
        #endregion

        #region this region holds methods for a Function type delegate

        public int Method4(ref string message)
        {
            Console.WriteLine($"Method 4. Add something to the message");
            string m = Console.ReadLine();//get a new string form the user
            message += m;// assign that string to the existing string (it's on the heap)
            return 1;
        }

        public int Method5(ref string message)
        {
            Console.WriteLine($"Method 5. Add something to the message");
            string m = Console.ReadLine();
            message += m;
            return 2;
        }

        public int Method6(ref string message)
        {
            Console.WriteLine($"Method 6. Add something to the message");
            string m = Console.ReadLine();
            message += m;
            return 3;
        }

        public int Method7()
        {
            Console.WriteLine($"Method 7. Give us a number.");
            int usersInt;
            bool m = Int32.TryParse(Console.ReadLine(), out usersInt);
            return usersInt;
        }

        public int Method8(string message)
        {
            Console.WriteLine($"Method 6. Add something to the message");
            string m = Console.ReadLine();
            message += m;
            return 3;
        }

        #endregion


    }
}
