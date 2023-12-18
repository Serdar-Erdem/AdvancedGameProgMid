using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Data.ValueObjects;
using Enums;
using DG.Tweening;
using Managers;

namespace Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private Transform playerMesh;

        private PlayerMovementData _movementData;
        private bool _isReadyToMove, _isReadyToPlay;
        private float _inputValue, _inputValueX, _inputValueZ;
        private Vector2 _clampValues;
        private bool _sidewaysEnable;

        public GameStates CurrentGameState = GameStates.Runner;

        public void SetMovementData(PlayerMovementData playerMovementData) => _movementData = playerMovementData;

        public void EnableMovement()
        {
            _isReadyToMove = true;
            _isReadyToPlay = true;
        }

        public void DisableMovement() => _isReadyToMove = false;

        public void UpdateRunnerInputValue(RunnerHorizontalInputParams inputParam)
        {
            _inputValue = inputParam.XValue;
            _clampValues = inputParam.ClampValues;
        }

        public void UpdateIdleInputValue(IdleInputParams inputParam)
        {
            _inputValueX = inputParam.IdleXValue;
            _inputValueZ = inputParam.IdleZValue;
        }

        public void IsReadyToPlay(bool state) => _isReadyToPlay = state;

        private void FixedUpdate()
        {
            if (_isReadyToPlay && _isReadyToMove && _sidewaysEnable)
                Move();
            else
                StopSideways();
        }

        private void Move()
        {
            if (CurrentGameState == GameStates.Runner) RunnerMove();
            if (CurrentGameState == GameStates.Idle) IdleMove();
        }

        private void IdleMove()
        {
            var velocity = rigidbody.velocity;
            velocity = new Vector3(_inputValueX * _movementData.ForwardSpeed, velocity.y, _inputValueZ * _movementData.ForwardSpeed);
            rigidbody.velocity = velocity;

            if (_inputValueX != 0 || _inputValueZ != 0)
            {
                Quaternion toRotation = Quaternion.LookRotation(new Vector3(_inputValueX * _movementData.ForwardSpeed, velocity.y, _inputValueZ * _movementData.ForwardSpeed));
                playerManager.ChangeAnimation(PlayerAnimationTypes.Run);
                playerMesh.rotation = toRotation;
            }
            else
            {
                playerManager.ChangeAnimation(PlayerAnimationTypes.Idle);
            }
        }

        private void RunnerMove()
        {
            var velocity = rigidbody.velocity;
            velocity = new Vector3(_inputValue * _movementData.SidewaysSpeed, velocity.y, _movementData.ForwardSpeed);
            rigidbody.velocity = velocity;

            Vector3 position = new Vector3(Mathf.Clamp(rigidbody.position.x, _clampValues.x, _clampValues.y), rigidbody.position.y, rigidbody.position.z);
            rigidbody.position = position;
        }

        private void StopSideways()
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, _movementData.ForwardSpeed);
            rigidbody.angularVelocity = Vector3.zero;
        }

        public void Stop()
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

        public void OnReset()
        {
            Stop();
            _isReadyToPlay = false;
            _isReadyToMove = false;
        }

        public void SetSidewayEnabled(bool isSidewayEnabled) => _sidewaysEnable = isSidewayEnabled;

        public void ChangeVerticalMovement(float verticalSpeed) => _movementData.ForwardSpeed = verticalSpeed;

        public async void RepositionPlayerForDrone(GameObject other)
        {
            await Task.Delay(200);
            transform.DOMove(new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z + other.transform.localScale.z * 2), 2f).OnComplete(() => playerManager.CloseScoreText(false));
        }

        public void DisableStopVerticalMovement()
        {
            _movementData.ForwardSpeed = 0;
            rigidbody.angularVelocity = Vector3.zero;
        }

        public void StopAllMovement() => _isReadyToPlay = false;

        public void EnableIdleMovement()
        {
            _isReadyToPlay = true;
            _sidewaysEnable = true;
        }
    }
}
