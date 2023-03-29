using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] TMP_Text scoreText;

    private int score = 0;
    private int scoreSinceDeath = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int points)
    {
        scoreSinceDeath += points;

        UpdateScore();
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScores()
    {
        score = 0;
        scoreSinceDeath = 0;

        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = scoreSinceDeath.ToString();
    }

    public void PlayerDied()
    {
        // Reset score since death
        scoreSinceDeath = score;

        UpdateScore();

        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        // Check if player has fallen off the map
        if (CharacterController.Instance && CharacterController.Instance.transform.position.y < -10f)
        {
            PlayerDied();
        }
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            // No more scenes in build order, go back to first scene
            nextSceneIndex = 0;
        }

        score = scoreSinceDeath;

        SceneManager.LoadScene(nextSceneIndex);
    }
}