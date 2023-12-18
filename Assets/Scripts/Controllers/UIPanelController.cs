using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Controllers
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> panels;

        public void TogglePanel(UIPanelTypes panelParam, bool state)
        {
            panels[(int)panelParam].SetActive(state);
        }

        public void OpenPanel(UIPanelTypes panelParam)
        {
            TogglePanel(panelParam, true);
        }

        public void ClosePanel(UIPanelTypes panelParam)
        {
            TogglePanel(panelParam, false);
        }
    }
}
