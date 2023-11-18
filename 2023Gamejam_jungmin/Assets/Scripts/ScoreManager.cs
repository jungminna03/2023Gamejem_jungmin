using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    static ScoreManager _instance;
    public static ScoreManager Instance { get { Init(); return _instance; } }

    [SerializeField] int _score = 0;

    [SerializeField] float _deadline ;
    [SerializeField] GameObject _gameOverButton;
    [SerializeField] Text _scoreText;

    [SerializeField] ParticleSystem particleObject;
    [SerializeField] Spawner spawner;

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

    public void CheckEndGame(float y)
    {
        if (y > _deadline)
        {
            _score *= -1;
            DataBase.Instance.Fame = (int)Mathf.Min(DataBase.Instance.Fame * 1.3f);
            StartCoroutine("isOnParticle");
        }
        else
        {
            StopCoroutine("isOnParticle");
            particleObject.gameObject.SetActive(false);
        }
    }

    private IEnumerator isOnParticle()
    {
        particleObject.gameObject.SetActive(true);
        while (true)
        {
            if (particleObject.IsAlive() == false)
            {
                spawner.StopSpawn();
                _gameOverButton.gameObject.SetActive(true); 
                break;
            }
            yield return null;
        }
    }
}
