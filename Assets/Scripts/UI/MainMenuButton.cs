using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OnPress()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
