using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    [SerializeField] GameObject _gameOverUI;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Ore>())
        {
            if (gameObject.transform.position.y <= gameObject.transform.position.y + collision.gameObject.GetComponent<CircleCollider2D>().offset.y * 2)
            {
                _gameOverUI.SetActive(true);
            }
        }
    }
}
