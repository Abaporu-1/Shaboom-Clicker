using UnityEngine;
[CreateAssetMenu]
public class MewingUpgrades : Upgrade
{
    public SO_Builds mewingData;
    private int duplicator = 2;
    private bool[] haveUpgrade = new bool[10];
    public override void BuyUpgrade()
    {
        BuildScript build_ = GameManager.Instance.GetBuildByData(mewingData);
        if(CanBuy())
        {
            switch (upgradeIndex)
            {
                case 1:
                build_.MultiplyMultiplier(duplicator);
                GameManager.Instance.IncreaseClickMultiplier(duplicator);
                break;
                case 2:
                build_.MultiplyMultiplier(duplicator);
                GameManager.Instance.IncreaseClickMultiplier(duplicator);
                break;
            }
            Debug.Log(upgradeIndex);
            haveUpgrade[upgradeIndex - 1] = true;
        }
    }
    public override bool CanBuy()
    {
        BuildScript build_ = GameManager.Instance.GetBuildByData(mewingData);
        if(build_.level >= unlockedLevel && !haveUpgrade[upgradeIndex - 1])
        {
            return true;
        }
        return false;
    }
}
