
using UnityEngine;

public class movingBullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Rigidbody rb;
    private GameObject enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right *bulletSpeed );
    }
    
    //the bullets pushing back the enemy didnt work so used this instead
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            enemy = collision.gameObject;
            rb = enemy.GetComponent<Rigidbody>(); //getting the rigidbody of our player
    
            enemy.SetActive(false);
            
            
         //  enemyPush();
           
        }
    }
    
    // private void enemyPush()
    // {
    //     //playerScript.enabled = false; //to disable movement
    //
    //     rb.AddForce (Vector3.up * 250) ; //will knock the player upward 
    //     if (enemy.transform.position.x < transform.position.x)
    //     { rb.AddForce(Vector3.right * -500); } //If the player is left of the enemy when colliding, shove the player to the left by 500.
    //     else
    //     { rb.AddForce (Vector3.right * 500) ;} //If the player is right of the enemy
    //
        //Invoke ("MoveAgain", 1);//calling the method, 1 is the delay time before it starts
    }


