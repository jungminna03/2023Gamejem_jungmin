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
    [SerializeField]
    private TextMeshProUGUI Text;

    public tutorialScripts[] ts = new tutorialScripts[0];

    public void StartScripts(int num)
    {
        StartCoroutine("PrintScripts", ts[num]);
    }

    IEnumerator PrintScripts(tutorialScripts dialogs)
    {
        foreach (var dialog in dialogs.Dialogs)
        {
            Debug.Log("dialog");
            Text.text = dialog;
            while (true)
            {
                yield return null;
                if (Input.GetMouseButtonDown(0))
                {
                    break;
                }
            }
        }
        Text.text = "";
       
    }
}
