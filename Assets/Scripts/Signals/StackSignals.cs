using Enums;
using UnityEngine;
using UnityEngine.Events;
using Extentions;


namespace Signals
{
    public class StackSignals : MonoSingleton<StackSignals>
    {
        private UnityAction<GameObject> onIncreaseStackCallback = delegate { };
        private UnityAction<int> onDecreaseStackCallback = delegate { };
        private UnityAction onStackInitCallback = delegate { };
        private UnityAction onDoubleStackCallback = delegate { };
        private UnityAction<int> onDecreaseStackRoulletteCallback = delegate { };
        private UnityAction<int> onDecreaseStackOnDroneAreaCallback = delegate { };
        private UnityAction<ColorTypes> onColorChangeCallback = delegate { };
        private UnityAction<int> onDroneAreaCallback = delegate { };
        private UnityAction<GameObject> onRebuildStackCallback = delegate { };
        private UnityAction<CollectableAnimationTypes> onAnimationChangeCallback = delegate { };

        public event UnityAction<GameObject> onIncreaseStack
        {
            add => onIncreaseStackCallback += value;
            remove => onIncreaseStackCallback -= value;
        }

        public event UnityAction<int> onDecreaseStack
        {
            add => onDecreaseStackCallback += value;
            remove => onDecreaseStackCallback -= value;
        }

        public event UnityAction onStackInit
        {
            add => onStackInitCallback += value;
            remove => onStackInitCallback -= value;
        }

        public event UnityAction<int> onDecreaseStackRoullette
        {
            add => onDecreaseStackRoulletteCallback += value;
            remove => onDecreaseStackRoulletteCallback -= value;
        }

        public event UnityAction<int> onDroneArea
        {
            add => onDroneAreaCallback += value;
            remove => onDroneAreaCallback -= value;
        }

        public event UnityAction<int> onDecreaseStackOnDroneArea
        {
            add => onDecreaseStackOnDroneAreaCallback += value;
            remove => onDecreaseStackOnDroneAreaCallback -= value;
        }

        public event UnityAction onDoubleStack
        {
            add => onDoubleStackCallback += value;
            remove => onDoubleStackCallback -= value;
        }

        public event UnityAction<ColorTypes> onColorChange
        {
            add => onColorChangeCallback += value;
            remove => onColorChangeCallback -= value;
        }

        public event UnityAction<GameObject> onRebuildStack
        {
            add => onRebuildStackCallback += value;
            remove => onRebuildStackCallback -= value;
        }

        public event UnityAction<CollectableAnimationTypes> onAnimationChange
        {
            add => onAnimationChangeCallback += value;
            remove => onAnimationChangeCallback -= value;
        }

        public void InvokeOnIncreaseStack(GameObject obj)
        {
            onIncreaseStackCallback?.Invoke(obj);
        }

        public void InvokeOnDecreaseStack(int value)
        {
            onDecreaseStackCallback?.Invoke(value);
        }

        public void InvokeOnStackInit()
        {
            onStackInitCallback?.Invoke();
        }

        public void InvokeOnDecreaseStackRoullette(int value)
        {
            onDecreaseStackRoulletteCallback?.Invoke(value);
        }

        public void InvokeOnDroneArea(int value)
        {
            onDroneAreaCallback?.Invoke(value);
        }

        public void InvokeOnDecreaseStackOnDroneArea(int value)
        {
            onDecreaseStackOnDroneAreaCallback?.Invoke(value);
        }

        public void InvokeOnDoubleStack()
        {
            onDoubleStackCallback?.Invoke();
        }

        public void InvokeOnColorChange(ColorTypes color)
        {
            onColorChangeCallback?.Invoke(color);
        }

        public void InvokeOnRebuildStack(GameObject obj)
        {
            onRebuildStackCallback?.Invoke(obj);
        }

        public void InvokeOnAnimationChange(CollectableAnimationTypes animationType)
        {
            onAnimationChangeCallback?.Invoke(animationType);
        }
    }
}
