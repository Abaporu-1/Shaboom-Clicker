using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;private set;}
    private double currencyBadomp;
    [SerializeField]private BigInteger totalCurrency;
    [SerializeField]private double currencyPerSecond;
    [SerializeField]private float clickValue;
    [SerializeField]private List<BuildScript> builds;
    public System.Action OnCurrencyChanged;
    

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
    public void ClickFarm()
    {
        int baseValue = 1;
        clickValue = baseValue;
        totalCurrency += (BigInteger)clickValue;
        OnCurrencyChanged?.Invoke();
    }
    public void CalculatePerSecondIncome()
    {
        double sum = 0f;
        foreach(BuildScript build in builds)
        {
            sum += build.GetProduction();
        }
        if(Mathf.Abs((float)(currencyPerSecond - sum)) > 0.0001f)
        {
        currencyPerSecond = sum;
        OnCurrencyChanged?.Invoke();
        }
    }
    private void SetPerSecondIncome()
    {
        currencyBadomp += currencyPerSecond*Time.deltaTime;
        if (currencyBadomp >= 1)
        {
            BigInteger amount = (BigInteger)currencyBadomp;
            totalCurrency += amount;
            currencyBadomp -= (double)amount;
            OnCurrencyChanged?.Invoke();
        }
    }
   public BigInteger ShareTotalCurrencyAmount()
    {
        return totalCurrency;
    }
    public double ShareCurrencyPerSecondAmount()
    {
        return currencyPerSecond;
    }
    public void BuyBuild(int index)
    {
        BuildScript build = builds[index];

        BigInteger cost = new BigInteger(build.GetCost());

        if (TrySpendCurrency(cost))
        {
            build.BuyBuild();
        }
        else
        {

        }
    }
     public void BuyUpgrade(Upgrade upgrade, SO_Builds data)
    {
        BuildScript build_ = GetBuildByData(data);
        if (build_ == null)
        {
            return;
        }
        if(build_.level >= upgrade.unlockedLevel && TrySpendCurrency(upgrade.price))
        {
            upgrade.BuyUpgrade();
        }
    }
    private bool TrySpendCurrency(BigInteger amount)
    {
        if (totalCurrency >= amount)
        {
            totalCurrency -= amount;
            OnCurrencyChanged?.Invoke();
            return true;
        }

        return false;
        }

    public List<BuildScript> GetBuilds()
    {
        return builds;
    }
    public BuildScript GetBuildByData(SO_Builds data)
    {   
        foreach (BuildScript build in builds)
        {
            if (build.data == data)
                return build;
        }

        return null;
    }
    void Update()
    {
        CalculatePerSecondIncome();
        SetPerSecondIncome();
        Debug.Log("Total Currency: "+ totalCurrency);
    }
}
