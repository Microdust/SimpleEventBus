using System;

namespace EventBus.Sample
{
    public struct SomeMessage
    {
        public string Name;
        public string Message;

        public SomeMessage(string name, string message)
        {
            Name = name;
            Message = message;
        }

        public void PrintContent()
        {
            Console.WriteLine($"{Name} says: {Message}");
        }
    }
}