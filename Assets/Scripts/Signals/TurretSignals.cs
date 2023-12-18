using UnityEngine;
using UnityEngine.Events;
using Extentions;


namespace Signals
{
    public class TurretSignals : MonoSingleton<TurretSignals>
    {
        private UnityAction onResetListCallback = delegate { };

        public event UnityAction onResetList
        {
            add => onResetListCallback += value;
            remove => onResetListCallback -= value;
        }

        public void InvokeOnResetList()
        {
            onResetListCallback?.Invoke();
        }
    }
}
