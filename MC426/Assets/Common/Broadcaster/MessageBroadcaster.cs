using System;
using System.Linq;

namespace Common.Broadcaster
{
    public class MessageBroadcaster
    {
        static MessageBroadcaster _instance;
        public static MessageBroadcaster Instance
        {
            get { return _instance ?? (_instance = new MessageBroadcaster()); }
        }

        readonly SafeList<object> _subscribers = new SafeList<object>();

        public void Subscribe<T>(IMessageSubscriber<T> subscriber) where T : IMessage
        {
            if(!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }

        public void Unsubscribe<T>(IMessageSubscriber<T> subscriber) where T : IMessage
        {
            if (_subscribers.Contains(subscriber))
            {
                _subscribers.Remove(subscriber);
            }
        }

        public void BroadcastMessage<T>(T message) where T : IMessage
        {
            foreach (var subscriber in _subscribers)
            {
                try
                {
                    var subs = subscriber as IMessageSubscriber<T>;
                    if (subs == null) continue;
                    subs.OnMessageReceived(message);
                }
                catch (InvalidCastException)
                {
                    // This supposed to be blank so we can ignore false alarms. The Invalid Cast Exception in this particular case is expected
                    // because it's a listener that don't need to receive the message in the first place. Since we don't want to spam the Console with misleading errors
                    // we catch and ignore it.
                }
            }
        }
    }
}