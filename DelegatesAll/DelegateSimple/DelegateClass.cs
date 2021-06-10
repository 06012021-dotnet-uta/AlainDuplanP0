using System;

namespace DelegateSimple
{
    public class DelegateClass
    {
        /*declare a delegate Type. 
         this gives the method signature for any method 
         that can be assigned to
         a delegate of this type.*/
        public delegate void SimpleDelegate();

        /*now create the instance of the delegate 
        type that you can assign methods to.*/
        public SimpleDelegate mySimpleDelegate;

        public delegate int NotSimpleDelegate(ref string message);
        public NotSimpleDelegate myNotSimpleDelegate;

        //make other methods to do things...


        /* Action Delegates no NOT return a value. They return void.
        'Action delgateName' is used when it has no parameters.
        'Action<paramType>' is used for delegates with >0 parameters*/
        public Action myAction { get; set; }
        public Action<int> myActionWithOneParameter { get; set; }

        /* Function<> delegates take a number of parameters and return a value.
        */
        public Func<int> myFuncDelegate;
        public Func<int, int> myFuncDelegateWithOneParam;
        public Func<string> myFuncDelegateWithString;


    }
}