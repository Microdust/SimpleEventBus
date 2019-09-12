using System;
using System.Collections.Generic;

namespace EventBus
{
    /// <summary>
    /// A simple event bus to decouple components by publish/subscribe messages.
    /// EventBus is not thread-safe.
    /// </summary>
    public static class EventBus
    {
        private readonly static IDictionary<Type, IList<object>> _subscriptions = new Dictionary<Type, IList<object>>(32);

        /// <summary>
        /// Subscribe an object to receive events of the specified type.
        /// </summary>
        public static void Subscribe<T>(ISubscribe<T> sub)
        {
            if (!_subscriptions.TryGetValue(typeof(T), out IList<object> subs))
            {
                subs = new List<object>();
                _subscriptions.Add(typeof(T), subs);
            }
            subs.Add(sub);
        }

        /// <summary>
        /// Unsubscribe an object to no longer receive events of the specified type.
        /// </summary>
        public static void Unsubscribe<T>(ISubscribe<T> sub)
        {
            if (!_subscriptions.TryGetValue(typeof(T), out IList<object> subs))
                return;
            
            subs.Remove(sub);                
            if (subs.Count == 0)
            {
                _subscriptions.Remove(typeof(T));
            }
        }

        /// <summary>
        ///  Publish a message to all the respective subscribers
        /// </summary>
        public static void Publish<T>(T content)
        {
            if (!_subscriptions.TryGetValue(typeof(T), out IList<object> subs))
                return;
            
            for (int i = subs.Count - 1; i >= 0; i--)
            {
                (subs[i] as ISubscribe<T>).Execute(content);
            }
        }

        /// <summary>
        ///  Delete all subscriptions from the table.
        /// </summary>
        public static void ClearAll()
        {
            _subscriptions.Clear();
        }
    }
}