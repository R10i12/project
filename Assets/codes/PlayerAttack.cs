using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    public GameObject attackArea = default;
    public GameObject heavyAttackArea = default;
    private bool attacking = false;
    private bool heavyAttacking = false;

    private float timeToAttack = 0.7f;
    private float heavyAttackTime = 1.2f;
    private float timer;

    public Animator animator;
    public GameObject hitEffect;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
            Debug.LogWarning("Start içinde Animator bulunamadı: " + gameObject.name);

        FindAttackAreas();

        characterData data = GetComponentInChildren<characterData>();
        if (data != null)
            hitEffect = data.hitEffectPrefab;
        else
            Debug.LogWarning("characterData bulunamadı: " + gameObject.name);
    }

    void Update()
    {
        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        if (attackArea == null || heavyAttackArea == null)
            FindAttackAreas();

        if (Input.GetMouseButtonDown(0) && attackArea != null && !attacking && !heavyAttacking)
            NormalAttack();

        if (Input.GetMouseButtonDown(1) && heavyAttackArea != null && !attacking && !heavyAttacking)
            HeavyAttack();

        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer > timeToAttack)
            {
                EndAttack();
            }
        }

        if (heavyAttacking)
        {
            timer += Time.deltaTime;
            if (timer > heavyAttackTime)
            {
                EndHeavyAttack();
            }
        }
    }

    private void NormalAttack()
    {
        attacking = true;
        timer = 0;
        if (attackArea != null)
            attackArea.SetActive(true);
        if (animator != null)
            animator.SetBool("isPunching", true);
    }

    private void HeavyAttack()
    {
        heavyAttacking = true;
        timer = 0;
        if (heavyAttackArea != null)
            heavyAttackArea.SetActive(true);
        if (animator != null)
            animator.SetBool("isHeavyAttacking", true);
    }

    private void EndAttack()
    {
        attacking = false;
        timer = 0;
        if (attackArea != null)
            attackArea.SetActive(false);
        if (animator != null)
            animator.SetBool("isPunching", false);
    }

    private void EndHeavyAttack()
    {
        heavyAttacking = false;
        timer = 0;
        if (heavyAttackArea != null)
            heavyAttackArea.SetActive(false);
        if (animator != null)
            animator.SetBool("isHeavyAttacking", false);
    }

    private void FindAttackAreas()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);
        foreach (Transform t in allChildren)
        {
            if (attackArea == null && t.name.ToLower() == "attackarea")
            {
                attackArea = t.gameObject;
                attackArea.SetActive(false);
                Debug.Log("attackArea bulundu: " + attackArea.name);
            }
            else if (heavyAttackArea == null && t.name.ToLower() == "heavyattackarea")
            {
                heavyAttackArea = t.gameObject;
                heavyAttackArea.SetActive(false);
                Debug.Log("heavyAttackArea bulundu: " + heavyAttackArea.name);
            }
        }

        if (attackArea == null)
            Debug.LogWarning("attackArea bulunamadı: " + gameObject.name);
        if (heavyAttackArea == null)
            Debug.LogWarning("heavyAttackArea bulunamadı: " + gameObject.name);
    }
}

