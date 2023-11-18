using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    InputHandler _inputHandler;
    [SerializeField] float _spawnWaitTime = 0.5f;

    [SerializeField] GameObject _currnetOre;
    [SerializeField] GameObject _nextOre;

    [SerializeField] GameObject[] _ableOres;

    private void Awake()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
    }
    private void Start()
    {
        StartCoroutine(FirstSpawnOre());
    }
    public IEnumerator SpawnOre()
    {
        yield return new WaitForSeconds(_spawnWaitTime);

        _currnetOre = _nextOre;
        _nextOre = RandomOre();

        GameObject go = Instantiate(_currnetOre, gameObject.transform);
        _inputHandler._currentOre = go;

        yield return null;
    }

    public IEnumerator FirstSpawnOre()
    {
        yield return new WaitForSeconds(_spawnWaitTime);

        _currnetOre = RandomOre();
        _nextOre = RandomOre();

        GameObject go = Instantiate(_currnetOre, gameObject.transform);
        _inputHandler._currentOre = go;

        yield return null;
    }

    GameObject RandomOre()
    {
        int rand = 100 / DataBase.Instance._level;
        int weight = rand;

        for (int i = 0; i < DataBase.Instance._level; ++i)
        {
            if (weight > Random.Range(0, 100))
                return _ableOres[i];

            weight += rand;
        }

        return null;
    }
}
