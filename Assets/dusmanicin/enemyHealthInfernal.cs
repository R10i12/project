using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthInfernal : MonoBehaviour
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
        Debug.Log("Infernal hasar aldý: -" + value);
        ChangeCurrentHealth(-value);
    }

    private void Die()
    {
        Debug.Log("Infernal ÖLDÜ: " + gameObject.name);
        PlayerCredit.instance.AddCredit(15);

        if (animator != null)
        {
            animator.SetBool("myZombieAttack", false);
            animator.SetBool("isDead", true);
        }

        enemyAIInfernal ai = GetComponent<enemyAIInfernal>();
        if (ai != null) ai.enabled = false;

        dusman logic = GetComponent<dusman>();
        if (logic != null) logic.isDead = true;

        StartCoroutine(DestroyAfterDelay(3f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Infernal yok ediliyor: " + gameObject.name);
        Destroy(gameObject);
    }
}
