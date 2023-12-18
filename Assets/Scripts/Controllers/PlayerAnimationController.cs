using Enums;
using UnityEngine;

namespace Controllers
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void ChangeAnimation(PlayerAnimationTypes animationType)
        {
            if (animationType == PlayerAnimationTypes.Run)
            {
                PlayRunningAnimation();
            }
            else
            {
                SetAnimationTrigger(animationType);
            }
        }

        private void PlayRunningAnimation()
        {
            animator.Play("Running");
        }

        private void SetAnimationTrigger(PlayerAnimationTypes animationType)
        {
            animator.SetTrigger(animationType.ToString());
        }
    }
}
