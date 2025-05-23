using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackDelay;
    public EnemyAI enemyAI;
    private float attackTimer;
    public Animator animator;
    private void Awake()
    {
        attackTimer = attackDelay;
    }
    private void Update()
    {

        if (enemyAI.currentEnemyState == EnemyAI.EnemyState.attack)//enemy state çekemior

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
