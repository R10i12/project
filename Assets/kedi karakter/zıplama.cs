using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zıplama : MonoBehaviour
{
    private bool zipzip = true;
    public float speed = 10f;
    Rigidbody rb;

    public Animator animator; // <-- Animatör referansı

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator bulunamadı! " + gameObject.name);
        }
    }

    void Update()
    {
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
        if (Input.GetKeyDown(KeyCode.Space) && zipzip)
        {
            StartCoroutine(ziplamaCoroutine());
        }
    }

    IEnumerator ziplamaCoroutine()
    {
        zipzip = false;

        animator.SetBool("isJumping", true); // <-- Animasyonu başlat
        rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);

        yield return new WaitForSeconds(1f);

        animator.SetBool("isJumping", false); // <-- Animasyonu sonlandır
        zipzip = true;
    }
}

