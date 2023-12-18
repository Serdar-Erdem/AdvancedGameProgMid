using Enums;
using UnityEngine;

namespace Controllers
{
    public class CollectableAnimationController : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        public void PlayAnimation(CollectableAnimationTypes animationType)
        {
            if (animator != null)
            {
                animator.SetTrigger(animationType.ToString());
            }
            else
            {
                Debug.LogError("Animator is not assigned in CollectableAnimationController .");
            }
        }
    }
}
