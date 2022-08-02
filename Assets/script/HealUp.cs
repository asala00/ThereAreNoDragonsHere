using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUp : MonoBehaviour
{
    private pHealth playerHPscript;

    private void Update()
    {
        transform.Rotate(transform.up, 360 * 0.9f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHPscript = other.gameObject.GetComponent<pHealth>();
            playerHPscript.HP +=2;
            
            Destroy(gameObject);
        }
    }
}
