using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private string inGameSceneName = "";
    [SerializeField]
    private string LobbySceneName = "";

    public void OnStartButton()
    {
        SceneManager.LoadScene(LobbySceneName);
    }

    public void OnLobbyButton()
    {
        SceneManager.LoadScene(LobbySceneName);
    }

    public void OnInGame()
    {
        SceneManager.LoadScene(inGameSceneName);
    }
}
