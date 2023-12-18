using UnityEngine;

namespace Commands
{
    public class LoadIdleLevelCommand : MonoBehaviour
    {
        public void LoadIdleLevel(int idleLevelID, Transform levelHolder)
        {
            string prefabPath = $"Prefabs/IdleLevelPrefabs/IdleLevel {idleLevelID}";
            GameObject idleLevelPrefab = Resources.Load<GameObject>(prefabPath);

            if (idleLevelPrefab != null)
            {
                Instantiate(idleLevelPrefab, levelHolder);
                CoreGameSignals.Instance.onGameInit?.Invoke();
            }
            else
            {
                Debug.LogError($"Prefab not found at path: {prefabPath}");
            }
        }
    }
}
