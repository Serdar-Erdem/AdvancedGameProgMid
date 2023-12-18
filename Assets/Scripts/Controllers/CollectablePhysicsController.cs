using Enums;
using UnityEngine;

namespace Controllers
{
    public class CollectablePhysicsController : MonoBehaviour
    {
        [SerializeField] private CollectableManager manager;

        private void OnTriggerEnter(Collider other)
        {
            if (CompareTag("Collected"))
            {
                HandleCollectedTrigger(other);
            }

            if (other.CompareTag("Roulette"))
            {
                manager.DecreaseStackOnIdle();
            }

            if (other.CompareTag("DroneAreaPhysics"))
            {
                HandleDroneAreaPhysicsTrigger(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (CompareTag("Collected"))
            {
                if (other.CompareTag("TurretAreaGround"))
                {
                    gameObject.tag = "Collected";
                    manager.ChangeAnimationOnController(CollectableAnimationTypes.Run);
                }

                if (other.CompareTag("DroneAreaPhysics"))
                {
                    manager.ChangeAnimationOnController(CollectableAnimationTypes.Run);
                }
            }
        }

        private void HandleCollectedTrigger(Collider other)
        {
            if (other.CompareTag("Collectable"))
            {
                HandleCollectableCollision(other);
            }

            if (other.CompareTag("Obstacle"))
            {
                Destroy(other.transform.parent.gameObject);
                manager.DecreaseStack();
            }

            if (other.CompareTag("TurretAreaGround"))
            {
                HandleTurretAreaCollision(other);
            }

            if (other.CompareTag("ColoredGround"))
            {
                HandleColoredGroundCollision(other);
            }
        }

        private void HandleCollectableCollision(Collider other)
        {
            CollectableManager otherCollectableManager = other.transform.parent.GetComponent<CollectableManager>();

            if (otherCollectableManager.CurrentColorType == manager.CurrentColorType)
            {
                other.transform.tag = "Collected";
                otherCollectableManager.IncreaseStack();
            }
            else
            {
                Destroy(other.transform.parent.gameObject);
                manager.DecreaseStack();
            }
        }

        private void HandleTurretAreaCollision(Collider other)
        {
            TurretAreaController turretAreaController = other.GetComponent<TurretAreaController>();
            TurretAreaManager turretAreaManager = other.GetComponentInParent<TurretAreaManager>();

            manager.ChangeAnimationOnController(CollectableAnimationTypes.CrouchRun);

            if (manager.CurrentColorType != turretAreaController.ColorType)
            {
                turretAreaManager.AddTargetToList(transform.parent.gameObject);
            }
        }

        private void HandleColoredGroundCollision(Collider other)
        {
            manager.DeListStack();
            manager.SetCollectablePositionOnDroneArea(other.gameObject.transform);
            manager.CheckColorType(other.GetComponent<DroneColorAreaManager>());
            tag = "Untagged";
        }

        private void HandleDroneAreaPhysicsTrigger(Collider other)
        {
            tag = "Collected";

            if (manager.MatchType == MatchType.Match)
            {
                manager.ChangeOutlineState(true);
                manager.IncreaseStack();
            }
            else
            {
                manager.DelayedDeath(true);
            }
        }
    }
}
