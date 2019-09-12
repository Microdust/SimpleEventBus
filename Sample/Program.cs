using System;
using System.Diagnostics;

namespace EventBus.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // SomeSubscriber subscribes to SomeMessage in its Constructor
            var sub = new SomeSubscriber();

            // A simple message object to pass to the subscribers
            SomeMessage message = new SomeMessage("Thomas", "Hello world");

            // Publish SomeMessage to be picked up by the SomeSubscriber object
            EventBus.Publish<SomeMessage>(message);

            // Remove the object from the subscriber list
            EventBus.Unsubscribe<SomeMessage>(sub);
    
            // Alternatively, use a SelfContainedEvent for convenience
            // Using SomeMessageEvents implemented as a SelfContainedEvent. Add the subscriber object once more
            SomeMessageEvents.Subscribe(sub);

            // The Post method internally calls Publish
            SomeMessageEvents.Post("Stranger", "I am hidden");

            // Unsubscribe the subscriber object again
            SomeMessageEvents.Unsubscribe(sub);

            // There are no subscribers thus the following message will not be delivered
            SomeMessageEvents.Post("Guy Fawkes", " You wear a mask for so long you forget who you were beneath it");
        }
    }
}