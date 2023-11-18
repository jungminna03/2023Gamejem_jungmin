using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    static DataBase _instance;
    public static DataBase Instance { get { Init(); return _instance; } }

    public int _level = 1;
    public int _fame = 100;
    public int _money = 100;

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
