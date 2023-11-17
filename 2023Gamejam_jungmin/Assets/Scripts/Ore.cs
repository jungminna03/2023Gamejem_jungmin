using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public int _count;

    int _point;
    [SerializeField] GameObject _nextOre;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ore ore = collision.gameObject.GetComponent<Ore>();

        if (ore != null && ore._count == _count && _nextOre != null && collision.transform.position.y > transform.position.y)
        {
            GameObject go = GameObject.Instantiate(_nextOre);
            go.transform.position = transform.position;
            go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;


            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(gameObject);


            // TODO : ���� �ֱ�
        }

    }
}
