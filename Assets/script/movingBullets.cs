using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right *bulletSpeed);
    }

}
