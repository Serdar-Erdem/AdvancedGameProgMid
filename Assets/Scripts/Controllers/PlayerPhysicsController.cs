using System;
using Enums;
using UnityEngine;
using Managers;
using Signals;

namespace Controllers
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private GameObject playerObj;

        private bool _enteredRoullette;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("DroneArea"))
                playerManager.CloseScoreText(true);
            else if (other.CompareTag("DroneAreaPhysics"))
            {
                playerManager.RepositionPlayerForDrone(other.gameObject);
                playerManager.EnableVerticalMovement();
            }
            else if (other.CompareTag("Market"))
                playerManager.ChangeAnimation(PlayerAnimationTypes.Throw);
            else if (other.CompareTag("Portal"))
                StackSignals.Instance.onColorChange?.Invoke(other.GetComponent<ColorController>().ColorType);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("DroneArea"))
                playerManager.StopVerticalMovement();
            else if (other.CompareTag("Roulette") && !_enteredRoullette)
            {
                ScoreSignals.Instance.onAddLevelTototalScore?.Invoke();
                playerManager.StopAllMovement();
                playerManager.ActivateMesh();
                _enteredRoullette = true;
            }
        }
    }
}
