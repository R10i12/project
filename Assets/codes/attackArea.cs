using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackArea : MonoBehaviour
{
    private int damage = 15;

    [SerializeField] private GameObject hitEffect;

    private void OnTriggerEnter(Collider collider)
    {
        // D��mana hasar ver
        if (collider.TryGetComponent<EnemyHealth>(out var health))
        {
            health.DecreaseHealth(damage);
        }
        else if (collider.TryGetComponent<enemyHealthInfernal>(out var healthInfernal))
        {
            healthInfernal.DecreaseHealth(damage);
        }

        // Efekti y�nl� �ekilde ��kar
        if (hitEffect != null)
        {
            Vector3 center = GetComponent<Collider>().bounds.center;

            GameObject effectInstance = Instantiate(
                hitEffect,
                center,
                Quaternion.LookRotation(transform.forward) // transform.forward y�n�ne bak
            );

            Destroy(effectInstance, 2f);
        }
    }
}
