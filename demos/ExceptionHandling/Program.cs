using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int j = 0; j < 5; j++){

                int five = 5;
                int zero = 0;
                try{
                    int a = five / 0;
                }catch(ArithmeticException){
                    Console.WriteLine("\nMovong on...\n");
                }finally{
                    Console.WriteLine("\nThis is the Finally block\n");
                    if(zero == 0){
                        zero = 5;
                    }
                    else if(zero == 5){
                        zero = 0;
                    }
                }
            }
        }
    }
}
