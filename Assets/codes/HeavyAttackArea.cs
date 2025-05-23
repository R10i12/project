using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttackArea : MonoBehaviour
{
    private int damage = 40;

    [SerializeField] private GameObject hitEffect;

    private void OnTriggerEnter(Collider collider)
    {
        // Düşmana hasar ver
        if (collider.TryGetComponent<EnemyHealth>(out var health))
        {
            health.DecreaseHealth(damage);
        }
        else if (collider.TryGetComponent<enemyHealthInfernal>(out var healthInfernal))
        {
            healthInfernal.DecreaseHealth(damage);
        }

        // Efekti gecikmeli ve yönlü çıkar
        if (hitEffect != null)
        {
            Vector3 center = GetComponent<Collider>().bounds.center;
            StartCoroutine(SpawnDelayedEffect(center));
        }
    }

    private IEnumerator SpawnDelayedEffect(Vector3 position)
    {
        yield return new WaitForSeconds(1f); // 1 saniye gecikme

        GameObject effectInstance = Instantiate(
            hitEffect,
            position,
            Quaternion.LookRotation(transform.forward) // Karakterin baktığı yöne göre
        );

        Destroy(effectInstance, 2f); // 2 saniye sonra yok et
    }
}
