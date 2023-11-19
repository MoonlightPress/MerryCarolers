using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string SceneName;

    public void LoadScene()
    {
        if (FMODUnity.RuntimeManager.HaveAllBanksLoaded)
        {
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
        }
        else
        {
            Debug.Log("Failed to load FMOD banks");
        }
    }
}
