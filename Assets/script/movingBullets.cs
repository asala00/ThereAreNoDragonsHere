
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
        rb.AddForce(Vector3.right *bulletSpeed );
        
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


