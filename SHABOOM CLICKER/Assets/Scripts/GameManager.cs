using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;private set;}
    private double currencyBadomp;
    [SerializeField]private BigInteger totalCurrency;
    [SerializeField]private double currencyPerSecond;
    [SerializeField]private float clickValue;
    [SerializeField]private List<BuildScript> builds;
    [SerializeField] private TMP_Text textTotalIncome, textIncomePerSecond;

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
        
    }
    public void CalculatePerSecondIncome()
    {
        float sum = 0f;
        foreach(BuildScript build in builds)
        {
            sum += build.GetProduction();
        }
        currencyPerSecond = sum;
    }
    private void SetPerSecondIncome()
    {
        currencyBadomp += currencyPerSecond*Time.deltaTime;
        if (currencyBadomp >= 1)
        {
            BigInteger amount = (BigInteger)currencyBadomp;
            totalCurrency += amount;
            currencyBadomp -= (double)amount;
        }
    }
    private void UIUpdate()
    {
        textTotalIncome.text = NumberFormatter.Format(totalCurrency) + " Aura";
        textIncomePerSecond.text = NumberFormatter.Format(currencyPerSecond) + " a/s";
    }
    void Update()
    {
        CalculatePerSecondIncome();
        SetPerSecondIncome();
        UIUpdate();
        Debug.Log("Total Currency: "+totalCurrency);
    }
}
