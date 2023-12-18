using TMPro;
using UnityEngine;

namespace Controllers
{
    public class LevelPanelController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelText;

        public void SetLevelText(int value)
        {
            int levelValue = value + 2;
            Debug.Log("levelValue: " + levelValue);
            levelText.text = "LEVEL " + levelValue.ToString();
        }
    }
}
