using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour
{
    [SerializeField] private int healAmount = 25;
    [SerializeField] private GameObject healEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth health = other.GetComponent<playerHealth>();
            if (health != null)
            {
                health.IncreaseHealth(healAmount);
                
            }
            if (healEffect != null)
            {
                Instantiate(healEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
