using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    InputHandler _inputHandler;
    [SerializeField] float _spawnWaitTime = 0.5f;

    [SerializeField] GameObject _currnetOre;

    [SerializeField] GameObject[] _ableOres;

    private void Awake()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
    }
    private void Start()
    {
        StartCoroutine(SpawnOre());
    }
    public IEnumerator SpawnOre()
    {
        yield return new WaitForSeconds(_spawnWaitTime);

        _currnetOre = RendomOre();

        GameObject go = Instantiate(_currnetOre, gameObject.transform);
        _inputHandler._currentOre = go;

        yield return null;
    }

    public GameObject RendomOre()
    {
        int rand = 100 / _ableOres.Length;
        int weight = rand;

        for (int i = 0; i < _ableOres.Length; ++i)
        {
            if (weight > Random.Range(0, 100))
                return _ableOres[i];

            weight += rand;
        }

        return null;
    }
}
