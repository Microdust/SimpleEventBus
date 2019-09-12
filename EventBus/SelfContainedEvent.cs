namespace EventBus
{
    public abstract class SelfContainedEvent<T>
    {
        public static void Subscribe(ISubscribe<T> subscriber)
        {
            EventBus.Subscribe(subscriber);
        }

        public static void Unsubscribe(ISubscribe<T> subscriber)
        {
            EventBus.Unsubscribe(subscriber);
        }
    }
}