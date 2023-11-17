using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct PlanetSet
{
    public PlanetName planetName;
    public int Price;
    public int Count;
}

public class PlanetSetting : MonoBehaviour
{
    
    public PlanetSet[] planets=new PlanetSet[10]; 
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
