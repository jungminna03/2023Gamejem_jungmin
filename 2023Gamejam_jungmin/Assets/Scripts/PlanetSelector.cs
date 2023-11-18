using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject[] planetList;

    public void FindOnClicked()
    {
        for (int i = 0; i < planetList.Length; i++)
        {
           if (planetList[i].GetComponent<Planet>()._onClicked == true)
            {
                planetList[i].GetComponent<Planet>().OffClick();
            }
            
        }
    }
}
