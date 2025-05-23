using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyAI;

public class enemy : MonoBehaviour

{
    public playerHealth DecreaseHealth;
    
    [SerializeField] private EnemyAI enemyAI;
    public int value;
   private void OnTriggerEnter(Collider other) { 
        if (other.CompareTag("Player"))
        
        
        { 
            enemyAI.isInsideOfPlayer = true;
            enemyAI.ChangeEnemyState(EnemyState.attack);
            Debug.Log("temas var");
        
        } 
    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))


        {
            enemyAI.isInsideOfPlayer = false;
            enemyAI.ChangeEnemyState(EnemyState.idle);
            Debug.Log("temas yok");

        }

    }

}
