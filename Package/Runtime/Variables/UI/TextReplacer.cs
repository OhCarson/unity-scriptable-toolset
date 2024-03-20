using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Scriptable.Variables
{
    public class TextReplacer : MonoBehaviour
    {
        public TMP_Text Text;

        public ScriptableVariable Variable;

        public bool AlwaysUpdate;
        
        private void OnEnable()
        {
            Text.text = Variable.ToString();
        }

        private void Update()
        {
            if (AlwaysUpdate)
            {
                Text.text = Variable.ToString();
            }
        }
    }
}