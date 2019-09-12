namespace EventBus
{
    public interface ISubscribe<T>
    {
        void Execute(T content);
    }
}