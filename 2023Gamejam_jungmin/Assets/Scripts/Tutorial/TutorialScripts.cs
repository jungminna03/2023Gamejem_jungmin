using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialScripts : MonoBehaviour
{
    [System.Serializable]
    public class tutorialScripts
    {
        public string[] Dialogs = new string[0];
    }

    public tutorialScripts[] ts = new tutorialScripts[0];
    private int TutorialNum = 0;
    private bool isRun = false;
    private void Awake()
    {
        StartScripts(TutorialNum);
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.F) && !isRun)
        {
            Debug.Log("A");
            
        }
    }
    public void StartScripts(int num)
    {
        Debug.Log("StartSCripts()");
        StartCoroutine("PrintScripts", ts[num]);
    }

    IEnumerator PrintScripts(tutorialScripts dialogs)
    {
        isRun = true;
        foreach (var dialog in dialogs.Dialogs)
        {
            Debug.Log("dialog");
            GetComponent<TextMeshProUGUI>().text = dialog;
            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    break;
                }
            }
        }
        TutorialNum++;
        isRun = false;
        yield return null;
    }
}
