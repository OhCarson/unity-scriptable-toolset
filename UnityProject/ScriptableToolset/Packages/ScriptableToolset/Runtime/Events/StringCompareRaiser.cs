using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scriptable.Variables
{
    //check two variables are the same in their ToString output
    //not flexible but works
    public class StringCompareRaiser : MonoBehaviour
    {
        public bool runOnEnable = true;
        //public enum ComparisonType { Equal, Greater, Less, GreaterEqual, GreaterLess }
        public StringReference variableA, variableB;
        public UnityEvent onTrueEvent, onFalseEvent;

        public void OnEnable()
        {
            if(runOnEnable)
                Process();
        }

        public void Process()
        {
            if (variableA.ToString() == variableB.ToString())
                onTrueEvent.Invoke();
            else
                onFalseEvent.Invoke();
        }
    }
}