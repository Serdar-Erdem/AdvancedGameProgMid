using System;
using UnityEngine;
using Enums;
using Data.ValueObjects;
using UnityEngine.Events;
using Extentions;
using Object = System.Object;

namespace Signals
{
    public class SaveSignals : MonoSingleton<SaveSignals>
    {
        private UnityAction<SaveTypes, int> onChangeSaveDataCallback = delegate { };
        private UnityAction<IdleLevelListData> onChangeIdleLevelListDataCallback = delegate { };
        private UnityAction onApplicationPauseCallback = delegate { };
        private Func<SaveTypes, int> onGetIntSaveDataCallback = delegate { return 0; };
        private Func<IdleLevelListData> onGetIdleSaveDataCallback = delegate { return new IdleLevelListData(); };
        private UnityAction<SaveData> onSendDataToManagersCallback = delegate { };

        public event UnityAction<SaveTypes, int> onChangeSaveData
        {
            add => onChangeSaveDataCallback += value;
            remove => onChangeSaveDataCallback -= value;
        }

        public event UnityAction<IdleLevelListData> onChangeIdleLevelListData
        {
            add => onChangeIdleLevelListDataCallback += value;
            remove => onChangeIdleLevelListDataCallback -= value;
        }

        public event UnityAction onApplicationPause
        {
            add => onApplicationPauseCallback += value;
            remove => onApplicationPauseCallback -= value;
        }

        public event Func<SaveTypes, int> onGetIntSaveData
        {
            add => onGetIntSaveDataCallback += value;
            remove => onGetIntSaveDataCallback -= value;
        }

        public event Func<IdleLevelListData> onGetIdleSaveData
        {
            add => onGetIdleSaveDataCallback += value;
            remove => onGetIdleSaveDataCallback -= value;
        }

        public event UnityAction<SaveData> onSendDataToManagers
        {
            add => onSendDataToManagersCallback += value;
            remove => onSendDataToManagersCallback -= value;
        }

        public void InvokeOnChangeSaveData(SaveTypes saveType, int data)
        {
            onChangeSaveDataCallback?.Invoke(saveType, data);
        }

        public void InvokeOnChangeIdleLevelListData(IdleLevelListData data)
        {
            onChangeIdleLevelListDataCallback?.Invoke(data);
        }

        public void InvokeOnApplicationPause()
        {
            onApplicationPauseCallback?.Invoke();
        }

        public int InvokeOnGetIntSaveData(SaveTypes saveType)
        {
            return onGetIntSaveDataCallback?.Invoke(saveType) ?? 0;
        }

        public IdleLevelListData InvokeOnGetIdleSaveData()
        {
            return onGetIdleSaveDataCallback?.Invoke() ?? new IdleLevelListData();
        }

        public void InvokeOnSendDataToManagers(SaveData data)
        {
            onSendDataToManagersCallback?.Invoke(data);
        }
    }
}
