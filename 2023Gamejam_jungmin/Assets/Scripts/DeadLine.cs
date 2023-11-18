using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    static ScoreManager _instance;


    [SerializeField] float _deadline;
    [SerializeField] GameObject _gameOverButton;

    [SerializeField] ParticleSystem particleObject;
    [SerializeField] Spawner spawner;

    GameObject checkob;
    private void Update()
    {
        Ore[] ores = FindObjectsOfType<Ore>();
        foreach (Ore o in ores)
        {
            if (o.transform.position.y> _deadline &&
                FindObjectOfType<InputHandler>()._currentOre!= o.gameObject)
            {
                CheckEndGame(o);
            }
        }
    }
    public void CheckEndGame(Ore o)
    {
        if (o.gameObject == checkob)
            return;
        if (checkob != null)
            return;
        checkob = o.gameObject;
        DataBase.Instance.Fame = (int)Mathf.Min(DataBase.Instance.Fame ,1.3f);
        StartCoroutine("isOnParticle");
        
    }

    private IEnumerator isOnParticle()
    {
        particleObject.gameObject.SetActive(true);
        while (true)
        {
            if (checkob.transform.position.y < _deadline)
            {
                StopCoroutine("isOnParticle");
                particleObject.gameObject.SetActive(false);
                break;
            }
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
