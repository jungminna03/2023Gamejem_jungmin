using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Lobby : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _currentMoney;
    [SerializeField] TextMeshProUGUI _objCount;

    private void Update()
    {
        _currentMoney.text = $"{DataBase.Instance.Money}";
        _objCount.text = $"{DataBase.Instance.Fame}";
    }
}
