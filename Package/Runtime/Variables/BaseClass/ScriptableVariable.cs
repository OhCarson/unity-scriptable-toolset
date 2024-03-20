using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Scriptable.Variables
{
    public class ScriptableVariable : ScriptableObject
    {
        public Action<string> onChange;
    }
}