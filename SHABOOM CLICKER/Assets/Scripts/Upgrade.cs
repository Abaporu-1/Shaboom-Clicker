using UnityEngine;

public class Upgrade : ScriptableObject
{
    public new string name;
    public string description;
    public string effectDescription;
    public int price;
    public int unlockedLevel;
    public int upgradeIndex;
    public virtual void BuyUpgrade(){}
    public virtual bool CanBuy(){return false;}
}
