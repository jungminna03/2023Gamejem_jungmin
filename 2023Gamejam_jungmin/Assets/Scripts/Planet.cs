using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    private PlanetName planetName;

    public PlanetName m_PlanetName => planetName;


}
