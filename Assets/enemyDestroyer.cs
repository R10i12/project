using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDestroyer : MonoBehaviour
{
    public void DestroyAfterDelay(float delay)
    {
        StartCoroutine(DestroyRoutine(delay));
    }

    private IEnumerator DestroyRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("GERÇEKTEN siliniyor: " + gameObject.name);
        Destroy(gameObject);
    }
}

