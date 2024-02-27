using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Scriptable.Variables
{
    public class TextReplacerFloat : MonoBehaviour
    {
        public TMP_Text Text;

        public FloatVariable Variable;

        public bool AlwaysUpdate;
        
        private void OnEnable()
        {
            Text.text = Variable.Value.ToString();

        }

        private void Update()
        {
            if (AlwaysUpdate)
            {
                Text.text = Variable.Value.ToString();
            }
        }
    }
}