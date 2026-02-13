using System.Numerics;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get;private set;}
    [SerializeField] private TMP_Text textTotalIncome, textIncomePerSecond;
    [SerializeField] private TMP_Text[] costText;

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
    private void Start()
    {
        GameManager.Instance.OnCurrencyChanged += UIAuraAmount;
        UIAuraAmount();
    }
    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnCurrencyChanged -= UIAuraAmount;
        }
    }
        private void UIAuraAmount()
        {
            BigInteger totalCurrency = GameManager.Instance.ShareTotalCurrencyAmount();
            double currencyPerSecond = GameManager.Instance.ShareCurrencyPerSecondAmount();
            textTotalIncome.text = NumberFormatter.Format(totalCurrency) + " Aura";
            textIncomePerSecond.text = NumberFormatter.Format(currencyPerSecond) + " a/s";
            UpdateAllBuildCosts(GameManager.Instance.GetBuilds());
        }
        public void UpdateAllBuildCosts(List<BuildScript> builds)
{
        for (int i = 0; i < builds.Count; i++)
        {
            double cost = builds[i].GetCost();
            costText[i].text = NumberFormatter.Format(new BigInteger(cost));
        }
}

}
