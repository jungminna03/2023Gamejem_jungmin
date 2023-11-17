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
            Vector3 middle = transform.position - collision.transform.position;
            middle = (middle / 2) + collision.transform.position;
            Debug.Log(middle);

            GameObject go = GameObject.Instantiate(_nextOre);
            go.transform.position = middle;
            go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;


            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(gameObject);


            // TODO : 점수 주기
        }

    }
}
