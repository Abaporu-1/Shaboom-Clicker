using UnityEngine;
[CreateAssetMenu]
public class MewingUpgrades : Upgrade
{
    public override void BuyUpgrade()
    {
        BuildScript build_ = GameManager.Instance.GetBuildByData(data);
        bool[] haveUpgrade = UpgradeManager.Instance.ChooseBool(data);
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
                case 3:
                build_.MultiplyMultiplier(duplicator);
                GameManager.Instance.IncreaseClickMultiplier(duplicator);
                break;
            }
            Debug.Log(upgradeIndex);
            haveUpgrade[upgradeIndex - 1] = true;
        }
    }
}
