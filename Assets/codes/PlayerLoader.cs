using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public saveManager saveManager;
    public playerHealth healthScript;

    private void Start()
    {
        SaveData data = saveManager.LoadGame();
        if (data != null)
        {
            transform.position = new Vector3(data.playerX, data.playerY, data.playerZ);
            healthScript.currentHealth = data.currentHealth;

            if (PlayerCredit.instance != null)
            {
                PlayerCredit.instance.SetCredit(data.credits);
            }
        }
    }
}
