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

    int _currentScore;
    int _currentMoney;

    private void Awake()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        _moneyText = GameObject.Find("MoneyText").GetComponent <TextMeshProUGUI>();

        _currentScore = ScoreManager.Instance.GetScore();
        _currentMoney = DataBase.Instance.Money;

        DataBase.Instance.Money += _currentScore;
    }

    void Update()
    {
        _startTimeDelta += Time.deltaTime;

        if(_startTimeDelta > _startTime)
        {
            _scoreText.text = ($"Score: {(int)Mathf.Lerp(_currentScore, 0, _startTimeDelta)}");
            _moneyText.text = ($"Money: {(int)Mathf.Lerp(_currentMoney, _currentMoney + _currentScore, _startTimeDelta)}"); 
        }
    }

    private void OnEnable()
    {
        _scoreText.text = ($"Score : {ScoreManager.Instance.GetScore()}");
        _moneyText.text = ($"Money : {DataBase.Instance.Money}");
        _startTimeDelta = 0;
    }
}
