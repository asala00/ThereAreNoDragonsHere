using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifeSpan;
    private Rigidbody rb; //will be used to AddForce and move the projectile
    
    private pHealth playerHPscript;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward *bulletSpeed );
        Invoke("Delete",lifeSpan);
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHPscript = collision.gameObject.GetComponent<pHealth>();
            playerHPscript.HP --;
            
            Destroy(gameObject);
        }
    }
}
