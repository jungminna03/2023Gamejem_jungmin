using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOres : MonoBehaviour
{
    private static MyOres instance;

    private int myores = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static MyOres GetInstance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public void AddOre()
    {
        myores++;
    }

    public int getMyOres()
    {
        return myores;
    }
}
