using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed=5; 
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    { float xmovement = Input.GetAxisRaw("Horizontal");
        float zmovement = Input.GetAxisRaw("Vertical");
        // transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
   
        Vector3 Velocity = Vector3.right * xmovement * speed * Time.deltaTime + Vector3.back * zmovement * speed * Time.deltaTime;

        transform.Translate(Velocity);

       

    }
}