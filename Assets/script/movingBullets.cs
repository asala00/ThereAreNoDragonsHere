
using UnityEngine;

public class movingBullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifeSpan;
    private Rigidbody rb;
    private GameObject enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * bulletSpeed );//replaced vector3 with transform so it rotates wherever the player is facing+used right instead of forward cuz the guns orientation was based on the global and coldnt be changed
        
        Invoke("Delete",lifeSpan);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            enemy = collision.gameObject;
            enemy.SetActive(false); //prefabs cant be destroyed so deactivate
            Destroy(gameObject);
        }
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}


