using System.Numerics;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textTotalIncome, textIncomePerSecond;

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
    }
    
}
