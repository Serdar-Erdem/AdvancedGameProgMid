using System;
using UnityEngine;
using Data.ValueObjects;
using UnityEngine.Events;
using Extentions;
using Enums;
using Object = System.Object;

namespace Signals
{
    public class CameraSignals : MonoSingleton<CameraSignals>
    {
        private UnityAction<CameraStates> onChangeCameraStatesCallback = delegate { };

        public event UnityAction<CameraStates> onChangeCameraStates
        {
            add => onChangeCameraStatesCallback += value;
            remove => onChangeCameraStatesCallback -= value;
        }

        public void InvokeOnChangeCameraStates(CameraStates cameraState)
        {
            onChangeCameraStatesCallback?.Invoke(cameraState);
        }
    }
}
