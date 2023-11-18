using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    private void OnEnable()
    {
        SoundManager.GetInstance.PlaySound(Define.Sound.Settlement);
    }
    public void LoadLobbyScene()
    {
        // SoundManager.GetInstance.PlaySound(Define.Sound.Start);
        gameObject.SetActive(false);
        SceneManager.LoadScene((int)Define.Scenes.Lobby);
        Time.timeScale = 1.0f;
    }
}
