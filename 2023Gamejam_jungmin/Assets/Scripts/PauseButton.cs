using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] GameObject ContinuePanel;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        ContinuePanel.SetActive(true);
    }
}
