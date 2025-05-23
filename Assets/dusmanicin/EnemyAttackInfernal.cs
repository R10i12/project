using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackInfernal : MonoBehaviour
{
    [SerializeField] private float attackDelay;
    private enemyAIInfernal enemyAI;
    private float attackTimer;
    public Animator animator;
    private void Awake()
    {
        enemyAI = GetComponent<enemyAIInfernal>();
        attackTimer = attackDelay;
    }
    private void Update()
    {

        if (enemyAI.currentEnemyState == enemyAIInfernal.EnemyState.attack)//enemy state çekemior

        {
            animator.SetBool("myZombieAttack", true);
            if (attackTimer < 0)//Düþman Saldýrý Sistemi | EP35 | Temel Seviye Unity Eðitimi burada kaldým

            {
                PlayerHealth.instance.DecreaseHealth(10);//decrease komutu olan fonk atancak
                attackTimer = attackDelay;
            }

        }
        else
        {
            animator.SetBool("myZombieAttack", false);
        }
    }
}
