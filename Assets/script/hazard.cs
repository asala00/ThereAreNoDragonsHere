using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hazard : MonoBehaviour
{ 
    [SerializeField] private float hazardSpeed;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;
 
    void Update()
    {
        ///When a Lerp is involved, Vector3 is no longer just X, Y, and Z values,
        /// it is now starting position, ending position, and the speed at which traveling between these two takes place.
        transform.position = Vector3. Lerp(startPoint, endPoint, Mathf.PingPong(Time.time
            * hazardSpeed, 1)) ;
    }
    
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(1);
            }
        }
    }