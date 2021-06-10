using System;

namespace DelegateSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegateClass myDelegateClass = new DelegateClass();
            MethodsClass myMethodsClass = new MethodsClass();

            //add methods with = then +=
            // myDelegateClass.mySimpleDelegate = myMethodsClass.method1;
            // myDelegateClass.mySimpleDelegate += myMethodsClass.method2;
            // myDelegateClass.mySimpleDelegate += myMethodsClass.method3;

            //delete a method for the incocation list.
            // myDelegateClass.mySimpleDelegate -= myMethodsClass.method2;


            // myDelegateClass.mySimpleDelegate();
            //Console.WriteLine(myDelegateClass.mySimpleDelegate.GetInvocationList().ToString());


            /* add some appropriate methods to the other delegate 
            that has a string parameter.*/
            // myDelegateClass.myNotSimpleDelegate = myMethodsClass.Method4;
            // myDelegateClass.myNotSimpleDelegate += myMethodsClass.Method5;
            // myDelegateClass.myNotSimpleDelegate += myMethodsClass.Method6;

            // Console.WriteLine("Please start a message");
            // string myString = Console.ReadLine();
            // int result = myDelegateClass.myNotSimpleDelegate(ref myString);
            // Console.WriteLine($"the result is => {result}");
            // Console.WriteLine($"the string is now => {myString}");

            #region Action<> Delegates

            // myDelegateClass.myActionWithOneParameter = myMethodsClass.method11;
            // myDelegateClass.myActionWithOneParameter += myMethodsClass.method22;
            // myDelegateClass.myActionWithOneParameter += myMethodsClass.method33;
            // myDelegateClass.myActionWithOneParameter(5);

            // myDelegateClass.myFuncDelegate = myMethodsClass.Method7;
            // int myInt = myDelegateClass.myFuncDelegate();
            // Console.WriteLine($"The int returned is {myInt}");

            /* you can use a Lambda expression for methods you only intend to call once.
            */
            //myFuncDelegate has no parameters and returns an int
            myDelegateClass.myFuncDelegateWithOneParam = num =>
            {
                Console.WriteLine("add a number");
                int usersInt;
                bool m = Int32.TryParse(Console.ReadLine(), out usersInt);
                return usersInt + num;
            };

            //int myInt = myDelegateClass.myFuncDelegate();
            int myInt2 = myDelegateClass.myFuncDelegateWithOneParam(10);
            Console.WriteLine($"The int returned is {myInt2}");
            #endregion

        }
    }
}
