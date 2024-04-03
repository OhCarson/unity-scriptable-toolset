﻿using System;

namespace Scriptable.Variables
{
    [Serializable]
    public class FloatReference
    {
        public bool UseConstant = true;
        public float ConstantValue;
        public FloatVariable Variable;

        public FloatReference()
        { }

        public FloatReference(float value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public float Value
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
                    Variable.SetValue(value); 
            }
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}