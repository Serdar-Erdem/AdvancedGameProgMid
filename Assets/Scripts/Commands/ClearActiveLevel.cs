using UnityEngine;

namespace Commands
{
    public class ClearActiveLevel: MonoBehaviour
    {
        public void ClearActiveLevel(Transform levelHolder)
        {
            Transform childTransform = levelHolder.GetChild(0);
            if (childTransform != null)
            {
                Destroy(childTransform.gameObject);
            }
        }
    }
}
