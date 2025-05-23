using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbDetector : MonoBehaviour
{
    private PlayerClimb climbScript;

    private void Start()
    {
        climbScript = GetComponentInParent<PlayerClimb>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            climbScript.StartClimbing();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            climbScript.StopClimbing();
        }
    }
}
