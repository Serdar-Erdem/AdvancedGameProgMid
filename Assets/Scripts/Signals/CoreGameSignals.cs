using System;
using UnityEngine;
using UnityEngine.Events;
using Extentions;
using Enums

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        private UnityAction<GameStates> onChangeGameStateCallback = delegate { };
        private UnityAction<GameStates> onGetGameStateCallback = delegate { };
        private UnityAction onGameInitCallback = delegate { };
        private UnityAction onGameInitLevelCallback = delegate { };
        private UnityAction onLevelInitializeCallback = delegate { };
        private UnityAction onLevelIdleInitializeCallback = delegate { };
        private UnityAction onLevelFailedCallback = delegate { };
        private UnityAction onLevelSuccessfulCallback = delegate { };
        private UnityAction onResetCallback = delegate { };
        private UnityAction onStageAreaReachedCallback = delegate { };
        private UnityAction onStageSuccessfulCallback = delegate { };
        private UnityAction onNextLevelCallback = delegate { };
        private UnityAction onRestartLevelCallback = delegate { };
        private UnityAction onClearActiveIdleLevelCallback = delegate { };
        private UnityAction onClearActiveLevelCallback = delegate { };
        private UnityAction onPlayCallback = delegate { };
        private Func<int> onGetLevelIDCallback = delegate { return 0; };
        private Func<int> onGetIdleLevelIDCallback = delegate { return 0; };

        public event UnityAction<GameStates> onChangeGameState
        {
            add => onChangeGameStateCallback += value;
            remove => onChangeGameStateCallback -= value;
        }

        public event UnityAction<GameStates> onGetGameState
        {
            add => onGetGameStateCallback += value;
            remove => onGetGameStateCallback -= value;
        }

        public event UnityAction onGameInit
        {
            add => onGameInitCallback += value;
            remove => onGameInitCallback -= value;
        }

        public event UnityAction onGameInitLevel
        {
            add => onGameInitLevelCallback += value;
            remove => onGameInitLevelCallback -= value;
        }

        public event UnityAction onLevelInitialize
        {
            add => onLevelInitializeCallback += value;
            remove => onLevelInitializeCallback -= value;
        }

        public event UnityAction onLevelIdleInitialize
        {
            add => onLevelIdleInitializeCallback += value;
            remove => onLevelIdleInitializeCallback -= value;
        }

        public event UnityAction onClearActiveIdleLevel
        {
            add => onClearActiveIdleLevelCallback += value;
            remove => onClearActiveIdleLevelCallback -= value;
        }

        public event UnityAction onClearActiveLevel
        {
            add => onClearActiveLevelCallback += value;
            remove => onClearActiveLevelCallback -= value;
        }

        public event UnityAction onLevelFailed
        {
            add => onLevelFailedCallback += value;
            remove => onLevelFailedCallback -= value;
        }

        public event UnityAction onLevelSuccessful
        {
            add => onLevelSuccessfulCallback += value;
            remove => onLevelSuccessfulCallback -= value;
        }

        public event UnityAction onNextLevel
        {
            add => onNextLevelCallback += value;
            remove => onNextLevelCallback -= value;
        }

        public event UnityAction onRestartLevel
        {
            add => onRestartLevelCallback += value;
            remove => onRestartLevelCallback -= value;
        }

        public event UnityAction onPlay
        {
            add => onPlayCallback += value;
            remove => onPlayCallback -= value;
        }

        public event UnityAction onReset
        {
            add => onResetCallback += value;
            remove => onResetCallback -= value;
        }

        public event UnityAction onStageAreaReached
        {
            add => onStageAreaReachedCallback += value;
            remove => onStageAreaReachedCallback -= value;
        }

        public event UnityAction onStageSuccessful
        {
            add => onStageSuccessfulCallback += value;
            remove => onStageSuccessfulCallback -= value;
        }

        public event Func<int> onGetLevelID
        {
            add => onGetLevelIDCallback += value;
            remove => onGetLevelIDCallback -= value;
        }

        public event Func<int> onGetIdleLevelID
        {
            add => onGetIdleLevelIDCallback += value;
            remove => onGetIdleLevelIDCallback -= value;
        }

        protected override void Awake()
        {
            base.Awake();
        }

        public void InvokeOnChangeGameState(GameStates gameState)
        {
            onChangeGameStateCallback?.Invoke(gameState);
        }

        public void InvokeOnGetGameState(GameStates gameState)
        {
            onGetGameStateCallback?.Invoke(gameState);
        }

        public void InvokeOnGameInit()
        {
            onGameInitCallback?.Invoke();
        }

        public void InvokeOnGameInitLevel()
        {
            onGameInitLevelCallback?.Invoke();
        }

        public void InvokeOnLevelInitialize()
        {
            onLevelInitializeCallback?.Invoke();
        }

        public void InvokeOnLevelIdleInitialize()
        {
            onLevelIdleInitializeCallback?.Invoke();
        }

        public void InvokeOnClearActiveIdleLevel()
        {
            onClearActiveIdleLevelCallback?.Invoke();
        }

        public void InvokeOnClearActiveLevel()
        {
            onClearActiveLevelCallback?.Invoke();


