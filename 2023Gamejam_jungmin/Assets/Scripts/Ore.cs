using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public int _count;

    [SerializeField] int _point;
    [SerializeField] GameObject _nextOre;

    GameObject _deleteGameObject;
    public bool _isCreate = false;

    public bool _invincible = true;

    private void Awake()
    {
        ScoreManager.Instance.AddScore(_point);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ore ore = collision.gameObject.GetComponent<Ore>();

        if (collision.gameObject.tag == "Item")
        {
            _invincible = false;
        }

        if (ore != null && ore._count == _count && _nextOre != null && collision.transform.position.y < transform.position.y && _count < DataBase.Instance._level)
        {
            if (ore._isCreate || _isCreate)
                return;
            ore._isCreate = true;

            SoundManager.GetInstance.PlaySound(Define.Sound.ItemCombine);
            transform.GetComponent<CircleCollider2D>().enabled = false;
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            _deleteGameObject = collision.gameObject;
            StartCoroutine("CreateAnimation");
        }
    }
    IEnumerator CreateAnimation()
    {
        while (true)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position,
                _deleteGameObject.transform.position, 4.0f * Time.deltaTime);

            if (Vector2.Distance(transform.position, _deleteGameObject.transform.position) < 0.3f)
            {
                break;
            }

        }
        GameObject go = GameObject.Instantiate(_nextOre);
        go.transform.position = transform.position;
        go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        GameObject.Destroy(_deleteGameObject);
        GameObject.Destroy(gameObject);

    }

}

