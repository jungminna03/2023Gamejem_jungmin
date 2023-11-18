using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public int _count;

    [SerializeField] int _point;
    [SerializeField] GameObject _nextOre;

    GameObject deleteGameObject;
    public bool IsCreate = false;

    private void Awake()
    {
        ScoreManager.Instance.AddScore(_point);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ore ore = collision.gameObject.GetComponent<Ore>();

        if (ore != null && ore._count == _count && _nextOre != null && collision.transform.position.y < transform.position.y && _count < DataBase.Instance._level)
        {
            if (ore.IsCreate || IsCreate)
                return;
            ore.IsCreate = true;

            SoundManager.GetInstance.PlaySound(Define.Sound.ItemCombine);
            transform.GetComponent<CircleCollider2D>().enabled = false;
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            deleteGameObject = collision.gameObject;
            StartCoroutine("CreateAnimation");


        }
    }
    IEnumerator CreateAnimation()
    {
        while (true)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position,
                deleteGameObject.transform.position, 4.0f * Time.deltaTime);

            if (Vector2.Distance(transform.position, deleteGameObject.transform.position) < 0.3f)
            {
                break;
            }

        }
        GameObject go = GameObject.Instantiate(_nextOre);
        go.transform.position = transform.position;
        go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        GameObject.Destroy(deleteGameObject);
        GameObject.Destroy(gameObject);

    }

}

