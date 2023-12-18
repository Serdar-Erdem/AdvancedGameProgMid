using Cinemachine;
using UnityEngine;

namespace Managers.Abstracts.Concretes
{
    public class StartOfIdleState : CameraBaseState
    {
        public override async void EnterState(CameraStateManager camManager, CinemachineVirtualCamera virtualCamera, Transform followTarget)
        {
            await Task.Delay(1000);
        }

        public override void UpdateState(CameraStateManager camManager)
        {
        }

        public override void OnCollisionEnter(CameraStateManager camManager)
        {
        }
    }
}
