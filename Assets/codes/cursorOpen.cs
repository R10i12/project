using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorOpen : MonoBehaviour
{
    public playerHealth playerHealth;

    void Start()
    {
        // Cursor oyun baþýnda kilitli
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Eðer referansý elle vermediysen:
        if (playerHealth == null)
            playerHealth = FindObjectOfType<playerHealth>();
    }

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {

        }
    }
}
