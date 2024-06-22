using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private int timeToWait;
    
    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex == 0)
            StartCoroutine("WaitForTime");
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadOptionsMenu() => SceneManager.LoadScene("OptionsScreen");

    public void LoadNextScene()
    {
        if(currentSceneIndex >= 4)
            currentSceneIndex = 0;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadYouLose() => SceneManager.LoadScene("LoseScreen");

    public void Quit() => Application.Quit();
}
