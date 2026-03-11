using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public bool[] mewingHaveUpgrade;
    public bool[] workoutHaveUpgrade;
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
        }
    }
  #region SAVE & LOAD

    public void Save(ref UpgradesData upgradesData)
    {
       upgradesData.mewingHaveUpgrade = (bool[])mewingHaveUpgrade.Clone();
    }
    public void Load(UpgradesData upgradesData)
    {
        if(upgradesData.mewingHaveUpgrade != null && upgradesData.mewingHaveUpgrade.Length == mewingHaveUpgrade.Length)
        {
            mewingHaveUpgrade = (bool[])upgradesData.mewingHaveUpgrade.Clone();
        }
    }
  #endregion
}
