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
                    Debug.Log("µ· ¾øÀ½");
                    return;
                }
                if (p.Count + buyCount > 100)
                {
                    buyCount = 100 - p.Count;
                    buytext.text = $"buy: {buyCount}";
                    Debug.Log("ÃÖ´ë °¹¼ö");
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
                    Debug.Log("ÃÖ´ë ÆÇ¸Å °¹¼ö");
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
                if (p.Count + buyCount > 100)
                {
                    Debug.Log("ÃÖ´ë ±¸¸Å °¹¼ö");
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
                    Debug.Log("ÃÖ´ë ÆÇ¸Å °¹¼ö");
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
