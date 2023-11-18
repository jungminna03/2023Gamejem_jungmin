using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    static DataBase _instance;
    public static DataBase Instance { get { Init(); return _instance; } }

    public int _level = 1;
    [SerializeField] int _fame = 100;
    [SerializeField] int _money = 100;
    public bool _tutorial1_check=false;
    public bool _tutorial2_check = false;

    public int Fame
    {
        get { return _fame; }
        set
        {
            _fame = value;
            if (_fame > 15000)
                _fame = 15000;
            else if (_fame < 0)
                _fame = 0;
        }
    }
    public int Money
    {
        get { return _money; }
        set
        {
            _money = value;
            if (_money > int.MaxValue)
                _money = int.MaxValue;
            else if (_money < 0)
                _money = 0;
        }
    }

    void Start()
    {
        Init();
    }

    public static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("DataBase");
            
            if (go == null)
            {
                go = new GameObject() { name = "DataBase" };
                go.AddComponent<DataBase>();
            }

            DontDestroyOnLoad(go);
            _instance = go.GetComponent<DataBase>();
        }
    }
}
