using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText; 
    [SerializeField] TextMeshProUGUI _moneyText;

    [SerializeField] float _changeSpeed;
    [SerializeField] float _startTime = 0.5f;
    float _startTimeDelta;

    private void Awake()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        _moneyText = GameObject.Find("MoneyText").GetComponent <TextMeshProUGUI>();
    }

    void Update()
    {
        _startTimeDelta += Time.deltaTime;

        if(_startTimeDelta > _startTime)
        {

            _scoreText.text = ($"Score: {ScoreManager.Instance.GetScore()}");
            _moneyText.text = ($"Score: {Mathf.Lerp(DataBase.Instance._money, DataBase.Instance._money + ScoreManager.Instance.GetScore(), 5 / Time.deltaTime).ToString()}"); 
        }
    }

    private void OnEnable()
    {
        _scoreText.text = ($"Score : {ScoreManager.Instance.GetScore()}");
        _moneyText.text = ($"Money : {DataBase.Instance._money}");
        _startTimeDelta = 0;
        DataBase.Instance._money += ScoreManager.Instance.GetScore();
    }
}
