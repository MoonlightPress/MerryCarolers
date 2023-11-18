using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string SceneName;

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(SceneName);
    }
}
