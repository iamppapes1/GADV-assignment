using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenHandling : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void ToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
