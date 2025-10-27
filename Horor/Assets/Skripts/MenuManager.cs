using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    [SerializeField] Button loadButton;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        if (PlayerPrefs.HasKey("posX"))
        {
            loadButton.interactable = true;
        }
    }
    public void StartNewGame()
    {
        if (PlayerPrefs.HasKey("posX"))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Game");
        }
        else
        {
            SceneManager.LoadScene("Game");
        }

    }
    
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("posX"))
        {
            SceneManager.LoadScene("Game");
        }
    } 

        public void ExitGame()
    {;
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }



}
