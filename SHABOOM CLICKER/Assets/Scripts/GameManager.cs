using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;private set;}
    /* -- CURRENCY BADOMP EXPLANATION --
    
    Á primeira vista não está mt claro o q ele faz - se achar um nome melhor, pode mudar - então fica aqui a explicação:

    -> currencyBadomp é o intermediário entre o currencyPerSecond e totalCurrency, visto que totalCurrency é BigInt e 
    currencyPerSecond é double.
    - 1: currencyPerSecond é somado no currencyBadomp em tempo delta
    - 2: se o valor somado for maior que 1 inteiro, o currencyBadomp é adicionado no totalCurrency
    
    */
    private double currencyBadomp;
    [SerializeField]private BigInteger totalCurrency;
    [SerializeField]private double currencyPerSecond;
    [SerializeField]private float clickValue;
    private int clickMultiplier = 1;
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
      void Start()
    {
        SaveThings.Load();
    }
    void Update()
    {
        CalculatePerSecondIncome();
        SetPerSecondIncome();
    }
    /* FUNÇÕES CRIADAS PARA USAR EM BOTÕES E TESTAR SE O SAVE E LOAD ESTAVAM FUNCIONANDO
    public void SaveGame()
    {
        SaveThings.Save();
    }
    public void LoadGame()
    {
        SaveThings.Load();
    }
    */
    public void ClickFarm()
    {
        int baseValue = 1;
        clickValue = baseValue * clickMultiplier;
        totalCurrency += (BigInteger)clickValue;
        OnCurrencyChanged?.Invoke();
    }
    public void IncreaseClickMultiplier(int multiplier_)
    {
        clickMultiplier *= multiplier_;
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
     public void BuyUpgrade(Upgrade upgrade)
    {
        if(upgrade.CanBuy() && TrySpendCurrency(upgrade.price))
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
     #region Save & Load
    public void Save(ref AuraSaveData auraData, ref BuildsData buildsData)
    {
        // TOTAL CURRENCY & CLICK MULTIPLIER
        auraData.totalCurrency = totalCurrency.ToString();
        buildsData.clickMultiplier = clickMultiplier;

        // GARANTIA DE QUE OS ARRAYS DA DATA TEM O MESMO TAMANHO DA LISTA
        if((buildsData.level == null || buildsData.level.Length != builds.Count) ||
        (buildsData.multiplier == null || buildsData.multiplier.Length != builds.Count))
        {
            buildsData.level = new int[builds.Count];
            buildsData.multiplier = new int[builds.Count];
        }
        // LEVEL E MULTIPLICADOR DAS BUILDS
        for(int i = 0;  i < builds.Count; i++)
        {
            buildsData.level[i] = builds[i].level;
            buildsData.multiplier[i] = builds[i].multiplier;
        }
    }
    public void Load(AuraSaveData auraData, BuildsData buildsData)
    {
        totalCurrency = BigInteger.Parse(auraData.totalCurrency);


        // Garantia de que o multiplicador não vai ser 0(zero) == CLICK MULTIPLIER
        if(buildsData.clickMultiplier > 0)
        {
            clickMultiplier = buildsData.clickMultiplier;
        }
        else
        {
            clickMultiplier = 1;
        }

        // CHECA SE OS ARRAYS DA DATA TEM O MESMO TAMANHO DA LISTA E SE NÃO SÃO VAZIOS
       if((buildsData.level != null && buildsData.level.Length == builds.Count) &&
        (buildsData.multiplier != null && buildsData.multiplier.Length == builds.Count))
        {
            for(int i = 0;  i < builds.Count; i++)
            {
                builds[i].level = buildsData.level[i];
                // Garantia de que o multiplicador não vai ser 0(zero) == BUILDS MULTIPLIER
                if(buildsData.multiplier[i] > 0)
                {
                    builds[i].multiplier =buildsData.multiplier[i];
                }
                else
                {
                    builds[i].multiplier = 1;
                }
            }
            
        }
        OnCurrencyChanged?.Invoke();
    }
    #endregion
    private void OnApplicationQuit()
    {
        SaveThings.Save();
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveThings.Save();
        }
    }

}
