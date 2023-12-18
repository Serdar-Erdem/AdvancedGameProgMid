using Data.ValueObjects;

namespace Commands
{
    public class SaveToDatabase
    {
        public void SaveDataToDatabase(SaveData data)
        {
            SaveIntData("Bonus", data.Bonus);
            SaveIntData("Level", data.Level);
            SaveIntData("TotalColorman", data.TotalColorman);
            SaveIdleLevelListData("IdleLevelListData", data.IdleLevelListData);
        }

        private void SaveIntData(string key, int value)
        {
            ES3.Save(key, value);
        }

        private void SaveIdleLevelListData(string key, IdleLevelListData value)
        {
            ES3.Save(key, value);
        }
    }
}
