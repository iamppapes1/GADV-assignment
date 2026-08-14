using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenHandling : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("GameplayScene");
        Time.timeScale = 1;
    }

    public void ToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
