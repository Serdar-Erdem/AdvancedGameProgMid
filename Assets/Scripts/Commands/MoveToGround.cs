using DG.Tweening;
using Enums;
using UnityEngine;

namespace Commands
{
    public class MoveToGround : MonoBehaviour
    {
        public void MoveToGround(Transform groundTransform)
        {
            float zValue = Random.Range(-(groundTransform.localScale.z / 3), (groundTransform.localScale.z / 3));

            transform.DOMove(new Vector3(groundTransform.position.x, transform.position.y, groundTransform.position.z + zValue), 2f)
                .OnComplete(() =>
                {
                    CollectableManager collectableManager = transform.GetComponent<CollectableManager>();
                    if (collectableManager != null)
                    {
                        collectableManager.ChangeAnimationOnController(CollectableAnimationTypes.Crouch);
                    }
                });
        }
    }
}
