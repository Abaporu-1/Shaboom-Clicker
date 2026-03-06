using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public bool[] mewingHaveUpgrade;
    public static UpgradeManager Instance {get;private set;}
    void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {

    }
}
