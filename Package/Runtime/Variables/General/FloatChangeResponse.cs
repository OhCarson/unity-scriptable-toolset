using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scriptable.Variables
{
    public class FloatChangeResponse : MonoBehaviour
    {
        public enum Condition { None, Equal, Greater, Less, GreaterEqual, LessEqual }
        public enum Operation { Add, Subtract, Multiply, Divide_AB, Divide_BA }

        [System.Serializable]
        public struct OutputOperation
        {
            public Operation operation;
            public FloatReference value;
        }

        [System.Serializable]
        public struct ConditionalsFloat
        {
            public Condition condition;
            public FloatReference value;
            public UnityEvent<float> response;
        }

        [System.Serializable]
        public struct ConditionalsString
        {
            
            public Condition condition;
            public FloatReference value;
            public UnityEvent<string> response;
        }

        public bool callOnEnable = true;

        public FloatVariable floatVariable;

        public List<OutputOperation> operations;
        public List<ConditionalsFloat> responsesFloat;
        public List<ConditionalsString> responsesString;

        private void OnEnable()
        {
            floatVariable.onChangeFloat += Respond;
            if (callOnEnable)
                Respond(floatVariable.Value);
        }

        private void OnDisable()
        {
            floatVariable.onChangeFloat -= Respond;
        }
        private void Respond(float value)
        {
            //operations
            foreach(var operation in operations)
            {
                switch(operation.operation)
                {
                    case Operation.Add:
                        value += operation.value;
                        break;
                    case Operation.Subtract:
                        value -= operation.value;
                        break;
                    case Operation.Multiply:
                        value *= operation.value;
                        break;
                    case Operation.Divide_AB:
                        value /= operation.value;
                        break;
                    case Operation.Divide_BA:
                        value = operation.value / value;
                        break;
                }
            }

            //conditionals
            foreach(var conditional in responsesFloat)
            {
                switch(conditional.condition)
                {
                    case Condition.None:
                        conditional.response.Invoke(value);
                        break;
                    case Condition.Equal:
                        if(value == conditional.value)
                            conditional.response.Invoke(value);
                        break;
                    case Condition.Less:
                        if (value < conditional.value)
                            conditional.response.Invoke(value);
                        break;
                    case Condition.Greater:
                        if (value > conditional.value)
                            conditional.response.Invoke(value);
                        break;
                    case Condition.LessEqual:
                        if (value <= conditional.value)
                            conditional.response.Invoke(value);
                        break;
                    case Condition.GreaterEqual:
                        if (value >= conditional.value)
                            conditional.response.Invoke(value);
                        break;
                }
            }

            foreach (var conditional in responsesString)
            {
                switch (conditional.condition)
                {
                    case Condition.None:
                        conditional.response.Invoke(value.ToString());
                        break;
                    case Condition.Equal:
                        if (value == conditional.value)
                            conditional.response.Invoke(value.ToString());
                        break;
                    case Condition.Less:
                        if (value < conditional.value)
                            conditional.response.Invoke(value.ToString());
                        break;
                    case Condition.Greater:
                        if (value > conditional.value)
                            conditional.response.Invoke(value.ToString());
                        break;
                    case Condition.LessEqual:
                        if (value <= conditional.value)
                            conditional.response.Invoke(value.ToString());
                        break;
                    case Condition.GreaterEqual:
                        if (value >= conditional.value)
                            conditional.response.Invoke(value.ToString());
                        break;
                }
            }
        }
    }
}