using System;
using Enums;
using UnityEngine;
using UnityEngine.Events;
using Extentions;


namespace Signals
{
    public class PlayerSignal : MonoSingleton<PlayerSignal>
    {
        private UnityAction<float> onChangeVerticalSpeedCallback = delegate { };
        private UnityAction onIncreaseScaleCallback = delegate { };

        public event UnityAction<float> onChangeVerticalSpeed
        {
            add => onChangeVerticalSpeedCallback += value;
            remove => onChangeVerticalSpeedCallback -= value;
        }

        public event UnityAction onIncreaseScale
        {
            add => onIncreaseScaleCallback += value;
            remove => onIncreaseScaleCallback -= value;
        }

        public void InvokeOnChangeVerticalSpeed(float speed)
        {
            onChangeVerticalSpeedCallback?.Invoke(speed);
        }

        public void InvokeOnIncreaseScale()
        {
            onIncreaseScaleCallback?.Invoke();
        }
    }
}
