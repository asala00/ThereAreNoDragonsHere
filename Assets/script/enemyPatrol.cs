using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    private GameObject player;
    //next 2 vars r to use for the enemy to chase the player:
    private bool detected = false;
    public float speed;
    
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        //"Vector3.Distance" is how we set up a distance check. In the parenthesis we write two values: Point A and Point B, two different locations
        float playerDistance = Vector3.Distance(player.transform.position, transform.position); //player.transform.position, the current position of our Player.,,transform.position, the current position of this enemy.
        
        if (playerDistance <= 15 && detected == false) //setting the enemy to detect the player when near
        { detected = true;}

        if (detected == true)
        {
            if (player.transform.position.x < transform.position.x)
            {
                transform.Translate(Vector3.forward * -speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

            }
        }
    }
}
