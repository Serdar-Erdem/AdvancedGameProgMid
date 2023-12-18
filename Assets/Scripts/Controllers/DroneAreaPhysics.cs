using Enums;
using UnityEngine;

namespace Controllers
{
    public class DroneAreaPhysics : MonoBehaviour
    {
        [SerializeField] private DroneColorAreaManager droneColorAreaManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Collected"))
            {
                CheckCollectedColorType(other.GetComponentInParent<CollectableManager>());
            }
        }

        private void CheckCollectedColorType(CollectableManager collectableManager)
        {
            if (collectableManager.CurrentColorType == droneColorAreaManager.CurrentColorType)
            {
                droneColorAreaManager.matchType = MatchType.Match;
            }
        }
    }
}
