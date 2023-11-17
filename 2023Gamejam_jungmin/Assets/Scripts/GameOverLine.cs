using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    [SerializeField] GameObject _gameOverUI;
    [SerializeField] Transform _gameOverBar;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Ore>() != null)
        {
            if (_gameOverBar.transform.position.y < collision.transform.position.y &&
                _gameOverBar.transform.position.y < _gameOverBar.transform.position.y + collision.gameObject.GetComponent<CircleCollider2D>().radius * 2)
            {
                Debug.Log(collision.transform.position);
                _gameOverUI.SetActive(true);
            }
        }
    }
}
