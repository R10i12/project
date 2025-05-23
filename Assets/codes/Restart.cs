using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isMenuOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpen = !isMenuOpen;
            pauseMenu.SetActive(isMenuOpen);
        }
    }
    public void ResetTheGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        Debug.Log("tus calisti");
    }
}
