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
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("������ ���� �����ϴ�!!");
                    return;
                }
                if (p.Count + buyCount > 100)
                {
                    buyCount = 100 - p.Count;
                    buytext.text = $"����: {buyCount}";
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("�ִ�� �� �� �ִ� �����Դϴ�!!");
                    return;
                }
                buytext.text = $"����: {buyCount}";
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
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("�ִ�� �Ǹ� �� �� �ִ� �����Դϴ�!!");
                    Debug.Log("�ִ� �Ǹ� ����");
                    if (sellCount <= 0)
                        sellCount = 1;
                    selltext.text = $"�Ǹ�: {sellCount}";
                    return;
                }
                selltext.text = $"�Ǹ�: {sellCount}";
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
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("���� �༺�� ����մϴ�!!");
                    return;
                }
                if (p.Count + buyCount > 100)
                {
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("�ִ�� �� �� �ִ� �����Դϴ�!!");
                    Debug.Log("�ִ� ���� ����");
                    return;
                }
                FindObjectOfType<PlanetSetting>().planets[i].Count += buyCount;
                countText.text = $"{FindObjectOfType<PlanetSetting>().planets[i].Count}��";
                FindObjectOfType<PlanetSetting>().gold -= buyCount * p.Price;
                goldText.text = $"{FindObjectOfType<PlanetSetting>().gold}$";
                buyCount = 1;
                buytext.text = $"����: {buyCount}";
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
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("�ִ�� �Ǹ� �� �� �ִ� �����Դϴ�!!");
                    Debug.Log("�ִ� �Ǹ� ����");
                    return;
                }
                FindObjectOfType<PlanetSetting>().planets[i].Count -= sellCount;
                countText.text = $"{FindObjectOfType<PlanetSetting>().planets[i].Count}��";
                FindObjectOfType<PlanetSetting>().gold += sellCount * (p.Price);
                goldText.text = $"{FindObjectOfType<PlanetSetting>().gold}$";
                sellCount = 1;
                selltext.text = $"�Ǹ�: {sellCount}";
            }
        }
    }
    public void Set()
    {
        buyCount = 1;
        buytext.text = $"����: {buyCount}";
        sellCount = 1;
        selltext.text = $"�Ǹ�: {sellCount}";
    }


}
