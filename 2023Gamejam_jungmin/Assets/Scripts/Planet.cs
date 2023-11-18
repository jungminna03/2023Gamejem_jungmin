using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public int _level;

    [SerializeField] int _price;
    [SerializeField] GameObject _buyButton;
    bool _onClicked = false;

    private Text _buyText;
    
    void Start()
    {
        _buyButton.SetActive(false);
        _buyText = _buyButton.GetComponentInChildren<Text>();
        _buyText.fontSize = 18;
        _buyText.text = "����: " + _price.ToString();
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

        SoundManager.GetInstance.PlaySound(Define.Sound.PLANETSELECT);
    }

    public void OnBuy()
    {
        if (_price > DataBase.Instance.Money)
        {
            // TODO : �� ���� UI
            Debug.Log("���� �����մϴ�");
            SoundManager.GetInstance.PlaySound(Define.Sound.Error);
        }
        else
        {
            DataBase.Instance._level = _level;
            DataBase.Instance.Money -= _price;
            _buyButton.SetActive(false);
            SoundManager.GetInstance.PlaySound(Define.Sound.BuyButton);
        }
    }


}
