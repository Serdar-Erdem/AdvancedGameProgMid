using Data.ValueObjects;
using Enums;
using UnityEngine;

namespace Commands
{
    public class GetSaveData
    {
        public int GetIntSaveData(SaveTypes saveType)
        {
            return ES3.FileExists() ? LoadIntSaveData(saveType) : 0;
        }

        private int LoadIntSaveData(SaveTypes saveType)
        {
            switch (saveType)
            {

                case SaveTypes.IdleLevel:
                    return ES3.Load<int>("IdleLevel");

                case SaveTypes.Bonus:
                    return ES3.Load<int>("Bonus");

                case SaveTypes.Level:
                    return ES3.Load<int>("Level");

                case SaveTypes.TotalColorman:
                    return ES3.Load<int>("TotalColorman");

                default:
                    return 0;
            }
        }

        public IdleLevelListData GetIdleLevelData()
        {
            return ES3.FileExists() ? LoadIdleLevelData() : new IdleLevelListData();
        }

        private IdleLevelListData LoadIdleLevelData()
        {
            return ES3.Load<IdleLevelListData>("IdleLevelListData");
        }
    }
}
