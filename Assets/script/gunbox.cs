using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunbox : MonoBehaviour
{
   
    void Update()
    {
        transform.Rotate(transform.up, 360 * 0.9f * Time.deltaTime);
    }
}
