using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    public void switchScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}