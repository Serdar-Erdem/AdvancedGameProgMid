using Keys;
using UnityEngine.Events;
using Extentions;


namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        private UnityAction<RunnerHorizontalInputParams> onInputDraggedCallback = delegate { };
        private UnityAction<IdleInputParams> onIdleInputTakenCallback = delegate { };
        private UnityAction<bool> onSidewaysEnableCallback = delegate { };

        public event UnityAction<RunnerHorizontalInputParams> onInputDragged
        {
            add => onInputDraggedCallback += value;
            remove => onInputDraggedCallback -= value;
        }

        public event UnityAction<IdleInputParams> onIdleInputTaken
        {
            add => onIdleInputTakenCallback += value;
            remove => onIdleInputTakenCallback -= value;
        }

        public event UnityAction<bool> onSidewaysEnable
        {
            add => onSidewaysEnableCallback += value;
            remove => onSidewaysEnableCallback -= value;
        }

        public void InvokeOnInputDragged(RunnerHorizontalInputParams inputParams)
        {
            onInputDraggedCallback?.Invoke(inputParams);
        }

        public void InvokeOnIdleInputTaken(IdleInputParams inputParams)
        {
            onIdleInputTakenCallback?.Invoke(inputParams);
        }

        public void InvokeOnSidewaysEnable(bool enable)
        {
            onSidewaysEnableCallback?.Invoke(enable);
        }
    }
}
