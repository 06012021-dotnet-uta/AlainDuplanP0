using System;

namespace EventHandlerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHandlerClass eventHandlerClass = new EventHandlerClass();
            MethodsClass methodsClass = new MethodsClass();

            eventHandlerClass.myMessageHandler += methodsClass.OnMessageSend1;//you can only subscribe methods to the event with '+="
            eventHandlerClass.myMessageHandler += methodsClass.OnMessageSend2;

            System.Console.WriteLine("enter a word");
            string message = Console.ReadLine();// get a meesage from the user
            eventHandlerClass.MessageSend(message);// envoke the prep/protectod method to the event

        }
    }
}
