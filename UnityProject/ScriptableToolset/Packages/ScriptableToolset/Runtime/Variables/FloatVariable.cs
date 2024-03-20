using UnityEngine;
using System;

namespace Scriptable.Variables
{
    [CreateAssetMenu]
    public class FloatVariable : ScriptableVariable
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        [SerializeField]
        private float _value;
        public float Value
        {
            get { return _value; }
            set { SetValue(value); }
        }
        public Action<float> onChangeFloat;

        public void SetValue(float value)
        {
            var prevVal = _value;
            _value = value;
            ChangeCheck(prevVal);
        }

        public void SetValue(FloatVariable value)
        {
            var prevVal = _value;
            _value = value.Value;
            ChangeCheck(prevVal);
        }

        public void ApplyChange(float amount)
        {
            var prevVal = _value;
            _value += amount;
            ChangeCheck(prevVal);
        }

        public void ApplyChange(FloatVariable amount)
        {
            var prevVal = _value;
            _value += amount.Value;
            ChangeCheck(prevVal);
        }

        private void ChangeCheck(float prevVal)
        {
            if (onChangeFloat != null && prevVal != _value)
                onChangeFloat.Invoke(_value);
            if (onChange != null && prevVal != _value)
                onChange.Invoke(_value.ToString());
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}