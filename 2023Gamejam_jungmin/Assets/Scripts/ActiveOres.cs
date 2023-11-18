using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveOres : MonoBehaviour
{
    [SerializeField]
    private Image[] oreImage;
    private int myOres;

    private void Awake()
    {
        myOres = MyOres.GetInstance.getMyOres();

        for (int i = 0; i < myOres; i++)
        {
            oreImage[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }
}
