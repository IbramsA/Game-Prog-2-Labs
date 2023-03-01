using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
// Write down your variables here
    public float Score=0;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void IncrementScore()
    {
        Score += 1;
        if ( Score == 3)
        {
            Debug.Log("You win !");
            SceneManager.LoadScene("EmptyScene");
        }
    }
}
