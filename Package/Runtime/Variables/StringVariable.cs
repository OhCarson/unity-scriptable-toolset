using UnityEngine;
using System;

namespace Scriptable.Variables
{
    [CreateAssetMenu]
    public class StringVariable : ScriptableVariable
    {
        [SerializeField]
        private string value = "";

        public string Value
        {
            get { return value; }
            set {
                var prevValue = this.value;
                this.value = value;

                if (prevValue != value && onChange != null)
                    onChange.Invoke(value);
            }
        }

        public override string ToString()
        {
            return value;
        }

        public void CopyFrom(ScriptableVariable variable)
        {
            this.Value = variable.ToString();
        }
    }
}