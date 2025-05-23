using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyInfernal : MonoBehaviour
{
    public playerHealth DecreaseHealth;

    [SerializeField] private enemyAIInfernal enemyAI;
    public int value;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))


        {
            enemyAI.isInsideOfPlayer = true;
            enemyAI.ChangeEnemyState(enemyAIInfernal.EnemyState.attack);
            Debug.Log("temas var");

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))


        {
            enemyAI.isInsideOfPlayer = false;
            enemyAI.ChangeEnemyState(enemyAIInfernal.EnemyState.idle);
            Debug.Log("temas yok");

        }

    }
}
