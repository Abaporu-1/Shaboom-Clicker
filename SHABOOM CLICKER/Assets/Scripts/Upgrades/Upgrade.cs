using UnityEngine;

public class Upgrade : ScriptableObject
{
    public new string name;
    public string description;
    public string effectDescription;
    public int price;
    public int unlockedLevel;
    public int upgradeIndex;
    public SO_Builds data;
    public int duplicator = 2;
    public virtual void BuyUpgrade()
    {
        BuildScript build_ = GameManager.Instance.GetBuildByData(data);
        bool[] haveUpgrade = UpgradeManager.Instance.ChooseBool(data);
        if(CanBuy())
        {
            build_.MultiplyMultiplier(duplicator);
            haveUpgrade[upgradeIndex - 1] = true;
        }
    }
    public virtual bool CanBuy()
    {
        BuildScript build_ = GameManager.Instance.GetBuildByData(data);
        bool[] haveUpgrade = UpgradeManager.Instance.ChooseBool(data);
        if(build_.level >= unlockedLevel && !haveUpgrade[upgradeIndex - 1])
        {
            return true;
        }
        return false;
    }
}
