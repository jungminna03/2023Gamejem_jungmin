using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public void OnBuyButton()
    {
        if (FindObjectOfType<PlayerInfo>().Gold < FindObjectOfType<PurchaseWindow>()._buyPrice * FindObjectOfType<PurchaseWindow>()._buyCount)
        {
            FindObjectOfType<ErrorIMG>().PrintErrorMessage("구매할 돈이 없습니다!!");
        }
        else
        {
            FindObjectOfType<PurchaseWindow>().BuyPlanet();
        }
    }
}
