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
        public GameObject CheckBox;
    }
    [SerializeField]
    private TextMeshProUGUI Text;
    [SerializeField]
    private GameObject TextIMG;
    public tutorialScripts[] ts = new tutorialScripts[0];
    bool nextDialog = false;
    private void Start()
    {
        StartScripts(0);
    }
    public void StartScripts(int num)
    {
        StartCoroutine("PrintScripts", ts[num]);
    }
    public void NextDialog()
    {
        nextDialog = true;
    }
    public void StopDialog()
    {
        StopCoroutine("PrintScripts");
    }
    IEnumerator PrintScripts(tutorialScripts dialogs)
    {
        TextIMG.SetActive(true);
        dialogs.CheckBox.SetActive(true);
        foreach (var dialog in dialogs.Dialogs)
        {
            Text.text = dialog;
            while (true)
            {
                yield return null;
                if(nextDialog)
                {
                    nextDialog= false;
                    break;
                }
            }
        }
        Text.text = "";
        TextIMG.SetActive(false);
    }
}
