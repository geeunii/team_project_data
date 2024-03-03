using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject soundPanel;

    private bool isMenuOpen = false;

    private void Start()
    {
        Button menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OpenMenu);
    }

    private void OpenMenu()
    {
        menuPanel.SetActive(true);
        isMenuOpen = true;
    }

    public void SoundButton()
    {
        soundPanel.SetActive(true);
    }

    public void CloseSoundPanel()
    {
        soundPanel.SetActive(false);
    }

    public void MainButton()
    {
        menuPanel.SetActive(false);
        isMenuOpen = false;
        //SceneManager.LoadScene("Title");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (soundPanel.activeSelf)
            {
                soundPanel.SetActive(false);
            }
            else if (isMenuOpen)
            {
                menuPanel.SetActive(false);
                isMenuOpen = false;
            }
            else
            {
                menuPanel.SetActive(true);
                isMenuOpen = true;
            }
        }
    }
}


