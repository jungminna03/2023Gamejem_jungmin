using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    Spawner _spawner;
    public GameObject _currentOre;
    [SerializeField] float _horizontalSpeed = 0.001f;
    [SerializeField] bool _isSelect;

    [SerializeField] GameObject _finishPanel;

    public int _currentCount = 0;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && _currentOre != null)
        {
            _isSelect = true;

            if(Input.GetAxis("Mouse X") > 0)
            {
                
                if (/*_currentOre.GetComponent<CircleCollider2D>().radius + */_currentOre.transform.position.x > 3 - _currentOre.GetComponent<CircleCollider2D>().radius)
                {
                    return;
                }
                else
                {
                    _currentOre.transform.position += new Vector3(_horizontalSpeed, 0, 0);
                }
            }
            else if(Input.GetAxis("Mouse X") < 0) 
            {
                if (/*-_currentOre.GetComponent<CircleCollider2D>().radius + */_currentOre.transform.position.x < -3 + _currentOre.GetComponent<CircleCollider2D>().radius)
                {
                    return;
                }
                else
                {
                    _currentOre.transform.position += new Vector3(_horizontalSpeed * (-1), 0, 0);
                }
            }
        }

        if(_isSelect)
        {
            if (Input.GetMouseButtonUp(0) && _currentOre != null)
            {
                ++_currentCount;

                if (_currentCount >= DataBase.Instance.Fame / 30)
                {
                    StartCoroutine("EndGame");
                    _spawner.StopSpawn();
                }

                _spawner.Respawn();
                _currentOre.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                _isSelect = false;
                _currentOre = null;
            }
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        DataBase.Instance.Fame = (int)(DataBase.Instance.Fame *1.3f);
        _finishPanel.SetActive(true);
    }
}
