using System;
using System.Collections.Generic;

namespace BookingSystem.BL.Util
{
    public class EventManager
    {
        private IDictionary<EventType, List<IEventListener>> listeners;

        public EventManager()
        {
            listeners = new Dictionary<EventType, List<IEventListener>>();
            listeners.Add(EventType.Saved, new List<IEventListener>());
            listeners.Add(EventType.Deleted, new List<IEventListener>());
        }

        public void Subscribe(EventType eventType, IEventListener listener)
        {
            var eventListeners = listeners[eventType];
            eventListeners.Add(listener);
        }

        public void Unsubscribe(EventType eventType, IEventListener listener)
        {
            var eventListeners = listeners[eventType];
            eventListeners.Remove(listener);
        }

        public void Notify(EventType eventType, string data)
        {
            var eventListeners = listeners[eventType];
            foreach(var listener in eventListeners)
            {
                listener.Update(data);
            }
        }
    }
}
