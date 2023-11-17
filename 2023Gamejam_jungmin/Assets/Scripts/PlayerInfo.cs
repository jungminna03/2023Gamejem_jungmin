using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [System.Serializable]
    public struct PlanetInfo
    {
        public string Name;
        public int Count;
    }

    public int Gold = 0;
    public PlanetInfo[] planets = new PlanetInfo[10];

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
