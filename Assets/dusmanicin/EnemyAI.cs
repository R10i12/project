using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool isInsideOfPlayer; // Trigger ile ayarlanacak
    public EnemyState currentEnemyState;
    public EnemyHealth enemyHealth;
    public Animator animator;

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        
    }

    private void Start()
    {
        ChangeEnemyState(EnemyState.idle);
    }

    private void Update()
    {
        // Her karede durumu kontrol et
        if (enemyHealth.currentHealth <= 0)
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

    public void ChangeEnemyState(EnemyState state)
    {
        if (currentEnemyState == state) return;

        currentEnemyState = state;
        Debug.Log("State deðiþti: " + currentEnemyState);

        switch (currentEnemyState)
        {
            case EnemyState.walk:
                if (animator != null)
                {
                    animator.SetBool("myZombieAttack", false);
                }
                break;

            case EnemyState.attack:
                if (animator != null)
                {
                    animator.SetBool("myZombieAttack", true);
                }
                break;

            case EnemyState.die:
                if (animator != null)
                {
                    animator.SetBool("myZombieAttack", false);
                    animator.SetBool("isDead", true);
                }

                dusman d = GetComponent<dusman>();
                if (d != null)
                {
                    d.isDead = true;
                }

                StartCoroutine(DestroyAfterDelay(3f));
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

    // Ýsteðe baðlý: Oyuncu içeri girince state deðiþsin
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