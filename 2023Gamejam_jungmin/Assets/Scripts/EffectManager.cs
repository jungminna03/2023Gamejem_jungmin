using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;
    [SerializeField] GameObject[] _effectList;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static EffectManager GetInstance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public void PlayEffect(Define.Effect effect, Vector3 position)
    {
        Instantiate(_effectList[(int)effect], position, new Quaternion(0, 0, 0, 0));
    }
}
