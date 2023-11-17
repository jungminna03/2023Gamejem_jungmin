using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePanel : MonoBehaviour
{
    public void OnContinueButton()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}
