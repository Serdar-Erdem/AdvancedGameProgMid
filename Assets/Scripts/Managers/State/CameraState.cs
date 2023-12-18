using System;
using Enums;
using UnityEngine;
using DG.Tweening;
using Signals;

namespace Managers
{
    public class CameraState : MonoBehaviour
    {
        [SerializeField] private Transform initPosition;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        private Vector3 initialPosition;
        private Transform playerManager;

        private CameraBaseState currentState;
        private StartState startState = new StartState();
        private RunnerState runnerState = new RunnerState();
        private IdleState idleState = new IdleState();
        private StartOfIdleState startOfIdleState = new StartOfIdleState();


        private void Awake()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            GetInitialPosition();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void Start()
        {
            OnCameraInitialization();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += OnCameraInitialization;
            CameraSignals.Instance.onChangeCameraStates += OnChangeCameraState;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= OnCameraInitialization;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void Update()
        {
        }

        private void GetInitialPosition()
        {
            initialPosition = transform.localPosition;
        }

        private void OnMoveToInitialPosition()
        {
            transform.localPosition = initialPosition;
        }

        private void OnCameraInitialization()
        {
            ChangeState(startState);
        }

        private void OnChangeCameraState(CameraStates _currentState)
        {
            switch (_currentState)
            {
                case CameraStates.StartState:
                    ChangeState(startState);
                    break;

                case CameraStates.Runner:
                    ChangeState(runnerState);
                    break;

                case CameraStates.Idle:
                    ChangeState(idleState);
                    break;

                case CameraStates.StartOfIdle:
                    ChangeState(startOfIdleState);
                    break;
            }
        }

        private void ChangeState(CameraBaseState _cameraState)
        {
            playerManager = GameObject.FindWithTag("Player").transform;
            currentState = _cameraState;
            currentState.EnterState(this, virtualCamera, playerManager);
        }

        private void OnReset()
        {
            virtualCamera.Follow = null;
            virtualCamera.LookAt = null;
            OnMoveToInitialPosition();
        }
    }
}
