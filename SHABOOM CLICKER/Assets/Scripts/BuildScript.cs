using UnityEngine;
[System.Serializable]

public class BuildScript
{
    public SO_Builds data;
    public int level = 0;
    public float multiplier = 1f;
    public double GetProduction()
    {
        return (data.baseProduction * multiplier) * level;
    }
    public double GetCost()
    {
        return data.baseCost * Mathf.Pow(data.priceMultiplier, level);
    }
    public void BuyBuild()
    {
        level++;
    }

}
