using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptable.Events
{
    public class GameEventMonoBehaviourRaiser : MonoBehaviour
    {
        public List<GameEvent> onAwakeEvents, onStartEvents, onEnabledEvents, onDisabledEvents, onUpdateEvents;

        private void Awake()
        {
            foreach (var e in onDisabledEvents)
                e.Raise();
        }

        private void Start()
        {
            foreach (var e in onStartEvents)
                e.Raise();
        }

        private void Update()
        {
            foreach (var e in onUpdateEvents)
                e.Raise();
        }

        private void OnEnable()
        {
            foreach (var e in onEnabledEvents)
                e.Raise();
        }

        private void OnDisable()
        {
            foreach (var e in onDisabledEvents)
                e.Raise();
        }
    }

}