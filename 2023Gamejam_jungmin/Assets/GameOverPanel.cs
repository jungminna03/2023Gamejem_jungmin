using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText; 
    [SerializeField] TextMeshProUGUI _moneyText;

    [SerializeField] float _targetPos = 500;
    [SerializeField] float _moneySpeed = 1;
    [SerializeField] float _panelSpeed = 0.3f;
    [SerializeField] float _startTime = 0.5f;
    float _startTimeDelta;
    float _changeTimeDelta;

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
        float y = Mathf.Lerp(transform.position.y, _targetPos, _startTimeDelta * _panelSpeed);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        if (_startTimeDelta > _startTime)
        {
            _changeTimeDelta += Time.deltaTime;
            _scoreText.text = ($"Score: {(int)Mathf.Lerp(_currentScore, 0, _changeTimeDelta * _moneySpeed)}");
            _moneyText.text = ($"Money: {(int)Mathf.Lerp(_currentMoney, _currentMoney + _currentScore, _changeTimeDelta * _moneySpeed)}");
        }
    }

    private void OnEnable()
    {
        _scoreText.text = ($"Score : {ScoreManager.Instance.GetScore()}");
        _moneyText.text = ($"Money : {DataBase.Instance.Money}");
        _startTimeDelta = 0;
    }
}
