using DG.Tweening;
using UnityEngine;
using TMPro;

namespace Controllers
{
    public class PlayerTextController : MonoBehaviour
    {
        [SerializeField] private TextMeshPro playerScoreText;

        public void UpdatePlayerScore(float totalScore)
        {
            playerScoreText.text = totalScore.ToString();
        }

        public void CloseScoreText(bool isClosed)
        {
            transform.DOScale(isClosed ? Vector3.zero : Vector3.one, 0.1f);
        }
    }
}
