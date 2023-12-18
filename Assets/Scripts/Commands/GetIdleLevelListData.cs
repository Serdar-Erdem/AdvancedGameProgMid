using Data.ValueObjects;

using Data.UnityObjects;
using UnityEngine;

namespace Commands
{
    public class GetIdleLevelListData
    {
        private IdleLevelListData GetIdleLevelListData() => Resources.Load<CD_IdleLevel>("Data/CD_IdleLevel")?.IdleLevelListData;

        public void OnInitializeSyncData(SaveData _data)
        {
            if (ES3.FileExists())
            {
                _data.IdleLevel = ES3.Load<int>("IdleLevel", 0);
                _data.TotalColorman = ES3.Load<int>("TotalColorman", 0);
                _data.Level = ES3.Load<int>("Level", 0);
                _data.Bonus = ES3.Load<int>("Bonus", 0);
                _data.IdleLevelListData = ES3.Load<IdleLevelListData>("IdleLevelListData");

            }
            else
            {
                InitializeDefaultValues(_data);
            }
        }

        private void InitializeDefaultValues(SaveData _data)
        {
            ES3.Save("IdleLevel", 0);
            ES3.Save("TotalColorman", 0);
            ES3.Save("Level", 0);
            ES3.Save("Bonus", 0);
            ES3.Save("IdleLevelListData", GetIdleLevelListData());
            OnInitializeSyncData(_data);
        }
    }
}
