using Enums;
using UnityEngine;
using UnityEngine.Events;
using Extentions;


namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        private UnityAction<UIPanelTypes> onOpenPanelCallback = delegate { };
        private UnityAction<UIPanelTypes> onClosePanelCallback = delegate { };

        public event UnityAction<UIPanelTypes> onOpenPanel
        {
            add => onOpenPanelCallback += value;
            remove => onOpenPanelCallback -= value;
        }

        public event UnityAction<UIPanelTypes> onClosePanel
        {
            add => onClosePanelCallback += value;
            remove => onClosePanelCallback -= value;
        }

        public void InvokeOnOpenPanel(UIPanelTypes panelType)
        {
            onOpenPanelCallback?.Invoke(panelType);
        }

        public void InvokeOnClosePanel(UIPanelTypes panelType)
        {
            onClosePanelCallback?.Invoke(panelType);
        }
    }
}
