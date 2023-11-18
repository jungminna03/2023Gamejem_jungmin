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
    [SerializeField] Sprite _clickecd;
    [SerializeField] Sprite _nonClicked;
    
    bool _onClicked = false;

    private Text _buyText;

    
    void Start()
    {
        _buyButton.SetActive(false);
        _buyText = _buyButton.GetComponentInChildren<Text>();
        _buyText.fontSize = 18;
        _buyText.text = "가격: " + _price.ToString();
    }

    private void Update()
    {
        if (DataBase.Instance._level + 1 < _level)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void OnClicked()
    {
        if (_onClicked)
        {
            _onClicked = false;
            GetComponent<Image>().sprite = _nonClicked;
        }
        else
        {
            _onClicked = true;
            GetComponent<Image>().sprite = _clickecd;
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
            // TODO : 돈 부족 UI
            Debug.Log("돈이 부족합니다");
            SoundManager.GetInstance.PlaySound(Define.Sound.Error);
        }
        else
        {
            DataBase.Instance._level = _level;
            DataBase.Instance.Money -= _price;
            _buyButton.SetActive(false);
            SoundManager.GetInstance.PlaySound(Define.Sound.BuyButton);
            GetComponent<Image>().sprite = _nonClicked;
        }
    }


}
