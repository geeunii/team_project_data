using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionUI : MonoBehaviour
{
    public Button dogSelectButton;
    public Button catSelectButton;
    public Button startButton;
    public GameObject characterSelectionUI; // ĳ���� ���� UI â�� ��Ÿ���� ���� ������Ʈ

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
        characterSelectionUI.SetActive(false); // UI â�� ��Ȱ��ȭ�Ͽ� ����
    }
}

