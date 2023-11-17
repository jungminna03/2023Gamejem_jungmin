using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    public void LoadLobbyScene()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene((int)Define.Scenes.Lobby);
    }
}
