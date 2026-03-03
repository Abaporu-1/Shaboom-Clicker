using System.Numerics;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get;private set;}
    [SerializeField] private GameObject[] canvas;
    [SerializeField] private GameObject[] shopPanel;
    private int currentIndex = -1;
    private int shopCurrentIndex = -1;
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
    public void MainScreen()
    {
        foreach(GameObject canva_ in canvas)
        {
            canva_.SetActive(false);
        }
        currentIndex = -1;
    }
  public void OpenCanva(int index)
    {
        if (index < 0 || index >= canvas.Length) return;
        if (index == currentIndex) return;
        if (currentIndex >= 0)
        {
            canvas[currentIndex].SetActive(false);
        }
        canvas[index].SetActive(true);
        currentIndex = index;
    }
    public void ChangeShopScreen(int index)
    {
         if (index < 0 || index >= shopPanel.Length) return;
        if (index == shopCurrentIndex) return;
        if (shopCurrentIndex >= 0)
        {
            shopPanel[shopCurrentIndex].SetActive(false);
        }
        shopPanel[index].SetActive(true);
        shopCurrentIndex = index;
    }
}
