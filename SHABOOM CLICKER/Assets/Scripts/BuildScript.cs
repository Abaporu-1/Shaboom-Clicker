[System.Serializable]
public class BuildScript
{
    public SO_Builds data;
    public int level = 0;
    public float multiplier = 1f;
    public float GetProduction()
    {
        return (data.baseProduction * multiplier) * level;
    }
    public float GetCost()
    {
        return data.baseCost * UnityEngine.Mathf.Pow(data.priceMultiplier, level);
    }
    public void BuyBuild()
    {
        level++;
    }

}
