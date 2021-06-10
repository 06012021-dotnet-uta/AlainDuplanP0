using System.Threading.Tasks;
namespace AsyncAwaitDemo{
    public class AsyncMethodClass{
        
        public async Task<string> method1(){
            System.Console.WriteLine("Method 1 BT");
            Task task = Task.Delay(1000);
            System.Console.WriteLine("Method 1 DT");
           //string userInput = System.Console.ReadLine();
            System.Console.WriteLine("Method 1 AT");
            await task;
            return "its me";
        }

        public async Task<int> method2(){
            System.Console.WriteLine("Method 2 BT");
            Task task = Task.Delay(2000);
            System.Console.WriteLine("Method 2 DT");
            await task;
            System.Console.WriteLine("Method 2 AT");
            return 1;
        }

        public async Task<string> method3(){
            System.Console.WriteLine("Method 3 BT");
            Task task = Task.Delay(3000);
            System.Console.WriteLine("Method 3 DT");
            
            await task;
            System.Console.WriteLine("Method 3 AT");
            return "userInput";
        }

        public async Task<Person> method4(){
            System.Console.WriteLine("Method 4 BT");
            Task task = Task.Delay(4000);
            System.Console.WriteLine("Method 4 DT");
            Person p = new Person(){Fname = "Ethan Hawke", Age = 50};
            
            await task;
            System.Console.WriteLine("Method 4 AT");
            return p;
        }
    }

    public class Person{
        public string Fname{get; set;}
        public int Age {get; set;}
    }
}