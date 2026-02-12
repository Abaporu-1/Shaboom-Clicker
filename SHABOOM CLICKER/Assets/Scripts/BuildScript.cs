using UnityEngine;

public class BuildScript:MonoBehaviour
{
    public SO_Builds data;
    [SerializeField] private int level = 0;
    [SerializeField] private float multiplier = 1f;
    public float GetProduction()
    {
        return (data.baseProduction * multiplier) * level;
    }
    public float GetCost()
    {
        return data.baseCost * Mathf.Pow(data.priceMultiplier, level);
    }
    public void BuyBuild()
    {
        level++;
    }

}
