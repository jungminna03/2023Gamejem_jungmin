using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void OnLobbyButton()
    {
        SoundManager.GetInstance.PlaySound(Define.Sound.Start);
        SceneManager.LoadScene((int)Define.Scenes.Lobby);
    }

    public void OnInGame()
    {
        SoundManager.GetInstance.PlaySound(Define.Sound.Start);
        SceneManager.LoadScene((int)Define.Scenes.Ingame);
    }
}