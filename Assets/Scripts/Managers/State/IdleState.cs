using Cinemachine;
using UnityEngine;

namespace Managers.Abstracts.Concretes
{
    public class IdleState : CameraBaseState
    {
        public override void EnterState(CameraStateManager camManager, CinemachineVirtualCamera virtualCamera, Transform followTarget)
        {
        }

        public override void UpdateState(CameraStateManager camManager)
        {
        }

        public override void OnCollisionEnter(CameraStateManager camManager)
        {
        }
    }
}
