using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameStartButton : MonoBehaviour
{
    public GameObject menuPanel;

    public void OnResumeButtonClicked()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
    }

    public void OnMenuButtonClicked()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
        SceneManager.LoadScene("MainGame");
    }
}