namespace EventBus.Sample
{
    public class SomeMessageEvents : SelfContainedEvent<SomeMessage>
    {
        private static SomeMessage _instance = new SomeMessage();

        public static void Post(string name, string message)
        {
            _instance.Name = name;
            _instance.Message = message;

            EventBus.Publish(_instance);
        }

    }

}