using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class TurretAreaController : MonoBehaviour
    {
        public ColorTypes ColorType;
        public Vector3 CurrentTargetPos;

        [SerializeField] private int turretSearchPeriod;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private TurretAreaManager turretAreaManager;
        [SerializeField] private Transform turret;


        private void Awake()
        {
            ChangeInitColor();
        }

        private void ChangeInitColor()
        {
            var colorHandler = Addressables.LoadAssetAsync<Material>($"CoreColor/Color_{ColorType}");
            meshRenderer.material = (colorHandler.WaitForCompletion() != null) ? colorHandler.Result : null;
        }

        private void Start()
        {
            InvokeRepeating(nameof(GetRandomSearchPoint), 0f, turretSearchPeriod);
        }

        private void GetRandomSearchPoint()
        {
            CurrentTargetPos = new Vector3(
                Random.Range(transform.position.x - (transform.localScale.x / 2), transform.position.x + (transform.localScale.x / 2)),
                transform.position.y,
                Random.Range(transform.position.z - (transform.localScale.z / 2), transform.position.z + (transform.localScale.z / 2))
            );
        }

        public void StartSearchRotation()
        {
            RotateToTargetPos();
        }

        public void RotateToTargetPos()
        {
            Vector3 relativePos = CurrentTargetPos - turret.position;
            Quaternion finalRotate = Quaternion.LookRotation(relativePos);
            turret.rotation = Quaternion.Lerp(turret.rotation, finalRotate, 0.1f);
        }

        public void StartWarnedRotation(GameObject target)
        {
            CurrentTargetPos = target.transform.position;
            RotateToTargetPos();
        }

        public void FireTurretAnimation()
        {
        }
    }
}
