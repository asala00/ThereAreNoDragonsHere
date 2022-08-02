using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] private float hazardSpeed;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;
    
    
    void Update()
    {
        transform.position = Vector3. Lerp(startPoint, endPoint, Mathf.PingPong(Time.time
            * hazardSpeed, 1)) ;
    }
}
