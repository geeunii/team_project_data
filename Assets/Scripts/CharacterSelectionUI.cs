using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionUI : MonoBehaviour
{
    public Button dogSelectButton;
    public Button catSelectButton;
    public Button startButton;
    public GameObject characterSelectionUI; // 캐릭터 선택 UI 창을 나타내는 게임 오브젝트

    private string selectedCharacter;

    private void Start()
    {
        dogSelectButton.onClick.AddListener(SelectDogCharacter);
        catSelectButton.onClick.AddListener(SelectCatCharacter);
        startButton.onClick.AddListener(StartGame);
    }

    private void SelectDogCharacter()
    {
        selectedCharacter = "dog";
        CloseCharacterSelectionUI();
    }

    private void SelectCatCharacter()
    {
        selectedCharacter = "cat";
        CloseCharacterSelectionUI();
    }

    private void StartGame()
    {
        if (selectedCharacter == "dog")
        {
            SceneManager.LoadScene("MainGame");
        }
        else if (selectedCharacter == "cat")
        {
            SceneManager.LoadScene("MainGameCat");
        }
    }

    private void CloseCharacterSelectionUI()
    {
        characterSelectionUI.SetActive(false); // UI 창을 비활성화하여 닫음
    }
}

