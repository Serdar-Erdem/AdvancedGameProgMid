using Signals;
using UnityEngine;

namespace Commands
{
    public class LoadLevel : MonoBehaviour
    {
        public void LoadLevel(int levelID, Transform levelHolder)
        {
            string prefabPath = $"Prefabs/LevelPrefabs/level {levelID}";
            GameObject levelPrefab = Resources.Load<GameObject>(prefabPath);

            if (levelPrefab != null)
            {
                Instantiate(levelPrefab, levelHolder);
                CoreGameSignals.Instance.onGameInitLevel?.Invoke();
            }
            else
            {
                Debug.LogError($"Prefab not found at path: {prefabPath}");
            }
        }
    }
}
