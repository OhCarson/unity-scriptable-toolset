using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scriptable.Variables
{
    public class BoolCompareRaiser : MonoBehaviour
    {
        public bool runOnEnable = true;
        public bool runOnUpdate = false;
        public BoolReference variableA, variableB;
        public UnityEvent onTrueEvent, onFalseEvent;

        public void OnEnable()
        {
            if (runOnEnable)
                Process();
        }

        public void Update()
        {
            if(runOnUpdate)
                Process();
        }

        public void Process()
        {
            if (variableA.Value == variableB.Value)
                onTrueEvent.Invoke();
            else
                onFalseEvent.Invoke();
        }
    }
}