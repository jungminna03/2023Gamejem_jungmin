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
    [SerializeField]
    int TutorialSceneNum;
    private void Start()
    {
        Invoke("StartTutorial", 0.5f);
    }

    private void StartTutorial()
    {
        if (TutorialSceneNum == 1 && DataBase.Instance._tutorial1_check == false)
            StartScripts(0);
        if (TutorialSceneNum == 2 && DataBase.Instance._tutorial2_check == false)
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
    public void CheckTutorial(int num)
    {
        if (num == 1)
        {
            DataBase.Instance._tutorial1_check = true;
        }
        else if( num == 2)
        {
            DataBase.Instance._tutorial2_check = true;
        }
    }
    public void StopDialog()
    {
        Text.text = "";
        TextIMG.SetActive(false);
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
