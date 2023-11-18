using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public int _level;

    [SerializeField] int _price;
    [SerializeField] GameObject _buyButton;
    bool _onClicked = false;
    
    void Start()
    {
        _buyButton.SetActive(false);
    }

    public void OnClicked()
    {
        if (_onClicked)
        {
            _onClicked = false;
        }
        else
        {
            _onClicked = true;
        }

        if (DataBase.Instance._level < _level)
        {
            _buyButton.SetActive(_onClicked);
        }
    }

    public void OnBuy()
    {
        if (_price > DataBase.Instance._money)
        {
            // TODO : �� ���� UI
            Debug.Log("���� �����մϴ�");
        }
        else
        {
            DataBase.Instance._level = _level;
            DataBase.Instance._money -= _price;
            _buyButton.SetActive(false);
        }
    }
}
