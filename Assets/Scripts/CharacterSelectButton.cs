using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectButton : MonoBehaviour
{
    public GameObject characterSelectPanel;
    public Button mainButton;

    private void Start()
    {
        Button characterSelectButton = GetComponent<Button>();
        characterSelectButton.onClick.AddListener(OpenCharacterSelectPanel);

        mainButton.onClick.AddListener(CloseCharacterSelectPanel);
    }

    private void OpenCharacterSelectPanel()
    {
        characterSelectPanel.SetActive(true);
    }

    private void CloseCharacterSelectPanel()
    {
        characterSelectPanel.SetActive(false);
    }
}

