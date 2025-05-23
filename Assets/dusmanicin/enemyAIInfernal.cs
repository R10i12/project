using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAIInfernal : MonoBehaviour
{
    public bool isInsideOfPlayer;
    public EnemyState currentEnemyState;
    public enemyHealthInfernal enemyHealthI;
    public Animator animator;

    private void Awake()
    {
        enemyHealthI = GetComponent<enemyHealthInfernal>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        ChangeEnemyState(EnemyState.idle);
    }

    private void Update()
    {
        if (enemyHealthI.currentHealth <= 0)
        {
            ChangeEnemyState(EnemyState.die);
        }
        else if (isInsideOfPlayer)
        {
            ChangeEnemyState(EnemyState.attack);
        }
        else
        {
            ChangeEnemyState(EnemyState.walk);
        }
    }

    public void ChangeEnemyState(EnemyState newState)
    {
        if (currentEnemyState == newState) return;

        currentEnemyState = newState;
        Debug.Log("Infernal state deðiþti: " + currentEnemyState);

        switch (currentEnemyState)
        {
            case EnemyState.walk:
                if (animator != null)
                    animator.SetBool("myZombieAttack", false);
                break;

            case EnemyState.attack:
                if (animator != null)
                    animator.SetBool("myZombieAttack", true);
                break;

            case EnemyState.die:
                if (animator != null)
                {
                    animator.SetBool("myZombieAttack", false);
                    animator.SetBool("isDead", true);
                }

                dusman d = GetComponent<dusman>();
                if (d != null) d.isDead = true;

                StartCoroutine(DestroyAfterDelay(3f));
                break;

            case EnemyState.idle:
                if (animator != null)
                    animator.SetBool("myZombieAttack", false);
                break;
        }
    }

    public enum EnemyState
    {
        Null,
        walk,
        attack,
        idle,
        die,
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideOfPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideOfPlayer = false;
        }
    }
}