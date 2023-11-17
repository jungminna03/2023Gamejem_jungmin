using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void OnLobbyButton()
    {
        SceneManager.LoadScene((int)Define.Scenes.Lobby);
    }

    public void OnInGame()
    {
        SceneManager.LoadScene((int)Define.Scenes.Ingame);
    }
}
