using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveOres : MonoBehaviour
{
    [SerializeField]
    private Image[] oreImage;
    [SerializeField]
    private GameObject Deadline;
    [SerializeField]
    private float[] flowers;

    private int myOres;
    private void Awake()
    {
        myOres = MyOres.GetInstance.getMyOres();
        Deadline.transform.position = new Vector2(0,flowers[myOres]);
        for (int i = 0; i < myOres; i++)
        {
            oreImage[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }
}
