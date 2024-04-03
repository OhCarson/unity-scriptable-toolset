using System;

namespace Scriptable.Variables
{
    [Serializable]
    public class StringReference
    {
        public bool UseConstant = true;
        public string ConstantValue;
        public StringVariable Variable;

        public StringReference()
        { }

        public StringReference(string value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public string Value
        {
            get {
                if (UseConstant)
                    return ConstantValue;
                return Variable.Value; 
            }
            set { 
                if(UseConstant) 
                    ConstantValue = value;
                else
                    Variable.Value = value; 
            }
        }

        public static implicit operator string(StringReference reference)
        {
            return reference.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}