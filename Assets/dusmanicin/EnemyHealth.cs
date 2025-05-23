using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] public int currentHealth;
    [SerializeField] private int maxHealth;
    public Animator animator;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ChangeCurrentHealth(int value)
    {
        currentHealth += value;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseHealth(int value)
    {
        ChangeCurrentHealth(value);
    }

    public void DecreaseHealth(int value)
    {
        ChangeCurrentHealth(-value);
    }

    private void Die()
    {
        Debug.Log("�ld�: " + gameObject.name); // Bu mesaj Console'da g�r�n�yor mu?

        PlayerCredit.instance.AddCredit(1);

        if (animator != null)
        {
            animator.SetBool("myZombieAttack", false);


            // �l�m animasyonunu tetikle
            animator.SetBool("isDead", true);
        }

        Debug.Log("�ld�: " + gameObject.name);

        var ai = GetComponent<enemyAIInfernal>();
        if (ai != null) ai.enabled = false;

        var logic = GetComponent<dusman>();
        if (logic != null) logic.isDead = true;

        // Destroy sistemi
        enemyDestroyer destroyer = GetComponent<enemyDestroyer>();
        if (destroyer != null)
        {
            destroyer.DestroyAfterDelay(5f);
        }
        else
        {
            Debug.LogError("EnemyDestroyer component yok!");
        }
    }

}
