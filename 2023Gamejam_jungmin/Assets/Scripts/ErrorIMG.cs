using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorIMG : MonoBehaviour
{
    [SerializeField]
    private Image Errorimg;
    [SerializeField]
    private TextMeshProUGUI Errortext;

    public void PrintErrorMessage(string message)
    {
        Errorimg.gameObject.SetActive(true);
        Errortext.text = message;
        StartCoroutine("ErrorimgFadeOut");
    }

    IEnumerator ErrorimgFadeOut()
    {
        float parcent = 0;
        Color c1 = Errorimg.color;
        Color c2 = Errortext.color;

        while (parcent<1)
        {
            parcent += Time.deltaTime;
            c1.a -= Time.deltaTime;
            c2.a -= Time.deltaTime;
            Errorimg.color = c1;
            Errortext.color = c2;
            yield return null;
        }
        
        Errorimg.gameObject.SetActive(false);
        c1.a = 1;
        c2.a = 1;
        Errorimg.color = c1;
        Errortext.color = c2;
    }
}
