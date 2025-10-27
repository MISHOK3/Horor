using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_Text saveWarning;


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

    public void SavePlayerPosition()
    {
         GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 pos = player.transform.position;

            PlayerPrefs.SetFloat("posX", pos.x);
            PlayerPrefs.SetFloat("posY", pos.y);
            PlayerPrefs.SetFloat("posZ", pos.z);
            PlayerPrefs.Save();
            saveWarning.text = "The save was successful!";
            Invoke("DeleteText", 2f);
        } 
    }

    public void DeleteText()
    {
        saveWarning.text = "";
    }
}

