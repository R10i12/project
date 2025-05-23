using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    public Animator animator;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    public controller controllerScript;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator bulunamadı! " + gameObject.name);
        }
        if (controllerScript == null)
        {
            Debug.LogError("Controller script atanmadı!");
        }
    }

    void Update()
    {
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
        if (controllerScript == null) return;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
            controllerScript.speed = runSpeed;
        }
        else
        {
            animator.SetBool("isRunning", false);
            controllerScript.speed = walkSpeed;
        }

        animator.SetBool("isWalking", Input.GetKey(KeyCode.W));
        animator.SetBool("isWalkingBack", Input.GetKey(KeyCode.S));
        animator.SetBool("isWalkingRight", Input.GetKey(KeyCode.D));
        animator.SetBool("isWalkingLeft", Input.GetKey(KeyCode.A));
    }
}