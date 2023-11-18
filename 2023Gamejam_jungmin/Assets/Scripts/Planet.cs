using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public int _level;

    [SerializeField] int _price;
    public GameObject _buyButton;
    [SerializeField] Sprite _clicked;
    [SerializeField] Sprite _nonClicked;
    
    [HideInInspector]
    public bool _onClicked = false;

    private TextMeshProUGUI _buyText;

    void Start()
    {
        _buyButton.SetActive(false);
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
        GetComponentInParent<PlanetSelector>().FindOnClicked();
        if (_onClicked)
        {
            _onClicked = false;
            GetComponent<Image>().sprite = _nonClicked;
        }
        else
        {
            _onClicked = true;
            GetComponent<Image>().sprite = _clicked;
        }

        if (DataBase.Instance._level < _level)
        {
            _buyButton.SetActive(_onClicked);
            _buyText = _buyButton.GetComponentInChildren<TextMeshProUGUI>();
            _buyText.text = "가격: " + _price.ToString();
        }

        SoundManager.GetInstance.PlaySound(Define.Sound.PLANETSELECT);
    }

    public void OffClick()
    {
        _onClicked = false;
        GetComponent<Image>().sprite = _nonClicked;
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
            MyOres.GetInstance.AddOre();
        }
    }


}
