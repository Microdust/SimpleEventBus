namespace EventBus.Sample
{
    public class SomeSubscriber : ISubscribe<SomeMessage>
    {

        public SomeSubscriber()
        {
            EventBus.Subscribe(this);
        }

        public void Execute(SomeMessage content)
        {
            content.PrintContent();
        }

    }
}