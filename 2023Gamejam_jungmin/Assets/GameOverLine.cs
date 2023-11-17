using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    [SerializeField] float _gameOverLimit;
    private void OnTriggerExit(Collider other)
    {
        if(other.ClosestPoint(transform.position).y > gameObject.transform.position.y)
        {
            Debug.Log(other.ClosestPoint(transform.position).y);
        }
    }
}
