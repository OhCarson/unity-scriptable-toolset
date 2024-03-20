using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scriptable.Variables
{
    public class VariableChangeResponse : MonoBehaviour
    {
        public bool callOnEnable = true;

        public ScriptableVariable stringVariable;
        public UnityEvent<string> response;

        private void OnEnable()
        {
            stringVariable.onChange += Respond;
            if (callOnEnable)
                Respond(stringVariable.ToString());
        }

        private void OnDisable()
        {
            stringVariable.onChange -= Respond;
        }
        private void Respond(string value)
        {
            response.Invoke(value);
        }
    }
}