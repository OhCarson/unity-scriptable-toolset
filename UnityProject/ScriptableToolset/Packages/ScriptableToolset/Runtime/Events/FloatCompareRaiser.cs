using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scriptable.Variables
{
    //check two variables are the same in their ToString output
    //not flexible but works
    public class FloatCompareRaiser : MonoBehaviour
    {
        public bool runOnEnable = true;
        public enum ComparisonType { Equal, Greater, Less, GreaterEqual, GreaterLess }
        public ComparisonType comparisonType;
        public FloatReference variableA, variableB;
        public UnityEvent onTrueEvent, onFalseEvent;

        public void OnEnable()
        {
            if(runOnEnable)
                Process();
        }

        public void Process()
        {
            bool success = false;
            switch(comparisonType)
            {
                case ComparisonType.Equal:
                    success = variableA.Value == variableB.Value;
                    break;
                case ComparisonType.Greater:
                    success = variableA.Value > variableB.Value;
                    break;
                case ComparisonType.Less:
                    success = variableA.Value < variableB.Value;
                    break;
                case ComparisonType.GreaterEqual:
                    success = variableA.Value >= variableB.Value;
                    break;
                case ComparisonType.GreaterLess:
                    success = variableA.Value <= variableB.Value;
                    break;
            }

            if (success)
                onTrueEvent.Invoke();
            else
                onFalseEvent.Invoke();
        }
    }
}