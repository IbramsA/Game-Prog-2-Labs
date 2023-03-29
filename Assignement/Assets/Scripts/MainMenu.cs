using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text scoreText;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;

        if (scoreText)
            scoreText.text = $"Final Score\n{GameManager.Instance.GetScore()}";
    }

    public void ResetGame()
    {
        GameManager.Instance.ResetScores();
        GameManager.Instance.LoadNextScene();
    }

    public void StartGame()
    {
        GameManager.Instance.LoadNextScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}