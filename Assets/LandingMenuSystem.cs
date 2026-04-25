using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingMenuController : MonoBehaviour
{
    public TMP_InputField nameInput;
    public string gameSceneName = "GameScene";
    public string highScoreSceneName = "HighScoreScene";

    public void StartNewGame()
    {
        string playerName = nameInput != null ? nameInput.text.Trim() : "";

        if (string.IsNullOrEmpty(playerName))
            playerName = "Unknown";

        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenHighScores()
    {
        SceneManager.LoadScene(highScoreSceneName);
    }

    public void LoadSavedGame()
    {
        string playerName = nameInput != null ? nameInput.text.Trim() : "";

        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}