using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scriptable.Variables
{
    public class ScriptableTimer : MonoBehaviour
    {
        public enum EventType { UpdateFloat, UpdateWhole, Start, Pause, Resume, Finish, Cancel }
        [System.Serializable]
        public struct TimerEventFloat
        {
            public EventType eventType;
            public UnityEvent<float> timerEvent;
        }

        [System.Serializable]
        public struct TimerEventString
        {
            public EventType eventType;
            public UnityEvent<string> timerEvent;
        }


        private float _dir = 1;
        private float _startTime, _targetTime;
        private bool _isRunning = false;
        private bool _isPaused = false;

        public enum Mode { CountDown, CountUp };
        
        public bool startOnEnable = true;

        public FloatReference startValue;
        public FloatReference targetTime;
        public FloatReference outputDelta;
        public FloatReference outputWhole;

        public List<TimerEventFloat> timerEventsFloat;
        public List<TimerEventString> timerEventsString;

        private void OnEnable()
        {
            if (startOnEnable)
                StartTimer();
        }

        private void Update()
        {
            if(_isRunning && !_isPaused)
            {
                //timer decrement
                var timerPrev = outputDelta.Value;
                var wholePrev = outputWhole.Value;
                var timerNew = outputDelta.Value + (Time.deltaTime * _dir);

                //clamp to start / output range and set
                outputDelta.Value = Mathf.Clamp(
                    timerNew, 
                    Mathf.Min(_startTime, _targetTime), 
                    Mathf.Max(_startTime, _targetTime)
                    );

                //round whole and set
                if (_dir <= 0)
                    outputWhole.Value = 
                        Mathf.CeilToInt(outputDelta.Value);
                if (_dir > 0)
                    outputWhole.Value = 
                        Mathf.FloorToInt(outputDelta.Value);

                //events
                SendEvent(EventType.UpdateFloat, outputDelta.Value);

                if (wholePrev != outputWhole.Value)
                {
                    SendEvent(EventType.UpdateWhole, outputWhole.Value);
                }

                //if outputdelta is target time, finish
                if (outputDelta.Value == _targetTime)
                    FinishTimer();
            }
        }

        public void StartTimer()
        {
            _isRunning = true;
            _isPaused = false;
            
            _startTime = startValue.Value;
            _targetTime = targetTime.Value;
            
            if (targetTime.Value < startValue.Value)
                _dir = -1;
            else
                _dir = 1;

            outputDelta.Value = _startTime;

            //round whole and set
            if (_dir <= 0)
                outputWhole.Value = 
                    Mathf.CeilToInt(outputDelta.Value);
            if (_dir >= 0)
                outputWhole.Value = 
                    Mathf.FloorToInt(outputDelta.Value);

            //call events
            SendEvent(EventType.Start, outputDelta.Value);
            SendEvent(EventType.UpdateFloat, outputDelta.Value);
            SendEvent(EventType.UpdateWhole, outputWhole.Value);
        }

        public void PauseTimer()
        {
            _isPaused = true;
            SendEvent(EventType.Pause, outputDelta.Value);
        }

        public void ResumeTimer()
        {
            _isPaused = false;
            SendEvent(EventType.Resume, outputDelta.Value);
        }

        public void FinishTimer()
        {
            _isRunning = false;
            SendEvent(EventType.Finish, outputDelta.Value);
        }

        public void CancelTimer()
        {
            _isRunning = false;
            _isPaused = false;
            SendEvent(EventType.Cancel, outputDelta.Value);
        }

        public void SendEvent(EventType eventType, float value)
        {
            foreach (var e in timerEventsFloat)
            {
                if (e.eventType != eventType)
                    continue;

                switch (e.eventType)
                {
                    case EventType.UpdateFloat:
                        e.timerEvent.Invoke(value);
                        break;
                    case EventType.UpdateWhole:
                        e.timerEvent.Invoke(value);
                        break;
                    case EventType.Start:
                        e.timerEvent.Invoke(value);
                        break;
                    case EventType.Pause:
                        e.timerEvent.Invoke(value);
                        break;
                    case EventType.Resume:
                        e.timerEvent.Invoke(value);
                        break;
                    case EventType.Finish:
                        e.timerEvent.Invoke(value);
                        break;
                }
            }

            foreach (var e in timerEventsString)
            {
                if (e.eventType != eventType)
                    continue;

                switch (e.eventType)
                {
                    case EventType.UpdateFloat:
                        e.timerEvent.Invoke(value.ToString());
                        break;
                    case EventType.UpdateWhole:
                        e.timerEvent.Invoke(value.ToString());
                        break;
                    case EventType.Start:
                        e.timerEvent.Invoke(value.ToString());
                        break;
                    case EventType.Pause:
                        e.timerEvent.Invoke(value.ToString());
                        break;
                    case EventType.Resume:
                        e.timerEvent.Invoke(value.ToString());
                        break;
                    case EventType.Finish:
                        e.timerEvent.Invoke(value.ToString());
                        break;
                }
            }
        }

    }
}
