using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveTrigger : MonoBehaviour
{
    public saveManager saveManager;
    public playerHealth healthScript;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            int currentCredit = PlayerCredit.instance != null ? PlayerCredit.instance.credits : 0;
            saveManager.SaveGame(transform, healthScript.currentHealth, currentCredit);
            Debug.Log("Oyun kaydedildi.");
        }
    }
}