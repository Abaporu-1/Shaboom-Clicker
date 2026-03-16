using UnityEngine;
using System.IO;

public class SaveThings
{
    private static SaveData _saveData = new SaveData();
    [System.Serializable]
    public struct SaveData
    {
        public AuraSaveData auraData;
        public BuildsData buildsData;
        public UpgradesData upgradesData;
    }
    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/save" + ".save";
        return saveFile;
    }
    public static void Save()
    {
        HandleSaveData();
        Debug.Log("SAVE");
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));
        Debug.Log("SaveFile created");
    }
    public static void Load()
    {
        if (File.Exists(SaveFileName()))
        {
            string saveContent = File.ReadAllText(SaveFileName());
            Debug.Log("READ SAVEFILE");
            _saveData = JsonUtility.FromJson<SaveData>(saveContent);
            Debug.Log("LOAD");
            HandleLoadData();
        }
    }
    private static void HandleSaveData()
    {
        GameManager.Instance.Save(ref _saveData.auraData, ref _saveData.buildsData);
        UpgradeManager.Instance.Save(ref _saveData.upgradesData);
    }
    private static void HandleLoadData()
    {
        GameManager.Instance.Load(_saveData.auraData, _saveData.buildsData);
        UpgradeManager.Instance.Load(_saveData.upgradesData);
    }
}
[System.Serializable]
public struct AuraSaveData
{
    public string totalCurrency;
}
[System.Serializable]
public struct BuildsData
{
    public int[] level;
    public int[] multiplier;
    public int clickMultiplier;
}
[System.Serializable]
public struct UpgradesData
{
    public bool[] mewingHaveUpgrade;
    public bool[] workoutHaveUpgrade;
    public bool[] styleHaveUpgrade;
    public bool[] looksHaveUpgrade;
    public bool[] meditationHaveUpgrade;
}
