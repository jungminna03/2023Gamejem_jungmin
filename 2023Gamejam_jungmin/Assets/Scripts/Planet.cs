using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public int _level;

    [SerializeField] int _price;
    [SerializeField] GameObject _buyButton;
    bool _onClicked = false;
    bool _onBuyed = false;
    
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

        if (_onBuyed == false)
        {
            _buyButton.SetActive(_onClicked);
        }
    }

    public void OnBuy()
    {
        if (_price > DataBase.Instance._money)
        {
            // TODO : µ∑ ∫Œ¡∑ UI
            Debug.Log("µ∑¿Ã ∫Œ¡∑«’¥œ¥Ÿ");
        }
        else
        {
            DataBase.Instance._level = _level;
        }
    }
}
