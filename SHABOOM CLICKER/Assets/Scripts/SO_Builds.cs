using UnityEngine;

[CreateAssetMenu(fileName = "SO_Builds", menuName = "Scriptable Objects/SO_Builds")]
public class SO_Builds : ScriptableObject
{
    public string buildName;
    public double baseProduction;
    public double  baseCost;
    public double priceMultiplier;
}
