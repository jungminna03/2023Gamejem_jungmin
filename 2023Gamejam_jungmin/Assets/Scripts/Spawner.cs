using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    InputHandler _inputHandler;
    [SerializeField] float _spawnWaitTime = 0.5f;

    [SerializeField] GameObject _currnetOre;

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
        GameObject go = Instantiate(_currnetOre, gameObject.transform);
        _inputHandler._currentOre = go;

        yield return null;
    }
}
