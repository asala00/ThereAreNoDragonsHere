using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{

    private GameObject player;
    private Rigidbody rb;
    private Movement2d playerScript; //to use in disabling the movement script in order for the enemy to knock back the player thro rigidbodies collisions
    
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            rb = player.GetComponent<Rigidbody>(); //getting the rigidbody of our player

            playerScript = player.GetComponent<Movement2d>();//to disable movement
            
            //making a method that makes the enemy knockback the player on collision
            playerPush();
        }
    }

    private void playerPush()
    {
        playerScript.enabled = false; //to disable movement
        
        rb.AddForce (Vector3.up * 250) ; //will knock the player upward 
        if (player.transform.position.x < transform.position.x)
        { rb.AddForce(Vector3.right * -500); } //If the player is left of the enemy when colliding, shove the player to the left by 500.
        else
        { rb.AddForce (Vector3.right * 500) ;} //If the player is right of the enemy

        Invoke ("MoveAgain", 1);//calling the method, 1 is the delay time before it starts
    }

    private void MoveAgain()       //re-enables the movement script
    {
        playerScript.enabled = true; //to enable movement
    }
}
