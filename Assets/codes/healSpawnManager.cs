using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healSpawnManager : MonoBehaviour
{
    [SerializeField] private List<Transform> healSpawnPoints;
    [SerializeField] private GameObject healPrefab;
    [SerializeField] private float spawnInterval = 15f;

    private void Awake()
    {
        StartCoroutine(HealSpawnCoroutine());
    }

    private IEnumerator HealSpawnCoroutine()
    {
        while (true)
        {
            if (healSpawnPoints.Count == 0 || healPrefab == null)
                yield break;

            int index = Random.Range(0, healSpawnPoints.Count);
            Transform spawnPoint = healSpawnPoints[index];
            Instantiate(healPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
