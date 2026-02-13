using System.Numerics;
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
    public BigInteger GetCost()
    {
        return new BigInteger(data.baseCost) * BigInteger.Pow(new BigInteger(data.priceMultiplier), level);
    }
    public void BuyBuild()
    {
        level++;
    }

}
