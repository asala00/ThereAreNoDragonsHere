using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private Transform player; //to use it in start to look at the player
    private bool detected; //will keep our method from being Invoked infinitely
    
    //similar to canon script\/ 
    public Transform BullSpwanPoint;
    public GameObject bullet;
    void Start()
    {
        player = GameObject.Find("player").transform;
    }

    
    void Update()
    {
        transform.LookAt(player);
        detectingPlayer(); //to constantly shoot at the player when in range
    }

    void detectingPlayer()
    {
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        if (playerDistance < 15 && detected == false)
        {
            detected = true;
            InvokeRepeating("Shooting",0,1); //time == delay time
        }
        else if (playerDistance > 15)
        {
            detected = false;
            CancelInvoke("Shooting");
        }
    }

    private void Shooting()
    {
        Instantiate(bullet, BullSpwanPoint.position, BullSpwanPoint.rotation);
        //BullSpwanPoint.rotation instead of transform.rotation
        //cuz unlike the player and its gun this turret rotates in all directions to look at the player
    }
    
}
