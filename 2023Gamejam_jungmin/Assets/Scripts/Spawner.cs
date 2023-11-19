using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    InputHandler _inputHandler;
    [SerializeField] float _spawnWaitTime = 0.5f;

    [SerializeField] GameObject _currnetOre;
    [SerializeField] GameObject _nextOre;

    [SerializeField] GameObject[] _ableOres;

    [SerializeField] Image _nextOreImage;
    
    float _currentTime = 0;

    bool _stopSpawn = false;
    bool _endSpawn = false;
    private void Awake()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
    }

    private void Update()
    {
        if (_currentTime >= _spawnWaitTime && _stopSpawn == false && _endSpawn == false)
        {
            _currnetOre = _nextOre;
            _nextOre = RandomOre();
            _nextOreImage.sprite = _nextOre.GetComponent<SpriteRenderer>().sprite;

            if (_currnetOre != null)
            {
                GameObject go = Instantiate(_currnetOre, gameObject.transform);
                SoundManager.GetInstance.PlaySound(Define.Sound.ItemSpawn);
                _inputHandler._currentOre = go;

                _currentTime = 0;
                _stopSpawn = true;
            }
        }

        _currentTime += Time.deltaTime;
    }

    GameObject RandomOre()
    {
        int rand = 100 / DataBase.Instance.Level;
        int weight = rand;

        for (int i = 0; i < DataBase.Instance.Level; ++i)
        {
            if (weight > Random.Range(0, 100))
                return _ableOres[i];

            weight += rand;
        }

        return null;
    }

    public void Respawn()
    {
        _stopSpawn = false;
        _currentTime = 0;
    }

    public void StopSpawn()
    {
        _endSpawn = true;
        _currentTime = 0;
    }
}
