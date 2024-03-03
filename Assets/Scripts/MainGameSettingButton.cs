using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameSettingButton : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject soundPanel;

    private bool isPaused = false;
    private float savedTimeScale = 1.5f; // 일시정지 전의 Time.timeScale 값

    private void Start()
    {
        Button menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OpenMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

            if (soundPanel.activeSelf)
            {
                soundPanel.SetActive(false);
            }
        }
    }

    private void OpenMenu()
    {
        menuPanel.SetActive(true);
    }

    private void PauseGame()
    {
        //Time.timeScale = 0f;
        isPaused = true;
        menuPanel.SetActive(true);
        savedTimeScale = Time.timeScale; // 일시정지 전의 Time.timeScale 값을 저장
        Time.timeScale = 0.0f;

    }

    private void ResumeGame()
    {
        if (savedTimeScale > 0)
        {
            Time.timeScale = savedTimeScale; // 일시정지 전의 Time.timeScale 값을 불러옴
        }

        isPaused = false;
        menuPanel.SetActive(false);
    }

    public void MainButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }

    public void OnMainButtonClicked()
    {
        MainButton();
    }

    public void OnPauseButtonClicked()
    {
        PauseGame();
    }

    public void OnSoundButtonClicked()
    {
        soundPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    // sound

    public void SoundButton()
    {
        soundPanel.SetActive(true);
    }

    public void CloseSoundPanel()
    {
        soundPanel.SetActive(false);
    }
}