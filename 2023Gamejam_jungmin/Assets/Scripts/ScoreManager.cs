using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    static ScoreManager _instance;
    public static ScoreManager Instance { get { Init(); return _instance; } }

    [SerializeField] int _score = 0;

    [SerializeField] float _deadline ;
    [SerializeField] GameObject _gameOverButton;
    [SerializeField] TextMeshProUGUI _scoreText;

    public static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("ScoreManager");

            if (go == null)
            {
                go = new GameObject() { name = "ScoreManager" };
                go.AddComponent<ScoreManager>();
            }

            _instance = go.GetComponent<ScoreManager>();
        }
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = _score.ToString();
    }

    public int GetScore()
    {
        return _score;
    }
}
