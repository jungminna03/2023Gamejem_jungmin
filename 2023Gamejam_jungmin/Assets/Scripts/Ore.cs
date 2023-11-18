using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public int _count;

    [SerializeField] int _point;
    [SerializeField] GameObject _nextOre;

    private void Awake()
    {
        ScoreManager.Instance.AddScore(_point);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ore ore = collision.gameObject.GetComponent<Ore>();

        if (ore != null && ore._count == _count && _nextOre != null && collision.transform.position.y > transform.position.y && _count < DataBase.Instance._level)
        {
            SoundManager.GetInstance.PlaySound(Define.Sound.ItemCombine);
            GameObject go = GameObject.Instantiate(_nextOre);
            go.transform.position = transform.position;
            go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(gameObject);
        }
        ScoreManager.Instance.CheckEndGame(transform.position.y);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ScoreManager.Instance.CheckEndGame(transform.position.y);
    }
}
