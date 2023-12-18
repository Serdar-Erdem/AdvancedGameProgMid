using UnityEngine;

namespace Controllers
{
    public class TurretAreaPhysicController : MonoBehaviour
    {
        [SerializeField] private TurretAreaManager turretAreaManager;

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Collected"))
            {
                turretAreaManager.ResetTurretArea();
            }
        }
    }
}
