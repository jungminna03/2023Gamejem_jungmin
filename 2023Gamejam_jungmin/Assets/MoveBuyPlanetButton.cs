using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBuyPlanetButton : MonoBehaviour
{
    [SerializeField] GameObject _targetPlanet;
    [SerializeField] float _downPos;
    private void Update()
    {
        gameObject.transform.position = new Vector3(_targetPlanet.transform.position.x, _targetPlanet.transform.position.y + _downPos, _targetPlanet.transform.position.z);
    }
}
