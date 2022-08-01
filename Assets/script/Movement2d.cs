using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2d : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float speed;
    private bool canJump;
    private Rigidbody rb;

     private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis ( "Horizontal") * speed, 0);
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        
        //jumping w rules
        bool grounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer); //(,,) >>>The starting point of the linecast, the end point, and what layer the linecast is looking to detect.
        Debug.DrawLine (transform.position, groundCheck.position, Color.red); //drawing a line based of the prev line26

        if (grounded == true)
        { canJump = true; }
        else
        { canJump = false; }

        JumpyJumpo();
    }
    
    private void JumpyJumpo()
    {
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce) ;
        }
    }

    public int OrbAmount = 0;
    private void OnTriggerEnter(Collider myOrb)
    {
        if (myOrb.gameObject.CompareTag("collect"))
        { 
            OrbAmount += 1; 
            Destroy(myOrb.gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (OrbAmount == 4 && col.gameObject.CompareTag("nextL"))
        {
            SceneManager.LoadScene("Level2");
        }
        else if (OrbAmount < 4 && col.gameObject.CompareTag("nextL"))
        {
            Debug.Log("jump off and try again");
        }
        
        if (col.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene("StartLevel");
        }
    }
}
