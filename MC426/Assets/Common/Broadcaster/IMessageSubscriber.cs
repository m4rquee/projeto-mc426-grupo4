namespace Common.Broadcaster
{
    public interface IMessageSubscriber<in T> where T : IMessage
    {
        void OnMessageReceived(T message);
    }
}