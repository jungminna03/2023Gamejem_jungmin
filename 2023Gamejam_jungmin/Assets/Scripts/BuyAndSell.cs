using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyAndSell : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI buytext;
    [SerializeField]
    private TextMeshProUGUI selltext;
    [SerializeField]
    private TextMeshProUGUI planetNameText;
    [SerializeField]
    private TextMeshProUGUI goldText;
    [SerializeField]
    private TextMeshProUGUI countText;

    int buyCount=1;
    int sellCount=1;
    public void BuyAdd(int num)
    {
        if (buyCount + num < 1) return;
        buyCount += num;
        for(int i=0; i<10; i++)
        {
            PlanetSet p = FindObjectOfType<PlanetSetting>().planets[i];
            if (p.planetName.ToString() == planetNameText.text)
            {
                if (FindObjectOfType<PlanetSetting>().gold - buyCount * p.Price < 0)
                {
                    buyCount -= num;
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("Not Monney");
                    return;
                }
                if (p.Count + buyCount > 100)
                {
                    buyCount = 100 - p.Count;
                    buytext.text = $"buy: {buyCount}";
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("Max Buy Count");
                    return;
                }
                buytext.text = $"buy: {buyCount}";
            }
        }
    }
    public void SellAdd(int num)
    {
        if (sellCount + num < 1) return;
        sellCount += num;
        for (int i = 0; i < 10; i++)
        {
            PlanetSet p = FindObjectOfType<PlanetSetting>().planets[i];
            if (p.planetName.ToString() == planetNameText.text)
            {
                if (p.Count - sellCount < 1)
                {
                    sellCount = p.Count-1;
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("Max Sell count");
                    Debug.Log("최대 판매 갯수");
                    if (sellCount <= 0)
                        sellCount = 1;
                    selltext.text = $"sell: {sellCount}";
                    return;
                }
                selltext.text = $"sell: {sellCount}";
            }
        }
    }
    public void Buy()
    {
        for (int i = 0; i < 10; i++)
        {
            PlanetSet p = FindObjectOfType<PlanetSetting>().planets[i];
            if (p.planetName.ToString() == planetNameText.text)
            {
                if (FindObjectOfType<PlanetSetting>().planets[i - 1].Count == 0)
                {
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("You Must Buy Before Planet");
                    return;
                }
                if (p.Count + buyCount > 100)
                {
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("Max buy count");
                    Debug.Log("최대 구매 갯수");
                    return;
                }
                FindObjectOfType<PlanetSetting>().planets[i].Count += buyCount;
                countText.text = $"{FindObjectOfType<PlanetSetting>().planets[i].Count}C";
                FindObjectOfType<PlanetSetting>().gold -= buyCount * p.Price;
                goldText.text = $"{FindObjectOfType<PlanetSetting>().gold}$";
                buyCount = 1;
                buytext.text = $"buy: {buyCount}";
            }
        }
    }
    public void Sell()
    {
        for (int i = 0; i < 10; i++)
        {
            PlanetSet p = FindObjectOfType<PlanetSetting>().planets[i];
            if (p.planetName.ToString() == planetNameText.text)
            {
                if (p.Count - sellCount < 1)
                {
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("Max Sell count");
                    Debug.Log("최대 판매 갯수");
                    return;
                }
                FindObjectOfType<PlanetSetting>().planets[i].Count -= sellCount;
                countText.text = $"{FindObjectOfType<PlanetSetting>().planets[i].Count}C";
                FindObjectOfType<PlanetSetting>().gold += sellCount * (p.Price);
                goldText.text = $"{FindObjectOfType<PlanetSetting>().gold}$";
                sellCount = 1;
                selltext.text = $"sell: {sellCount}";
            }
        }
    }
    public void Set()
    {
        buyCount = 1;
        buytext.text = $"buy: {buyCount}";
        sellCount = 1;
        selltext.text = $"sell: {sellCount}";
    }


}
