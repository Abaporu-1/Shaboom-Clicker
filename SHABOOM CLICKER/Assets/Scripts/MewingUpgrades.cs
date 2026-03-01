using UnityEngine;
[CreateAssetMenu]
public class MewingUpgrades : Upgrade
{
    public SO_Builds mewingData;
    public int upgradeIndex;
    private int duplicator = 2;
    public override void BuyUpgrade()
    {
        BuildScript build_ = GameManager.Instance.GetBuildByData(mewingData);
        if(build_.level >= unlockedLevel)
        {
            switch (upgradeIndex)
            {
                case 1:
                build_.MultiplyMultiplier(duplicator);
                GameManager.Instance.IncreaseClickMultiplier(duplicator);
                break;
            }
        }
    }
}
