using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public void OnBuyButton()
    {
        if (FindObjectOfType<PlayerInfo>().Gold < FindObjectOfType<PurchaseWindow>()._buyPrice * FindObjectOfType<PurchaseWindow>()._buyCount)
        {
            FindObjectOfType<ErrorIMG>().PrintErrorMessage("������ ���� �����ϴ�!!");
        }
        else
        {
            FindObjectOfType<PurchaseWindow>().BuyPlanet();
        }
    }
}
