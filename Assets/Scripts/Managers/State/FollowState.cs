using Cinemachine;
using UnityEngine;

namespace Managers.Abstracts.Concretes
{
    public class FollowState : CameraBaseState
    {
        public override void EnterState(CameraStateManager camManager, CinemachineVirtualCamera virtualCamera, Transform followTarget)
        {
            camManager.StartCoroutine(ChangeFollowTargetAsync(virtualCamera, followTarget));
        }

        private System.Collections.IEnumerator ChangeFollowTargetAsync(CinemachineVirtualCamera virtualCamera, Transform followTarget)
        {
            yield return new WaitForSeconds(1f);
            virtualCamera.Follow = followTarget;
        }

        public override void UpdateState(CameraStateManager camManager)
        {
        }

        public override void OnCollisionEnter(CameraStateManager camManager)
        {
        }
    }
}
