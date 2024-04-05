using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Scriptable.Variables
{
    public class TextFloatToTimeSpan : MonoBehaviour
    {
        public TMP_Text Label;

        public FloatReference Variable;
        public enum DisplayRange { Seconds, Minutes, Hours, Days };

        public DisplayRange displayRange;
        public bool DisplayMilliseconds = false;

        //replace {t} with text
        public string Text = "{t}";

        public bool AlwaysUpdate = true;

        private void OnEnable()
        {
            Label.text = FormatFloat();
        }

        private void Update()
        {
            if (AlwaysUpdate)
            {
                Label.text = FormatFloat();
            }
        }

        public string FormatFloat()
        {
            var from = new DateTime();
            var to = from.AddSeconds(Variable.Value);
            var timeSpan = to - from;

            var timeText = "";

            switch(displayRange)
            {
                case DisplayRange.Seconds:
                    timeText = ((int)timeSpan.TotalSeconds).ToString("D2");
                    break;
                case DisplayRange.Minutes:
                    timeText = ((int)timeSpan.TotalMinutes).ToString("D2") + ":" +
                        ((int)timeSpan.Seconds).ToString("D2");
                    break;
                case DisplayRange.Hours:
                    timeText = ((int)timeSpan.TotalHours).ToString() + ":" +
                        ((int)timeSpan.Minutes).ToString("D2") + ":" +
                        ((int)timeSpan.Seconds).ToString("D2");
                    break;
                case DisplayRange.Days:
                    timeText = ((int)timeSpan.TotalDays).ToString("D2") + ":" +
                        ((int)timeSpan.Hours).ToString("D2") + ":" +
                        ((int)timeSpan.Minutes).ToString("D2") + ":" +
                        ((int)timeSpan.Seconds).ToString("D2");
                    break;
            }

            if(DisplayMilliseconds)
                timeText = timeText + "." + ((int)timeSpan.Milliseconds).ToString("D2").Substring(0,2);

            return Text.Replace("{t}", timeText);
        }
    }
}