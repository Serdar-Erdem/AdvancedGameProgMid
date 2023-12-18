using Cinemachine;
using UnityEngine;
using Signals;
using Enums;


namespace Managers.Abstracts.Concretes
{
    public class MyStartState : CameraBaseState
    {
        public override async void EnterState(CameraStateManager camManager, CinemachineVirtualCamera virtualCamera, Transform followTarget)
        {
            Debug.Log("MyStartState EnterState is working");

            await Task.Delay(1000);

            virtualCamera.Follow = camManager.initPosition;
            CameraSignals.Instance.onChangeCameraStates?.Invoke(CameraStates.Runner);
        }

        public override void UpdateState(CameraStateManager camManager)
        {
        }

        public override void OnCollisionEnter(CameraStateManager camManager)
        {
        }
    }
}
