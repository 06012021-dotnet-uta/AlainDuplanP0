using System;

namespace DelegateSimple
{
    public class MethodClass{
        public void method1(){
            Console.WriteLine("This is method 1");
        }
         public void method2(){
            Console.WriteLine("This is method 2");
        }
         public void method3(){
            Console.WriteLine("This is method 3");
        }
         public int method4(string message){
            Console.WriteLine("This is method 4");
            return 1;
        }
        public int method5 (string message){
            Console.WriteLine("this is method 5");
            string m = Console.ReadLine();
            return 2;
        }

         public int method6 (string message){
            Console.WriteLine("this is method 5");
            message += Console.ReadLine();
            return 3;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DelegateSimple myDelegateClass = new DelegateSimple();
            MethodClass myMethodClass = new MethodClass();

            /*myDelegateClass.mySimpleDelegate = myMethodClass.method1;
            myDelegateClass.mySimpleDelegate += myMethodClass.method2;
            myDelegateClass.mySimpleDelegate += myMethodClass.method3;
            myDelegateClass.mySimpleDelegate -= myMethodClass.method2;
            */

            //myDelegateClass.mySimpleDelegate();
            //Console.WriteLine(myDelegateClass.mySimpleDelegate.GetInvocationList().ToString());
            
            myDelegateClass.myNotSimpleDelegate = myMethodClass.method4;
            myDelegateClass.myNotSimpleDelegate += myMethodClass.method5;
            myDelegateClass.myNotSimpleDelegate += myMethodClass.method6;
            int result = myDelegateClass.myNotSimpleDelegate("generic");
    }
}
}
