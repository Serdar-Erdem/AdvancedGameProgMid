using System;
using UnityEngine;
using UnityEngine.Events;
using Extentions;


namespace Signals
{
    public class DroneAreaSignals : MonoSingleton<DroneAreaSignals>
    {
        private UnityAction onDroneCheckStartedCallback = delegate { };
        private UnityAction onDroneCheckCompletedCallback = delegate { };

        public event UnityAction onDroneCheckStarted
        {
            add => onDroneCheckStartedCallback += value;
            remove => onDroneCheckStartedCallback -= value;
        }

        public event UnityAction onDroneCheckCompleted
        {
            add => onDroneCheckCompletedCallback += value;
            remove => onDroneCheckCompletedCallback -= value;
        }

        public void InvokeOnDroneCheckStarted()
        {
            onDroneCheckStartedCallback?.Invoke();
        }

        public void InvokeOnDroneCheckCompleted()
        {
            onDroneCheckCompletedCallback?.Invoke();
        }
    }
}
