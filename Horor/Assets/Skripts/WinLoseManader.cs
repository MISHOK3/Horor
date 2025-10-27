using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinLoseManader : MonoBehaviour
{
   
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        if (PlayerPrefs.HasKey("posX"))
        {
            
        }
    }

    public void GoBackMenu()
    {
        if (PlayerPrefs.HasKey("posX"))
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void StartNewGame()
    {
        if (PlayerPrefs.HasKey("posX"))
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
}
