using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Scriptable.Variables
{
    public class TextReplacer : MonoBehaviour
    {
        public TMP_Text Text;

        public StringVariable Variable;

        public bool AlwaysUpdate;
        
        private void OnEnable()
        {
            Text.text = Variable.Value;
        }

        private void Update()
        {
            if (AlwaysUpdate)
            {
                Text.text = Variable.Value;
            }
        }
    }
}