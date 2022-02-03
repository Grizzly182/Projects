using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlaySingle() {
        SceneManager.LoadScene("1PlayerScene");
        SceneManager.UnloadSceneAsync("Menu");
        Time.timeScale = 1;
        CameraRect.CorrectResolution();
    }

    public void PlayMulti() {
        SceneManager.LoadScene("2PlayersScene");
        SceneManager.UnloadSceneAsync("Menu");
        Time.timeScale = 1;
        CameraRect.CorrectResolution();
    }

    public void PlayTraining() {

    }
}