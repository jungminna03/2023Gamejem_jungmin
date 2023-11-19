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
        if (DataBase.Instance.Level + 1 < _level)
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
            GetComponent<Image>().sprite = _clicked;
        }

        if (DataBase.Instance.Level < _level)
        {
            _buyButton.SetActive(_onClicked);
            _buyText = _buyButton.GetComponentInChildren<TextMeshProUGUI>();

            if (_buyText != null) 
                _buyText.text = "����: " + _price.ToString();
        }

        SoundManager.GetInstance.PlaySound(Define.Sound.PLANETSELECT);
    }

    public void OffClick()
    {
        _onClicked = false;
        GetComponent<Image>().sprite = _nonClicked;
        _buyButton.SetActive(false);
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
            DataBase.Instance.Level = _level;
            DataBase.Instance.Money -= _price;
            _buyButton.SetActive(false);
            SoundManager.GetInstance.PlaySound(Define.Sound.BuyButton);
            GetComponent<Image>().sprite = _nonClicked;
            MyOres.GetInstance.AddOre();
        }
    }


}
