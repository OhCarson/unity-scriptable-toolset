using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace Scriptable.Variables
{
    public class TextReplacerAdvanced : MonoBehaviour
    {
        [System.Serializable]
        public struct ReplaceTarget
        {
            public string tag;
            public ScriptableVariable variable;
        }

        public bool AlwaysUpdate;

        public string displayText;

        public TMP_Text Label;

        public List<ReplaceTarget> variables;


        private void OnEnable()
        {
            Label.text = ParseText();

        }

        private void Update()
        {
            if (AlwaysUpdate)
            {
                Label.text = ParseText();
            }
        }

        private string ParseText()
        {
            var textOutput = displayText;
            foreach(var replaceTarget in variables)
            {
                //parse displayText for instances of tag
                textOutput = textOutput.Replace(replaceTarget.tag, replaceTarget.variable.ToString() );
            }
            return textOutput;
        }
    }
}