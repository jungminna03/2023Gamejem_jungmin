using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static ScoreManager _instance;
    public static ScoreManager Instance { get { Init(); return _instance; } }

    [SerializeField] int _score = 0;

    [SerializeField] float _deadline ;
    [SerializeField] GameObject _gameOverButton;

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
    }

    public int GetScore()
    {
        return _score;
    }

    public void CheckEndGame(float y)
    {
        if (y > _deadline)
        {
            _score *= -1;
            DataBase.Instance._fame = (int)Mathf.Min(DataBase.Instance._fame * 1.3f);
            _gameOverButton.SetActive(true);
        }
    }
}
