using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public bool[] mewingHaveUpgrade;
    public bool[] workoutHaveUpgrade;
    public bool[] styleHaveUpgrade;
    public bool[] looksHaveUpgrade;
    public bool[] meditationHaveUpgrade;
    public bool[] coldHaveUpgrade;
    public static UpgradeManager Instance {get;private set;}
    void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public bool[] ChooseBool(SO_Builds data)
    {
        string name = data.name;
        switch (name)
        {
            default: return null;
            case "Mewing":
            return mewingHaveUpgrade;
            case "Workout":
            return workoutHaveUpgrade;
            case "Style":
            return styleHaveUpgrade;
            case "LooksMaxxing":
            return looksHaveUpgrade;
            case "Meditation":
            return meditationHaveUpgrade;
            case "ColdBath":
            return coldHaveUpgrade;
        }
    }
  #region SAVE & LOAD

    public void Save(ref UpgradesData upgradesData)
    {
        upgradesData.mewingHaveUpgrade = (bool[])mewingHaveUpgrade.Clone();
        upgradesData.workoutHaveUpgrade = (bool[])workoutHaveUpgrade.Clone();
        upgradesData.styleHaveUpgrade = (bool[])styleHaveUpgrade.Clone();
        upgradesData.looksHaveUpgrade = (bool[])looksHaveUpgrade.Clone();
        upgradesData.meditationHaveUpgrade = (bool[])meditationHaveUpgrade.Clone();
        upgradesData.coldHaveUpgrade = (bool[])coldHaveUpgrade.Clone();
    }
    public void Load(UpgradesData upgradesData)
    {
        if(upgradesData.mewingHaveUpgrade != null && upgradesData.mewingHaveUpgrade.Length == mewingHaveUpgrade.Length)
        {
            mewingHaveUpgrade = (bool[])upgradesData.mewingHaveUpgrade.Clone();
        }
        if(upgradesData.workoutHaveUpgrade != null && upgradesData.workoutHaveUpgrade.Length == workoutHaveUpgrade.Length)
        {
            workoutHaveUpgrade = (bool[])upgradesData.workoutHaveUpgrade.Clone();
        }
        if(upgradesData.styleHaveUpgrade != null && upgradesData.styleHaveUpgrade.Length == styleHaveUpgrade.Length)
        {
            styleHaveUpgrade = (bool[])upgradesData.styleHaveUpgrade.Clone();
        }
        if(upgradesData.looksHaveUpgrade != null && upgradesData.looksHaveUpgrade.Length == looksHaveUpgrade.Length)
        {
            looksHaveUpgrade = (bool[])upgradesData.looksHaveUpgrade.Clone();
        }
        if(upgradesData.meditationHaveUpgrade != null && upgradesData.meditationHaveUpgrade.Length == meditationHaveUpgrade.Length)
        {
            meditationHaveUpgrade = (bool[])upgradesData.meditationHaveUpgrade.Clone();
        }
        if(upgradesData.coldHaveUpgrade != null && upgradesData.coldHaveUpgrade.Length == coldHaveUpgrade.Length)
        {
            coldHaveUpgrade = (bool[])upgradesData.coldHaveUpgrade.Clone();
        }
    }
  #endregion
}
