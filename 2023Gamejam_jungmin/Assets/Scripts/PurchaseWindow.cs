using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseWindow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _planetNameText;
    [SerializeField] Image _planetImage;
    [SerializeField] TextMeshProUGUI _buyText;
    [SerializeField] TextMeshProUGUI _sellText;
    [SerializeField] TextMeshProUGUI _goldText;
    [SerializeField] TextMeshProUGUI _countText;
    PlayerInfo _playerInfo;
    Planet _currentPlanet;

    public int _buyPrice;
    public int _sellPrice;
    public int _buyCount;
    public int _sellCount;

    string _planetName;

    private void Awake()
    {
        _playerInfo = FindObjectOfType<PlayerInfo>();
    }
    /*public void BuyAdd(int num)
    {
        if (buyCount + num < 1) return;
        buyCount += num;
        for (int i = 0; i < 10; i++)
        {
            PlanetSet p = FindObjectOfType<PlanetSetting>().planets[i];
            if (p.planetName.ToString() == _planetNameText.text)
            {
                if (FindObjectOfType<PlanetSetting>().gold - buyCount * p.Price < 0)
                {
                    buyCount -= num;
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("구매할 돈이 없습니다!!");
                    return;
                }

                if (p.Count + buyCount >= 99)
                {
                    buyCount = 100 - p.Count;
                    _buyText.text = $"구매: {buyCount}";
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("최대로 살 수 있는 갯수입니다!!");
                    return;
                }
                _buyText.text = $"구매: {buyCount}";
            }
        }
    }
    public void SellAdd(int num)
    {
        if (sellCount + num < 1) return;
        sellCount += num;
        for (int i = 0; i < 10; i++)
        {
            PlanetSet p = FindObjectOfType<PlanetSetting>().planets[i];
            if (p.planetName.ToString() == _planetNameText.text)
            {
                if (p.Count - sellCount < 1)
                {
                    sellCount = p.Count - 1;
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("최대로 판매 할 수 있는 갯수입니다!!");
                    Debug.Log("최대 판매 갯수");
                    if (sellCount <= 0)
                        sellCount = 1;
                    _sellText.text = $"판매: {sellCount}";
                    return;
                }
                _sellText.text = $"판매: {sellCount}";
            }
        }
    }*/
    public void BuyPlanet()
    {
        for (int i = 0; i < FindObjectOfType<PlayerInfo>().planets.Length; i++)
        {
            PlayerInfo.PlanetInfo planetInfo = FindObjectOfType<PlayerInfo>().planets[i];
            if (planetInfo.Name.ToString() == _planetNameText.text)
            {
                if (i != 0 && FindObjectOfType<PlayerInfo>().planets[i - 1].Count == 0)
                {
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("이전 행성을 사야합니다!!");
                    return;
                }

                planetInfo.Count += _buyCount;
                _countText.text = $"{planetInfo.Count}개";
                FindObjectOfType<PlayerInfo>().Gold -= _buyCount * _currentPlanet.BuyPrice;
                _goldText.text = $"{FindObjectOfType<PlayerInfo>().Gold}$";

                _buyCount = 1;
                _buyText.text = $"구매: {_buyCount}";
            }
        }
    }
    public void SellPlanet()
    {
        for (int i = 0; i < FindObjectOfType<PlayerInfo>().planets.Length; i++)
        {
            PlayerInfo.PlanetInfo planetInfo = FindObjectOfType<PlayerInfo>().planets[i];
            if (planetInfo.Name.ToString() == _planetNameText.text)
            {
                FindObjectOfType<PlayerInfo>().planets[i].Count -= _sellCount;
                _countText.text = $"{planetInfo.Count}개";
                FindObjectOfType<PlayerInfo>().Gold += _sellCount * _currentPlanet.SellPrice;
                _goldText.text = $"{FindObjectOfType<PlayerInfo>().Gold}$";

                _sellCount = 1;
                _sellText.text = $"판매: {_sellCount}";
            }
        }
    }

    public void ChangePurchaseCount(int count)
    {
        if (_buyCount + count > 0 && _buyCount + count < 99)
        {
            _buyCount += count;
        }
        else if(_buyCount + count >= 99)
        {
            _buyCount = 99;
        }
        else if(_buyCount + count <= 0)
        {
            _buyCount = 0;
        }
        else if(_buyCount == 99)
        {
            FindObjectOfType<ErrorIMG>().PrintErrorMessage("최대로 살 수 있는 갯수입니다!!");
        }
        else if(_buyCount == 0)
        {
            return;
        }

        _buyText.text = $"구매: {_buyCount}";
    }
    public void ChangeSellCount(int count)
    {
        for (int i = 0; i < FindObjectOfType<PlayerInfo>().planets.Length; i++)
        {
            PlayerInfo.PlanetInfo planetInfo = FindObjectOfType<PlayerInfo>().planets[i];
            if (planetInfo.Name.ToString() == _planetNameText.text)
            {
                if (_buyCount + count > 0 && _buyCount + count < planetInfo.Count)
                {
                    _buyCount += count;
                }
                else if (_buyCount + count >= planetInfo.Count)
                {
                    _buyCount = planetInfo.Count;
                }
                else if (_buyCount + count <= 0)
                {
                    _buyCount = 0;
                }
                else if (_buyCount == planetInfo.Count)
                {
                    FindObjectOfType<ErrorIMG>().PrintErrorMessage("최대로 팔 수 있는 갯수입니다!!");
                }
                else if (_buyCount == 0)
                {
                    return;
                }

                break;
            }
        }

        _buyText.text = $"판매: {_sellCount}";
    }

    public void GetInfo(Planet planet)
    {
        _currentPlanet = planet;
        _playerInfo = FindObjectOfType<PlayerInfo>();

        _planetName = _currentPlanet.planetName;
        _planetNameText.text = _planetName;
        _planetImage = _currentPlanet.PlanetImage;
        _buyPrice = _currentPlanet.BuyPrice;
        _buyText.text = _sellPrice.ToString();
        _sellPrice = _currentPlanet.SellPrice;
        _sellText.text = _planetName.ToString();

        _goldText.text = _playerInfo.Gold.ToString();

        foreach (PlayerInfo.PlanetInfo playerPlanes in _playerInfo.planets)
        {
            if(playerPlanes.Name == planet.name)
            {
                _countText.text = playerPlanes.Count.ToString();
            }
        }
       
        _buyCount = 1;
        _sellCount = 1;
        _buyText.text = $"구매: {_buyCount}";
        _sellText.text = $"판매: {_sellCount}";
    }
}