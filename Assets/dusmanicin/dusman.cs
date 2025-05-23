using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class dusman : MonoBehaviour
{
    [SerializeField]private float hareketHiz;
    private Transform player;
    private Rigidbody rb;
    public bool isDead = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
       player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (isDead) return;

        transform.LookAt(player.position);
        transform.position = Vector3.MoveTowards(transform.position, player.position, hareketHiz * Time.deltaTime);
        
    }
}
