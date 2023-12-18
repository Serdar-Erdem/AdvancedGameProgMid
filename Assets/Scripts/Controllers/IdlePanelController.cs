using TMPro;
using UnityEngine;

namespace Controllers
{
    public class IdlePanelController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerScoreText;

        public void SetScoreText(int value)
        {
            playerScoreText.text = value.ToString();
        }
    }
}
