using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
