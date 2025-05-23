using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class mainMenu : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/save.json";
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;

        if (File.Exists(savePath))
        {
            // Kayýt varsa devam et (GameScene index'i 1 olarak kalmýþ)
            SceneManager.LoadSceneAsync(1);
        }
        else
        {
            // Kayýt yoksa yine sahneye geç ama sýfýrdan baþlar
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
