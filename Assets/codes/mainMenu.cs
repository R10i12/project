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
            // Kay�t varsa devam et (GameScene index'i 1 olarak kalm��)
            SceneManager.LoadSceneAsync(1);
        }
        else
        {
            // Kay�t yoksa yine sahneye ge� ama s�f�rdan ba�lar
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
