using DG.Tweening;
using UnityEngine;

namespace Controllers
{
    public class PlayerMeshController : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer meshRenderer;

        public void IncreasePlayerSize()
        {
            if (CanIncreaseSize())
            {
                transform.parent.DOScale(transform.parent.localScale + Vector3.one * 0.2f, 1f);
            }
        }

        public void ActivateMesh()
        {
            meshRenderer.enabled = true;
        }

        private bool CanIncreaseSize()
        {
            return transform.parent.localScale.x <= 3;
        }
    }
}
