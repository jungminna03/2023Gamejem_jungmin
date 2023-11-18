using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] GameObject ContinuePanel;
    public void PauseGame()
    {
        SoundManager.GetInstance.PlaySound(Define.Sound.PauseButton);
        Time.timeScale = 0f;
        ContinuePanel.SetActive(true);
    }
}
