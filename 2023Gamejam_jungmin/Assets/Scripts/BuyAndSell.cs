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
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("구매할 돈이 없습니다!!");
                    return;
                }
                if (p.Count + buyCount > 100)
                {
                    buyCount = 100 - p.Count;
                    buytext.text = $"구매: {buyCount}";
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("최대로 살 수 있는 갯수입니다!!");
                    return;
                }
                buytext.text = $"구매: {buyCount}";
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
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("최대로 판매 할 수 있는 갯수입니다!!");
                    Debug.Log("최대 판매 갯수");
                    if (sellCount <= 0)
                        sellCount = 1;
                    selltext.text = $"판매: {sellCount}";
                    return;
                }
                selltext.text = $"판매: {sellCount}";
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
                if ( i!=0 && FindObjectOfType<PlanetSetting>().planets[i - 1].Count == 0)
                {
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("이전 행성을 사야합니다!!");
                    return;
                }
                if (p.Count + buyCount > 100)
                {
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("최대로 살 수 있는 갯수입니다!!");
                    Debug.Log("최대 구매 갯수");
                    return;
                }
                FindObjectOfType<PlanetSetting>().planets[i].Count += buyCount;
                countText.text = $"{FindObjectOfType<PlanetSetting>().planets[i].Count}개";
                FindObjectOfType<PlanetSetting>().gold -= buyCount * p.Price;
                goldText.text = $"{FindObjectOfType<PlanetSetting>().gold}$";
                buyCount = 1;
                buytext.text = $"구매: {buyCount}";
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
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("최대로 판매 할 수 있는 갯수입니다!!");
                    Debug.Log("최대 판매 갯수");
                    return;
                }
                FindObjectOfType<PlanetSetting>().planets[i].Count -= sellCount;
                countText.text = $"{FindObjectOfType<PlanetSetting>().planets[i].Count}개";
                FindObjectOfType<PlanetSetting>().gold += sellCount * (p.Price);
                goldText.text = $"{FindObjectOfType<PlanetSetting>().gold}$";
                sellCount = 1;
                selltext.text = $"판매: {sellCount}";
            }
        }
    }
    public void Set()
    {
        buyCount = 1;
        buytext.text = $"구매: {buyCount}";
        sellCount = 1;
        selltext.text = $"판매: {sellCount}";
    }


}
