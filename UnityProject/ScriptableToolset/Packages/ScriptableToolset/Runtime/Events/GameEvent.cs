using System.Collections.Generic;
using UnityEngine;
using System;

namespace Scriptable.Events
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener> eventListeners = 
            new List<GameEventListener>();

        /// <summary>
        /// an action for easily hooking in to events within a script
        /// needs to be used with respect tho...
        /// </summary>
        [NonSerialized]
        public Action onRaiseAction;

        public void Raise()
        {
            for (int i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised();

            if (onRaiseAction != null)
                onRaiseAction();
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}