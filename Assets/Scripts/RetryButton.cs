using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void RestartGame()
    {
        int previousScore = PlayerPrefs.GetInt("PreviousScore");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("PreviousScore", previousScore);
        PlayerPrefs.Save();
    }
}


