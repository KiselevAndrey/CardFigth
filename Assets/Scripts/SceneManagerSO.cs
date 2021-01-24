using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneManager")]
public class SceneManagerSO : ScriptableObject
{
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadScene(Object scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
