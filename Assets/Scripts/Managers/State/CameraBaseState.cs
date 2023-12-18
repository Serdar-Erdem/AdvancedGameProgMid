using UnityEngine;
using Cinemachine;

namespace Managers.Abstracts
{
    public abstract class CameraBaseState
    {
        protected CameraStateManager _camManager;
        protected CinemachineVirtualCamera virtualCamera;
        protected Transform followTarget;

        public void EnterState(CameraStateManager camManager, CinemachineVirtualCamera camera, Transform target)
        {
            _camManager = camManager;
            virtualCamera = camera;
            followTarget = target;
            EnterState();
        }

        public abstract void UpdateState();
        public abstract void OnCollisionEnter();

        protected virtual void EnterState() { }
    }
}
