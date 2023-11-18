using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryDialog : MonoBehaviour
{
    [System.Serializable]
    public struct DialogsTime
    {
        public float time;
        public string dialog;
        public int way;
    }
    [SerializeField]
    DialogsTime[] dialogs=new DialogsTime[0];

    [SerializeField]
    TextMeshProUGUI textMeshPro;
    Animator anim;
    int m_way = 0;

    private void Start()
    {
        anim=GetComponent<Animator>();
        StartDialog(m_way++);
    }

    public void StartDialog(int num)
    {
        StartCoroutine("printDialog", dialogs[num]);
    }
    
    IEnumerator printDialog(DialogsTime dialogtime)
    {
        if (dialogtime.way!=0)
            anim.SetInteger("Way", dialogtime.way);

        foreach(var d  in dialogtime.dialog)
        {
            textMeshPro.text += d;
            yield return new WaitForSeconds(dialogtime.time);
        }
        yield return new WaitForSeconds(0.5f);
        Color c = textMeshPro.color;
        while (true)
        {
            yield return null;
            c.a -= Time.deltaTime;
            textMeshPro.color = c;
            if (c.a <= 0)
            {
             
                break;
            }
        }
        textMeshPro.text = "";
        c.a = 1;
        textMeshPro.color = c;
        if (m_way != dialogs.Length)
        StartDialog(m_way++);
        

    }


}
