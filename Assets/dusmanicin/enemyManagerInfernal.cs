using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManagerInfernal : MonoBehaviour
{
    [SerializeField] private List<Transform> enemySpawnPoint;
    [SerializeField] private GameObject enemyPrefab;
    private IEnumerator EnemySpawnCoroutine()
    {
        while (true)
        {
            int index = Random.Range(0, enemySpawnPoint.Count);
            Transform spawnPoint = enemySpawnPoint[index];
            Instantiate(enemyPrefab,spawnPoint.position,Quaternion.identity);
            yield return new WaitForSeconds(60);
        }
    }
    private void Awake()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
