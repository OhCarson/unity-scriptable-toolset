using UnityEngine;
using System;

namespace Scriptable.Variables
{
    [CreateAssetMenu]
    public class BoolVariable : ScriptableVariable
    {
        [SerializeField]
        private bool value = false;
        public Action<bool> onChangeBool;
        public bool Value
        {
            get { return value; }
            set {
                var prevValue = this.value;
                this.value = value;

                if (prevValue != value && onChange != null)
                    onChange.Invoke(value.ToString());
                if (prevValue != value && onChangeBool != null)
                    onChangeBool.Invoke(value);
            }
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}