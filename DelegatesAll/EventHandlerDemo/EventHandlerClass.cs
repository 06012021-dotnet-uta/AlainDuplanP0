using System;

namespace EventHandlerDemo
{
    public class EventHandlerClass
    {
        // 1. Create the delelgate type
        public delegate void MessageHandler(object source, MessageEventArgsClass args);

        // 2. instantiate the delegate
        public event MessageHandler myMessageHandler;


        // 3. create a method that will raise the event through this preparatory/protector method
        public void MessageSend(string message)
        {
            message += message;// douible the string (just for fun)
            OnMessageSend(message);
        }

        // 4. create the method that actually raises the event.
        private void OnMessageSend(string message)
        {
            //check if there are any subscribers to the delegate
            if (myMessageHandler != null)
            {
                // create the instance of MessageEventArgsClass to send with the event
                MessageEventArgsClass meac = new MessageEventArgsClass() { MyString = message };
                //envoke the event with 'this' which is the current context class
                myMessageHandler(this, meac);
                System.Console.WriteLine(meac.MyString);
            }
            else
            {
                System.Console.WriteLine("There were no subscribers to the event");
            }
        }
    }//EoC
}//EoN