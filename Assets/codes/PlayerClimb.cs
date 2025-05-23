using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    public float climbSpeed = 3f;
    private bool isClimbing = false;
    private Rigidbody rb;
    public Animator animator;
    private bool animatorChecked = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        if (animator != null)
        {
            animatorChecked = true;
        }
    }

    private void Update()
    {
        // Eðer animator hala null'sa bir kez daha dene
        if (!animatorChecked)
        {
            animator = GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animatorChecked = true;
            }
        }
    }

    public void StartClimbing()
    {
        isClimbing = true;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        animator.SetBool("isClimbing", true);
    }

    public void StopClimbing()
    {
        isClimbing = false;
        rb.useGravity = true;
        animator.SetBool("isClimbing", false);
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 climbMovement = new Vector3(0f, verticalInput, 0f) * climbSpeed;
            rb.velocity = climbMovement;
        }
    }
}
