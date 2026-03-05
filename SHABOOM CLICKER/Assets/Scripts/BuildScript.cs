using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class BuildScript
{
    public SO_Builds data;
    public int level = 0;
    public int multiplier = 1;
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
    public void MultiplyMultiplier(int multiplier_)
    {
        multiplier *= multiplier_;
    }
}
