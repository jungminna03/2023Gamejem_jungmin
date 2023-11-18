using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    static ScoreManager _instance;

    [SerializeField] GameObject _gameOverButton;

    [SerializeField] Spawner _spawner;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Ore ore = collision.GetComponent<Ore>();

        if (ore != null && ore._invincible == false && ore.GetComponent<CircleCollider2D>().enabled == true)
        {
            _gameOverButton.SetActive(true);
            _spawner.StopSpawn();
        }
    }
}
