using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour

{
    public int damageAmount = 10;
    public float damageInterval = 1f; // Her 1 saniyede bir zarar
    private float damageTimer = 0f;

    private bool isPlayerInRange = false;
    private playerHealth playerHealthRef;

    void Update()
    {
        if (isPlayerInRange && playerHealthRef != null)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                playerHealthRef.DecreaseHealth(damageAmount);
                damageTimer = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealthRef = collision.gameObject.GetComponent<playerHealth>();

            if (playerHealthRef != null)
            {
                isPlayerInRange = true;
                damageTimer = damageInterval; // Ýlk çarpmada hemen hasar ver
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            playerHealthRef = null;
            damageTimer = 0f;
        }
    }
}
    

