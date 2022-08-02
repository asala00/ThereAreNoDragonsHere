
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2d : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float speed;
    private bool canJump;
    private Rigidbody rb;
    [SerializeField] GameObject gun;

     private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gun.SetActive(false);
    }

    private void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis ( "Horizontal") * speed, 0);
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        
        //jumping w rules
        bool grounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer); //(,,) >>>The starting point of the linecast, the end point, and what layer the linecast is looking to detect.
        Debug.DrawLine (transform.position, groundCheck.position, Color.red); //drawing a line based of the prev line26

        if (grounded == true)
        { canJump = true; }
        else
        { canJump = false; }

        JumpyJumpo();
    }
    
    private void JumpyJumpo()
    {
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce) ;
        }
    }

    [SerializeField] int orbAmount = 0;
    private void OnTriggerEnter(Collider myOrb)
    {
        if (myOrb.gameObject.CompareTag("collect"))
        { 
            orbAmount += 1; 
            Destroy(myOrb.gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (orbAmount == 4 && col.gameObject.CompareTag("nextL"))
        {
            SceneManager.LoadScene("Level2");
        }
        else if (orbAmount < 4 && col.gameObject.CompareTag("nextL"))
        {
            Debug.Log("jump off and try again");
        }
        
        if (col.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene("StartLevel");
        }
        if (col.gameObject.CompareTag("gunBox"))
        {
            Destroy(col.gameObject);
            gun.SetActive(true);
                
        }
    }
    }

