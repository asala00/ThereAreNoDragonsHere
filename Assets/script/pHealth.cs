using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pHealth : MonoBehaviour
{
    [SerializeField] public int HP;
    
    
    
    void Update()
    {
        if (HP == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //instead of just respawning the player at the begenning i decided 
        //to reload the scene cuz i still dont know how to make the enemies
        //go back to their original postion
        SceneManager.LoadScene(1);
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("enemy"))
        { HP--; } 
    }
}
