using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void FixedUpdate()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Win" || currentScene.name == "GameOver")
        {
            StartCoroutine(WaitSwitchScene(5f));
        }
    }

    private IEnumerator WaitSwitchScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartMenu();
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}