using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Lobby : MonoBehaviour
{
    [SerializeField] Text _currentMoney;
    [SerializeField] Text _objCount;

    private void Update()
    {
        _currentMoney.text = $"$ {DataBase.Instance._money}";
        _objCount.text = $"¸í¼º : {DataBase.Instance._fame}";
    }
}
